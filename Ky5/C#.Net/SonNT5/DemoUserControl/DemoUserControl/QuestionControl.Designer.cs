namespace DemoUserControl
{
    partial class QuestionControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtContent = new System.Windows.Forms.TextBox();
            this.pnAnswerContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(13, 14);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ReadOnly = true;
            this.txtContent.Size = new System.Drawing.Size(1102, 93);
            this.txtContent.TabIndex = 0;
            // 
            // pnAnswerContainer
            // 
            this.pnAnswerContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnAnswerContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnAnswerContainer.Location = new System.Drawing.Point(13, 113);
            this.pnAnswerContainer.Name = "pnAnswerContainer";
            this.pnAnswerContainer.Size = new System.Drawing.Size(1102, 305);
            this.pnAnswerContainer.TabIndex = 1;
            // 
            // QuestionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnAnswerContainer);
            this.Controls.Add(this.txtContent);
            this.Name = "QuestionControl";
            this.Size = new System.Drawing.Size(1130, 436);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.FlowLayoutPanel pnAnswerContainer;
    }
}
