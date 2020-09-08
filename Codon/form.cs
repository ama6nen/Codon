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

        public List<string> CodonMemory = new List<string>();

        private async void ShowIfInvalid(TextBox box)
        {
            if (box.Text == string.Empty)
            {
                box.Text = "Input is invalid!";
                await Task.Delay(2500);
                box.Text = string.Empty;
            }
        }

        private void FormatInput(string input)
        {
            if (AutoFormat.Checked)
            {
                input = input.Replace('U', 'T');
                var array = input.Split(3).ToList();
                InputText.Text = "";
                foreach (var codon in array)
                {
                    if (!Codon.Table.ContainsKey(codon))
                        continue;
   
                    InputText.Text += (UseUracil.Checked ? codon.Replace('T', 'U') : codon) + " ";
                    if (UseStop.Checked && Codon.IsStopCodon(codon))
                            break;
                }
                InputText.Text = InputText.Text.TrimEnd(' ');
            }
            else
                InputText.Text = (UseUracil.Checked ? input.Replace('T', 'U') : input);

        }

        private void form_Load(object sender, EventArgs e)
        {
            string last = "";
            int counter = 1;
            foreach (var pair in Codon.Table.AsParallel())
            {
                if (pair.Value.Item1 == last)
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

        private void Translate_Click(object sender, EventArgs e)
        {
            bool memory = (int)AdjustMode.Codon_Memory == Adjust.SelectedIndex;
            bool tag = (int)AdjustMode.Amino_Tag == Adjust.SelectedIndex;
            if (memory)
                CodonMemory.Clear();
            //convert to upper and fix rna uracil, newlines, and spaces
            var str = InputText.Text.ToUpperInvariant().Replace('U', 'T').Replace(" ", "").Replace(Environment.NewLine, string.Empty);
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

            FormatInput(str);
            ShowIfInvalid(OutputText);
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

                if (AutoFormat.Checked)
                {
                    if (UseUracil.Checked)
                        found = found.Replace("T", "U");
                    InputText.Text += found + " ";
                }
                else InputText.Text += found;
            }

            if (AutoFormat.Checked)
                InputText.Text = InputText.Text.TrimEnd(' ');
            ShowIfInvalid(InputText);
        }

        private void ApplyPointMutation_Click(object sender, EventArgs e)
        {
            var str = InputText.Text.ToUpperInvariant().Replace('U', 'T').Replace(" ", "").Replace(Environment.NewLine, string.Empty);

            var i = (int)PointIndex.Value;
            if (i >= str.Length || str[i] == '?') //out of bounds and infinite loop
            {
                ShowIfInvalid(InputText);
                return;
            }

            //We dont really care if we have to call this function a few more times since wont affect perf
            var nuc = str[i];
            while (nuc == str[i])
                nuc = Codon.GetRandomBase();

            str = str.Remove(i, 1).Insert(i, nuc.ToString()); //theres no convenient replace-char-at-index func

            FormatInput(str);
            ShowIfInvalid(InputText);
        }

        //couldn't bother to actually make it have a proper frame like the start codon and from there shift it
        //or make the string loop around or so forth, so this is pretty much same as a deletion mutation
        private void FrameshiftMutate_Click(object sender, EventArgs e)
        {
            var str = InputText.Text.ToUpperInvariant().Replace('U', 'T').Replace(" ", "").Replace(Environment.NewLine, string.Empty);

            if (ReadingFrame.Value > str.Length)
                ReadingFrame.Value = 0;
            str = str.Remove(0, (int)ReadingFrame.Value); //very simple

            FormatInput(str);
            ShowIfInvalid(InputText);
        }

        private void GenRandom_Click(object sender, EventArgs e)
        {
            InputText.Text = "";

            for(var i = 0; i < CodonGen.Value; i++)
                InputText.Text += Codon.GetRandomCodon();

            FormatInput(InputText.Text);
        }
    }
}
