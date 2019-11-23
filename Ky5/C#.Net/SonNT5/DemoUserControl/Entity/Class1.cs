using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Answer
    {
        public int ID { get; set;}
        public string Content { get; set; }
        public bool Correct { get; set; }
    }

    public class Question
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public int Time { get; set; } //seconds

        public List<Answer> answers { get; set; }

        public bool isMultipleChoice
        {
            get
            {
                int count = 0;
                foreach(Answer a in answers)
                {
                    if (a.Correct)
                        count++;
                }
                return count > 1;
            }
        }
    }

}
