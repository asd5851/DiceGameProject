using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DiceAdventure
{
    public class ShootingGame
    {
        Random random = new Random();
        int X = 10;
        int Y = 10;
        int b_X = 10;
        int b_Y = 10;
        int temp_y = 0;
        int temp_x = 0;
        int item_x = 25, item_y = 9;
        static int shot_cnt = 0;
        int Width = 50;
        int Height = 30;
        bool win = false;
        FrameView view = new FrameView();
        ConsoleKeyInfo keyinfo = new ConsoleKeyInfo();
        char key;
        public void ShottingLogic()
        {
            b_Y--;
        }
        public void Input()
        {
            if (Console.KeyAvailable)
            {
                keyinfo = Console.ReadKey(true);
                key = keyinfo.KeyChar;
            }
        }
        public void WriteItem(int x, int y)
        {
            Console.SetCursorPosition(2 * x, y);
            Console.Write("★");
        }
        public void WritePoint(int x, int y, bool show, bool bullet)
        {
            Console.SetCursorPosition(x * 2, y);
            if (show && !bullet)
            {
                Console.Write("▲");
            }
            else if (show && bullet)
            {
                Console.Write(".");
            }
            else
            {
                Console.Write("  ");
            }

        }
        public void StartShoot()
        {
            Console.Clear();
            Console.SetCursorPosition(Width / 2, Height / 2 - 4);
            Console.WriteLine("슈팅 게임");
            Console.SetCursorPosition(Width / 2, Height / 2 - 2);
            Console.WriteLine("슈팅 게임을 시작합니다.");
            Console.SetCursorPosition(Width / 2, Height / 2);
            Console.WriteLine("목표물을 10개 맞추면 승리 합니다.");
            Console.SetCursorPosition(Width / 2, Height / 2 + 2);
            Console.WriteLine("승리할 경우 체력이 +1 증가하며");
            Console.SetCursorPosition(Width / 2, Height / 2 + 4);
            Console.WriteLine("사망했을경우 체력이 -1 깎입니다.");
            Console.SetCursorPosition(Width / 2, Height / 2 + 6);
            Console.WriteLine("Press Any Key");
            view.MiniGameFrame();
            Console.ReadKey();
        }
        public bool ShootMain()
        {

            StartShoot();
            shot_cnt = 0;
            Console.Clear();
            bool go = false;
            while (true)
            {
                WritePoint(X, Y, false, false);
                if (b_X == item_x && b_Y == item_y)
                {
                    item_x = random.Next(6, 40 + 1);
                    item_y = random.Next(6, 20 + 1);
                    shot_cnt++;
                }
                WriteItem(item_x, item_y);
                Input();
                switch (key)
                {
                    case 'w':
                        Y--;
                        break;
                    case 's':
                        Y++;
                        break;
                    case 'd':
                        X++;
                        break;
                    case 'a':
                        X--;
                        break;
                }
                WritePoint(X, Y, true, false); // 입력받으면 움직인다.
                WritePoint(b_X, b_Y, true, true); // 총알그려!
                WritePoint(b_X, temp_y, false, false); // 총알흔적을지워!
                temp_y = b_Y;
                ShottingLogic(); // 쏘면 총알이 나간다.
                if (b_X == 5 || b_Y == 5 || b_Y == 30 || b_X == 50)
                {
                    WritePoint(b_X, temp_y, false, false);
                    b_X = X;
                    b_Y = Y - 1;
                }
                if (X == 5 || Y == 5 || Y == 30 || X == 50)
                {
                    win = false;
                    break;
                }
                if (shot_cnt >= 10)
                {
                    win = true;
                    break;
                }
                view.MiniGameFrame();
                Thread.Sleep(50);
            }
            if (win)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}

