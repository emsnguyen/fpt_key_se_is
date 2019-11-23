namespace DemoUserControl
{
    partial class MainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnQuestionContainer = new System.Windows.Forms.Panel();
            this.pnButtonContrainer = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            this.examTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // pnQuestionContainer
            // 
            this.pnQuestionContainer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnQuestionContainer.Location = new System.Drawing.Point(12, 46);
            this.pnQuestionContainer.Name = "pnQuestionContainer";
            this.pnQuestionContainer.Size = new System.Drawing.Size(1130, 436);
            this.pnQuestionContainer.TabIndex = 0;
            // 
            // pnButtonContrainer
            // 
            this.pnButtonContrainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnButtonContrainer.Location = new System.Drawing.Point(12, 488);
            this.pnButtonContrainer.Name = "pnButtonContrainer";
            this.pnButtonContrainer.Size = new System.Drawing.Size(1130, 89);
            this.pnButtonContrainer.TabIndex = 1;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(1091, 9);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(51, 20);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "label1";
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(1028, 583);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(114, 35);
            this.btnFinish.TabIndex = 3;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            // 
            // examTimer
            // 
            this.examTimer.Enabled = true;
            this.examTimer.Interval = 1000;
            this.examTimer.Tick += new System.EventHandler(this.examTimer_Tick);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 630);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.pnButtonContrainer);
            this.Controls.Add(this.pnQuestionContainer);
            this.Name = "MainScreen";
            this.Text = "EOS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnQuestionContainer;
        private System.Windows.Forms.FlowLayoutPanel pnButtonContrainer;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Timer examTimer;
    }
}

