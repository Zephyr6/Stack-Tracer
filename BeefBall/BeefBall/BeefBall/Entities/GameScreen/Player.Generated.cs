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
using FlatRedBall.Graphics.Animation;
using Microsoft.Xna.Framework.Audio;

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

namespace BeefBall.Entities.GameScreen
{
	public partial class Player : PositionedObject, IDestroyable
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
		public enum VariableState
		{
			Uninitialized, //This exists so that the first set call actually does something
			R_Idle, 
			L_Idle, 
			R_Walking, 
			L_Walking, 
			L_Attack, 
			R_Attack, 
			Jumping, 
			R_Attack2, 
			L_Attack2
		}
		VariableState mCurrentState = VariableState.Uninitialized;
		public VariableState CurrentState
		{
			get
			{
				return mCurrentState;
			}
			set
			{
				mCurrentState = value;
				switch(mCurrentState)
				{
					case  VariableState.R_Idle:
						ChainName = "R_Idle";
						break;
					case  VariableState.L_Idle:
						ChainName = "L_Idle";
						break;
					case  VariableState.R_Walking:
						ChainName = "R_Idle";
						break;
					case  VariableState.L_Walking:
						ChainName = "L_Idle";
						break;
					case  VariableState.L_Attack:
						ChainName = "L_1_Punch";
						break;
					case  VariableState.R_Attack:
						ChainName = "R_1_Punch";
						break;
					case  VariableState.Jumping:
						ChainName = "Jumping";
						break;
					case  VariableState.R_Attack2:
						ChainName = "R_2_Punch";
						break;
					case  VariableState.L_Attack2:
						ChainName = "L_2_Punch";
						break;
				}
			}
		}
		static object mLockObject = new object();
		static bool mHasRegisteredUnload = false;
		static bool IsStaticContentLoaded = false;
		private static AnimationChainList AnimationChainListFile;
		private static SoundEffect hit;
		private static Scene InnerExSceneFile;
		private static SoundEffect swing;
		private static SoundEffect swing2;
		private static SoundEffect jump;
		
		private FlatRedBall.Math.Geometry.Circle mBody;
		public FlatRedBall.Math.Geometry.Circle Body
		{
			get
			{
				return mBody;
			}
		}
		private FlatRedBall.Math.Geometry.AxisAlignedRectangle mRightAttack;
		public FlatRedBall.Math.Geometry.AxisAlignedRectangle RightAttack
		{
			get
			{
				return mRightAttack;
			}
		}
		private FlatRedBall.Math.Geometry.AxisAlignedRectangle mLeftAttack;
		public FlatRedBall.Math.Geometry.AxisAlignedRectangle LeftAttack
		{
			get
			{
				return mLeftAttack;
			}
		}
		private FlatRedBall.Sprite InnerExScene;
		public float MovementSpeed = 70f;
		public string ChainName
		{
			get
			{
				return InnerExScene.CurrentChainName;
			}
			set
			{
				InnerExScene.CurrentChainName = value;
			}
		}
		public int Index { get; set; }
		public bool Used { get; set; }
		protected Layer LayerProvidedByContainer = null;

        public Player(string contentManagerName) :
            this(contentManagerName, true)
        {
        }


        public Player(string contentManagerName, bool addToManagers) :
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
			mBody = new FlatRedBall.Math.Geometry.Circle();
			mRightAttack = new FlatRedBall.Math.Geometry.AxisAlignedRectangle();
			mLeftAttack = new FlatRedBall.Math.Geometry.AxisAlignedRectangle();
			InnerExScene = InnerExSceneFile.Sprites.FindByName("innerex32x321").Clone();
			
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
			if (RightAttack != null)
			{
				RightAttack.Detach(); ShapeManager.Remove(RightAttack);
			}
			if (LeftAttack != null)
			{
				LeftAttack.Detach(); ShapeManager.Remove(LeftAttack);
			}
			if (InnerExScene != null)
			{
				InnerExScene.Detach(); SpriteManager.RemoveSprite(InnerExScene);
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
				Body.X = -4f;
			}
			else
			{
				Body.RelativeX = -4f;
			}
			if (Body.Parent == null)
			{
				Body.Y = -9f;
			}
			else
			{
				Body.RelativeY = -9f;
			}
			Body.Radius = 7f;
			if (mRightAttack!= null && mRightAttack.Parent == null)
			{
				mRightAttack.CopyAbsoluteToRelative();
				mRightAttack.AttachTo(this, false);
			}
			RightAttack.Visible = false;
			if (RightAttack.Parent == null)
			{
				RightAttack.X = 8f;
			}
			else
			{
				RightAttack.RelativeX = 8f;
			}
			if (RightAttack.Parent == null)
			{
				RightAttack.Y = 1f;
			}
			else
			{
				RightAttack.RelativeY = 1f;
			}
			RightAttack.ScaleX = 8f;
			RightAttack.ScaleY = 7f;
			RightAttack.Color = Color.Blue;
			if (mLeftAttack!= null && mLeftAttack.Parent == null)
			{
				mLeftAttack.CopyAbsoluteToRelative();
				mLeftAttack.AttachTo(this, false);
			}
			LeftAttack.Visible = false;
			if (LeftAttack.Parent == null)
			{
				LeftAttack.X = -15f;
			}
			else
			{
				LeftAttack.RelativeX = -15f;
			}
			if (LeftAttack.Parent == null)
			{
				LeftAttack.Y = 1f;
			}
			else
			{
				LeftAttack.RelativeY = 1f;
			}
			LeftAttack.ScaleX = 8f;
			LeftAttack.ScaleY = 7f;
			LeftAttack.Color = Color.Blue;
			if (InnerExScene!= null && InnerExScene.Parent == null)
			{
				InnerExScene.CopyAbsoluteToRelative();
				InnerExScene.AttachTo(this, false);
			}
			X = 0f;
			Y = 0f;
			MovementSpeed = 70f;
			Drag = 1f;
			ChainName = "R_Idle";
			RotationX = 0f;
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
				mBody.X = -4f;
			}
			else
			{
				mBody.RelativeX = -4f;
			}
			if (mBody.Parent == null)
			{
				mBody.Y = -9f;
			}
			else
			{
				mBody.RelativeY = -9f;
			}
			mBody.Radius = 7f;
			ShapeManager.AddToLayer(mRightAttack, layerToAddTo);
			mRightAttack.Visible = false;
			if (mRightAttack.Parent == null)
			{
				mRightAttack.X = 8f;
			}
			else
			{
				mRightAttack.RelativeX = 8f;
			}
			if (mRightAttack.Parent == null)
			{
				mRightAttack.Y = 1f;
			}
			else
			{
				mRightAttack.RelativeY = 1f;
			}
			mRightAttack.ScaleX = 8f;
			mRightAttack.ScaleY = 7f;
			mRightAttack.Color = Color.Blue;
			ShapeManager.AddToLayer(mLeftAttack, layerToAddTo);
			mLeftAttack.Visible = false;
			if (mLeftAttack.Parent == null)
			{
				mLeftAttack.X = -15f;
			}
			else
			{
				mLeftAttack.RelativeX = -15f;
			}
			if (mLeftAttack.Parent == null)
			{
				mLeftAttack.Y = 1f;
			}
			else
			{
				mLeftAttack.RelativeY = 1f;
			}
			mLeftAttack.ScaleX = 8f;
			mLeftAttack.ScaleY = 7f;
			mLeftAttack.Color = Color.Blue;
			SpriteManager.AddToLayer(InnerExScene, layerToAddTo);
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
			SpriteManager.ConvertToManuallyUpdated(InnerExScene);
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
						FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("PlayerStaticUnload", UnloadStaticContent);
						mHasRegisteredUnload = true;
					}
				}
				bool registerUnload = false;
				if (!FlatRedBallServices.IsLoaded<AnimationChainList>(@"content/entities/player/animationchainlistfile.achx", ContentManagerName))
				{
					registerUnload = true;
				}
				AnimationChainListFile = FlatRedBallServices.Load<AnimationChainList>(@"content/entities/player/animationchainlistfile.achx", ContentManagerName);
				hit = FlatRedBallServices.Load<SoundEffect>(@"content/entities/player/hit", ContentManagerName);
				if (!FlatRedBallServices.IsLoaded<Scene>(@"content/entities/player/innerexscenefile.scnx", ContentManagerName))
				{
					registerUnload = true;
				}
				InnerExSceneFile = FlatRedBallServices.Load<Scene>(@"content/entities/player/innerexscenefile.scnx", ContentManagerName);
				swing = FlatRedBallServices.Load<SoundEffect>(@"content/entities/player/swing", ContentManagerName);
				swing2 = FlatRedBallServices.Load<SoundEffect>(@"content/entities/player/swing2", ContentManagerName);
				jump = FlatRedBallServices.Load<SoundEffect>(@"content/entities/player/jump", ContentManagerName);
				if (registerUnload && ContentManagerName != FlatRedBallServices.GlobalContentManager)
				{
					lock (mLockObject)
					{
						if (!mHasRegisteredUnload && ContentManagerName != FlatRedBallServices.GlobalContentManager)
						{
							FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("PlayerStaticUnload", UnloadStaticContent);
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
			if (AnimationChainListFile != null)
			{
				AnimationChainListFile= null;
			}
			if (hit != null)
			{
				hit= null;
			}
			if (InnerExSceneFile != null)
			{
				InnerExSceneFile.RemoveFromManagers(ContentManagerName != "Global");
				InnerExSceneFile= null;
			}
			if (swing != null)
			{
				swing= null;
			}
			if (swing2 != null)
			{
				swing2= null;
			}
			if (jump != null)
			{
				jump= null;
			}
		}
		public static object GetStaticMember (string memberName)
		{
			switch(memberName)
			{
				case  "AnimationChainListFile":
					return AnimationChainListFile;
				case  "hit":
					return hit;
				case  "InnerExSceneFile":
					return InnerExSceneFile;
				case  "swing":
					return swing;
				case  "swing2":
					return swing2;
				case  "jump":
					return jump;
			}
			return null;
		}
		static VariableState mLoadingState = VariableState.Uninitialized;
		public static VariableState LoadingState
		{
			get
			{
				return mLoadingState;
			}
			set
			{
				mLoadingState = value;
			}
		}
		public Instruction InterpolateToState (VariableState stateToInterpolateTo, double secondsToTake)
		{
			switch(stateToInterpolateTo)
			{
				case  VariableState.R_Idle:
					break;
				case  VariableState.L_Idle:
					break;
				case  VariableState.R_Walking:
					break;
				case  VariableState.L_Walking:
					break;
				case  VariableState.L_Attack:
					break;
				case  VariableState.R_Attack:
					break;
				case  VariableState.Jumping:
					break;
				case  VariableState.R_Attack2:
					break;
				case  VariableState.L_Attack2:
					break;
			}
			var instruction = new DelegateInstruction<VariableState>(StopStateInterpolation, stateToInterpolateTo);
			instruction.TimeToExecute = TimeManager.CurrentTime + secondsToTake;
			this.Instructions.Add(instruction);
			return instruction;
		}
		public void StopStateInterpolation (VariableState stateToStop)
		{
			switch(stateToStop)
			{
				case  VariableState.R_Idle:
					break;
				case  VariableState.L_Idle:
					break;
				case  VariableState.R_Walking:
					break;
				case  VariableState.L_Walking:
					break;
				case  VariableState.L_Attack:
					break;
				case  VariableState.R_Attack:
					break;
				case  VariableState.Jumping:
					break;
				case  VariableState.R_Attack2:
					break;
				case  VariableState.L_Attack2:
					break;
			}
			CurrentState = stateToStop;
		}
		public void InterpolateBetween (VariableState firstState, VariableState secondState, float interpolationValue)
		{
			#if DEBUG
			if (float.IsNaN(interpolationValue))
			{
				throw new Exception("interpolationValue cannot be NaN");
			}
			#endif
			switch(firstState)
			{
				case  VariableState.R_Idle:
					break;
				case  VariableState.L_Idle:
					break;
				case  VariableState.R_Walking:
					break;
				case  VariableState.L_Walking:
					break;
				case  VariableState.L_Attack:
					break;
				case  VariableState.R_Attack:
					break;
				case  VariableState.Jumping:
					break;
				case  VariableState.R_Attack2:
					break;
				case  VariableState.L_Attack2:
					break;
			}
			switch(secondState)
			{
				case  VariableState.R_Idle:
					break;
				case  VariableState.L_Idle:
					break;
				case  VariableState.R_Walking:
					break;
				case  VariableState.L_Walking:
					break;
				case  VariableState.L_Attack:
					break;
				case  VariableState.R_Attack:
					break;
				case  VariableState.Jumping:
					break;
				case  VariableState.R_Attack2:
					break;
				case  VariableState.L_Attack2:
					break;
			}
		}
		object GetMember (string memberName)
		{
			switch(memberName)
			{
				case  "AnimationChainListFile":
					return AnimationChainListFile;
				case  "hit":
					return hit;
				case  "InnerExSceneFile":
					return InnerExSceneFile;
				case  "swing":
					return swing;
				case  "swing2":
					return swing2;
				case  "jump":
					return jump;
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
			InstructionManager.IgnorePausingFor(RightAttack);
			InstructionManager.IgnorePausingFor(LeftAttack);
			InstructionManager.IgnorePausingFor(InnerExScene);
		}

    }
	
	
	// Extra classes
	public static class PlayerExtensionMethods
	{
	}
	
}
