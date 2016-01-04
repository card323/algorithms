using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nc_zipper
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine(p.zipString("aabcccccaaa"));
        }

        public string zipString(string iniString)
        {
            char last = '\0';
            int count = 0;
            int l = 0;
            char[] buffer = new char[3000];
            foreach (char c in iniString)
            {
                if (last == c)
                    count++;
                else
                {
                    if (count > 0)
                    {
                        buffer[l++] = last;
                        buffer[l++] = (char)('0' + count);

                        if (l >= iniString.Length)
                            return iniString;
                    }
                    last = c;
                    count = 1;
                }
            }

            if (count > 0)
            {
                buffer[l++] = last;
                buffer[l++] = (char)('0' + count);
                if (l >= iniString.Length)
                    return iniString;
            }

            return new string(buffer, 0, l);
        }
    }
}
