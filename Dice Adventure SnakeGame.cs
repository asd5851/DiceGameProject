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
        Random random = new Random();
        ConsoleKeyInfo keyinfo = new ConsoleKeyInfo();

        int Height = 20;
        int Width = 30;

        static int[] snake_X = new int[50];
        static int[] snake_Y = new int[50];
        int item_X; // 아이템의 x좌표
        int item_Y; // 아이템의 y좌표
        char key;
        public int snake_length = 3; // 처음 뱀의 길이

        // 생성자 : 초기에 생성할떄 이렇게 생성이 된다 (규율)
        // 시작위치는 5,5 아이템의 위치는  2 ~ 28 랜덤
        public SnakeGAME()
        {
            snake_X[0] = 5;
            snake_Y[0] = 5;
            Console.CursorVisible = false;
            item_X = random.Next(2, (30 - 2));
            item_Y = random.Next(2, (20 - 2));

        }
        public void SnakeBoard(int board_w, int board_h)
        {

            for (int i = 1; i <= (board_w); i++)
            {
                Console.SetCursorPosition(i*2, 1);
                Console.Write("□");
            }
            for (int i = 1; i <= (board_w); i++)
            {
                Console.SetCursorPosition(i*2, (board_h));
                Console.Write("□");
            }
            for (int i = 1; i <= (board_h); i++)
            {
                Console.SetCursorPosition(1*2, i);
                Console.Write("□");
            }
            for (int i = 1; i <= (board_h); i++)
            {
                Console.SetCursorPosition(board_w*2, i);
                Console.Write("□");
            }

        }
        public void Input()
        {
            if (Console.KeyAvailable)
            {
                keyinfo = Console.ReadKey(true);
                key = keyinfo.KeyChar;
            }
        }
        public void WritePoint(int x, int y, bool item)
        {
            Console.SetCursorPosition(x * 2, y);
            Console.Write("○");
        }
        public void Logic()
        {

            if (snake_X[0] == item_X)
            {
                if (snake_Y[0] == item_Y)
                {
                    snake_length++;

                    item_X = random.Next(2, (30 - 2));
                    item_Y = random.Next(2, (20 - 2));
                }
            }
            for (int i = snake_length; i > 1; i--)
            {
                snake_X[i - 1] = snake_X[i - 2]; // [2] = [1], [1] = [0]
                snake_Y[i - 1] = snake_Y[i - 2];
            }


            switch (key)
            {
                case 'w':
                    snake_Y[0]--;
                    break;
                case 's':
                    snake_Y[0]++;
                    break;
                case 'd':
                    snake_X[0]++;
                    break;
                case 'a':
                    snake_X[0]--;
                    break;
            }
            for (int i = 0; i <= (snake_length - 1); i++)
            {
                if(snake_X[i] == 50 || snake_Y[i] == 20 || snake_X[i] == 1 || snake_Y[i] == 1)
                {
                    break;
                }
                WritePoint(snake_X[i], snake_Y[i], false);
                WritePoint(item_X, item_Y, true);


            }

            Thread.Sleep(100);
        }


        public void SnakeMain()
        {
            SnakeGAME snake = new SnakeGAME();
            snake_Y[0] = 5; // 시작 x좌표
            snake_X[0] = 5; // 시작 y좌표
            item_X = random.Next(2, (15));
            item_Y = random.Next(2, (15));
            while (true)
            {
                snake.SnakeBoard(50, 20);
                snake.Input();
                snake.Logic();
            }
            Console.ReadKey();
        }
    }
}
// 
// ●○○ ->  ●○○○
//  6 5 4       ●○○
//  0 1 2
// ○○●
//  4 5 6
//  2 1 0
