using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Codon
{
    public partial class form : Form
    {
        public form()
        {
            InitializeComponent();
        }

        private void form_Load(object sender, EventArgs e)
        {
         
        }

        private void Translate_Click(object sender, EventArgs e)
        {
            //convert to upper and fix rna uracil, newlines, and spaces
            var str = InputText.Text.ToUpperInvariant().Replace('U', 'T').Replace(" ", "").Replace(Environment.NewLine, string.Empty);
            var array = str.Split(3).ToList(); //custom split extension to group string into array where each element is 3.

            OutputText.Text = "";
            foreach(var codon in array)
            {
                if (!Codon.Table.ContainsKey(codon)) //invalid
                    continue;

                OutputText.Text += (LetterCode.Checked ? Codon.Table[codon].Item1 : Codon.Table[codon].Item2) + " ";
            }
            OutputText.Text = OutputText.Text.TrimEnd(' '); //lazy way of replacing trailing space
            OutputText.Text = OutputText.Text.Replace("Acid", " Acid"); //create the illusion of acid having a space
        }

        private void ReverseTranslate_Click(object sender, EventArgs e)
        {
            //fix newlines, ",", and acid names
            var str = OutputText.Text.Replace(",", "").Replace(Environment.NewLine, "").Replace(" Acid", "Acid");
            var array = str.Split(' ').ToList(); //split by space instead this time

            InputText.Text = "";
            foreach (var codon in array)
            {
                string found = string.Empty;
                foreach(var pair in Codon.Table.AsParallel()) //inefficient, but quick solution to get key by value
                {
                    if(codon == pair.Value.Item1 || codon == pair.Value.Item2)
                    {
                        found = pair.Key;
                        break;
                    }
                }

                if (string.IsNullOrEmpty(found)) //not found or invalid
                    continue;

                if (UseUracil.Checked)
                    found = found.Replace("T", "U");
                InputText.Text += found + " ";
            }
            InputText.Text = InputText.Text.TrimEnd(' ');
        }
    }
}
