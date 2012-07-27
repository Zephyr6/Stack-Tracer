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
	public partial class QuizScreen : Screen
	{
		// Generated Fields
		#if DEBUG
		static bool HasBeenLoadedWithGlobalContentManager = false;
		#endif
		
		private BeefBall.Entities.Button AButton;
		private BeefBall.Entities.Button BButton;
		private BeefBall.Entities.Button CButton;
		private BeefBall.Entities.Button DButton;
		private BeefBall.Entities.Button NextQuestion;
		public event FlatRedBall.Gui.WindowEvent AButtonRollOn;
		public event FlatRedBall.Gui.WindowEvent AButtonRollOff;
		public event FlatRedBall.Gui.WindowEvent AButtonClick;
		public event FlatRedBall.Gui.WindowEvent BButtonRollOn;
		public event FlatRedBall.Gui.WindowEvent BButtonRollOff;
		public event FlatRedBall.Gui.WindowEvent BButtonClick;
		public event FlatRedBall.Gui.WindowEvent CButtonRollOn;
		public event FlatRedBall.Gui.WindowEvent CButtonRollOff;
		public event FlatRedBall.Gui.WindowEvent CButtonClick;
		public event FlatRedBall.Gui.WindowEvent DButtonRollOn;
		public event FlatRedBall.Gui.WindowEvent DButtonRollOff;
		public event FlatRedBall.Gui.WindowEvent DButtonClick;
		public event FlatRedBall.Gui.WindowEvent NextQuestionClick;

		public QuizScreen()
			: base("QuizScreen")
		{
		}

        public override void Initialize(bool addToManagers)
        {
			// Generated Initialize
			LoadStaticContent(ContentManagerName);
			AButton = new BeefBall.Entities.Button(ContentManagerName, false);
			AButton.Name = "AButton";
			BButton = new BeefBall.Entities.Button(ContentManagerName, false);
			BButton.Name = "BButton";
			CButton = new BeefBall.Entities.Button(ContentManagerName, false);
			CButton.Name = "CButton";
			DButton = new BeefBall.Entities.Button(ContentManagerName, false);
			DButton.Name = "DButton";
			NextQuestion = new BeefBall.Entities.Button(ContentManagerName, false);
			NextQuestion.Name = "NextQuestion";
			AButton.RollOn += OnAButtonRollOn;
			AButton.RollOn += OnAButtonRollOnTunnel;
			AButton.RollOff += OnAButtonRollOff;
			AButton.RollOff += OnAButtonRollOffTunnel;
			AButton.Click += OnAButtonClick;
			AButton.Click += OnAButtonClickTunnel;
			BButton.RollOn += OnBButtonRollOn;
			BButton.RollOn += OnBButtonRollOnTunnel;
			BButton.RollOff += OnBButtonRollOff;
			BButton.RollOff += OnBButtonRollOffTunnel;
			BButton.Click += OnBButtonClick;
			BButton.Click += OnBButtonClickTunnel;
			CButton.RollOn += OnCButtonRollOn;
			CButton.RollOn += OnCButtonRollOnTunnel;
			CButton.RollOff += OnCButtonRollOff;
			CButton.RollOff += OnCButtonRollOffTunnel;
			CButton.Click += OnCButtonClick;
			CButton.Click += OnCButtonClickTunnel;
			DButton.RollOn += OnDButtonRollOn;
			DButton.RollOn += OnDButtonRollOnTunnel;
			DButton.RollOff += OnDButtonRollOff;
			DButton.RollOff += OnDButtonRollOffTunnel;
			DButton.Click += OnDButtonClick;
			DButton.Click += OnDButtonClickTunnel;
			NextQuestion.Click += OnNextQuestionClick;
			NextQuestion.Click += OnNextQuestionClickTunnel;
			
			
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
				
				AButton.Activity();
				BButton.Activity();
				CButton.Activity();
				DButton.Activity();
				NextQuestion.Activity();
			}
			else
			{
			}
			base.Activity(firstTimeCalled);
			if (!IsActivityFinished)
			{
				CustomActivity(firstTimeCalled);
			}


				// After Custom Activity
				
            
		}

		public override void Destroy()
		{
			// Generated Destroy
			
			if (AButton != null)
			{
				AButton.Destroy();
				AButton.Detach();
			}
			if (BButton != null)
			{
				BButton.Destroy();
				BButton.Detach();
			}
			if (CButton != null)
			{
				CButton.Destroy();
				CButton.Detach();
			}
			if (DButton != null)
			{
				DButton.Destroy();
				DButton.Detach();
			}
			if (NextQuestion != null)
			{
				NextQuestion.Destroy();
				NextQuestion.Detach();
			}

			base.Destroy();

			CustomDestroy();

		}

		// Generated Methods
		public virtual void PostInitialize ()
		{
			bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
			AButton.DisplayText = "A";
			AButton.ScaleX = 25f;
			if (AButton.Parent == null)
			{
				AButton.X = -75f;
			}
			else
			{
				AButton.RelativeX = -75f;
			}
			if (AButton.Parent == null)
			{
				AButton.Y = -90f;
			}
			else
			{
				AButton.RelativeY = -90f;
			}
			BButton.DisplayText = "B";
			BButton.ScaleX = 25f;
			if (BButton.Parent == null)
			{
				BButton.X = -25f;
			}
			else
			{
				BButton.RelativeX = -25f;
			}
			if (BButton.Parent == null)
			{
				BButton.Y = -90f;
			}
			else
			{
				BButton.RelativeY = -90f;
			}
			CButton.DisplayText = "C";
			CButton.ScaleX = 25f;
			if (CButton.Parent == null)
			{
				CButton.X = 25f;
			}
			else
			{
				CButton.RelativeX = 25f;
			}
			if (CButton.Parent == null)
			{
				CButton.Y = -90f;
			}
			else
			{
				CButton.RelativeY = -90f;
			}
			DButton.DisplayText = "D";
			DButton.ScaleX = 25f;
			if (DButton.Parent == null)
			{
				DButton.X = 75f;
			}
			else
			{
				DButton.RelativeX = 75f;
			}
			if (DButton.Parent == null)
			{
				DButton.Y = -90f;
			}
			else
			{
				DButton.RelativeY = -90f;
			}
			NextQuestion.DisplayText = "Next Question";
			if (NextQuestion.Parent == null)
			{
				NextQuestion.Y = -90f;
			}
			else
			{
				NextQuestion.RelativeY = -90f;
			}
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
		}
		public virtual void AddToManagersBottomUp ()
		{
			AButton.AddToManagers(mLayer);
			AButton.CurrentState = BeefBall.Entities.Button.VariableState.Disabled;
			AButton.DisplayText = "A";
			AButton.ScaleX = 25f;
			if (AButton.Parent == null)
			{
				AButton.X = -75f;
			}
			else
			{
				AButton.RelativeX = -75f;
			}
			if (AButton.Parent == null)
			{
				AButton.Y = -90f;
			}
			else
			{
				AButton.RelativeY = -90f;
			}
			BButton.AddToManagers(mLayer);
			BButton.CurrentState = BeefBall.Entities.Button.VariableState.Disabled;
			BButton.DisplayText = "B";
			BButton.ScaleX = 25f;
			if (BButton.Parent == null)
			{
				BButton.X = -25f;
			}
			else
			{
				BButton.RelativeX = -25f;
			}
			if (BButton.Parent == null)
			{
				BButton.Y = -90f;
			}
			else
			{
				BButton.RelativeY = -90f;
			}
			CButton.AddToManagers(mLayer);
			CButton.CurrentState = BeefBall.Entities.Button.VariableState.Disabled;
			CButton.DisplayText = "C";
			CButton.ScaleX = 25f;
			if (CButton.Parent == null)
			{
				CButton.X = 25f;
			}
			else
			{
				CButton.RelativeX = 25f;
			}
			if (CButton.Parent == null)
			{
				CButton.Y = -90f;
			}
			else
			{
				CButton.RelativeY = -90f;
			}
			DButton.AddToManagers(mLayer);
			DButton.CurrentState = BeefBall.Entities.Button.VariableState.Disabled;
			DButton.DisplayText = "D";
			DButton.ScaleX = 25f;
			if (DButton.Parent == null)
			{
				DButton.X = 75f;
			}
			else
			{
				DButton.RelativeX = 75f;
			}
			if (DButton.Parent == null)
			{
				DButton.Y = -90f;
			}
			else
			{
				DButton.RelativeY = -90f;
			}
			NextQuestion.AddToManagers(mLayer);
			NextQuestion.DisplayText = "Next Question";
			if (NextQuestion.Parent == null)
			{
				NextQuestion.Y = -90f;
			}
			else
			{
				NextQuestion.RelativeY = -90f;
			}
		}
		public virtual void ConvertToManuallyUpdated ()
		{
			AButton.ConvertToManuallyUpdated();
			BButton.ConvertToManuallyUpdated();
			CButton.ConvertToManuallyUpdated();
			DButton.ConvertToManuallyUpdated();
			NextQuestion.ConvertToManuallyUpdated();
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
			return null;
		}


	}
}
