
namespace Unilab2021A.Forms
{
    partial class Tutorial
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
            this.finishButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // finishButton
            // 
            this.finishButton.Location = new System.Drawing.Point(1203, 877);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(375, 77);
            this.finishButton.TabIndex = 0;
            this.finishButton.Text = "チュートリアル終了";
            this.finishButton.UseVisualStyleBackColor = true;
            this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
            // 
            // Tutorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1677, 1016);
            this.Controls.Add(this.finishButton);
            this.Name = "Tutorial";
            this.Text = "Tutorial";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button finishButton;
    }
}