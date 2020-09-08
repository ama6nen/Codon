using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Codon
{
    public enum Property
    {
        Nonpolar,
        Polar,
        Basic,
        Acidic,
        Stop,
        Start,
        Invalid,
    }

    public enum AdjustMode : int
    {
        None,
        Codon_Memory,
        Amino_Tag
    }
    public static class Codon
    {

        /*
          * The reason why there are so many codons but not as many amino acids is because point mutations are very common,
          * and in order for these common mutations to be less functionally affective the most common point mutations would
          * simply not change the amino acid at all, which would not change the function of the protein at all.
          * For non-coding DNA these redundant mutations are most of the time "Silent" too, which just means they don't have an observable effect.
          * Although for non-coding it's not always the case, unlike with coding DNA.
          * Better explanation: https://en.wikipedia.org/wiki/Synonymous_substitution
        */

        //Based on DNA table, not RNA. For RNA just replace T with U
        public static Dictionary<string, Tuple<string, string>> Table = new Dictionary<string, Tuple<string, string>>()
        {
            //Codon, Three letter code, and amino acid
            { "TTT", Tuple.Create("Phe", "Phenylalanine")  },
            { "TTC", Tuple.Create("Phe", "Phenylalanine")  },
            { "TTA", Tuple.Create("Leu", "Leucine")  },
            { "TTG", Tuple.Create("Leu", "Leucine")  }, //very rarely a start codon (at least in eukaryotes), can also code for Met
            { "CTT", Tuple.Create("Leu", "Leucine")  },
            { "CTC", Tuple.Create("Leu", "Leucine")  },
            { "CTA", Tuple.Create("Leu", "Leucine")  },
            { "CTG", Tuple.Create("Leu", "Leucine")  }, //very rarely a start codon (at least in eukaryotes), can also code for Met
            { "ATT", Tuple.Create("Ile", "Isoleucine")  },
            { "ATC", Tuple.Create("Ile", "Isoleucine")  },
            { "ATA", Tuple.Create("Ile", "Isoleucine")  },
            { "ATG", Tuple.Create("Met", "Methionine")  }, //start codon/iniation site: starts mRNA translation into protein, otherwise codes for Met
            { "GTT", Tuple.Create("Val", "Valine")  },
            { "GTC", Tuple.Create("Val", "Valine")  },
            { "GTA", Tuple.Create("Val", "Valine")  },
            { "GTG", Tuple.Create("Val", "Valine")  },
            { "TCT", Tuple.Create("Ser", "Serine")  },
            { "TCC", Tuple.Create("Ser", "Serine")  },
            { "TCA", Tuple.Create("Ser", "Serine")  },
            { "TCG", Tuple.Create("Ser", "Serine")  },
            { "AGT", Tuple.Create("Ser", "Serine")  },
            { "AGC", Tuple.Create("Ser", "Serine")  },
            { "CCT", Tuple.Create("Pro", "Proline")  },
            { "CCC", Tuple.Create("Pro", "Proline")  },
            { "CCA", Tuple.Create("Pro", "Proline")  },
            { "CCG", Tuple.Create("Pro", "Proline")  },
            { "ACT", Tuple.Create("Thr", "Threonine")  },
            { "ACC", Tuple.Create("Thr", "Threonine")  },
            { "ACA", Tuple.Create("Thr", "Threonine")  },
            { "ACG", Tuple.Create("Thr", "Threonine")  },
            { "GCT", Tuple.Create("Ala", "Alanine")  },
            { "GCC", Tuple.Create("Ala", "Alanine")  },
            { "GCA", Tuple.Create("Ala", "Alanine")  },
            { "GCG", Tuple.Create("Ala", "Alanine")  },
            { "TAT", Tuple.Create("Tyr", "Tyrosine")  }, //Also an excellent supplement (alone and especially when taken with stimulants) because it gets converted to L-DOPA -> dopamine,
            { "TAC", Tuple.Create("Tyr", "Tyrosine")  }, //which is great especially when you are able to produce more dopamine (like under stimulants) but may require tyrosine as a precursor, which majorly boosts the effects of said stimulant.
            { "TAA", Tuple.Create("Stp1", "Stop[Ochre]")  }, //Stop codon, Ochre in nomenclature comes from a stop codon mutation with TAA due to having ochre ccolor
            { "TAG", Tuple.Create("Stp2", "Stop[Amber]")  }, //Stop codon, Amber in nomenclature comes from the discoverers' friend's last name's meaning
            { "CAT", Tuple.Create("His", "Histidine")  },
            { "CAC", Tuple.Create("His", "Histidine")  },
            { "CAA", Tuple.Create("Gln", "Glutamine")  }, //Sometimes used as supplement for intestinal growth/health, but its not of interest to me so I don't know more
            { "CAG", Tuple.Create("Gln", "Glutamine")  },
            { "AAT", Tuple.Create("Asn", "Asparagine")  },
            { "AAC", Tuple.Create("Asn", "Asparagine")  },
            { "AAA", Tuple.Create("Lys", "Lysine")  },
            { "AAG", Tuple.Create("Lys", "Lysine")  },
            { "GAT", Tuple.Create("Asp", "AsparticAcid")  }, //Related to asparagine but not equivalent
            { "GAC", Tuple.Create("Asp", "AsparticAcid")  },
            { "GAA", Tuple.Create("Glu", "GlutamicAcid")  }, //Related to glutamine but not equivalent
            { "GAG", Tuple.Create("Glu", "GlutamicAcid")  },
            { "TGT", Tuple.Create("Cys", "Cysteine")  },
            { "TGC", Tuple.Create("Cys", "Cysteine")  },
            { "TGA", Tuple.Create("Stp3", "Stop[Opal]")  }, //Stop codon, Opal in nomenclature literally just tries to continue the pattern of colored minerals. Alternative name is Umber as well.
            { "TGG", Tuple.Create("Trp", "Tryptophan")  }, //Also good supplement because it gets converted into 5-HTP -> Serotonin. Although 5-HTP crosses BBB easier and has bigger effects.
            { "CGT", Tuple.Create("Arg", "Arginine")  },
            { "CGC", Tuple.Create("Arg", "Arginine")  },
            { "CGA", Tuple.Create("Arg", "Arginine")  },
            { "CGG", Tuple.Create("Arg", "Arginine")  },
            { "AGA", Tuple.Create("Arg", "Arginine")  },
            { "AGG", Tuple.Create("Arg", "Arginine")  },
            { "GGT", Tuple.Create("Gly", "Glycine")  }, //Also decent supplement for sleep (maybe because it can lower body temp, or because its the main inhibitory neurotransmitter)
            { "GGC", Tuple.Create("Gly", "Glycine")  }, //But it tastes way too sweet, in a way which makes it overwhelming
            { "GGA", Tuple.Create("Gly", "Glycine")  },
            { "GGG", Tuple.Create("Gly", "Glycine")  },

        };
         
        public static Dictionary<string, Tuple<string, string>> TagTable = new Dictionary<string, Tuple<string, string>>();

        public static Dictionary<string, Property> Bioproperties = new Dictionary<string, Property>()
        {
            { "Phe", Property.Nonpolar  },
            { "Leu", Property.Nonpolar  },
            { "Ile", Property.Nonpolar  },
            { "Met", Property.Start  },
            { "Val", Property.Nonpolar  },
            { "Ser", Property.Polar  },
            { "Pro", Property.Nonpolar  },
            { "Thr", Property.Polar  },
            { "Ala", Property.Nonpolar  },
            { "Tyr", Property.Polar  },
            { "Stp1", Property.Stop  },
            { "Stp2", Property.Stop  },
            { "Stp3", Property.Stop  },
            { "His", Property.Basic  },
            { "Gln", Property.Polar  },
            { "Asn", Property.Polar  },
            { "Lys", Property.Polar  },
            { "Asp", Property.Acidic  },
            { "Glu", Property.Acidic  },
            { "Cys", Property.Polar  },
            { "Trp", Property.Nonpolar  },
            { "Arg", Property.Basic  },
            { "Gly", Property.Nonpolar  },
        };

        private static Random random = new Random();
        public static char GetRandomBase()
        {
            switch(random.Next(0, 4))
            {
                case 0:
                    return 'A';
                case 1:
                    return 'T';
                case 2:
                    return 'G';
                case 3:
                    return 'C';
                default:
                    return '?';
            }
        }
    }
    public static class Extension
    {
        public static IEnumerable<string> Split(this string str, int len)
        {
            for (int i = 0; i < str.Length; i += len)
            {
                if (i + len > str.Length)
                    break;
                yield return str.Substring(i, len);
            }

        }

        //from stackoverflow
        public static string RemoveIntegers(this string input)
        => Regex.Replace(input, @"[\d-]", string.Empty);
        
    }
}
