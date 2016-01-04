using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lc_MaxProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine(
             p.MaxProduct(new string[] { "aecfeacdcdceeedbc", "fcaacf", "cacfbaddcdfdaabdeed", "ffabfdefbbcfbffeebef", "befafbbedcddeee", "bdcffe", "fcecacaedeaf", "fdedf", "debbfbbfabfeecaeadd", "aedd", "afeaeecfceeedc", "ccaafeddaade", "acdcfffdbccccdcdceeb", "adbca", "fe", "eedfeaedfdcfbedbaba", "facabfb", "acdebafda", "efdbaaccefdcdafbd", "fdfcbaffb", "ea", "ece", "dbafebecabbdbeab", "eebcbedcaa", "eabdfacecaeadaffdafc", "bfcfcfbadefdafd", "afdfcecdd", "ccabefbfadfdaedcbcde", "dceaaaffdcaadffcfca", "bedebcaeecdc", "fccbffadbeda", "dabaafa", "eebbeccddbaeede", "bebdb", "ccafcacbabdfcedcbd", "cfaccdcabfecfaaa", "acda", "deecdcac", "babaadaebcfcadbdcafaf", "cf", "abbcf", "bfdcbdedecf", "eedebecafe", "dbfacf", "eda", "eacbeddfdcbdfcfebb", "aabfdbfdbf", "effdbabcefeffffbaae", "bbeafeceb", "ec", "fbccdadefdb", "efacba", "ecd", "bdcdb", "dffabffcabfededbacdaa", "ebfeccdbefcecda", "bb", "dfffbbafaeeedbcde", "eccfffacffe", "beaeabecafdcfdcea", "fecfdadeceafdeecd", "ebbadfbcbbc", "dfebebb", "bddbdddbedafe", "eadbdebbfeab", "cfcdbbaa", "faafedadabdcfbeafbf", "ddffafadfadafbac", "aeadceaf", "bbdacfafa", "dcad", "cbccdbdeaccade", "bafedfc", "abaebcefecfdcfbc", "cabfdbebe", "bbbecfdacddadddcf", "cbbbd", "dfbdb", "efedc", "dbcfabeeaa", "bfcdbdebfdfceeaca", "de", "fcefea", "adddca", "afdadbadacddbd", "deea", "addbabcddeecafba", "efaeadcfacbfebeedacb", "baacdfdbd", "cecfeeddeed", "dbfdbdceebf", "adadceaacc", "dbebcabcdedeadbfaae", "adeccbcabaddcbefdfaf", "feeffbfbbbabdcaff", "bdcedcdaebffddbcfcaeb", "afaaafcdbbabe", "ebaedacacfbdcbceea", "cfaeecbabaf", "cecdba", "eeeeffaddaeefdfafeda", "fdfffbdbbbebdbcef", "fbfdadcebbeaefabdfb", "ebeeadaf", "abacffa", "edbead", "addcdcdececadcdce", "bfaadcaaddadfffa", "dcecbafdebccbeab" }));
        }

        public int MaxProduct(string[] words)
        {
            List<Word> list = new List<Word>();
            foreach (string w in words)
                list.Add(new Word(w));
            list.Sort();

            int max = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (max >= list[i].Length * list[i].Length)
                    break;
                for (int j = i + 1; j < list.Count; j++)
                {
                    int p = list[i].GetProduct(list[j]);
                    if (max < p)
                        max = p;
                    if (p != 0)
                        break;
                }
            }
            return max;
        }

        class Word : IComparable<Word>
        {
            public int Length;
            public int bits;
  

            public Word(string w)
            {
           
         
                Length = w.Length;
                foreach (char c in w)
                {
                    bits |= (1 << (c - 'a'));
                }
            }

            public int GetProduct(Word w)
            {
                if ((w.bits & this.bits) == 0)
                    return w.Length * this.Length;
                return 0;
            }

            int IComparable<Word>.CompareTo(Word other)
            {
                return other.Length - this.Length;
            }


        }
    }
}
