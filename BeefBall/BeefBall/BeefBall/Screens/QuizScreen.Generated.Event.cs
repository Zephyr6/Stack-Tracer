using System;
using FlatRedBall;
using FlatRedBall.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Specialized;
using BeefBall.Entities;
using BeefBall.Entities.GameScreen;
using BeefBall.Screens;
namespace BeefBall.Screens
{
	public partial class QuizScreen
	{
		void OnAButtonRollOnTunnel (FlatRedBall.Gui.IWindow callingWindow)
		{
			if (this.AButtonRollOn != null)
			{
				AButtonRollOn(callingWindow);
			}
		}
		void OnAButtonRollOffTunnel (FlatRedBall.Gui.IWindow callingWindow)
		{
			if (this.AButtonRollOff != null)
			{
				AButtonRollOff(callingWindow);
			}
		}
		void OnAButtonClickTunnel (FlatRedBall.Gui.IWindow callingWindow)
		{
			if (this.AButtonClick != null)
			{
				AButtonClick(callingWindow);
			}
		}
		void OnBButtonRollOnTunnel (FlatRedBall.Gui.IWindow callingWindow)
		{
			if (this.BButtonRollOn != null)
			{
				BButtonRollOn(callingWindow);
			}
		}
		void OnBButtonRollOffTunnel (FlatRedBall.Gui.IWindow callingWindow)
		{
			if (this.BButtonRollOff != null)
			{
				BButtonRollOff(callingWindow);
			}
		}
		void OnBButtonClickTunnel (FlatRedBall.Gui.IWindow callingWindow)
		{
			if (this.BButtonClick != null)
			{
				BButtonClick(callingWindow);
			}
		}
		void OnCButtonRollOnTunnel (FlatRedBall.Gui.IWindow callingWindow)
		{
			if (this.CButtonRollOn != null)
			{
				CButtonRollOn(callingWindow);
			}
		}
		void OnCButtonRollOffTunnel (FlatRedBall.Gui.IWindow callingWindow)
		{
			if (this.CButtonRollOff != null)
			{
				CButtonRollOff(callingWindow);
			}
		}
		void OnCButtonClickTunnel (FlatRedBall.Gui.IWindow callingWindow)
		{
			if (this.CButtonClick != null)
			{
				CButtonClick(callingWindow);
			}
		}
		void OnDButtonRollOnTunnel (FlatRedBall.Gui.IWindow callingWindow)
		{
			if (this.DButtonRollOn != null)
			{
				DButtonRollOn(callingWindow);
			}
		}
		void OnDButtonRollOffTunnel (FlatRedBall.Gui.IWindow callingWindow)
		{
			if (this.DButtonRollOff != null)
			{
				DButtonRollOff(callingWindow);
			}
		}
		void OnDButtonClickTunnel (FlatRedBall.Gui.IWindow callingWindow)
		{
			if (this.DButtonClick != null)
			{
				DButtonClick(callingWindow);
			}
		}
		void OnNextQuestionClickTunnel (FlatRedBall.Gui.IWindow callingWindow)
		{
			if (this.NextQuestionClick != null)
			{
				NextQuestionClick(callingWindow);
			}
		}
	}
}
