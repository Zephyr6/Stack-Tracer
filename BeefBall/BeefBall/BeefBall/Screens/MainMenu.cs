using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;

using FlatRedBall.Graphics.Model;
using FlatRedBall.Math.Geometry;
using FlatRedBall.Math.Splines;

using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;
using FlatRedBall.Localization;

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
#endif

namespace BeefBall.Screens
{
	public partial class MainMenu
	{
        enum MainMenuButtons
        {
            Start,
            About,
            Exit
        }

        MainMenuButtons currentButton = MainMenuButtons.Start;
        Xbox360GamePad mGamePad;
        bool canMove;
        bool isMousedOver;

		void CustomInitialize()
		{
            SpriteManager.Camera.X = 50;
            SpriteManager.Camera.Y = 40;

            StartGameButton.CurrentState = Entities.Button.VariableState.Regular;

            mGamePad = InputManager.Xbox360GamePads[0];

            canMove = true;

            FlatRedBallServices.Game.IsMouseVisible = true;
		}

		void CustomActivity(bool firstTimeCalled)
		{
            if (!isMousedOver)
            {
                if (canMove)
                    SelectActivity();

                if (mGamePad.LeftStick.Position.Y == 0)
                    canMove = true;

                if (currentButton == MainMenuButtons.Start)
                {
                    StartGameButton.CurrentState = Entities.Button.VariableState.Regular;
                    AboutButton.CurrentState = Entities.Button.VariableState.Disabled;
                    ExitButton.CurrentState = Entities.Button.VariableState.Disabled;
                }
                else if (currentButton == MainMenuButtons.About)
                {
                    StartGameButton.CurrentState = Entities.Button.VariableState.Disabled;
                    AboutButton.CurrentState = Entities.Button.VariableState.Regular;
                    ExitButton.CurrentState = Entities.Button.VariableState.Disabled;
                }
                else if (currentButton == MainMenuButtons.Exit)
                {
                    StartGameButton.CurrentState = Entities.Button.VariableState.Disabled;
                    AboutButton.CurrentState = Entities.Button.VariableState.Disabled;
                    ExitButton.CurrentState = Entities.Button.VariableState.Regular;
                }
            }
            else
            {
                if (mGamePad.LeftStick.Position.Y != 0)
                    isMousedOver = false;
            }

            if (mGamePad.ButtonPushed(Xbox360GamePad.Button.A) || mGamePad.ButtonPushed(Xbox360GamePad.Button.Start))
            {
                if (!isMousedOver)
                {
                    if (currentButton == MainMenuButtons.Start)
                    {
                        this.MoveToScreen(typeof(GameScreen).FullName);
                        Game1.StartGameSFX.Play();
                    }
                    else if (currentButton == MainMenuButtons.About)
                    {
                        this.MoveToScreen(typeof(About).FullName);
                        Game1.AboutGameSFX.Play();
                    }
                    else if (currentButton == MainMenuButtons.Exit)
                    {
                        FlatRedBallServices.Game.Exit();
                    }
                }
                else
                    isMousedOver = false;

            }
		}

        void SelectActivity()
        {
            if (mGamePad.LeftStick.Position.Y > 0)
            {
                beep.Play();
                if (currentButton == MainMenuButtons.Start)
                    currentButton = MainMenuButtons.Start;
                else if (currentButton == MainMenuButtons.About)
                    currentButton = MainMenuButtons.Start;
                else if (currentButton == MainMenuButtons.Exit)
                    currentButton = MainMenuButtons.About;
            }
            else if (mGamePad.LeftStick.Position.Y < 0)
            {
                beep.Play();
                if (currentButton == MainMenuButtons.Start)
                    currentButton = MainMenuButtons.About;
                else if (currentButton == MainMenuButtons.About)
                    currentButton = MainMenuButtons.Exit;
                else if (currentButton == MainMenuButtons.Exit)
                    currentButton = MainMenuButtons.Exit;
            }

            canMove = false;
        }

        void CustomDestroy()
		{


		}

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

	}
}
