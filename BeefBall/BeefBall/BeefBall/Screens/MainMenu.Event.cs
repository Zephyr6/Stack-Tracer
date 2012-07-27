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
        void OnStartButtonClick (FlatRedBall.Gui.IWindow callingWindow)
        {
            this.MoveToScreen(typeof(GameScreen).FullName);
        }
        void OnAboutButtonClick (FlatRedBall.Gui.IWindow callingWindow)
        {
            this.MoveToScreen(typeof(About).FullName);
        }
        void OnExitButtonClick (FlatRedBall.Gui.IWindow callingWindow)
        {
            FlatRedBallServices.Game.Exit();
        }
        void OnStartButtonRollOn (FlatRedBall.Gui.IWindow callingWindow)
        {
            this.StartGameButton.CurrentState = Button.VariableState.Regular;
            Game1.StartGameSFX.Play();
        }
        void OnStartButtonRollOff (FlatRedBall.Gui.IWindow callingWindow)
        {
            this.StartGameButton.CurrentState = Button.VariableState.Disabled;
        }
        void OnAboutButtonRollOn (FlatRedBall.Gui.IWindow callingWindow)
        {
            this.AboutButton.CurrentState = Button.VariableState.Regular;
            Game1.AboutGameSFX.Play();
        }
        void OnAboutButtonRollOff (FlatRedBall.Gui.IWindow callingWindow)
        {
            this.AboutButton.CurrentState = Button.VariableState.Disabled;
        }
        void OnExitButtonRollOn (FlatRedBall.Gui.IWindow callingWindow)
        {
            this.ExitButton.CurrentState = Button.VariableState.Regular;
            Game1.ExitGameSFX.Play();
            
        }
        void OnExitButtonRollOff (FlatRedBall.Gui.IWindow callingWindow)
        {
            this.ExitButton.CurrentState = Button.VariableState.Disabled;
        }

	}
}
