namespace LibraryProject
{
    partial class EditForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mColTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mColAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mColPublisher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mColTraslator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mColCondition = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(85, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(75, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(85, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mColID,
            this.mColTitle,
            this.mColAuthor,
            this.mColPublisher,
            this.mColTraslator,
            this.mColCondition});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(731, 440);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // mColID
            // 
            this.mColID.DataPropertyName = "bookID";
            this.mColID.HeaderText = "شناسه";
            this.mColID.Name = "mColID";
            this.mColID.ReadOnly = true;
            this.mColID.Width = 50;
            // 
            // mColTitle
            // 
            this.mColTitle.DataPropertyName = "title";
            this.mColTitle.HeaderText = "عنوان";
            this.mColTitle.Name = "mColTitle";
            this.mColTitle.Width = 150;
            // 
            // mColAuthor
            // 
            this.mColAuthor.DataPropertyName = "author";
            this.mColAuthor.HeaderText = "نویسنده";
            this.mColAuthor.Name = "mColAuthor";
            this.mColAuthor.Width = 150;
            // 
            // mColPublisher
            // 
            this.mColPublisher.DataPropertyName = "publisher";
            this.mColPublisher.HeaderText = " انتشارات";
            this.mColPublisher.Name = "mColPublisher";
            this.mColPublisher.Width = 150;
            // 
            // mColTraslator
            // 
            this.mColTraslator.DataPropertyName = "translator";
            this.mColTraslator.HeaderText = "مترجم";
            this.mColTraslator.Name = "mColTraslator";
            this.mColTraslator.Width = 150;
            // 
            // mColCondition
            // 
            this.mColCondition.DataPropertyName = "available";
            this.mColCondition.HeaderText = "موجود در قفسه";
            this.mColCondition.Name = "mColCondition";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(85, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 459);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(177, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(737, 459);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 459);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "EditForm";
            this.Text = "Edit Books";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn mColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn mColTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn mColAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn mColPublisher;
        private System.Windows.Forms.DataGridViewTextBoxColumn mColTraslator;
        private System.Windows.Forms.DataGridViewCheckBoxColumn mColCondition;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}