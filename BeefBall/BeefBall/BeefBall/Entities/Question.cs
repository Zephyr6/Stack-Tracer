using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeefBall.Entities
{
    class Question
    {
        public string QuestionText { get; set; }
        public string CorrectAnswer { get; set; }
        public string WrongAnswer1 { get; set; }
        public string WrongAnswer2 { get; set; }
        public string WrongAnswer3 { get; set; }
        public int answerIndex { get; private set; }
        public List<string> answerList = new List<string>();
        
        public Question() 
        {
            
            //string[] initAnswers = { CorrectAnswer, WrongAnswer1, WrongAnswer2, WrongAnswer3};
            //answerList = initAnswers;
            //SetAnswers();
        }

        public void SetAnswers()
        {
            answerList.Add(CorrectAnswer);
            answerList.Add(WrongAnswer1);
            answerList.Add(WrongAnswer2);
            answerList.Add(WrongAnswer3);
            Random rdm = new Random();
            int count = answerList.Count();

            while (count > 1) 
            {
                count--;
                int index = rdm.Next(count + 1);
                string value = answerList[index];
                answerList[index] = answerList[count];
                answerList[count] = value;
                GetCorrectAnswerIndex();
            } 
        }

        public void GetCorrectAnswerIndex()
        {
            for (int i = 0; i < answerList.Count(); i++)
            {
                //Console.WriteLine("Index: {0}", answerList[i]);
                //Console.WriteLine(CorrectAnswer);
                if (answerList[i].ToString() == CorrectAnswer)
                {
                    answerIndex = i;
                }
            }
            
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            string line;

            line = String.Format("{0}", QuestionText);
            stringBuilder.Append(line);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(Environment.NewLine);


            line = String.Format("A: {0}", answerList[0]); 
            stringBuilder.Append(line);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(Environment.NewLine);

            line = String.Format("B: {0}", answerList[1]);
            stringBuilder.Append(line);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(Environment.NewLine);

            line = String.Format("C: {0}", answerList[2]);
            stringBuilder.Append(line);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(Environment.NewLine);
            
            line = String.Format("D: {0}", answerList[3]);
            stringBuilder.Append(line);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(Environment.NewLine);

            line = String.Format("ANSWER INDEX IS: {0}", answerIndex.ToString());
            stringBuilder.Append(line);
            stringBuilder.Append(Environment.NewLine);
          
            return stringBuilder.ToString();
        }

    }
}
