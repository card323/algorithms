using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lc_nthSUNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            var array = new int[] { 2, 3, 5, 13, 19, 29, 31, 41, 43, 53, 59, 73, 83, 89, 97, 103, 107, 109, 127, 137, 139, 149, 163, 173, 179, 193, 197, 199, 211, 223, 227, 229, 239, 241, 251, 257, 263, 269, 271, 281, 317, 331, 337, 347, 353, 359, 367, 373, 379, 389, 397, 409, 419, 421, 433, 449, 457, 461, 463, 479, 487, 509, 521, 523, 541, 547, 563, 569, 577, 593, 599, 601, 613, 619, 631, 641, 659, 673, 683, 701, 709, 719, 733, 739, 743, 757, 761, 769, 773, 809, 811, 829, 857, 859, 881, 919, 947, 953, 967, 971 };

            //array = new int[] { 2 };


            Console.WriteLine(p.NthSuperUglyNumber(200000, array));



        }

        public int NthSuperUglyNumber(int n, int[] primes)
        {
            LinkedList<long> list = new LinkedList<long>();
            list.AddFirst(1);
            LinkedListNode<long>[] hints = new LinkedListNode<long>[primes.Length];
            var minNode = list.First;
            long min = 0;
            int size = n;
            while (n-- > 0)
            {
                min = minNode.Value;
                for (int i = 0; i < primes.Length; i++)
                {
                    var current = hints[i];
                    if (current == null)
                        current = list.First;

                    long p = primes[i];
                    while (current.Next != null && current.Next.Value <= p * min)
                    {
                        current = current.Next;
                    }
                    hints[i] = current;
                    if (current.Value == p * min)
                        continue;
                    
                    if (list.Count > size && list.Last.Value < p * min)
                    {
                        break;
                    }

                    list.AddAfter(current, p * min);
                    
                }
                minNode = minNode.Next;
            }

            return (int)min;
        }

    }
}
