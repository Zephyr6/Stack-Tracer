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
        //Text questionText;
        Text questionText = TextManager.AddText("");
        void CustomInitialize()
        {
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

        }

        static void CustomLoadStaticContent(string contentManagerName)
        {


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
            foreach (Question q in threeQuestions)
            {
                //Console.WriteLine(q);
            }
            TextManager.RemoveText(questionText);
            questionText = TextManager.AddText(threeQuestions[questionIndex].ToString());
            questionText.Scale = 4.5f;
            questionText.X = -50;
            questionText.Y = 20;

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
