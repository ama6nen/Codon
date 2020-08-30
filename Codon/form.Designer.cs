namespace Codon
{
    partial class form
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
            this.OutputText = new System.Windows.Forms.TextBox();
            this.Translate = new System.Windows.Forms.Button();
            this.InputText = new System.Windows.Forms.TextBox();
            this.LetterCode = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ReverseTranslate = new System.Windows.Forms.Button();
            this.UseUracil = new System.Windows.Forms.CheckBox();
            this.ReadingFrame = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ReadingFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // OutputText
            // 
            this.OutputText.Location = new System.Drawing.Point(344, 29);
            this.OutputText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OutputText.Multiline = true;
            this.OutputText.Name = "OutputText";
            this.OutputText.Size = new System.Drawing.Size(258, 129);
            this.OutputText.TabIndex = 0;
            // 
            // Translate
            // 
            this.Translate.Location = new System.Drawing.Point(277, 31);
            this.Translate.Name = "Translate";
            this.Translate.Size = new System.Drawing.Size(61, 25);
            this.Translate.TabIndex = 1;
            this.Translate.Text = " ->";
            this.Translate.UseVisualStyleBackColor = true;
            this.Translate.Click += new System.EventHandler(this.Translate_Click);
            // 
            // InputText
            // 
            this.InputText.Location = new System.Drawing.Point(12, 29);
            this.InputText.Multiline = true;
            this.InputText.Name = "InputText";
            this.InputText.Size = new System.Drawing.Size(258, 129);
            this.InputText.TabIndex = 2;
            // 
            // LetterCode
            // 
            this.LetterCode.AutoSize = true;
            this.LetterCode.Location = new System.Drawing.Point(13, 165);
            this.LetterCode.Name = "LetterCode";
            this.LetterCode.Size = new System.Drawing.Size(135, 21);
            this.LetterCode.TabIndex = 3;
            this.LetterCode.Text = "Letter code output";
            this.LetterCode.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "DNA/RNA sequence";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(341, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Protein amino acid sequence";
            // 
            // ReverseTranslate
            // 
            this.ReverseTranslate.Location = new System.Drawing.Point(277, 132);
            this.ReverseTranslate.Name = "ReverseTranslate";
            this.ReverseTranslate.Size = new System.Drawing.Size(61, 25);
            this.ReverseTranslate.TabIndex = 6;
            this.ReverseTranslate.Text = " <-";
            this.ReverseTranslate.UseVisualStyleBackColor = true;
            this.ReverseTranslate.Click += new System.EventHandler(this.ReverseTranslate_Click);
            // 
            // UseUracil
            // 
            this.UseUracil.AutoSize = true;
            this.UseUracil.Location = new System.Drawing.Point(344, 165);
            this.UseUracil.Name = "UseUracil";
            this.UseUracil.Size = new System.Drawing.Size(179, 21);
            this.UseUracil.TabIndex = 7;
            this.UseUracil.Text = "RNA mode - Uracil output";
            this.UseUracil.UseVisualStyleBackColor = true;
            // 
            // ReadingFrame
            // 
            this.ReadingFrame.Location = new System.Drawing.Point(15, 204);
            this.ReadingFrame.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ReadingFrame.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            -2147483648});
            this.ReadingFrame.Name = "ReadingFrame";
            this.ReadingFrame.Size = new System.Drawing.Size(100, 25);
            this.ReadingFrame.TabIndex = 8;
            // 
            // form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 241);
            this.Controls.Add(this.ReadingFrame);
            this.Controls.Add(this.UseUracil);
            this.Controls.Add(this.ReverseTranslate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LetterCode);
            this.Controls.Add(this.InputText);
            this.Controls.Add(this.Translate);
            this.Controls.Add(this.OutputText);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "form";
            this.ShowIcon = false;
            this.Text = "Codon Translator";
            this.Load += new System.EventHandler(this.form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReadingFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox OutputText;
        private System.Windows.Forms.Button Translate;
        private System.Windows.Forms.TextBox InputText;
        private System.Windows.Forms.CheckBox LetterCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ReverseTranslate;
        private System.Windows.Forms.CheckBox UseUracil;
        private System.Windows.Forms.NumericUpDown ReadingFrame;
    }
}

