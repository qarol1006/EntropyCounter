using System;
using System.Collections.Generic;
using System.Text;

namespace pierwszyProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\Qarol\Desktop\Rdz1.txt");
            int dlugosc = text.Length;
            bool czyByl = false;
            List<char> znaki = new List<char>();
            List<int> liczbaWystapien = new List<int>();
            List<double> pstwoWystapienia = new List<double>();

            foreach (char znak in text)
            {
                czyByl = false;
                for (int i = 0; i < znaki.Count; i++)
                {
                    if (znak == znaki[i])
                    {
                        czyByl = true;
                        liczbaWystapien[i]++;
                    }
                }

                if (czyByl == false)
                {
                    znaki.Add(znak);
                    liczbaWystapien.Add(1);
                }
            }

            for (int i = 0; i < znaki.Count; i++)
            {
                pstwoWystapienia.Add((double)liczbaWystapien[i] / dlugosc);
            }

            Console.WriteLine("znak\tl.wyst.\t\tp-stwo");

            for (int i = 0; i < znaki.Count; i++)
            {
                Console.WriteLine(znaki[i] + "\t" + liczbaWystapien[i] + "\t\t" + pstwoWystapienia[i]);
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////// są już prawdopodobieństwa, to teraz entropia
            double entropia = 0;

            foreach (double p in pstwoWystapienia)
            {
                entropia = entropia - p * Math.Log2(p);
            }

            Console.WriteLine("entropia = " + entropia);
            Console.WriteLine("dlugosc = " + dlugosc);

        }
    }
}
