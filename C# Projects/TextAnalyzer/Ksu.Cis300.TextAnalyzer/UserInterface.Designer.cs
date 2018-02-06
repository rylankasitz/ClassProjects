namespace Ksu.Cis300.TextAnalyzer
{
    partial class UserInterface
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
            this.uxSelectText1 = new System.Windows.Forms.Button();
            this.uxSelectText2 = new System.Windows.Forms.Button();
            this.uxText1 = new System.Windows.Forms.TextBox();
            this.uxText2 = new System.Windows.Forms.TextBox();
            this.uxNumberLabel = new System.Windows.Forms.Label();
            this.uxNumber = new System.Windows.Forms.NumericUpDown();
            this.uxAnalyze = new System.Windows.Forms.Button();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // uxSelectText1
            // 
            this.uxSelectText1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxSelectText1.Location = new System.Drawing.Point(12, 12);
            this.uxSelectText1.Name = "uxSelectText1";
            this.uxSelectText1.Size = new System.Drawing.Size(108, 41);
            this.uxSelectText1.TabIndex = 0;
            this.uxSelectText1.Text = "Text 1:";
            this.uxSelectText1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.uxSelectText1.UseVisualStyleBackColor = true;
            this.uxSelectText1.Click += new System.EventHandler(this.uxSelectText1_Click);
            // 
            // uxSelectText2
            // 
            this.uxSelectText2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxSelectText2.Location = new System.Drawing.Point(12, 59);
            this.uxSelectText2.Name = "uxSelectText2";
            this.uxSelectText2.Size = new System.Drawing.Size(108, 41);
            this.uxSelectText2.TabIndex = 1;
            this.uxSelectText2.Text = "Text 2:";
            this.uxSelectText2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.uxSelectText2.UseVisualStyleBackColor = true;
            this.uxSelectText2.Click += new System.EventHandler(this.uxSelectText2_Click);
            // 
            // uxText1
            // 
            this.uxText1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxText1.Location = new System.Drawing.Point(126, 17);
            this.uxText1.Name = "uxText1";
            this.uxText1.ReadOnly = true;
            this.uxText1.Size = new System.Drawing.Size(351, 29);
            this.uxText1.TabIndex = 2;
            // 
            // uxText2
            // 
            this.uxText2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxText2.Location = new System.Drawing.Point(126, 64);
            this.uxText2.Name = "uxText2";
            this.uxText2.ReadOnly = true;
            this.uxText2.Size = new System.Drawing.Size(351, 29);
            this.uxText2.TabIndex = 3;
            // 
            // uxNumberLabel
            // 
            this.uxNumberLabel.AutoSize = true;
            this.uxNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxNumberLabel.Location = new System.Drawing.Point(12, 126);
            this.uxNumberLabel.Name = "uxNumberLabel";
            this.uxNumberLabel.Size = new System.Drawing.Size(225, 24);
            this.uxNumberLabel.TabIndex = 4;
            this.uxNumberLabel.Text = "Number of Words To Use";
            // 
            // uxNumber
            // 
            this.uxNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxNumber.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.uxNumber.Location = new System.Drawing.Point(243, 118);
            this.uxNumber.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.uxNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxNumber.Name = "uxNumber";
            this.uxNumber.Size = new System.Drawing.Size(52, 29);
            this.uxNumber.TabIndex = 5;
            this.uxNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxNumber.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // uxAnalyze
            // 
            this.uxAnalyze.Enabled = false;
            this.uxAnalyze.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxAnalyze.Location = new System.Drawing.Point(301, 106);
            this.uxAnalyze.Name = "uxAnalyze";
            this.uxAnalyze.Size = new System.Drawing.Size(176, 41);
            this.uxAnalyze.TabIndex = 6;
            this.uxAnalyze.Text = "Analyze Texts";
            this.uxAnalyze.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.uxAnalyze.UseVisualStyleBackColor = true;
            this.uxAnalyze.Click += new System.EventHandler(this.uxAnalyze_Click);
            // 
            // uxOpenDialog
            // 
            this.uxOpenDialog.FileName = "openFileDialog1";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 159);
            this.Controls.Add(this.uxAnalyze);
            this.Controls.Add(this.uxNumber);
            this.Controls.Add(this.uxNumberLabel);
            this.Controls.Add(this.uxText2);
            this.Controls.Add(this.uxText1);
            this.Controls.Add(this.uxSelectText2);
            this.Controls.Add(this.uxSelectText1);
            this.Name = "UserInterface";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.uxNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxSelectText1;
        private System.Windows.Forms.Button uxSelectText2;
        private System.Windows.Forms.TextBox uxText1;
        private System.Windows.Forms.TextBox uxText2;
        private System.Windows.Forms.Label uxNumberLabel;
        private System.Windows.Forms.NumericUpDown uxNumber;
        private System.Windows.Forms.Button uxAnalyze;
        private System.Windows.Forms.OpenFileDialog uxOpenDialog;
    }
}

