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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form));
            this.OutputText = new System.Windows.Forms.TextBox();
            this.Translate = new System.Windows.Forms.Button();
            this.InputText = new System.Windows.Forms.TextBox();
            this.LetterCode = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ReverseTranslate = new System.Windows.Forms.Button();
            this.UseUracil = new System.Windows.Forms.CheckBox();
            this.ReadingFrame = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.BaseTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.Adjust = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ApplyPointMutation = new System.Windows.Forms.Button();
            this.Mutations = new System.Windows.Forms.GroupBox();
            this.PointIndex = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.FrameshiftMutate = new System.Windows.Forms.Button();
            this.AutoFormat = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CodonGen = new System.Windows.Forms.NumericUpDown();
            this.GenRandom = new System.Windows.Forms.Button();
            this.UseStop = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ReadingFrame)).BeginInit();
            this.Mutations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PointIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodonGen)).BeginInit();
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
            this.LetterCode.Location = new System.Drawing.Point(162, 165);
            this.LetterCode.Name = "LetterCode";
            this.LetterCode.Size = new System.Drawing.Size(135, 21);
            this.LetterCode.TabIndex = 3;
            this.LetterCode.Text = "Letter code output";
            this.BaseTooltip.SetToolTip(this.LetterCode, "Example for TAT/UAU:\r\nOtput be Tyr when enabled instead of Tyrosine");
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
            this.BaseTooltip.SetToolTip(this.label1, "Example sequence AUGATCGGGGCCCCUUU\r\nU is always treated as T\r\nSpaces, newlines, a" +
        "nd non-codon\'s will be ignored");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(341, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Protein amino acid sequence";
            this.BaseTooltip.SetToolTip(this.label2, "Amino acid sequences, separated by spaces.\r\nBoth Letter codes and normal sequence" +
        "s will work\r\n\r\nExample of equivalent input:\r\nMethionine Isoleucine Glycine Alani" +
        "ne Proline\r\nMet Ile Gly Ala Pro\r\n");
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
            this.UseUracil.Location = new System.Drawing.Point(162, 242);
            this.UseUracil.Name = "UseUracil";
            this.UseUracil.Size = new System.Drawing.Size(97, 21);
            this.UseUracil.TabIndex = 7;
            this.UseUracil.Text = "Prefer uracil";
            this.BaseTooltip.SetToolTip(this.UseUracil, "Simply replaces T with U");
            this.UseUracil.UseVisualStyleBackColor = true;
            // 
            // ReadingFrame
            // 
            this.ReadingFrame.Location = new System.Drawing.Point(146, 41);
            this.ReadingFrame.Name = "ReadingFrame";
            this.ReadingFrame.Size = new System.Drawing.Size(58, 25);
            this.ReadingFrame.TabIndex = 8;
            this.BaseTooltip.SetToolTip(this.ReadingFrame, "By how much to shift the frame by\r\n");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Frameshift";
            this.BaseTooltip.SetToolTip(this.label3, "Shifts the reading frame by removing bases according to their count");
            // 
            // Adjust
            // 
            this.Adjust.FormattingEnabled = true;
            this.Adjust.Items.AddRange(new object[] {
            "No adjustment",
            "Codon memory",
            "Amino acid tags"});
            this.Adjust.Location = new System.Drawing.Point(13, 185);
            this.Adjust.Name = "Adjust";
            this.Adjust.Size = new System.Drawing.Size(121, 25);
            this.Adjust.TabIndex = 11;
            this.BaseTooltip.SetToolTip(this.Adjust, resources.GetString("Adjust.ToolTip"));
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Adjustment Mode";
            this.BaseTooltip.SetToolTip(this.label4, "Affects where the reading starts.\r\nUseful for demonstrating frame shift mutations" +
        " for example.\r\n");
            // 
            // ApplyPointMutation
            // 
            this.ApplyPointMutation.Location = new System.Drawing.Point(75, 41);
            this.ApplyPointMutation.Name = "ApplyPointMutation";
            this.ApplyPointMutation.Size = new System.Drawing.Size(53, 25);
            this.ApplyPointMutation.TabIndex = 13;
            this.ApplyPointMutation.Text = "Apply";
            this.ApplyPointMutation.UseVisualStyleBackColor = true;
            this.ApplyPointMutation.Click += new System.EventHandler(this.ApplyPointMutation_Click);
            // 
            // Mutations
            // 
            this.Mutations.Controls.Add(this.FrameshiftMutate);
            this.Mutations.Controls.Add(this.label5);
            this.Mutations.Controls.Add(this.PointIndex);
            this.Mutations.Controls.Add(this.ApplyPointMutation);
            this.Mutations.Controls.Add(this.ReadingFrame);
            this.Mutations.Controls.Add(this.label3);
            this.Mutations.Location = new System.Drawing.Point(330, 185);
            this.Mutations.Name = "Mutations";
            this.Mutations.Size = new System.Drawing.Size(272, 78);
            this.Mutations.TabIndex = 14;
            this.Mutations.TabStop = false;
            this.Mutations.Text = "Mutation simulation";
            // 
            // PointIndex
            // 
            this.PointIndex.Location = new System.Drawing.Point(11, 41);
            this.PointIndex.Name = "PointIndex";
            this.PointIndex.Size = new System.Drawing.Size(58, 25);
            this.PointIndex.TabIndex = 15;
            this.BaseTooltip.SetToolTip(this.PointIndex, "Index where the mutation will happen");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Point";
            this.BaseTooltip.SetToolTip(this.label5, "Changes a letter in the DNA/RNA sequence\r\nat the specified index, to any other on" +
        "e.\r\nIn reality A usually mutates to T and\r\nC usually to G, but adding modes for " +
        "each would\r\nbe too much work.");
            // 
            // FrameshiftMutate
            // 
            this.FrameshiftMutate.Location = new System.Drawing.Point(210, 41);
            this.FrameshiftMutate.Name = "FrameshiftMutate";
            this.FrameshiftMutate.Size = new System.Drawing.Size(53, 25);
            this.FrameshiftMutate.TabIndex = 16;
            this.FrameshiftMutate.Text = "Apply";
            this.FrameshiftMutate.UseVisualStyleBackColor = true;
            this.FrameshiftMutate.Click += new System.EventHandler(this.FrameshiftMutate_Click);
            // 
            // AutoFormat
            // 
            this.AutoFormat.AutoSize = true;
            this.AutoFormat.Checked = true;
            this.AutoFormat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoFormat.Location = new System.Drawing.Point(162, 192);
            this.AutoFormat.Name = "AutoFormat";
            this.AutoFormat.Size = new System.Drawing.Size(97, 21);
            this.AutoFormat.TabIndex = 15;
            this.AutoFormat.Text = "Auto format";
            this.BaseTooltip.SetToolTip(this.AutoFormat, "Whether or not to add spaces between codons,\r\nremove trailing bases, and remove t" +
        "rash characters");
            this.AutoFormat.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Generate random";
            this.BaseTooltip.SetToolTip(this.label6, "Generates random sample DNA sequence.");
            // 
            // CodonGen
            // 
            this.CodonGen.Location = new System.Drawing.Point(15, 241);
            this.CodonGen.Name = "CodonGen";
            this.CodonGen.Size = new System.Drawing.Size(58, 25);
            this.CodonGen.TabIndex = 18;
            this.BaseTooltip.SetToolTip(this.CodonGen, "Count of the sample in codon count");
            // 
            // GenRandom
            // 
            this.GenRandom.Location = new System.Drawing.Point(79, 241);
            this.GenRandom.Name = "GenRandom";
            this.GenRandom.Size = new System.Drawing.Size(53, 25);
            this.GenRandom.TabIndex = 17;
            this.GenRandom.Text = "Gen";
            this.GenRandom.UseVisualStyleBackColor = true;
            this.GenRandom.Click += new System.EventHandler(this.GenRandom_Click);
            // 
            // UseStop
            // 
            this.UseStop.AutoSize = true;
            this.UseStop.Location = new System.Drawing.Point(162, 217);
            this.UseStop.Name = "UseStop";
            this.UseStop.Size = new System.Drawing.Size(99, 21);
            this.UseStop.TabIndex = 20;
            this.UseStop.Text = "Stop at stop";
            this.BaseTooltip.SetToolTip(this.UseStop, "Stop translation at stop codons");
            this.UseStop.UseVisualStyleBackColor = true;
            // 
            // form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 273);
            this.Controls.Add(this.UseStop);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AutoFormat);
            this.Controls.Add(this.CodonGen);
            this.Controls.Add(this.Mutations);
            this.Controls.Add(this.GenRandom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Adjust);
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
            this.Mutations.ResumeLayout(false);
            this.Mutations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PointIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodonGen)).EndInit();
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
        private System.Windows.Forms.ToolTip BaseTooltip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Adjust;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ApplyPointMutation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox Mutations;
        private System.Windows.Forms.NumericUpDown PointIndex;
        private System.Windows.Forms.Button FrameshiftMutate;
        private System.Windows.Forms.CheckBox AutoFormat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown CodonGen;
        private System.Windows.Forms.Button GenRandom;
        private System.Windows.Forms.CheckBox UseStop;
    }
}

