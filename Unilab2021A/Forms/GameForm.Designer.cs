
namespace Unilab2021A.Forms
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ActionBlockTypeSection = new System.Windows.Forms.FlowLayoutPanel();
            this.FirstFunctionSection = new System.Windows.Forms.FlowLayoutPanel();
            this.SecondFunctionSection = new System.Windows.Forms.FlowLayoutPanel();
            this.SwordSection = new System.Windows.Forms.FlowLayoutPanel();
            this.resetButton = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resetButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.37288F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.62712F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ActionBlockTypeSection, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.FirstFunctionSection, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.SecondFunctionSection, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.SwordSection, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.resetButton, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox3, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox4, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.800766F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.65517F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.800766F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.36782F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.662835F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.279694F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.17624F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.17624F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.60153F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(770, 522);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.tableLayoutPanel1.SetRowSpan(this.pictureBox1, 9);
            this.pictureBox1.Size = new System.Drawing.Size(630, 518);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // ActionBlockTypeSection
            // 
            this.ActionBlockTypeSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActionBlockTypeSection.Location = new System.Drawing.Point(636, 148);
            this.ActionBlockTypeSection.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ActionBlockTypeSection.Name = "ActionBlockTypeSection";
            this.ActionBlockTypeSection.Size = new System.Drawing.Size(132, 71);
            this.ActionBlockTypeSection.TabIndex = 13;
            // 
            // FirstFunctionSection
            // 
            this.FirstFunctionSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FirstFunctionSection.Location = new System.Drawing.Point(636, 223);
            this.FirstFunctionSection.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FirstFunctionSection.Name = "FirstFunctionSection";
            this.FirstFunctionSection.Size = new System.Drawing.Size(132, 36);
            this.FirstFunctionSection.TabIndex = 14;
            // 
            // SecondFunctionSection
            // 
            this.SecondFunctionSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SecondFunctionSection.Location = new System.Drawing.Point(637, 264);
            this.SecondFunctionSection.Name = "SecondFunctionSection";
            this.SecondFunctionSection.Size = new System.Drawing.Size(130, 32);
            this.SecondFunctionSection.TabIndex = 15;
            // 
            // SwordSection
            // 
            this.SwordSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SwordSection.Location = new System.Drawing.Point(637, 38);
            this.SwordSection.Name = "SwordSection";
            this.SwordSection.Size = new System.Drawing.Size(130, 70);
            this.SwordSection.TabIndex = 16;
            // 
            // resetButton
            // 
            this.resetButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resetButton.BackgroundImage")));
            this.resetButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.resetButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resetButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resetButton.Location = new System.Drawing.Point(637, 376);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(130, 68);
            this.resetButton.TabIndex = 17;
            this.resetButton.TabStop = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Location = new System.Drawing.Point(637, 450);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(130, 69);
            this.pictureBox3.TabIndex = 18;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.startButton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(635, 2);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(134, 31);
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox4.Location = new System.Drawing.Point(635, 113);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(134, 31);
            this.pictureBox4.TabIndex = 20;
            this.pictureBox4.TabStop = false;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(770, 522);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "GameForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resetButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel ActionBlockTypeSection;
        private System.Windows.Forms.FlowLayoutPanel FirstFunctionSection;
        private System.Windows.Forms.FlowLayoutPanel SecondFunctionSection;
        private System.Windows.Forms.FlowLayoutPanel SwordSection;
        private System.Windows.Forms.PictureBox resetButton;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}