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
		
		private BeefBall.Entities.Button ButtonInstance;
		private BeefBall.Entities.Button ButtonInstance2;
		private BeefBall.Entities.Button ButtonInstance3;
		private BeefBall.Entities.Button ButtonInstance4;

		public QuizScreen()
			: base("QuizScreen")
		{
		}

        public override void Initialize(bool addToManagers)
        {
			// Generated Initialize
			LoadStaticContent(ContentManagerName);
			ButtonInstance = new BeefBall.Entities.Button(ContentManagerName, false);
			ButtonInstance.Name = "ButtonInstance";
			ButtonInstance2 = new BeefBall.Entities.Button(ContentManagerName, false);
			ButtonInstance2.Name = "ButtonInstance2";
			ButtonInstance3 = new BeefBall.Entities.Button(ContentManagerName, false);
			ButtonInstance3.Name = "ButtonInstance3";
			ButtonInstance4 = new BeefBall.Entities.Button(ContentManagerName, false);
			ButtonInstance4.Name = "ButtonInstance4";
			
			
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
				
				ButtonInstance.Activity();
				ButtonInstance2.Activity();
				ButtonInstance3.Activity();
				ButtonInstance4.Activity();
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
			
			if (ButtonInstance != null)
			{
				ButtonInstance.Destroy();
				ButtonInstance.Detach();
			}
			if (ButtonInstance2 != null)
			{
				ButtonInstance2.Destroy();
				ButtonInstance2.Detach();
			}
			if (ButtonInstance3 != null)
			{
				ButtonInstance3.Destroy();
				ButtonInstance3.Detach();
			}
			if (ButtonInstance4 != null)
			{
				ButtonInstance4.Destroy();
				ButtonInstance4.Detach();
			}

			base.Destroy();

			CustomDestroy();

		}

		// Generated Methods
		public virtual void PostInitialize ()
		{
			bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
		}
		public virtual void AddToManagersBottomUp ()
		{
			ButtonInstance.AddToManagers(mLayer);
			ButtonInstance2.AddToManagers(mLayer);
			ButtonInstance3.AddToManagers(mLayer);
			ButtonInstance4.AddToManagers(mLayer);
		}
		public virtual void ConvertToManuallyUpdated ()
		{
			ButtonInstance.ConvertToManuallyUpdated();
			ButtonInstance2.ConvertToManuallyUpdated();
			ButtonInstance3.ConvertToManuallyUpdated();
			ButtonInstance4.ConvertToManuallyUpdated();
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
