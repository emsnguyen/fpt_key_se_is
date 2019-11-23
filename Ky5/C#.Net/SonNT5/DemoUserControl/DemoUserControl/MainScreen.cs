using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DemoUserControl
{

    public partial class MainScreen : Form
    {
        List<Question> questions = new List<Question>();
        List<QuestionControl> questionControls = new List<QuestionControl>();
        List<Button> questionButtons = new List<Button>();

        public MainScreen()
        {
            InitializeComponent();
            questions = QuestionDAO.generateQuestions(); // generate questions
            for (int i = 0; i < questions.Count; i++)
            {
                questionControls.Add(new QuestionControl(questions[i], this));
                Button b = new Button();
                b.BackColor = Color.White;
                b.Text = "" + (i + 1);
                b.Click += B_Click;
                pnButtonContrainer.Controls.Add(b);
                questionButtons.Add(b);
                TotalTime += questions[i].Time;
            }
            displayQuestion(questions[0]);
            lblTime.Text = formatTime(TotalTime);
        }

        private void B_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < questionButtons.Count; i++)
            {
                Button b = questionButtons[i];

                if (b == sender)
                {
                    displayQuestion(questions[i]);
                    return;
                }
            }
        }

        public void markedButtonAsConsidered(Question q, bool isConsidered)
        {
            for (int i = 0; i < questions.Count; i++)
            {
                if (q == questions[i])
                {
                    if (isConsidered)
                    {
                        questionButtons[i].BackColor = Color.Green;
                    }
                    else
                    {
                        questionButtons[i].BackColor = Color.White;
                    }
                }
            }
        }

        private void displayQuestion(Question q)
        {
            for (int i = 0; i < questions.Count; i++)
            {
                if (q == questions[i])
                {
                    pnQuestionContainer.Controls.Clear();
                    pnQuestionContainer.Controls.Add(questionControls[i]);
                    return;
                }
            }
        }
        int TotalTime = 0;

        private string formatTime(int time)
        {
            int hour = time / 3600;
            int minute = (time % 3600) / 60;
            int second = (time % 3600) % 60;

            return hour + ":" + minute + ":" + second;
        }

        private void examTimer_Tick(object sender, EventArgs e)
        {

            TotalTime--;
            if (TotalTime <= 0)
            {
                examTimer.Enabled = false;
                examTimer.Dispose();
                FinishExam();
            }
            lblTime.Text = formatTime(TotalTime);
        }

        private void FinishExam()
        {
            //
            MessageBox.Show("Finish");
        }
    }
}
