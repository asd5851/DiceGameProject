using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceAdventure
{
    public class View
    {
        public void StartView()
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
        public void StartView2()
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
                StartView();
                Thread.Sleep(100);
                Console.Clear();
                StartView2();
                Thread.Sleep(100);
                Console.Clear();
            }
            StartView();
            Console.WriteLine("\t\t\t\t\t\tPress Any Button");
            Console.ReadLine();
        }
        public void ShowMap(int start_height, int end_height, int width)
        {
            
            for(int i = start_height;i<end_height ; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("|");
            }
            for (int i = start_height; i < end_height; i++)
            {
                Console.SetCursorPosition(width+2, i);
                Console.Write("|");
            }
            for (int i = 4; i <= width - 3; i++)
            {
                Console.SetCursorPosition(i, (start_height + end_height) / 2 + 2);
                Console.Write("□");
            }
            for (int i = 1; i <= (width + 2); i++)
            {
                Console.SetCursorPosition(i, end_height);
                Console.Write("-");
            }
        }
        public void RollDiceOne(int Width, int Height)
        {
            Console.Clear();
            for (int i = Width / 2 - Height / 2; i <= Width / 2 + Height / 2; i++)
            {
                Console.SetCursorPosition(i, 2);
                Console.Write("□");
            }
            for (int i = Width / 2 - Height / 2; i <= Width / 2 + Height / 2; i++)
            {
                Console.SetCursorPosition(i, Height - 2);
                Console.Write("□");
            }
            for (int i = Height / 2 - Height / 4; i <= Height / 2 + Height / 4 + 1; i++)
            {
                Console.SetCursorPosition(Width / 2 - Height / 2, i);
                Console.Write("□");
            }
            for (int i = Height / 2 - Height / 4; i <= Height / 2 + Height / 4 + 1; i++)
            {
                Console.SetCursorPosition(Width / 2 + Height / 2, i);
                Console.Write("□");
            }
            Console.SetCursorPosition(Width / 2, Height / 2);
            Console.Write("■");
            for (int i = 1; i <= (Width + 2); i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("-");
            }
            for (int i = 1; i <= (Width + 2); i++)
            {
                Console.SetCursorPosition(i, (Height + 1));
                Console.Write("-");
            }
            for (int i = 1; i <= (Height + 1); i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("|");
            }
            for (int i = 1; i <= (Height + 1); i++)
            {
                Console.SetCursorPosition((Width + 2), i);
                Console.Write("|");
            }

        }
        public void RollDiceTwo(int Width, int Height)
        {
            Console.Clear();
            for (int i = Width / 2 - Height / 2; i <= Width / 2 + Height / 2; i++)
            {
                Console.SetCursorPosition(i, 2);
                Console.Write("□");
            }
            for (int i = Width / 2 - Height / 2; i <= Width / 2 + Height / 2; i++)
            {
                Console.SetCursorPosition(i, Height - 2);
                Console.Write("□");
            }
            for (int i = Height / 2 - Height / 4; i <= Height / 2 + Height / 4 + 1; i++)
            {
                Console.SetCursorPosition(Width / 2 - Height / 2, i);
                Console.Write("□");
            }
            for (int i = Height / 2 - Height / 4; i <= Height / 2 + Height / 4 + 1; i++)
            {
                Console.SetCursorPosition(Width / 2 + Height / 2, i);
                Console.Write("□");
            }
            Console.SetCursorPosition(Width / 2 - 2, Height / 2);
            Console.Write("■");

            Console.SetCursorPosition(Width / 2 + 2, Height / 2);
            Console.Write("■");
            for (int i = 1; i <= (Width + 2); i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("-");
            }
            for (int i = 1; i <= (Width + 2); i++)
            {
                Console.SetCursorPosition(i, (Height + 1));
                Console.Write("-");
            }
            for (int i = 1; i <= (Height + 1); i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("|");
            }
            for (int i = 1; i <= (Height + 1); i++)
            {
                Console.SetCursorPosition((Width + 2), i);
                Console.Write("|");
            }

        }

        public void RollDiceThree(int Width, int Height)
        {
            Console.Clear();
            for (int i = Width / 2 - Height / 2; i <= Width / 2 + Height / 2; i++)
            {
                Console.SetCursorPosition(i, 2);
                Console.Write("□");
            }
            for (int i = Width / 2 - Height / 2; i <= Width / 2 + Height / 2; i++)
            {
                Console.SetCursorPosition(i, Height - 2);
                Console.Write("□");
            }
            for (int i = Height / 2 - Height / 4; i <= Height / 2 + Height / 4 + 1; i++)
            {
                Console.SetCursorPosition(Width / 2 - Height / 2, i);
                Console.Write("□");
            }
            for (int i = Height / 2 - Height / 4; i <= Height / 2 + Height / 4 + 1; i++)
            {
                Console.SetCursorPosition(Width / 2 + Height / 2, i);
                Console.Write("□");
            }
            Console.SetCursorPosition(Width / 2 - 2, Height / 2 + 1);
            Console.Write("■");

            Console.SetCursorPosition(Width / 2 + 2, Height / 2 + 1);
            Console.Write("■");

            Console.SetCursorPosition(Width / 2, Height / 2 - 1);
            Console.Write("■");
            for (int i = 1; i <= (Width + 2); i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("-");
            }
            for (int i = 1; i <= (Width + 2); i++)
            {
                Console.SetCursorPosition(i, (Height + 1));
                Console.Write("-");
            }
            for (int i = 1; i <= (Height + 1); i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("|");
            }
            for (int i = 1; i <= (Height + 1); i++)
            {
                Console.SetCursorPosition((Width + 2), i);
                Console.Write("|");
            }
        }
        public void RollDiceFour(int Width, int Height)
        {
            Console.Clear();
            for (int i = Width / 2 - Height / 2; i <= Width / 2 + Height / 2; i++)
            {
                Console.SetCursorPosition(i, 2);
                Console.Write("□");
            }
            for (int i = Width / 2 - Height / 2; i <= Width / 2 + Height / 2; i++)
            {
                Console.SetCursorPosition(i, Height - 2);
                Console.Write("□");
            }
            for (int i = Height / 2 - Height / 4; i <= Height / 2 + Height / 4 + 1; i++)
            {
                Console.SetCursorPosition(Width / 2 - Height / 2, i);
                Console.Write("□");
            }
            for (int i = Height / 2 - Height / 4; i <= Height / 2 + Height / 4 + 1; i++)
            {
                Console.SetCursorPosition(Width / 2 + Height / 2, i);
                Console.Write("□");
            }
            Console.SetCursorPosition(Width / 2 - 2, Height / 2 + 1);
            Console.Write("■");
            Console.SetCursorPosition(Width / 2 - 2, Height / 2 - 1);
            Console.Write("■");
            Console.SetCursorPosition(Width / 2 + 2, Height / 2 + 1);
            Console.Write("■");
            Console.SetCursorPosition(Width / 2 + 2, Height / 2 - 1);
            Console.Write("■");
            
            for (int i = 1; i <= (Width + 2); i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("-");
            }
            for (int i = 1; i <= (Width + 2); i++)
            {
                Console.SetCursorPosition(i, (Height + 1));
                Console.Write("-");
            }
            for (int i = 1; i <= (Height + 1); i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("|");
            }
            for (int i = 1; i <= (Height + 1); i++)
            {
                Console.SetCursorPosition((Width + 2), i);
                Console.Write("|");
            }
        }
        public void RollDiceFive(int Width, int Height)
        {
            Console.Clear();
            for (int i = Width / 2 - Height / 2; i <= Width / 2 + Height / 2; i++)
            {
                Console.SetCursorPosition(i, 2);
                Console.Write("□");
            }
            for (int i = Width / 2 - Height / 2; i <= Width / 2 + Height / 2; i++)
            {
                Console.SetCursorPosition(i, Height - 2);
                Console.Write("□");
            }
            for (int i = Height / 2 - Height / 4; i <= Height / 2 + Height / 4 + 1; i++)
            {
                Console.SetCursorPosition(Width / 2 - Height / 2, i);
                Console.Write("□");
            }
            for (int i = Height / 2 - Height / 4; i <= Height / 2 + Height / 4 + 1; i++)
            {
                Console.SetCursorPosition(Width / 2 + Height / 2, i);
                Console.Write("□");
            }
            Console.SetCursorPosition(Width / 2 - 3, Height / 2 + 2);
            Console.Write("■");
            Console.SetCursorPosition(Width / 2 - 3, Height / 2 - 2);
            Console.Write("■");
            Console.SetCursorPosition(Width / 2 + 3, Height / 2 + 2);
            Console.Write("■");
            Console.SetCursorPosition(Width / 2 + 3, Height / 2 - 2);
            Console.Write("■");
            Console.SetCursorPosition(Width / 2, Height / 2);
            Console.Write("■");

            for (int i = 1; i <= (Width + 2); i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("-");
            }
            for (int i = 1; i <= (Width + 2); i++)
            {
                Console.SetCursorPosition(i, (Height + 1));
                Console.Write("-");
            }
            for (int i = 1; i <= (Height + 1); i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("|");
            }
            for (int i = 1; i <= (Height + 1); i++)
            {
                Console.SetCursorPosition((Width + 2), i);
                Console.Write("|");
            }
        }
        public void RollDiceSix(int Width, int Height)
        {
            Console.Clear();
            for (int i = Width / 2 - Height / 2; i <= Width / 2 + Height / 2; i++)
            {
                Console.SetCursorPosition(i, 2);
                Console.Write("□");
            }
            for (int i = Width / 2 - Height / 2; i <= Width / 2 + Height / 2; i++)
            {
                Console.SetCursorPosition(i, Height - 2);
                Console.Write("□");
            }
            for (int i = Height / 2 - Height / 4; i <= Height / 2 + Height / 4 + 1; i++)
            {
                Console.SetCursorPosition(Width / 2 - Height / 2, i);
                Console.Write("□");
            }
            for (int i = Height / 2 - Height / 4; i <= Height / 2 + Height / 4 + 1; i++)
            {
                Console.SetCursorPosition(Width / 2 + Height / 2, i);
                Console.Write("□");
            }
            Console.SetCursorPosition(Width / 2 - 2, Height / 2 + 2);
            Console.Write("■");
            Console.SetCursorPosition(Width / 2 - 2, Height / 2 - 2);
            Console.Write("■");
            Console.SetCursorPosition(Width / 2 + 2, Height / 2 + 2);
            Console.Write("■");
            Console.SetCursorPosition(Width / 2 + 2, Height / 2 - 2);
            Console.Write("■");
            Console.SetCursorPosition(Width / 2 - 2, Height / 2);
            Console.Write("■");
            Console.SetCursorPosition(Width / 2 + 2, Height / 2);
            Console.Write("■");

            for (int i = 1; i <= (Width + 2); i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("-");
            }
            for (int i = 1; i <= (Width + 2); i++)
            {
                Console.SetCursorPosition(i, (Height + 1));
                Console.Write("-");
            }
            for (int i = 1; i <= (Height + 1); i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("|");
            }
            for (int i = 1; i <= (Height + 1); i++)
            {
                Console.SetCursorPosition((Width + 2), i);
                Console.Write("|");
            }
        }
    }
}
