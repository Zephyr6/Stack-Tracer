using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Graphics;

using FlatRedBall.Math.Geometry;
using FlatRedBall.Math.Splines;
using BitmapFont = FlatRedBall.Graphics.BitmapFont;
using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;


#endif

namespace BeefBall.Entities.GameScreen
{
	public partial class Enemy
	{
        public bool canBeHit = true;
        public bool isDead;
        public bool engaged;

        double delay = 0.5;
        double timeHit = 0;

        int mHealth;
        public int Health{ get{return mHealth;} set {mHealth = value;}}
        HealthBar mHealthBar;
        private List<Text> damageTexts;

		private void CustomInitialize()
		{
            damageTexts = new List<Text>();
            Health = StartingHealth;
            mHealthBar = new HealthBar(ContentManagerName, false);
            mHealthBar.AddToManagers(LayerProvidedByContainer);
            mHealthBar.X = X;
            mHealthBar.Y = Y + 20;
            mHealthBar.AttachTo(this, true);
            mHealthBar.Visible = false;
            Acceleration.Y = -40F;
		}

		private void CustomActivity()
		{
            mHealthBar.RatioFull = Health / (float)StartingHealth;
                
            if (timeHit != 0)
            {
                if (TimeManager.SecondsSince(timeHit) >= delay)
                {
                    if (Health > 0)
                    {
                        CurrentState = VariableState.L_Idle;
                        canBeHit = true;
                        timeHit = 0;
                    }
                    else
                        Destroy();
                }
            }

            DamageTextActivity();
		}

        private void DamageTextActivity()
        {
            List<Text> textToRemove = new List<Text>();

            foreach (Text t in damageTexts)
            {
                if (t.Alpha <= 0)
                {
                    textToRemove.Add(t);
                }
            }

            foreach (Text t in textToRemove)
            {
                damageTexts.Remove(t);
            }
        }

        public void Hurt(int damage)
        {
            mHealthBar.Visible = true;
            AddDamageText(damage);
            
            Health -= damage;
            canBeHit = false;

            timeHit = TimeManager.CurrentTime;
            CurrentState = VariableState.L_Hurt;

            if (Health <= 0)
                Kill();
        }

        void AddDamageText(int amount)
        {
            Random rnd = new Random();

            Text dmgText = TextManager.AddText("-" + amount, this.LayerProvidedByContainer);

            dmgText.Velocity.Y = 40;
            dmgText.Velocity.X = rnd.Next(-15, 15);
            dmgText.SetColor(255, 0, 0);
            dmgText.AlphaRate = -0.4F;
            dmgText.Position = new Vector3(Body.X + Body.Radius, Body.Y + Body.Radius, Body.Z);
            dmgText.Scale += 3;

            damageTexts.Add(dmgText);
        }

        public void Kill()
        {
            delay = 1.5;
            CurrentState = VariableState.L_Die;
        }

		private void CustomDestroy()
		{
            mHealthBar.Destroy();
            isDead = true;
		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
	}
}
