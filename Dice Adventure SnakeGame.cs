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
        bool flag = true;
        int Height = 30;
        int Width = 50;
        static int item_cnt = 0;
        static int[] snake_X = new int[50];
        static int[] snake_Y = new int[50];
        int item_X; // 아이템의 x좌표
        int item_Y; // 아이템의 y좌표
        char key;
        public int snake_length = 2; // 처음 뱀의 길이

        // 생성자 : 초기에 생성할떄 이렇게 생성이 된다 (규율)
        // 시작위치는 5,5 아이템의 위치는  2 ~ 28 랜덤
        public SnakeGAME()
        {
            snake_X[0] = 5;
            snake_Y[0] = 5;
            item_X = random.Next(6, (50 - 2));
            item_Y = random.Next(6, (30 - 2));

        }
        public void StartSnake()
        {
            Console.Clear();
            Console.SetCursorPosition(Width / 2, Height / 2);
            Console.WriteLine("뱀 게임");
            Console.SetCursorPosition(Width / 2, Height / 2+1);
            Console.WriteLine("뱀 게임을 시작합니다.");
            Console.SetCursorPosition(Width / 2, Height / 2+2);
            Console.WriteLine("5개의 아이템을 먹으면 승리이며 벽에 부딪힐 경우 사망합니다.");
            Console.SetCursorPosition(Width / 2, Height / 2 + 3);
            Console.WriteLine("승리할 경우 체력이 +1 증가하며 사망했을경우 체력이 -1 깎입니다.");
            SnakeBoard(Width, Height);
            Console.ReadLine();
        }
        public void SnakeBoard(int board_w, int board_h)
        {
            for (int i = 5; i <= (board_w); i++)
            {
                Console.SetCursorPosition(i*2, 5);
                Console.Write("□");
            }
            for (int i = 5; i <= (board_w); i++)
            {
                Console.SetCursorPosition(i*2, (board_h));
                Console.Write("□");
            }
            for (int i = 5; i <= (board_h); i++)
            {
                Console.SetCursorPosition(5*2, i);
                Console.Write("□");
            }
            for (int i = 5; i <= (board_h); i++)
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
        public void WritePoint(int x, int y, bool item, string mark)
        {
            Console.SetCursorPosition(x*2, y);
            Console.Write(mark);
        }
        public bool Logic()
        {

            if (snake_X[0] == item_X)
            {
                if (snake_Y[0] == item_Y)
                {
                    snake_length++;
                    item_X = random.Next(6, (50 - 2));
                    item_Y = random.Next(6, (30 - 2));
                    item_cnt++;
                }
            }
            for (int i = snake_length - 1; i > 0; i--)
            {
                snake_X[i] = snake_X[i - 1]; // [2] = [1], [1] = [0]
                snake_Y[i] = snake_Y[i - 1];
            }
            // ●○○
            //●○○○ 
            //[0] 5 10 [1] 5 10
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
            // [0] 4 10
            Console.WriteLine(snake_length);
            for (int i = 0; i < (snake_length); i++)
            {
                if (snake_X[i]  == 50 || snake_Y[i]  == 30 || snake_X[i]  == 5 || snake_Y[i]  == 5)
                {
                    flag = false;
                }
                
                WritePoint(snake_X[i], snake_Y[i], false, "●");
                WritePoint(item_X, item_Y, true,"★");
            }
            WritePoint(snake_X[snake_length - 1], snake_Y[snake_length-1], true,"  ");
            Thread.Sleep(100);
            return flag;
        }


        public bool SnakeMain()
        {
            SnakeGAME snake = new SnakeGAME();
            snake_Y[0] = 10; // 시작 x좌표
            snake_X[0] = 10; // 시작 y좌표

            snake_Y[1] = 10;
            snake_X[1] = 11;

            snake_Y[2] = 10;
            snake_X[2] = 12;
            item_cnt= 0;
            snake_length = 2;
            item_X = random.Next(2, (15));
            item_Y = random.Next(2, (15));
            WritePoint(10, 10,true ,"●");
            StartSnake();
            Console.Clear();
            while (true)
            {
                snake.SnakeBoard(50, 30);
                snake.Input();
                
                if (snake.Logic() == false)
                {
                    return false;
                    break;
                }
                else if(item_cnt >= 5)
                {
                    return true;
                    break;
                }
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
