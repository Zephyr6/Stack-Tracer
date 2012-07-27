using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall.Math.Geometry;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Input;
using FlatRedBall.IO;
using FlatRedBall.Instructions;
using FlatRedBall.Math.Splines;
using FlatRedBall.Utilities;
using BitmapFont = FlatRedBall.Graphics.BitmapFont;

using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;

#if XNA4
using Color = Microsoft.Xna.Framework.Color;
#else
using Color = Microsoft.Xna.Framework.Graphics.Color;
#endif

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
using Microsoft.Xna.Framework.Media;
#endif

// Generated Usings
using FlatRedBall.Broadcasting;
using BeefBall.Entities;
using BeefBall.Entities.GameScreen;
using FlatRedBall;

namespace BeefBall.Screens
{
	public partial class MainMenu : Screen
	{
		// Generated Fields
		#if DEBUG
		static bool HasBeenLoadedWithGlobalContentManager = false;
		#endif
		private Scene MyBackground;
		
		private BeefBall.Entities.Button StartGameButton;
		private BeefBall.Entities.Button AboutButton;
		private BeefBall.Entities.Button ExitButton;
		private FlatRedBall.Scene scene;
		public event FlatRedBall.Gui.WindowEvent StartButtonClick;
		public event FlatRedBall.Gui.WindowEvent AboutButtonClick;
		public event FlatRedBall.Gui.WindowEvent ExitButtonClick;
		public event FlatRedBall.Gui.WindowEvent StartButtonRollOn;
		public event FlatRedBall.Gui.WindowEvent StartButtonRollOff;
		public event FlatRedBall.Gui.WindowEvent AboutButtonRollOn;
		public event FlatRedBall.Gui.WindowEvent AboutButtonRollOff;
		public event FlatRedBall.Gui.WindowEvent ExitButtonRollOn;
		public event FlatRedBall.Gui.WindowEvent ExitButtonRollOff;

		public MainMenu()
			: base("MainMenu")
		{
            
		}

        public override void Initialize(bool addToManagers)
        {
			// Generated Initialize
			LoadStaticContent(ContentManagerName);
			if (!FlatRedBallServices.IsLoaded<Scene>(@"content/screens/mainmenu/mybackground.scnx", ContentManagerName))
			{
			}
			MyBackground = FlatRedBallServices.Load<Scene>(@"content/screens/mainmenu/mybackground.scnx", ContentManagerName);
			scene = MyBackground;
			StartGameButton = new BeefBall.Entities.Button(ContentManagerName, false);
			StartGameButton.Name = "StartGameButton";
			AboutButton = new BeefBall.Entities.Button(ContentManagerName, false);
			AboutButton.Name = "AboutButton";
			ExitButton = new BeefBall.Entities.Button(ContentManagerName, false);
			ExitButton.Name = "ExitButton";
			StartGameButton.Click += OnStartButtonClick;
			StartGameButton.Click += OnStartButtonClickTunnel;
			AboutButton.Click += OnAboutButtonClick;
			AboutButton.Click += OnAboutButtonClickTunnel;
			ExitButton.Click += OnExitButtonClick;
			ExitButton.Click += OnExitButtonClickTunnel;
			StartGameButton.RollOn += OnStartButtonRollOn;
			StartGameButton.RollOn += OnStartButtonRollOnTunnel;
			StartGameButton.RollOff += OnStartButtonRollOff;
			StartGameButton.RollOff += OnStartButtonRollOffTunnel;
			AboutButton.RollOn += OnAboutButtonRollOn;
			AboutButton.RollOn += OnAboutButtonRollOnTunnel;
			AboutButton.RollOff += OnAboutButtonRollOff;
			AboutButton.RollOff += OnAboutButtonRollOffTunnel;
			ExitButton.RollOn += OnExitButtonRollOn;
			ExitButton.RollOn += OnExitButtonRollOnTunnel;
			ExitButton.RollOff += OnExitButtonRollOff;
			ExitButton.RollOff += OnExitButtonRollOffTunnel;
			
			
			PostInitialize();
			base.Initialize(addToManagers);
			if (addToManagers)
			{
				AddToManagers();
			}

        }
        
// Generated AddToManagers
		public override void AddToManagers ()
		{
			base.AddToManagers();
			AddToManagersBottomUp();
			CustomInitialize();
		}


		public override void Activity(bool firstTimeCalled)
		{
			// Generated Activity
			if (!IsPaused)
			{
				
				StartGameButton.Activity();
				AboutButton.Activity();
				ExitButton.Activity();
			}
			else
			{
			}
			base.Activity(firstTimeCalled);
			if (!IsActivityFinished)
			{
				CustomActivity(firstTimeCalled);
			}
			MyBackground.ManageAll();


				// After Custom Activity
				
            
		}

		public override void Destroy()
		{
			// Generated Destroy
			if (this.UnloadsContentManagerWhenDestroyed)
			{
				MyBackground.RemoveFromManagers(ContentManagerName != "Global");
			}
			else
			{
				MyBackground.RemoveFromManagers(false);
			}
			
			if (StartGameButton != null)
			{
				StartGameButton.Destroy();
				StartGameButton.Detach();
			}
			if (AboutButton != null)
			{
				AboutButton.Destroy();
				AboutButton.Detach();
			}
			if (ExitButton != null)
			{
				ExitButton.Destroy();
				ExitButton.Detach();
			}
			if (scene != null)
			{
				scene.RemoveFromManagers(ContentManagerName != "Global");
			}

			base.Destroy();

			CustomDestroy();

		}

		// Generated Methods
		public virtual void PostInitialize ()
		{
			bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
			StartGameButton.DisplayText = "Start";
			StartGameButton.ScaleX = 65f;
			if (StartGameButton.Parent == null)
			{
				StartGameButton.X = 50f;
			}
			else
			{
				StartGameButton.RelativeX = 50f;
			}
			if (StartGameButton.Parent == null)
			{
				StartGameButton.Y = 100f;
			}
			else
			{
				StartGameButton.RelativeY = 100f;
			}
			AboutButton.DisplayText = "About";
			if (AboutButton.Parent == null)
			{
				AboutButton.X = 50f;
			}
			else
			{
				AboutButton.RelativeX = 50f;
			}
			if (AboutButton.Parent == null)
			{
				AboutButton.Y = 50f;
			}
			else
			{
				AboutButton.RelativeY = 50f;
			}
			ExitButton.DisplayText = "Exit";
			if (ExitButton.Parent == null)
			{
				ExitButton.X = 50f;
			}
			else
			{
				ExitButton.RelativeX = 50f;
			}
			if (ExitButton.Parent == null)
			{
				ExitButton.Y = 0f;
			}
			else
			{
				ExitButton.RelativeY = 0f;
			}
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
		}
		public virtual void AddToManagersBottomUp ()
		{
			MyBackground.AddToManagers(mLayer);
			StartGameButton.AddToManagers(mLayer);
			StartGameButton.CurrentState = BeefBall.Entities.Button.VariableState.Disabled;
			StartGameButton.DisplayText = "Start";
			StartGameButton.ScaleX = 65f;
			if (StartGameButton.Parent == null)
			{
				StartGameButton.X = 50f;
			}
			else
			{
				StartGameButton.RelativeX = 50f;
			}
			if (StartGameButton.Parent == null)
			{
				StartGameButton.Y = 100f;
			}
			else
			{
				StartGameButton.RelativeY = 100f;
			}
			AboutButton.AddToManagers(mLayer);
			AboutButton.CurrentState = BeefBall.Entities.Button.VariableState.Disabled;
			AboutButton.DisplayText = "About";
			if (AboutButton.Parent == null)
			{
				AboutButton.X = 50f;
			}
			else
			{
				AboutButton.RelativeX = 50f;
			}
			if (AboutButton.Parent == null)
			{
				AboutButton.Y = 50f;
			}
			else
			{
				AboutButton.RelativeY = 50f;
			}
			ExitButton.AddToManagers(mLayer);
			ExitButton.CurrentState = BeefBall.Entities.Button.VariableState.Disabled;
			ExitButton.DisplayText = "Exit";
			if (ExitButton.Parent == null)
			{
				ExitButton.X = 50f;
			}
			else
			{
				ExitButton.RelativeX = 50f;
			}
			if (ExitButton.Parent == null)
			{
				ExitButton.Y = 0f;
			}
			else
			{
				ExitButton.RelativeY = 0f;
			}
		}
		public virtual void ConvertToManuallyUpdated ()
		{
			MyBackground.ConvertToManuallyUpdated();
			StartGameButton.ConvertToManuallyUpdated();
			AboutButton.ConvertToManuallyUpdated();
			ExitButton.ConvertToManuallyUpdated();
			scene.ConvertToManuallyUpdated();
		}
		public static void LoadStaticContent (string contentManagerName)
		{
			#if DEBUG
			if (contentManagerName == FlatRedBallServices.GlobalContentManager)
			{
				HasBeenLoadedWithGlobalContentManager = true;
			}
			else if (HasBeenLoadedWithGlobalContentManager)
			{
				throw new Exception("This type has been loaded with a Global content manager, then loaded with a non-global.  This can lead to a lot of bugs");
			}
			#endif
			BeefBall.Entities.Button.LoadStaticContent(contentManagerName);
			CustomLoadStaticContent(contentManagerName);
		}
		object GetMember (string memberName)
		{
			switch(memberName)
			{
				case  "MyBackground":
					return MyBackground;
			}
			return null;
		}


	}
}
