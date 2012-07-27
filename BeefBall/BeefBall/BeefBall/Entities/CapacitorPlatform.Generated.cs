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
using Microsoft.Xna.Framework.Graphics;

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
	public partial class CapacitorPlatform : PositionedObject, IDestroyable
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
		private static Texture2D Capacitor;
		private static Scene SceneFile;
		private static ShapeCollection CapacitorCollisionFile;
		
		private FlatRedBall.Scene CapacitorScn;
		private FlatRedBall.Math.Geometry.Polygon mCollision;
		public FlatRedBall.Math.Geometry.Polygon Collision
		{
			get
			{
				return mCollision;
			}
		}
		public int Index { get; set; }
		public bool Used { get; set; }
		protected Layer LayerProvidedByContainer = null;

        public CapacitorPlatform(string contentManagerName) :
            this(contentManagerName, true)
        {
        }


        public CapacitorPlatform(string contentManagerName, bool addToManagers) :
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
			CapacitorScn = SceneFile.Clone();
			for (int i = 0; i < CapacitorScn.Texts.Count; i++)
			{
				CapacitorScn.Texts[i].AdjustPositionForPixelPerfectDrawing = true;
			}
			mCollision = CapacitorCollisionFile.Polygons.FindByName("Polygon1").Clone();
			
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
			CapacitorScn.ManageAll();
			
			// After Custom Activity
		}

		public virtual void Destroy()
		{
			// Generated Destroy
			SpriteManager.RemovePositionedObject(this);
			
			if (CapacitorScn != null)
			{
				CapacitorScn.RemoveFromManagers(ContentManagerName != "Global");
			}
			if (Collision != null)
			{
				Collision.Detach(); ShapeManager.Remove(Collision);
			}


			CustomDestroy();
		}

		// Generated Methods
		public virtual void PostInitialize ()
		{
			bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
			CapacitorScn.CopyAbsoluteToRelative();
			CapacitorScn.AttachAllDetachedTo(this, false);
			if (mCollision!= null && mCollision.Parent == null)
			{
				mCollision.CopyAbsoluteToRelative();
				mCollision.AttachTo(this, false);
			}
			Collision.Visible = false;
			X = 0f;
			Y = 0f;
			Z = 0f;
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
			CapacitorScn.AddToManagers(layerToAddTo);
			ShapeManager.AddToLayer(mCollision, layerToAddTo);
			mCollision.Visible = false;
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
			CapacitorScn.ConvertToManuallyUpdated();
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
						FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("CapacitorPlatformStaticUnload", UnloadStaticContent);
						mHasRegisteredUnload = true;
					}
				}
				bool registerUnload = false;
				if (!FlatRedBallServices.IsLoaded<Texture2D>(@"content/entities/capacitorplatform/capacitor.png", ContentManagerName))
				{
					registerUnload = true;
				}
				Capacitor = FlatRedBallServices.Load<Texture2D>(@"content/entities/capacitorplatform/capacitor.png", ContentManagerName);
				if (!FlatRedBallServices.IsLoaded<Scene>(@"content/entities/capacitorplatform/scenefile.scnx", ContentManagerName))
				{
					registerUnload = true;
				}
				SceneFile = FlatRedBallServices.Load<Scene>(@"content/entities/capacitorplatform/scenefile.scnx", ContentManagerName);
				if (!FlatRedBallServices.IsLoaded<ShapeCollection>(@"content/entities/capacitorplatform/capacitorcollisionfile.shcx", ContentManagerName))
				{
					registerUnload = true;
				}
				CapacitorCollisionFile = FlatRedBallServices.Load<ShapeCollection>(@"content/entities/capacitorplatform/capacitorcollisionfile.shcx", ContentManagerName);
				if (registerUnload && ContentManagerName != FlatRedBallServices.GlobalContentManager)
				{
					lock (mLockObject)
					{
						if (!mHasRegisteredUnload && ContentManagerName != FlatRedBallServices.GlobalContentManager)
						{
							FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("CapacitorPlatformStaticUnload", UnloadStaticContent);
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
			if (Capacitor != null)
			{
				Capacitor= null;
			}
			if (SceneFile != null)
			{
				SceneFile.RemoveFromManagers(ContentManagerName != "Global");
				SceneFile= null;
			}
			if (CapacitorCollisionFile != null)
			{
				CapacitorCollisionFile.RemoveFromManagers(ContentManagerName != "Global");
				CapacitorCollisionFile= null;
			}
		}
		public static object GetStaticMember (string memberName)
		{
			switch(memberName)
			{
				case  "Capacitor":
					return Capacitor;
				case  "SceneFile":
					return SceneFile;
				case  "CapacitorCollisionFile":
					return CapacitorCollisionFile;
			}
			return null;
		}
		object GetMember (string memberName)
		{
			switch(memberName)
			{
				case  "Capacitor":
					return Capacitor;
				case  "SceneFile":
					return SceneFile;
				case  "CapacitorCollisionFile":
					return CapacitorCollisionFile;
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
			InstructionManager.IgnorePausingFor(CapacitorScn);
			InstructionManager.IgnorePausingFor(Collision);
		}

    }
	
	
	// Extra classes
	public static class CapacitorPlatformExtensionMethods
	{
	}
	
}
