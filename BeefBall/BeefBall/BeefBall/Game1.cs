using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using FlatRedBall;
using FlatRedBall.Graphics;
using FlatRedBall.Utilities;

using BeefBall.Screens;

namespace BeefBall
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

        public static SoundEffect StartGameSFX;
        public static SoundEffect AboutGameSFX;
        public static SoundEffect ExitGameSFX;

        public static int RIGHT = 0;
        public static int LEFT = 1;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            Content.RootDirectory = "Content";

			BackStack<string> bs = new BackStack<string>();
			bs.Current = string.Empty;
			
			#if WINDOWS_PHONE
			// Frame rate is 30 fps by default for Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);
            graphics.IsFullScreen = true;
			
			#endif
        }

        protected override void Initialize()
        {
            Renderer.UseRenderTargets = false;
            FlatRedBallServices.InitializeFlatRedBall(this, graphics);
			CameraSetup.SetupCamera(SpriteManager.Camera);
			GlobalContent.Initialize();

            // Are there any gamepads connected?
            if (FlatRedBall.Input.InputManager.Xbox360GamePads[0].IsConnected == false)
            {
                FlatRedBall.Input.InputManager.Xbox360GamePads[0].CreateDefaultButtonMap();
            }

			Screens.ScreenManager.Start(typeof(BeefBall.Screens.QuizScreen).FullName);

            base.Initialize();

            FlatRedBallServices.GraphicsOptions.UseMultiSampling = false;
            FlatRedBallServices.GraphicsOptions.TextureFilter = TextureFilter.Point;

            AboutGameSFX = Content.Load<SoundEffect>("AboutSound");
            ExitGameSFX = Content.Load<SoundEffect>("ExitSound");
            StartGameSFX = Content.Load<SoundEffect>("StartSound");
        }


        protected override void Update(GameTime gameTime)
        {
            FlatRedBallServices.Update(gameTime);

            ScreenManager.Activity();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            FlatRedBallServices.Draw();

            base.Draw(gameTime);
        }
    }
}
