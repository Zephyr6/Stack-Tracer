using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Model;

using FlatRedBall.Input;
using FlatRedBall.Utilities;

using FlatRedBall.Instructions;
using FlatRedBall.Math.Splines;
using BitmapFont = FlatRedBall.Graphics.BitmapFont;
using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;
// Generated Usings
using BeefBall.Screens;
using Matrix = Microsoft.Xna.Framework.Matrix;
using FlatRedBall.Graphics;
using FlatRedBall.Math;
using FlatRedBall.Broadcasting;
using BeefBall.Entities;
using BeefBall.Entities.GameScreen;
using FlatRedBall;
using FlatRedBall.Math.Geometry;

#if XNA4
using Color = Microsoft.Xna.Framework.Color;
#else
using Color = Microsoft.Xna.Framework.Graphics.Color;
#endif

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
#endif

#if FRB_XNA && !MONODROID
using Model = Microsoft.Xna.Framework.Graphics.Model;
#endif

namespace BeefBall.Entities
{
	public partial class ToQuiz : PositionedObject, IDestroyable
	{
        // This is made global so that static lazy-loaded content can access it.
        public static string ContentManagerName
        {
            get;
            set;
        }

		// Generated Fields
		#if DEBUG
		static bool HasBeenLoadedWithGlobalContentManager = false;
		#endif
		static object mLockObject = new object();
		static bool mHasRegisteredUnload = false;
		static bool IsStaticContentLoaded = false;
		private static Scene SceneFile;
		
		private FlatRedBall.Math.Geometry.Circle mBody;
		public FlatRedBall.Math.Geometry.Circle Body
		{
			get
			{
				return mBody;
			}
		}
		private FlatRedBall.Scene EntireScene;
		private FlatRedBall.Graphics.Text InstructionText;
		public bool InstructionTextVisible
		{
			get
			{
				return InstructionText.Visible;
			}
			set
			{
				InstructionText.Visible = value;
			}
		}
		public int Index { get; set; }
		public bool Used { get; set; }
		protected Layer LayerProvidedByContainer = null;

        public ToQuiz(string contentManagerName) :
            this(contentManagerName, true)
        {
        }


        public ToQuiz(string contentManagerName, bool addToManagers) :
			base()
		{
			// Don't delete this:
            ContentManagerName = contentManagerName;
            InitializeEntity(addToManagers);

		}

		protected virtual void InitializeEntity(bool addToManagers)
		{
			// Generated Initialize
			LoadStaticContent(ContentManagerName);
			EntireScene = SceneFile.Clone();
			for (int i = 0; i < EntireScene.Texts.Count; i++)
			{
				EntireScene.Texts[i].AdjustPositionForPixelPerfectDrawing = true;
			}
			mBody = new FlatRedBall.Math.Geometry.Circle();
			InstructionText = new FlatRedBall.Graphics.Text();
			
			PostInitialize();
			if (addToManagers)
			{
				AddToManagers(null);
			}


		}

// Generated AddToManagers
		public virtual void AddToManagers (Layer layerToAddTo)
		{
			LayerProvidedByContainer = layerToAddTo;
			SpriteManager.AddPositionedObject(this);
			AddToManagersBottomUp(layerToAddTo);
			CustomInitialize();
		}

		public virtual void Activity()
		{
			// Generated Activity
			
			CustomActivity();
			EntireScene.ManageAll();
			
			// After Custom Activity
		}

		public virtual void Destroy()
		{
			// Generated Destroy
			SpriteManager.RemovePositionedObject(this);
			
			if (Body != null)
			{
				Body.Detach(); ShapeManager.Remove(Body);
			}
			if (EntireScene != null)
			{
				EntireScene.RemoveFromManagers(ContentManagerName != "Global");
			}
			if (InstructionText != null)
			{
				InstructionText.Detach(); TextManager.RemoveText(InstructionText);
			}


			CustomDestroy();
		}

		// Generated Methods
		public virtual void PostInitialize ()
		{
			bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
			if (mBody!= null && mBody.Parent == null)
			{
				mBody.CopyAbsoluteToRelative();
				mBody.AttachTo(this, false);
			}
			Body.Visible = false;
			if (Body.Parent == null)
			{
				Body.X = -1f;
			}
			else
			{
				Body.RelativeX = -1f;
			}
			if (Body.Parent == null)
			{
				Body.Y = 0f;
			}
			else
			{
				Body.RelativeY = 0f;
			}
			Body.Radius = 10f;
			Body.Color = Color.GreenYellow;
			EntireScene.CopyAbsoluteToRelative();
			EntireScene.AttachAllDetachedTo(this, false);
			if (InstructionText!= null && InstructionText.Parent == null)
			{
				InstructionText.CopyAbsoluteToRelative();
				InstructionText.AttachTo(this, false);
			}
			InstructionText.DisplayText = "Press X to use.";
			if (InstructionText.Parent == null)
			{
				InstructionText.X = -40f;
			}
			else
			{
				InstructionText.RelativeX = -40f;
			}
			if (InstructionText.Parent == null)
			{
				InstructionText.Y = 20f;
			}
			else
			{
				InstructionText.RelativeY = 20f;
			}
			InstructionText.Scale = 8f;
			InstructionText.Spacing = 7f;
			X = 0f;
			Y = 0f;
			InstructionTextVisible = false;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
		}
		public virtual void AddToManagersBottomUp (Layer layerToAddTo)
		{
			// We move this back to the origin and unrotate it so that anything attached to it can just use its absolute position
			float oldRotationX = RotationX;
			float oldRotationY = RotationY;
			float oldRotationZ = RotationZ;
			
			float oldX = X;
			float oldY = Y;
			float oldZ = Z;
			
			X = 0;
			Y = 0;
			Z = 0;
			RotationX = 0;
			RotationY = 0;
			RotationZ = 0;
			ShapeManager.AddToLayer(mBody, layerToAddTo);
			mBody.Visible = false;
			if (mBody.Parent == null)
			{
				mBody.X = -1f;
			}
			else
			{
				mBody.RelativeX = -1f;
			}
			if (mBody.Parent == null)
			{
				mBody.Y = 0f;
			}
			else
			{
				mBody.RelativeY = 0f;
			}
			mBody.Radius = 10f;
			mBody.Color = Color.GreenYellow;
			EntireScene.AddToManagers(layerToAddTo);
			TextManager.AddToLayer(InstructionText, layerToAddTo);
			InstructionText.SetPixelPerfectScale(layerToAddTo);
			InstructionText.DisplayText = "Press X to use.";
			if (InstructionText.Parent == null)
			{
				InstructionText.X = -40f;
			}
			else
			{
				InstructionText.RelativeX = -40f;
			}
			if (InstructionText.Parent == null)
			{
				InstructionText.Y = 20f;
			}
			else
			{
				InstructionText.RelativeY = 20f;
			}
			InstructionText.Scale = 8f;
			InstructionText.Spacing = 7f;
			X = oldX;
			Y = oldY;
			Z = oldZ;
			RotationX = oldRotationX;
			RotationY = oldRotationY;
			RotationZ = oldRotationZ;
		}
		public virtual void ConvertToManuallyUpdated ()
		{
			this.ForceUpdateDependenciesDeep();
			SpriteManager.ConvertToManuallyUpdated(this);
			EntireScene.ConvertToManuallyUpdated();
			TextManager.ConvertToManuallyUpdated(InstructionText);
		}
		public static void LoadStaticContent (string contentManagerName)
		{
			ContentManagerName = contentManagerName;
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
			if (IsStaticContentLoaded == false)
			{
				IsStaticContentLoaded = true;
				lock (mLockObject)
				{
					if (!mHasRegisteredUnload && ContentManagerName != FlatRedBallServices.GlobalContentManager)
					{
						FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("ToQuizStaticUnload", UnloadStaticContent);
						mHasRegisteredUnload = true;
					}
				}
				bool registerUnload = false;
				if (!FlatRedBallServices.IsLoaded<Scene>(@"content/entities/toquiz/scenefile.scnx", ContentManagerName))
				{
					registerUnload = true;
				}
				SceneFile = FlatRedBallServices.Load<Scene>(@"content/entities/toquiz/scenefile.scnx", ContentManagerName);
				if (registerUnload && ContentManagerName != FlatRedBallServices.GlobalContentManager)
				{
					lock (mLockObject)
					{
						if (!mHasRegisteredUnload && ContentManagerName != FlatRedBallServices.GlobalContentManager)
						{
							FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("ToQuizStaticUnload", UnloadStaticContent);
							mHasRegisteredUnload = true;
						}
					}
				}
				CustomLoadStaticContent(contentManagerName);
			}
		}
		public static void UnloadStaticContent ()
		{
			IsStaticContentLoaded = false;
			mHasRegisteredUnload = false;
			if (SceneFile != null)
			{
				SceneFile.RemoveFromManagers(ContentManagerName != "Global");
				SceneFile= null;
			}
		}
		public static object GetStaticMember (string memberName)
		{
			switch(memberName)
			{
				case  "SceneFile":
					return SceneFile;
			}
			return null;
		}
		object GetMember (string memberName)
		{
			switch(memberName)
			{
				case  "SceneFile":
					return SceneFile;
			}
			return null;
		}
		protected bool mIsPaused;
		public override void Pause (InstructionList instructions)
		{
			base.Pause(instructions);
			mIsPaused = true;
		}
		public virtual void SetToIgnorePausing ()
		{
			InstructionManager.IgnorePausingFor(this);
			InstructionManager.IgnorePausingFor(Body);
			InstructionManager.IgnorePausingFor(EntireScene);
			InstructionManager.IgnorePausingFor(InstructionText);
		}

    }
	
	
	// Extra classes
	public static class ToQuizExtensionMethods
	{
	}
	
}
