
namespace Unilab2021A.Forms
{
    partial class SelectStage
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
            this.stage1Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // stage1Button
            // 
            this.stage1Button.Location = new System.Drawing.Point(302, 105);
            this.stage1Button.Name = "stage1Button";
            this.stage1Button.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.stage1Button.Size = new System.Drawing.Size(946, 63);
            this.stage1Button.TabIndex = 0;
            this.stage1Button.Text = "stage1";
            this.stage1Button.UseVisualStyleBackColor = true;
            this.stage1Button.Click += new System.EventHandler(this.stage1Button_Click);
            // 
            // SelectStage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1546, 979);
            this.Controls.Add(this.stage1Button);
            this.Name = "SelectStage";
            this.Text = "SelectStage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button stage1Button;
    }
}