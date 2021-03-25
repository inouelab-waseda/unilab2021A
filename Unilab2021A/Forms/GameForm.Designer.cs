
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.resetButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.actionPictureBox = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.itemPictureBox = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.max_count = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actionPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.37288F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.62712F));
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.max_count, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.itemPictureBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.actionPictureBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.resetButton, 1, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.569293F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.19169F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.81937F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.59794F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.28823F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.89255F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.843039F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.797881F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1180, 668);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.resetButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resetButton.Location = new System.Drawing.Point(974, 569);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(203, 39);
            this.resetButton.TabIndex = 10;
            this.resetButton.Text = "やりなおす";
            this.resetButton.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(973, 613);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 53);
            this.button1.TabIndex = 1;
            this.button1.Text = "たおしにいく";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // actionPictureBox
            // 
            this.actionPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionPictureBox.Location = new System.Drawing.Point(974, 199);
            this.actionPictureBox.Name = "actionPictureBox";
            this.actionPictureBox.Size = new System.Drawing.Size(203, 144);
            this.actionPictureBox.TabIndex = 7;
            this.actionPictureBox.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(974, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(203, 22);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "もってる剣";
            // 
            // itemPictureBox
            // 
            this.itemPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPictureBox.Location = new System.Drawing.Point(974, 26);
            this.itemPictureBox.Name = "itemPictureBox";
            this.itemPictureBox.Size = new System.Drawing.Size(203, 142);
            this.itemPictureBox.TabIndex = 8;
            this.itemPictureBox.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(974, 174);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(203, 22);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "使えるブロック";
            // 
            // max_count
            // 
            this.max_count.Dock = System.Windows.Forms.DockStyle.Fill;
            this.max_count.Location = new System.Drawing.Point(974, 437);
            this.max_count.Name = "max_count";
            this.max_count.Size = new System.Drawing.Size(203, 22);
            this.max_count.TabIndex = 0;
            this.max_count.Text = "3";
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "上",
            "下",
            "左",
            "右"});
            this.comboBox1.Location = new System.Drawing.Point(974, 349);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(203, 23);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.Text = "上";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.tableLayoutPanel1.SetRowSpan(this.pictureBox1, 8);
            this.pictureBox1.Size = new System.Drawing.Size(967, 664);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1180, 668);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GameForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actionPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox max_count;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox itemPictureBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox actionPictureBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}