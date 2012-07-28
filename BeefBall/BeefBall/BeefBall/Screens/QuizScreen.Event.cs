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
        bool canRollOver = true;
        bool canClick = true;
        

        void onXBoxXButtonClick(FlatRedBall.Gui.IWindow callingWindow)
        {
            
            if (questionIndex < 3 && canClick)
            {
                if (IsRightAnswer(0))
                {
                    numCorrect++;
                    answerXText.SetColor(0, 255, 0);
                }
                else 
                {
                    answerXText.SetColor(255, 0, 0);
                }

                CollapseWrongAnswers();
                questionIndex++;
                UpdateNumCorrect();
                NextQuestionVisible();
            } 
        }

        void OnXboxXButtonRollOn(FlatRedBall.Gui.IWindow callingWindow)
        {
            if (canRollOver)
            {
                XButtoninst.RotationZ = 1;
            }
        }

        void OnXBoxXButtonRollOff(FlatRedBall.Gui.IWindow callingWindow)
        {
            if (canRollOver)
            {
                XButtoninst.RotationZ = 0;
                XButtoninst.RotationX = 0;
                XButtoninst.RotationY = 0;
            }
        }

        void onXBoxYButtonClick(FlatRedBall.Gui.IWindow callingWindow)
        {
            if (questionIndex < 3 && canClick)
            {
                if (IsRightAnswer(1))
                {
                    numCorrect++;
                    answerYText.SetColor(0, 255, 0);
                }
                else
                {
                    answerYText.SetColor(255, 0, 0);
                }
                CollapseWrongAnswers();
                questionIndex++;
                UpdateNumCorrect();
                NextQuestionVisible();
            }
        }

        void OnXboxYButtonRollOn(FlatRedBall.Gui.IWindow callingWindow)
        {
            if (canRollOver)
            {
                YButtonInst.RotationZ = 1;
            }
        }

        void OnXBoxYButtonRollOff(FlatRedBall.Gui.IWindow callingWindow)
        {
            if (canRollOver)
            {
                YButtonInst.RotationZ = 0;
                YButtonInst.RotationX = 0;
                YButtonInst.RotationY = 0;
            }
        }

        void OnXBoxBButtonClick(FlatRedBall.Gui.IWindow callingWindow)
        {
            if (questionIndex < 3 && canClick)
            {
                if (IsRightAnswer(2))
                {
                    numCorrect++;
                    answerBText.SetColor(0, 255, 0);
                }
                else
                {
                    answerBText.SetColor(255, 0, 0);
                }

                CollapseWrongAnswers();
                questionIndex++;
                UpdateNumCorrect();
                NextQuestionVisible();
            }
           
        }
        
        void OnXboxBButtonRollOn(FlatRedBall.Gui.IWindow callingWindow)
        {
            if (canRollOver)
            {
                BButtonInst.RotationZ = 1;
            }
        }

        void OnXBoxBButtonRollOff(FlatRedBall.Gui.IWindow callingWindow)
        {
            if (canRollOver)
            {
                BButtonInst.RotationZ = 0;
                BButtonInst.RotationX = 0;
                BButtonInst.RotationY = 0;
            }
        }

        void OnXBoxAButtonClick(FlatRedBall.Gui.IWindow callingWindow)
        {
            if (questionIndex < 3 && canClick)
            {
                if (IsRightAnswer(3))
                {
                    numCorrect++;
                    answerAText.SetColor(0, 255, 0);
                }
                else
                {
                    answerAText.SetColor(255, 0, 0);
                }

                CollapseWrongAnswers();
                questionIndex++;
                UpdateNumCorrect();
                NextQuestionVisible();
            }
        }

        void OnXboxAButtonRollOn(FlatRedBall.Gui.IWindow callingWindow)
        {
            if(canRollOver)
            {
                AButtonInst.RotationZ = 1;
            }
        }

        void OnXBoxAButtonRollOff(FlatRedBall.Gui.IWindow callingWindow)
        {
            if (canRollOver)
            {
                AButtonInst.RotationZ = 0;
                AButtonInst.RotationX = 0;
                AButtonInst.RotationY = 0;
            }
        }
        

        void OnNextQuestionClick(FlatRedBall.Gui.IWindow callingWindow)
        {

            ResetTextColors();
            if (questionIndex < 3)
            {
                DisplayQuestions();
                InflateAllAnswers();
            }
                NextQuestionNotVisible();

            if(questionIndex > 2)
            {
                this.MoveToScreen(typeof(GameScreen).FullName);
            }
        }

        void CollapseWrongAnswers() 
        {
            canClick = false;
            if(!IsRightAnswer(0))
            {
                canRollOver = false;
                XButtoninst.RotationX = 5;
                XButtoninst.RotationY = 5;
                answerXText.DisplayText = "X)";
            }
            if (!IsRightAnswer(1))
            {
                canRollOver = false;
                YButtonInst.RotationX = 5;
                YButtonInst.RotationY = 5;
                answerYText.DisplayText = "Y)";
            }
            if (!IsRightAnswer(2))
            {
                canRollOver = false;
                BButtonInst.RotationX = 5;
                BButtonInst.RotationY = 5;
                answerBText.DisplayText = "B)";
            }
            if (!IsRightAnswer(3))
            {
                canRollOver = false;
                AButtonInst.RotationX = 5;
                AButtonInst.RotationY = 5;
                answerAText.DisplayText = "A)";
            }
        }

        void ResetTextColors() 
        {
            answerAText.SetColor(255, 255, 255);
            answerBText.SetColor(255, 255, 255);
            answerXText.SetColor(255, 255, 255);
            answerYText.SetColor(255, 255, 255);
    
        }

        void InflateAllAnswers() 
        {
            canClick = true;
            canRollOver = true;
            XButtoninst.RotationX = 0;
            XButtoninst.RotationY = 0;
            XButtoninst.RotationZ = 0;
            YButtonInst.RotationX = 0;
            YButtonInst.RotationY = 0;
            YButtonInst.RotationZ = 0;
            BButtonInst.RotationX = 0;
            BButtonInst.RotationY = 0;
            BButtonInst.RotationZ = 0;
            AButtonInst.RotationX = 0;
            AButtonInst.RotationY = 0;
            AButtonInst.RotationZ = 0;

        }

        public bool IsRightAnswer(int index) 
        {
            if (threeQuestions[questionIndex].answerIndex == index)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
        void NextQuestionVisible() 
        {

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
                this.NextQuestion.Visible = false;
            }
            else
                EndQuiz();
        }

        void EndQuiz() 
        {
            this.XButtoninst.Visible = false;
            this.YButtonInst.Visible = false;
            this.BButtonInst.Visible = false;
            this.AButtonInst.Visible = false;
        }

        void UpdateNumCorrect() 
        {
            this.NumberCorrect.CurrentState = Button.VariableState.Hover;
            string score = string.Format("{0} out of {1}", numCorrect, questionIndex);
            NumberCorrect.DisplayText = (score);
        }
	}
}
