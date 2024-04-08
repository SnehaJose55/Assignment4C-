namespace Assignment4
{
    partial class Form2
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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(506, 22);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(798, 253);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 62);
            label1.Name = "label1";
            label1.Size = new Size(98, 25);
            label1.TabIndex = 1;
            label1.Text = "Account Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 112);
            label2.Name = "label2";
            label2.Size = new Size(142, 25);
            label2.TabIndex = 2;
            label2.Text = "Transaction Date";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 159);
            label3.Name = "label3";
            label3.Size = new Size(77, 25);
            label3.TabIndex = 3;
            label3.Text = "Amount";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 207);
            label4.Name = "label4";
            label4.Size = new Size(102, 25);
            label4.TabIndex = 4;
            label4.Text = "Description";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(199, 59);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(204, 31);
            textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(199, 106);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(204, 31);
            textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(199, 156);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(204, 31);
            textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(199, 204);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(204, 31);
            textBox4.TabIndex = 8;
            // 
            // button1
            // 
            button1.Location = new Point(42, 332);
            button1.Name = "button1";
            button1.Size = new Size(130, 58);
            button1.TabIndex = 9;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(266, 332);
            button2.Name = "button2";
            button2.Size = new Size(118, 58);
            button2.TabIndex = 10;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(442, 331);
            button3.Name = "button3";
            button3.Size = new Size(118, 61);
            button3.TabIndex = 11;
            button3.Text = "Update";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button5
            // 
            button5.Location = new Point(1234, 404);
            button5.Name = "button5";
            button5.Size = new Size(90, 34);
            button5.TabIndex = 13;
            button5.Text = "&Exit";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1336, 450);
            Controls.Add(button5);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "Form2";
            Text = "Transaction Details";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button5;
    }
}