
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tutorial));
            this.finishButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tutorialMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tutorialMediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // finishButton
            // 
            this.finishButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.finishButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.finishButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finishButton.FlatAppearance.BorderSize = 0;
            this.finishButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.finishButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.finishButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.finishButton.Location = new System.Drawing.Point(1421, 922);
            this.finishButton.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(254, 90);
            this.finishButton.TabIndex = 0;
            this.finishButton.Text = "チュートリアル終了";
            this.finishButton.UseVisualStyleBackColor = true;
            this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel1.BackgroundImage")));
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.62532F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.37468F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.Controls.Add(this.finishButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tutorialMediaPlayer, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.35433F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.645669F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1677, 1016);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tutorialMediaPlayer
            // 
            this.tutorialMediaPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tutorialMediaPlayer.Enabled = true;
            this.tutorialMediaPlayer.Location = new System.Drawing.Point(7, 6);
            this.tutorialMediaPlayer.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tutorialMediaPlayer.Name = "tutorialMediaPlayer";
            this.tutorialMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("tutorialMediaPlayer.OcxState")));
            this.tutorialMediaPlayer.Size = new System.Drawing.Size(1405, 906);
            this.tutorialMediaPlayer.TabIndex = 1;
            // 
            // Tutorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1677, 1016);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "Tutorial";
            this.Text = "Tutorial";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tutorialMediaPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button finishButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private AxWMPLib.AxWindowsMediaPlayer tutorialMediaPlayer;
    }
}