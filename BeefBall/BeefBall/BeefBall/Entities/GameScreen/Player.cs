using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;

using FlatRedBall.Math.Geometry;
using FlatRedBall.Math.Splines;
using BitmapFont = FlatRedBall.Graphics.BitmapFont;
using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;
using Microsoft.Xna;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using FlatRedBall.Graphics;

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;


#endif

namespace BeefBall.Entities.GameScreen
{
	public partial class Player
	{
        public List<Enemy> enemies { get; set; }

        Xbox360GamePad mGamePad;
        double timePunched;
        Text debugText;

        int facing;

        public static int RIGHT = 0;
        public static int LEFT = 1;

        int punchPower = 10;

        public int PlayerIndex
        {
            set
            {
                mGamePad = InputManager.Xbox360GamePads[value];
            }
        }

        private void CustomInitialize()
        {
            facing = RIGHT;
            CurrentState = VariableState.R_Idle;

            this.PlayerIndex = 0;
            Acceleration.Y = -400F;

            debugText = TextManager.AddText("");
            debugText.Position.Y += 40;
            debugText.AttachTo(this, true);
            UpdateDebugText();
        }

        private void CustomActivity()
        {
            MoveActivity();

            UpdateDebugText();
        }

		private void CustomDestroy()
		{
            TextManager.RemoveText(debugText);

		}

        private void MoveActivity()
        {
            Velocity.X = 0;

            // Move left/right
            if (!IsAttacking() || CurrentState == VariableState.Jumping)
            {
                Velocity.X = mGamePad.LeftStick.Position.X * MovementSpeed;

                // Animate
                if (CurrentState != VariableState.Jumping)
                {
                    if (mGamePad.LeftStick.Position.X < 0)
                        CurrentState = VariableState.L_Walking;
                    else if (mGamePad.LeftStick.Position.X > 0)
                        CurrentState = VariableState.R_Walking;
                }
            }

            // Jump
            if (mGamePad.ButtonPushed(Xbox360GamePad.Button.A) && CurrentState != VariableState.Jumping)
            {
                jump.Play();
                Velocity.Y = 200;
                CurrentState = VariableState.Jumping;
            }

            // Idle
            if (mGamePad.LeftStick.Position.X == 0 && !IsAttacking())
            {
                if (CurrentState == VariableState.L_Walking)
                    CurrentState = VariableState.L_Idle;
                else if (CurrentState == VariableState.R_Walking)
                    CurrentState = VariableState.R_Idle;
            }

            AttackActivity();

            if (mGamePad.ButtonPushed(Xbox360GamePad.Button.Y))
                Console.WriteLine(InnerExScene.CurrentChain.TotalLength);
        }

        private bool IsAttacking()
        {
            return timePunched > 0 || CurrentState == VariableState.R_Attack || CurrentState == VariableState.R_Attack2 || CurrentState == VariableState.L_Attack || CurrentState == VariableState.L_Attack2;
        }

        private int GetFacing()
        {
            int dir = facing;

            if (mGamePad.LeftStick.Position.X > 0)
                dir = RIGHT;
            else if (mGamePad.LeftStick.Position.X < 0)
                dir = LEFT;

            facing = dir;

            return dir;
        }

        public void Land()
        {
            if(GetFacing() == RIGHT)
                CurrentState = VariableState.R_Idle;
            else if(GetFacing() == LEFT)
                CurrentState = VariableState.L_Idle;
        }

        void AttackActivity()
        {
            Random rand = new Random();

            if (mGamePad.ButtonPushed(Xbox360GamePad.Button.B))
            {
                if (CurrentState != VariableState.Jumping)
                    Velocity.X = 0;

                swing2.Play();

                if (!SpriteManager.Camera.IsPointInView(X, Y, 0F))
                    Y = 0;

                if (timePunched != 0)
                {
                    timePunched = TimeManager.CurrentTime;

                    if (CurrentState == VariableState.L_Attack2 || CurrentState == VariableState.R_Attack2)
                    {
                        if (GetFacing() == RIGHT)
                            CurrentState = VariableState.R_Attack;
                        else if (GetFacing() == LEFT)
                            CurrentState = VariableState.L_Attack;
                    }
                    else
                    {
                        if (GetFacing() == RIGHT)
                            CurrentState = VariableState.R_Attack2;
                        else if (GetFacing() == LEFT)
                            CurrentState = VariableState.L_Attack2;
                    }

                }
                else
                {
                    timePunched = TimeManager.CurrentTime;

                    if (GetFacing() == RIGHT)
                        CurrentState = VariableState.R_Attack;
                    else
                        CurrentState = VariableState.L_Attack;
                }

                foreach (Entities.GameScreen.Enemy el in enemies)
                {
                    int dmg = rand.Next(punchPower - (punchPower / 3), punchPower + (punchPower / 4));
                    Console.WriteLine("DAMAGE: {0} Min/Max: ({1}, {2})", dmg, punchPower - (punchPower / 3), punchPower + (punchPower / 4));

                    if (GetFacing() == RIGHT)
                    {
                        if ((RightAttack.CollideAgainst(el.Body) || RightAttack.CollideAgainst(el.Head))  && el.canBeHit)
                        {
                            hit.Play();
                            el.BodyColor = new Color(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
                            el.Hurt(dmg);
                        }
                    }
                    else if (GetFacing() == LEFT)
                    {
                        if ((LeftAttack.CollideAgainst(el.Body) || LeftAttack.CollideAgainst(el.Head)) && el.canBeHit)
                        {
                            hit.Play();
                            el.BodyColor = new Color(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
                            el.Hurt(dmg);
                        }
                    }
                }
            }

            if (timePunched > 0 && (TimeManager.SecondsSince(timePunched) >= InnerExScene.CurrentChain.TotalLength))
            {
                if (GetFacing() == RIGHT)
                    CurrentState = VariableState.R_Idle;
                else if (GetFacing() == LEFT)
                    CurrentState = VariableState.L_Idle;

                timePunched = 0;
            }
        }

        void UpdateDebugText()
        {
            debugText.DisplayText = string.Format("State: {0}\nFacing: {1}", CurrentState, GetFacing());
        }

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
	}
}
