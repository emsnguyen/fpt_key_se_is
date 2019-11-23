using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entity;

namespace DemoUserControl
{
    public partial class QuestionControl : UserControl
    {
        Question question;
        List<Control> buttonAnswers = new List<Control>();
        MainScreen parent;
        public QuestionControl(Question question,MainScreen parent)
        {
            InitializeComponent();
            this.question = question;
            txtContent.Text = question.Content;
            this.parent = parent;
            foreach (Answer a in question.answers)
            {
                Control c = null; 
                if(question.isMultipleChoice)
                {
                    c = new CheckBox();
                }
                else
                {
                    c = new RadioButton();
                }
                c.Text = a.Content;
                c.Click += C_Click;
                pnAnswerContainer.Controls.Add(c);
                buttonAnswers.Add(c);
            }

            
        }

        private void C_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach(Control c in buttonAnswers)
            {
                if(c is CheckBox)
                {
                    CheckBox cbx = (CheckBox)c;
                    count += (cbx.Checked ? 1 : 0);
                    break;
                }
                else if (c is RadioButton)
                {
                    RadioButton cbx = (RadioButton)c;
                    count += (cbx.Checked ? 1 : 0);
                    break;
                }
            }
            if (count > 0)
                parent.markedButtonAsConsidered(question, true);
            else
                parent.markedButtonAsConsidered(question, false);
        }
    }
}
