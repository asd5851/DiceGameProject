using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceAdventure
{
    public class SnakeGAME
    {
        /*
         * 뱀게임
         * wasd로 뱀게임을 진행한다.
         * 
         */
        Program program = new Program();
        View view = new View();
        char[] snake_x = new char[5];
        char[] snake_y = new char[5];
        int target_x = 5;
        int target_y = 5;
        public void SnakeBoard(int board_w, int board_h)
        {
            for (int i = 1; i <= (board_w); i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("□");
            }
            for (int i = 1; i <= (board_w); i++)
            {
                Console.SetCursorPosition(i, (board_h) * 2);
                Console.Write("□");
            }
            for (int i = 1; i <= (board_h) * 2; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("□");
            }
            for (int i = 1; i <= (board_h) * 2; i++)
            {
                Console.SetCursorPosition((board_w + 2), i);
                Console.Write("□");
            }
        }
        public void SnakeInit()
        {
            
        }
        public void SnakeBody(int y, int x)
        {
            Console.SetCursorPosition(y, x);
            Console.Write('●');
        }
        public void SnakeLogic()
        {

        }
        public void SnakeInput(int y, int x)
        {
            ConsoleKeyInfo cki;
            cki = Console.ReadKey();
            switch (cki.Key)
            {
                case ConsoleKey.UpArrow:
                    snake_y[y - 1] = snake_y[y];
                    SnakeBody(snake_y[y - 1], snake_x[x]);
                    break;
                case ConsoleKey.DownArrow:
                    snake_y[y + 1] = snake_y[y];
                    SnakeBody(snake_y[y - 1], snake_x[x]);
                    break;
                case ConsoleKey.LeftArrow:
                    snake_x[x-1] = snake_x[x];
                    SnakeBody(snake_y[y], snake_x[x-1]);
                    break;
                case ConsoleKey.RightArrow:
                    snake_x[x+1] = snake_x[x];
                    SnakeBody(snake_y[y], snake_x[x+1]);
                    break;
            }
        }
    }
}
