﻿namespace RushTicketSoftware
{
    partial class UserTickedPanel
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
            this.btTicketSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbPassengers = new System.Windows.Forms.CheckedListBox();
            this.cbStartCity = new System.Windows.Forms.ComboBox();
            this.cbArriveCity = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbStartDate = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btTicketVali = new System.Windows.Forms.Button();
            this.btQuit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btTicketSearch
            // 
            this.btTicketSearch.Location = new System.Drawing.Point(801, 26);
            this.btTicketSearch.Name = "btTicketSearch";
            this.btTicketSearch.Size = new System.Drawing.Size(75, 28);
            this.btTicketSearch.TabIndex = 0;
            this.btTicketSearch.Text = "查询";
            this.btTicketSearch.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "出发地：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "目的地：";
            // 
            // lbPassengers
            // 
            this.lbPassengers.FormattingEnabled = true;
            this.lbPassengers.Location = new System.Drawing.Point(45, 428);
            this.lbPassengers.Name = "lbPassengers";
            this.lbPassengers.Size = new System.Drawing.Size(170, 184);
            this.lbPassengers.TabIndex = 3;
            // 
            // cbStartCity
            // 
            this.cbStartCity.FormattingEnabled = true;
            this.cbStartCity.Location = new System.Drawing.Point(116, 26);
            this.cbStartCity.Name = "cbStartCity";
            this.cbStartCity.Size = new System.Drawing.Size(136, 23);
            this.cbStartCity.TabIndex = 4;
            // 
            // cbArriveCity
            // 
            this.cbArriveCity.FormattingEnabled = true;
            this.cbArriveCity.Location = new System.Drawing.Point(350, 26);
            this.cbArriveCity.Name = "cbArriveCity";
            this.cbArriveCity.Size = new System.Drawing.Size(140, 23);
            this.cbArriveCity.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(513, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "出发日期：";
            // 
            // tbStartDate
            // 
            this.tbStartDate.Location = new System.Drawing.Point(597, 26);
            this.tbStartDate.Name = "tbStartDate";
            this.tbStartDate.Size = new System.Drawing.Size(148, 25);
            this.tbStartDate.TabIndex = 7;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(45, 84);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(840, 305);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(279, 428);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(361, 184);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // btTicketVali
            // 
            this.btTicketVali.Location = new System.Drawing.Point(690, 582);
            this.btTicketVali.Name = "btTicketVali";
            this.btTicketVali.Size = new System.Drawing.Size(75, 30);
            this.btTicketVali.TabIndex = 10;
            this.btTicketVali.Text = "验证";
            this.btTicketVali.UseVisualStyleBackColor = true;
            // 
            // btQuit
            // 
            this.btQuit.Location = new System.Drawing.Point(801, 582);
            this.btQuit.Name = "btQuit";
            this.btQuit.Size = new System.Drawing.Size(75, 30);
            this.btQuit.TabIndex = 11;
            this.btQuit.Text = "退出";
            this.btQuit.UseVisualStyleBackColor = true;
            this.btQuit.Click += new System.EventHandler(this.btQuit_Click);
            // 
            // UserTickedPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 646);
            this.Controls.Add(this.btQuit);
            this.Controls.Add(this.btTicketVali);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.tbStartDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbArriveCity);
            this.Controls.Add(this.cbStartCity);
            this.Controls.Add(this.lbPassengers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btTicketSearch);
            this.Name = "UserTickedPanel";
            this.Text = "UserTickedPanel";
            this.Load += new System.EventHandler(this.UserTickedPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btTicketSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox lbPassengers;
        private System.Windows.Forms.ComboBox cbStartCity;
        private System.Windows.Forms.ComboBox cbArriveCity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbStartDate;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btTicketVali;
        private System.Windows.Forms.Button btQuit;
    }
}