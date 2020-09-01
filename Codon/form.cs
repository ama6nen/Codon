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
            string last = "";
            int counter = 1;
            foreach(var pair in Codon.Table.AsParallel())
            {
                if(pair.Value.Item1 == last)
                {
                    Codon.TagTable.Add(pair.Key, new Tuple<string, string>(pair.Value.Item1 + counter.ToString(), pair.Value.Item2 + counter.ToString()));
                    counter++;
                }
                else
                {
                    Codon.TagTable.Add(pair.Key, pair.Value);
                    last = pair.Value.Item1;
                    counter = 1;
                }
            }
        }

        public List<string> CodonMemory = new List<string>();

        private void Translate_Click(object sender, EventArgs e)
        {
            bool memory = (int)AdjustMode.Codon_Memory == Adjust.SelectedIndex;
            bool tag = (int)AdjustMode.Amino_Tag == Adjust.SelectedIndex;
            if (memory)
                CodonMemory.Clear();
            //convert to upper and fix rna uracil, newlines, and spaces
            var str = InputText.Text.ToUpperInvariant().Replace('U', 'T').Replace(" ", "").Replace(Environment.NewLine, string.Empty);
            if (ReadingFrame.Value > str.Length)
                ReadingFrame.Value = 0;
            str = str.Remove(0, (int)ReadingFrame.Value);
            var array = str.Split(3).ToList(); //custom split extension to group string into array where each element is 3.

            OutputText.Text = "";
            foreach (var codon in array)
            {
                if (!Codon.Table.ContainsKey(codon)) //invalid
                    continue;

                string item;
                if (tag)
                    item = LetterCode.Checked ? Codon.TagTable[codon].Item1 : Codon.TagTable[codon].Item2;
                else
                    item = LetterCode.Checked ? Codon.Table[codon].Item1 : Codon.Table[codon].Item2;

                if (memory)
                    CodonMemory.Add(codon); //for reverse translation to be correct.
                OutputText.Text += item + " ";
            }
            OutputText.Text = OutputText.Text.TrimEnd(' '); //lazy way of replacing trailing space
            OutputText.Text = OutputText.Text.Replace("Acid", " Acid"); //create the illusion of acid having a space

            if (OutputText.Text == string.Empty)
                OutputText.Text = "Input was invalid";

            ReadingFrame.Value = 0;
        }

        private void ReverseTranslate_Click(object sender, EventArgs e)
        {
            //fix newlines, ",", and acid names
            var str = OutputText.Text.Replace(",", "").Replace(Environment.NewLine, "").Replace(" Acid", "Acid");
            var array = str.Split(' ').ToList(); //split by space instead this time

            InputText.Text = "";
            int currindex = 0;
            bool memory = (int)AdjustMode.Codon_Memory == Adjust.SelectedIndex && CodonMemory.Count == array.Count;
            bool tag = (int)AdjustMode.Amino_Tag == Adjust.SelectedIndex;
            Debug.WriteLine(memory);
            foreach (var codon in array)
            {
                string found = string.Empty;

                if (tag)
                {
                    foreach (var pair in Codon.TagTable.AsParallel()) //inefficient, but quick solution to get key by value
                    {
                        if (codon == pair.Value.Item1 || codon == pair.Value.Item2)
                        {
                            found = pair.Key;
                            break;
                        }
                    }
                }
                else
                {
                    foreach (var pair in Codon.Table.AsParallel()) //inefficient, but quick solution to get key by value
                    {
                        if (codon == pair.Value.Item1 || codon == pair.Value.Item2)
                        {
                            found = pair.Key;
                            break;
                        }
                    }
                }
               

                if (string.IsNullOrEmpty(found)) //not found or invalid
                    continue;

                if (memory)
                {
                    if (currindex < CodonMemory.Count && Codon.Table.TryGetValue(CodonMemory[currindex], out var corrected))
                    {
                        if (corrected.Item1 == codon || corrected.Item2 == codon)
                            found = CodonMemory[currindex]; //get the real value from memory
                    }
                    currindex++;
                }

                if (UseUracil.Checked)
                    found = found.Replace("T", "U");
                InputText.Text += found + " ";
            }
            InputText.Text = InputText.Text.TrimEnd(' ');

            if (InputText.Text == string.Empty)
                InputText.Text = "Input was invalid";
        }
    }
}
