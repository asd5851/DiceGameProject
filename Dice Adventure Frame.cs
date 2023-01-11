using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceAdventure
{
    public class FrameView
    {
        private int board_w = 50;
        private int board_h = 30;
        // 게임의 틀
        public void Frame(int Width, int Height)
        {
            int main_width = Width + 2;
            int main_height = Height + 1;

            for (int i = 1; i <= main_width; i++)
            {
                Console.SetCursorPosition(i, 1);
                if (i == main_width)
                {
                    Console.Write("┐");
                }
                else if (i == 1)
                {
                    Console.Write("┌");
                }
                else
                    Console.Write("─");

            }
            for (int i = 1; i < main_width; i++)
            {
                Console.SetCursorPosition(i, main_height);

                Console.Write("─");
            }
            for (int i = 2; i <= main_height; i++)
            {
                Console.SetCursorPosition(1, i);
                if (i == 2)
                {
                    Console.Write("┌");
                }

                //Console.Write("│");
            }

            for (int i = 2; i <= main_height; i++)
            {
                Console.SetCursorPosition(main_width, i);
                if (i == 2)
                {
                    //Console.WriteLine("┐");
                }
                Console.Write("│");
            }

            for (int i = main_height; i < main_height + Height / 2; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("│");
            }
            for (int i = main_height; i < main_height + Height / 2; i++)
            {
                Console.SetCursorPosition(main_width, i);
                Console.Write("│");
            }
            for (int i = 1; i <= main_width; i++)
            {
                Console.SetCursorPosition(i, main_height + Height / 2);
                if (i == main_width)
                {
                    Console.Write("┘");
                }
                else if(i == main_width / 4)
                {
                    Console.Write("┬");
                }
                else
                {
                    Console.Write("─");

                }
            }
            for (int i = 2; i < main_height + Height; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("│");
            }
            for (int i = main_height + Height / 2 + 1; i < main_height + Height; i++)
            {
                Console.SetCursorPosition(main_width / 4, i);
                Console.Write("│");
            }
            for (int i = 1; i <= main_width / 4; i++)
            {

                Console.SetCursorPosition(i, main_height + Height);
                if (i == 1)
                {
                    Console.Write("└");
                }
                else if (i == main_width / 4)
                {
                    Console.Write("┘");
                }
                else
                {

                    Console.Write("─");
                }
            }
            Console.WriteLine();
            Console.WriteLine();

        }

        // 주사위의 틀
        protected void DiceFrame(int Width, int Height)
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
        }

        // 주사위의 틀 + 게임의 틀
        protected void DiceView(int Width, int Height)
        {
            DiceFrame(Width, Height);
            Frame(Width, Height);
        }

        public void MiniGameFrame()
        {
            for (int i = 5; i <= (board_w); i++)
            {
                Console.SetCursorPosition(i * 2, 5);
                Console.Write("□");
            }
            for (int i = 5; i <= (board_w); i++)
            {
                Console.SetCursorPosition(i * 2, (board_h));
                Console.Write("□");
            }
            for (int i = 5; i <= (board_h); i++)
            {
                Console.SetCursorPosition(5 * 2, i);
                Console.Write("□");
            }
            for (int i = 5; i <= (board_h); i++)
            {
                Console.SetCursorPosition(board_w * 2, i);
                Console.Write("□");
            }
        }

    }
}
