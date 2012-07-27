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
	public partial class MainMenu
	{
		void OnStartButtonClickTunnel (FlatRedBall.Gui.IWindow callingWindow)
		{
			if (this.StartButtonClick != null)
			{
				StartButtonClick(callingWindow);
			}
		}
		void OnAboutButtonClickTunnel (FlatRedBall.Gui.IWindow callingWindow)
		{
			if (this.AboutButtonClick != null)
			{
				AboutButtonClick(callingWindow);
			}
		}
		void OnExitButtonClickTunnel (FlatRedBall.Gui.IWindow callingWindow)
		{
			if (this.ExitButtonClick != null)
			{
				ExitButtonClick(callingWindow);
			}
		}
		void OnStartButtonRollOnTunnel (FlatRedBall.Gui.IWindow callingWindow)
		{
			if (this.StartButtonRollOn != null)
			{
				StartButtonRollOn(callingWindow);
			}
		}
		void OnStartButtonRollOffTunnel (FlatRedBall.Gui.IWindow callingWindow)
		{
			if (this.StartButtonRollOff != null)
			{
				StartButtonRollOff(callingWindow);
			}
		}
		void OnAboutButtonRollOnTunnel (FlatRedBall.Gui.IWindow callingWindow)
		{
			if (this.AboutButtonRollOn != null)
			{
				AboutButtonRollOn(callingWindow);
			}
		}
		void OnAboutButtonRollOffTunnel (FlatRedBall.Gui.IWindow callingWindow)
		{
			if (this.AboutButtonRollOff != null)
			{
				AboutButtonRollOff(callingWindow);
			}
		}
		void OnExitButtonRollOnTunnel (FlatRedBall.Gui.IWindow callingWindow)
		{
			if (this.ExitButtonRollOn != null)
			{
				ExitButtonRollOn(callingWindow);
			}
		}
		void OnExitButtonRollOffTunnel (FlatRedBall.Gui.IWindow callingWindow)
		{
			if (this.ExitButtonRollOff != null)
			{
				ExitButtonRollOff(callingWindow);
			}
		}
	}
}
