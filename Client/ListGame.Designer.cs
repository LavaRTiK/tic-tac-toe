namespace Client
{
    partial class ListGame
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.играToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.створитиЛоббіToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вихідToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.NamePlayer1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NamePlayer2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusGame = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.играToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(674, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // играToolStripMenuItem
            // 
            this.играToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.створитиЛоббіToolStripMenuItem,
            this.вихідToolStripMenuItem});
            this.играToolStripMenuItem.Name = "играToolStripMenuItem";
            this.играToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.играToolStripMenuItem.Text = "Игра";
            // 
            // створитиЛоббіToolStripMenuItem
            // 
            this.створитиЛоббіToolStripMenuItem.Name = "створитиЛоббіToolStripMenuItem";
            this.створитиЛоббіToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.створитиЛоббіToolStripMenuItem.Text = "Створити лоббі";
            this.створитиЛоббіToolStripMenuItem.Click += new System.EventHandler(this.створитиЛоббіToolStripMenuItem_Click);
            // 
            // вихідToolStripMenuItem
            // 
            this.вихідToolStripMenuItem.Name = "вихідToolStripMenuItem";
            this.вихідToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.вихідToolStripMenuItem.Text = "Вихід";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(587, 326);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(55, 7);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Name:";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NamePlayer1,
            this.NamePlayer2,
            this.StatusGame});
            this.listView1.HideSelection = false;
            this.listView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listView1.Location = new System.Drawing.Point(12, 27);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(650, 293);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // NamePlayer1
            // 
            this.NamePlayer1.Text = "NamePlayer1";
            this.NamePlayer1.Width = 153;
            // 
            // NamePlayer2
            // 
            this.NamePlayer2.Text = "NamePlayer2";
            this.NamePlayer2.Width = 241;
            // 
            // StatusGame
            // 
            this.StatusGame.Text = "StatusGame";
            this.StatusGame.Width = 123;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(587, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "UpdateList";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ListGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 361);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ListGame";
            this.Text = "ListGame";
            this.Load += new System.EventHandler(this.ListGame_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem играToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem створитиЛоббіToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader NamePlayer1;
        private System.Windows.Forms.ColumnHeader NamePlayer2;
        private System.Windows.Forms.ColumnHeader StatusGame;
        private System.Windows.Forms.Button button2;
    }
}