using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class QuestionDAO
    {
        public static List<Question> generateQuestions()
        {
            List<Question> questions = new List<Question>();
            Question q1 = new Question() { ID = 1, Content = "Who are the most handsome guys in the class?" };
            q1.Time = 4;
            q1.answers = new List<Answer>();
            q1.answers.Add(new Answer() { ID = 1, Content = "Win", Correct = false });
            q1.answers.Add(new Answer() { ID = 2, Content = "Thai", Correct = false });
            q1.answers.Add(new Answer() { ID = 3, Content = "Loc", Correct = true });
            q1.answers.Add(new Answer() { ID = 4, Content = "Cong", Correct = true });

            Question q2 = new Question() { ID = 2, Content = "Who is the richest guy in the class?" };
            q2.answers = new List<Answer>();
            q2.answers.Add(new Answer() { ID = 5, Content = "Win", Correct = true });
            q2.answers.Add(new Answer() { ID = 6, Content = "Thai", Correct = false });
            q2.answers.Add(new Answer() { ID = 7, Content = "Loc", Correct = false });
            q2.answers.Add(new Answer() { ID = 8, Content = "Cong", Correct = false });
            q2.answers.Add(new Answer() { ID = 9, Content = "Ha", Correct = false });
            q2.answers.Add(new Answer() { ID = 10, Content = "Thuong", Correct = false });
            q2.Time = 4;

            Question q3 = new Question() { ID = 3, Content = "Do you love mr Son?" };
            q3.answers = new List<Answer>();
            q3.answers.Add(new Answer() { ID = 11, Content = "Yes", Correct = true });
            q3.answers.Add(new Answer() { ID = 12, Content = "No", Correct = false });
            q3.Time = 2;

            questions.Add(q1);
            questions.Add(q2);
            questions.Add(q3);


            return questions;
        }
    }
}
