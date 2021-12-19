
namespace FileSystemVisitorWinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Start = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ShouldRiseEvents = new System.Windows.Forms.CheckBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Contains = new System.Windows.Forms.RadioButton();
            this.Starts = new System.Windows.Forms.RadioButton();
            this.Ends = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Filter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Start.Location = new System.Drawing.Point(522, 11);
            this.Start.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Start.MaximumSize = new System.Drawing.Size(500, 51);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(348, 51);
            this.Start.TabIndex = 1;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Stop
            // 
            this.Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Stop.Location = new System.Drawing.Point(876, 11);
            this.Stop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(350, 51);
            this.Stop.TabIndex = 2;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 68);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(637, 518);
            this.dataGridView1.TabIndex = 3;
            // 
            // ShouldRiseEvents
            // 
            this.ShouldRiseEvents.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ShouldRiseEvents.Location = new System.Drawing.Point(12, 9);
            this.ShouldRiseEvents.Name = "ShouldRiseEvents";
            this.ShouldRiseEvents.Size = new System.Drawing.Size(134, 48);
            this.ShouldRiseEvents.TabIndex = 5;
            this.ShouldRiseEvents.Text = "Rise events";
            this.ShouldRiseEvents.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(654, 68);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(572, 518);
            this.dataGridView2.TabIndex = 6;
            // 
            // Contains
            // 
            this.Contains.AutoSize = true;
            this.Contains.Checked = true;
            this.Contains.Location = new System.Drawing.Point(3, 2);
            this.Contains.Name = "Contains";
            this.Contains.Size = new System.Drawing.Size(72, 19);
            this.Contains.TabIndex = 7;
            this.Contains.TabStop = true;
            this.Contains.Text = "Contains";
            this.Contains.UseVisualStyleBackColor = true;
            // 
            // Starts
            // 
            this.Starts.AutoSize = true;
            this.Starts.Location = new System.Drawing.Point(81, 2);
            this.Starts.Name = "Starts";
            this.Starts.Size = new System.Drawing.Size(80, 19);
            this.Starts.TabIndex = 8;
            this.Starts.Text = "Starts with";
            this.Starts.UseVisualStyleBackColor = true;
            // 
            // Ends
            // 
            this.Ends.AutoSize = true;
            this.Ends.Location = new System.Drawing.Point(167, 2);
            this.Ends.Name = "Ends";
            this.Ends.Size = new System.Drawing.Size(76, 19);
            this.Ends.TabIndex = 9;
            this.Ends.Text = "Ends with";
            this.Ends.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Contains);
            this.panel1.Controls.Add(this.Ends);
            this.panel1.Controls.Add(this.Starts);
            this.panel1.Location = new System.Drawing.Point(149, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 22);
            this.panel1.TabIndex = 10;
            // 
            // Filter
            // 
            this.Filter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Filter.Location = new System.Drawing.Point(149, 36);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(367, 23);
            this.Filter.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 598);
            this.Controls.Add(this.Filter);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.ShouldRiseEvents);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Start);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox ShouldRiseEvents;
        private System.Windows.Forms.DataGridView dataGridView2;
        private new System.Windows.Forms.RadioButton Contains;
        private System.Windows.Forms.RadioButton Starts;
        private System.Windows.Forms.RadioButton Ends;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox Filter;
    }
}

