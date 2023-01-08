using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceAdventure
{
    public class StartView
    {
        private void StartPrint()
        {
            Console.WriteLine();
            Console.WriteLine("\t\t\t ■■■■\t\t■\t\t ■■■■\t\t■■■■■");
            Console.WriteLine("\t\t\t ■      ■\t\t■\t\t■       ■\t\t■");
            Console.WriteLine("\t\t\t ■       ■\t\t■\t\t■\t\t\t■■■■■");
            Console.WriteLine("\t\t\t ■       ■\t\t■\t\t■\t\t\t■");
            Console.WriteLine("\t\t\t ■      ■\t\t■\t\t■       ■\t\t■");
            Console.WriteLine("\t\t\t ■■■■\t\t■\t\t ■■■■\t\t■■■■■");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("\t    ■\t\t ■■■■\t■        ■\t■■■■■■\t■\t■\t■■■■\t■■■■■");
            Console.WriteLine("\t  ■  ■\t ■\t ■ \t ■      ■\t     ■\t\t■\t■\t■\t■\t■");
            Console.WriteLine("\t ■    ■\t ■\t  ■\t  ■    ■\t     ■\t\t■\t■\t■■■■\t■");
            Console.WriteLine("\t■■■■■\t ■\t  ■\t   ■  ■\t     ■\t\t■\t■\t■  ■\t\t■■■■■");
            Console.WriteLine("\t■      ■\t ■\t ■\t    ■■\t     ■\t\t■\t■\t■    ■\t■");
            Console.WriteLine("\t■      ■\t ■■■■\t     ■\t\t     ■\t\t■■■■■\t■      ■\t■■■■■");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


            // Console.Clear();
        }
        private void StartPrint2()
        {
            Console.WriteLine();
            Console.WriteLine("\t\t\t □□□□\t\t□\t\t □□□□\t\t□□□□□");
            Console.WriteLine("\t\t\t □      □\t\t□\t\t□       □\t\t□");
            Console.WriteLine("\t\t\t □       □\t\t□\t\t□\t\t\t□□□□□");
            Console.WriteLine("\t\t\t □       □\t\t□\t\t□\t\t\t□");
            Console.WriteLine("\t\t\t □      □\t\t□\t\t□       □\t\t□");
            Console.WriteLine("\t\t\t □□□□\t\t□\t\t □□□□\t\t□□□□□");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("\t    □\t\t □□□□\t□        □\t□□□□□□\t□\t□\t□□□□\t□□□□□");
            Console.WriteLine("\t  □  □\t □\t □ \t □      □\t     □\t\t□\t□\t□\t□\t□");
            Console.WriteLine("\t □    □\t □\t  □\t  □    □\t     □\t\t□\t□\t□□□□\t□");
            Console.WriteLine("\t□□□□□\t □\t  □\t   □  □\t     □\t\t□\t□\t□  □\t\t□□□□□");
            Console.WriteLine("\t□      □\t □\t □\t    □□\t     □\t\t□\t□\t□    □\t□");
            Console.WriteLine("\t□      □\t □□□□\t     □\t\t     □\t\t□□□□□\t□      □\t□□□□□");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
        public void BlingStartView()
        {
            for (int i = 0; i < 15; i++)
            {
                StartPrint();
                Thread.Sleep(100);
                Console.Clear();
                StartPrint2();
                Thread.Sleep(100);
                Console.Clear();
            }
            StartPrint();
            Console.WriteLine("\t\t\t\t\t\tPress Any Button");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
