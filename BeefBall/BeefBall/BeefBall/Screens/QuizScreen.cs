using System;
using System.Collections.Generic;
using BeefBall.Entities;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;

using FlatRedBall.Graphics.Model;
using FlatRedBall.Math.Geometry;
using FlatRedBall.Math.Splines;

using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;
using FlatRedBall.Localization;

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
using System.IO;
using FlatRedBall.Graphics;
#endif

namespace BeefBall.Screens
{
    public partial class QuizScreen
    {
        private int tries = 3;
        private int correctAnswers = 0;
        private List<Question> questions = new List<Question>();
        private Question[] threeQuestions = new Question[3];
        Text questionText = TextManager.AddText("");
        Text answerXText = TextManager.AddText("");
        Text answerYText = TextManager.AddText("");
        Text answerBText = TextManager.AddText("");
        Text answerAText = TextManager.AddText("");

        //TextArial ta = new TextArial();
        void CustomInitialize()
        {
            InitializeCustomEvents();
            FlatRedBallServices.IsWindowsCursorVisible = true;
            NextQuestion.Visible = false;
            ReadInCSV();
            Select3RandomQuestions();
            DisplayQuestions();
        }

        void CustomActivity(bool firstTimeCalled)
        {


        }

        void CustomDestroy()
        {
            TextManager.RemoveText(questionText);
            TextManager.RemoveText(answerAText);
            TextManager.RemoveText(answerBText);
            TextManager.RemoveText(answerXText);
            TextManager.RemoveText(answerYText);  

        }

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        public void InitializeCustomEvents() 
        {
            XButtoninst.Click += onXBoxXButtonClick;
            XButtoninst.RollOn += OnXboxXButtonRollOn;
            XButtoninst.RollOff += OnXBoxXButtonRollOff;
            
            YButtonInst.Click += onXBoxYButtonClick;
            YButtonInst.RollOn += OnXboxYButtonRollOn;
            YButtonInst.RollOff += OnXBoxYButtonRollOff;
            
            AButtonInst.RollOn += OnXboxAButtonRollOn;
            AButtonInst.Click += OnXBoxAButtonClick;
            AButtonInst.RollOff += OnXBoxAButtonRollOff;
            
            BButtonInst.Click += OnXBoxBButtonClick;
            BButtonInst.RollOn += OnXboxBButtonRollOn;
            BButtonInst.RollOff += OnXBoxBButtonRollOff;
        }

        public void ReadInCSV()
        {
            using (StreamReader input = new StreamReader("qa.csv"))
            {
                string line;
                string[] lineList;
                while ((line = input.ReadLine()) != null)
                {
                    lineList = line.Split(',');
                    Question q = new Question();
                    q.QuestionText = lineList[0];
                    q.CorrectAnswer = lineList[1];
                    q.WrongAnswer1 = lineList[2];
                    q.WrongAnswer2 = lineList[3];
                    q.WrongAnswer3 = lineList[4];
                    q.SetAnswers();
                    questions.Add(q);
                }


            }
        }

        public void Select3RandomQuestions()
        {
            int indexQuestion1;
            int indexQuestion2;
            int indexQuestion3;
            int listSize = 0;

            Random rnd = new Random();

            foreach (Question q in questions)
            {
                listSize++;
            }

            indexQuestion1 = rnd.Next(listSize);

            do
            {
                indexQuestion2 = rnd.Next(listSize);
            } while (indexQuestion2 == indexQuestion1);

            do
            {
                indexQuestion3 = rnd.Next(listSize);
            } while (indexQuestion3 == indexQuestion1 || indexQuestion3 == indexQuestion2);

            threeQuestions[0] = questions[indexQuestion1];
            threeQuestions[1] = questions[indexQuestion2];
            threeQuestions[2] = questions[indexQuestion3];
        }


        public void DisplayQuestions()
        {
            questionText.DisplayText = threeQuestions[questionIndex].QuestionText;
            questionText.Scale = 8f;
            questionText.Spacing = 8;
            questionText.X = -150;
            questionText.Y = 100;

            answerXText.DisplayText = string.Format("X)   {0}", threeQuestions[questionIndex].answerList[0]);
            answerXText.Scale = 6f;
            answerXText.Spacing = 6;
            answerXText.X = -130;
            answerXText.Y = 60;

            answerYText.DisplayText = string.Format("Y)   {0}",threeQuestions[questionIndex].answerList[1]);
            answerYText.Scale = 6f;
            answerYText.Spacing = 6;
            answerYText.X = -130;
            answerYText.Y = 20;

            answerBText.DisplayText = string.Format("B)   {0}",threeQuestions[questionIndex].answerList[2]);
            answerBText.Scale = 6f;
            answerBText.Spacing = 6;
            answerBText.X = -130;
            answerBText.Y = -20;

            answerAText.DisplayText = string.Format("A)   {0}",threeQuestions[questionIndex].answerList[3]);
            answerAText.Scale = 6f;
            answerAText.Spacing = 6;
            answerAText.X = -130;
            answerAText.Y = -60;


        }

        public void DisplayCorrectAnswer()
        {
            
        }

        public Boolean IsRightAnswer()
        {
            return false;
        }

    }
}
