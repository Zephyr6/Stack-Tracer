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
        int questionIndex = 0;
        int numCorrect = 0;
        void OnAButtonRollOn (FlatRedBall.Gui.IWindow callingWindow)
        {
            this.AButton.CurrentState = Button.VariableState.Regular;
        }
        void OnAButtonRollOff (FlatRedBall.Gui.IWindow callingWindow)
        {
            this.AButton.CurrentState = Button.VariableState.Disabled;   
        }
        void OnAButtonClick (FlatRedBall.Gui.IWindow callingWindow)
        {
            if (questionIndex < 3)
            {
                if (threeQuestions[questionIndex].answerIndex == 0)
                {
                    numCorrect++;
                    //AButton.DisplayText = "Correct";
                    //this.AButton.CurrentState = Button.VariableState.Pressed;
                    //this.BButton.CurrentState = Button.VariableState.Disabled;
                    //this.CButton.CurrentState = Button.VariableState.Disabled;
                    //this.DButton.CurrentState = Button.VariableState.Disabled;
                }
                else
                {
                    //AButton.DisplayText = threeQuestions[questionIndex].answerIndex.ToString();
                }
               
                questionIndex++;
                NextQuestionVisible();
            }
            //else
                //AButton.DisplayText = "NULL";    
            }
        void OnBButtonRollOn (FlatRedBall.Gui.IWindow callingWindow)
        {
            this.BButton.CurrentState = Button.VariableState.Regular;
        }
        void OnBButtonRollOff (FlatRedBall.Gui.IWindow callingWindow)
        {
            this.BButton.CurrentState = Button.VariableState.Disabled;
        }
        void OnBButtonClick (FlatRedBall.Gui.IWindow callingWindow)
        {
            if (questionIndex < 3)
            {
                if (threeQuestions[questionIndex].answerIndex == 1)
                {
                    numCorrect++;
                    //BButton.DisplayText = "Correct";
                    //this.BButton.CurrentState = Button.VariableState.Pressed;
                    //this.AButton.CurrentState = Button.VariableState.Disabled;
                    //this.CButton.CurrentState = Button.VariableState.Disabled;
                    //this.DButton.CurrentState = Button.VariableState.Disabled;
                   
                }
                else
                {
                    //BButton.DisplayText = threeQuestions[questionIndex].answerIndex.ToString();
                }
                questionIndex++;
                NextQuestionVisible();

            }
               
        }
        void OnCButtonRollOn (FlatRedBall.Gui.IWindow callingWindow)
        {
            this.CButton.CurrentState = Button.VariableState.Regular;
        }
        void OnCButtonRollOff (FlatRedBall.Gui.IWindow callingWindow)
        {
            this.CButton.CurrentState = Button.VariableState.Disabled;
        }
        void OnCButtonClick (FlatRedBall.Gui.IWindow callingWindow)
        {
            if (questionIndex < 3)
            {
                if (threeQuestions[questionIndex].answerIndex == 2)
                {
                    numCorrect++
                    //CButton.DisplayText = "Correct";
                    //this.CButton.CurrentState = Button.VariableState.Pressed;
                    //this.AButton.CurrentState = Button.VariableState.Disabled;
                    //this.BButton.CurrentState = Button.VariableState.Disabled;
                    //this.DButton.CurrentState = Button.VariableState.Disabled;
                }
                else
                {
                    //CButton.DisplayText = threeQuestions[questionIndex].answerIndex.ToString();
                }
                questionIndex++;
                NextQuestionVisible();
            }
           
        }
        void OnDButtonRollOn (FlatRedBall.Gui.IWindow callingWindow)
        {
            this.DButton.CurrentState = Button.VariableState.Regular;
        }
        void OnDButtonRollOff (FlatRedBall.Gui.IWindow callingWindow)
        {
            this.DButton.CurrentState = Button.VariableState.Disabled;    
        }

        void OnNextQuestionClick(FlatRedBall.Gui.IWindow callingWindow)
        {

            if (questionIndex < 3)
            {
                DisplayQuestions();
            }
                NextQuestionNotVisible();
        }
        void OnDButtonClick (FlatRedBall.Gui.IWindow callingWindow)
        {
            if (questionIndex < 3)
            {
                if (threeQuestions[questionIndex].answerIndex == 3)
                {
                    numCorrect++;
                    //DButton.DisplayText = "Correct";
                    //this.DButton.CurrentState = Button.VariableState.Pressed;
                    //this.AButton.CurrentState = Button.VariableState.Disabled;
                    //this.BButton.CurrentState = Button.VariableState.Disabled;
                    //this.CButton.CurrentState = Button.VariableState.Disabled;
                }
                else
                {
                    //DButton.DisplayText = threeQuestions[questionIndex].answerIndex.ToString();
                }
                questionIndex++;
                NextQuestionVisible();
            }
            
        }

        void NextQuestionVisible() 
        {
            this.AButton.Visible = false;
            this.BButton.Visible = false;
            this.CButton.Visible = false;
            this.DButton.Visible = false;
            this.NextQuestion.Visible = true;
        }

        void NextQuestionNotVisible() 
        {
            if (questionIndex < 3)
            {
                this.AButton.Visible = true;
                this.BButton.Visible = true;
                this.CButton.Visible = true;
                this.DButton.Visible = true;
                this.NextQuestion.Visible = false;
            }
            else
                EndQuiz();
        }

        void EndQuiz() 
        {
            this.AButton.Visible = false;
            this.BButton.Visible = false;
            this.CButton.Visible = false;
            this.DButton.Visible = false;
            this.NextQuestion.Visible = false;  
        }
       

	}
}
