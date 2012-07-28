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
                }
                else
                {
                    //AButton.DisplayText = threeQuestions[questionIndex].answerIndex.ToString();
                }
               
                questionIndex++;
                UpdateNumCorrect();
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
                UpdateNumCorrect();
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
                    numCorrect++;
                   
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
                UpdateNumCorrect();
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

            if(questionIndex > 2)
            {
                this.MoveToScreen(typeof(GameScreen).FullName);
            }
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
                UpdateNumCorrect();
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
            if (questionIndex > 2)
            {
                this.NextQuestion.DisplayText = "Done";
            }
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
        }

        void UpdateNumCorrect() 
        {
            this.NumberCorrect.CurrentState = Button.VariableState.Hover;
            string score = string.Format("{0} out of {1}", numCorrect, questionIndex);
            NumberCorrect.DisplayText = (score);
        }
       

	}
}
