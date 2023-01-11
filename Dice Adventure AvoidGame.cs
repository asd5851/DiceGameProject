using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DiceAdventure
{
    /*
     * 피하는 객체
     * 움직임
     * 
     * 피해야되는 객체
     * 움직임
     * 
     * 로직
     * 판
     */
    public class AvoidGame
    {
        static Random random = new Random();
        Player player = new Player();
        ConsoleKeyInfo keyinfo = new ConsoleKeyInfo();
        View view = new View();
        char key;
        static int[] lst = new int[24];
        static int[] lst2 = new int[24];
        int X, Y;
        int Width = 30;
        int Height = 30;
        static int time_cnt = 300;
        bool win;
        struct collison
        {
            public int sub_x, sub_y;
        }
        collison[] subX = new collison[10]; // x고정 y변동 (가로)
        collison[] subY = new collison[10];
        collison[] tempX = new collison[10];
        collison[] tempY = new collison[10];
        public void LstInit1()
        {
            for (int i = 0; i < lst.Length - 5; i++)
            {
                lst[i] = i + 5;
            }

            for (int i = 0; i < 100; i++)
            {
                int s_idx = random.Next(0, lst.Length);
                int d_idx = random.Next(0, lst.Length);
                int temp = lst[s_idx];
                lst[s_idx] = lst[d_idx];
                lst[d_idx] = temp;
            }
        }            
        public void LstInit2()
        {

            for (int i = 0; i < lst2.Length - 5; i++) // 24 - 5 = 19
            {
                lst2[i] = i + 5; // 0 ~ 19 => 5 ~ 24
            }
            for (int i = 0; i < 100; i++)
            {
                int s_idx2 = random.Next(0, lst2.Length);
                int d_idx2 = random.Next(0, lst2.Length);
                int temp2 = lst2[s_idx2];
                lst2[s_idx2] = lst2[d_idx2];
                lst2[d_idx2] = temp2;
            }

        }
    
        public void Subinit1()
        {
            
            for (int i = 0; i < 10; i++)
            {
                LstInit1();
                subY[i].sub_x = lst[i];
                subY[i].sub_y = 5;
            }
        }
        public void Subinit2()
        {
            for (int i = 0; i < 10; i++)
            {
                LstInit2();
                subX[i].sub_x = 5;
                subX[i].sub_y = lst2[i];
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
        public void WritePoint(int x, int y, bool show, bool sub)
        {
            Console.SetCursorPosition(x * 2, y);
            if (show && !sub)
            {
                Console.Write("▣");

            }
            else if (show && sub)
            {
                Console.Write("■");
            }
            else
            {
                Console.Write("  ");
            }
        }
        public void MainLogic()
        {
            Console.Clear();
            X = 25;
            Y = 15;
            bool gameend = false;
            while (true)
            {

                time_cnt--;
                WritePoint(X, Y, false, false); // 플레이어 안보임
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
                if(X== 5 || X== 30 || Y == 5 || Y == 30)
                {
                    break;
                }
                for(int i=0;i<10; i++)
                {
                    WritePoint(subX[i].sub_x,subX[i].sub_y, true, true); // 서브그려!
                    WritePoint(subY[i].sub_x, subY[i].sub_y, true, true); // 서브그려!
                    WritePoint(tempX[i].sub_x, tempX[i].sub_y, false, false);   // 기존 서브위치 지워!
                    WritePoint(tempY[i].sub_x, tempY[i].sub_y, false, false);   // 기존 서브위치 지워!
                }
                for (int i = 0; i < 10; i++) 
                {
                    if ((X == subX[i].sub_x && Y == subX[i].sub_y) || (X == subY[i].sub_x && Y == subY[i].sub_y))
                    {
                        gameend = true;
                        break;
                    }
                }
                if (gameend)
                {
                    win = false;
                    //EndAvoid(false);
                    break;
                }
                
                // 기존 서브위치 저장해!
                for(int i = 0; i < 10; i++)
                {
                    tempX[i].sub_x = subX[i].sub_x;
                    tempX[i].sub_y = subX[i].sub_y;

                    tempY[i].sub_x = subY[i].sub_x;
                    tempY[i].sub_y = subY[i].sub_y;
                }

                SubLogic();// 서브 움직여!

                // 서브가 밖으로 나가버리면 
                for(int i=0; i < 10; i++)
                {
                    /* 없애고 다시생성 */
                    if (subX[i].sub_x == 5 || subX[i].sub_x == 30)
                    {
                        Subinit1();                       
                    }
                    if (subY[i].sub_y == 5 || subY[i].sub_y == 30)
                    {
                        Subinit2();
                    }
                }
                AvoidMap();
                Console.SetCursorPosition(3, 3);
                Console.WriteLine(time_cnt);
                if(time_cnt <= 0)
                {
                    win = true;
                    //EndAvoid(true);
                    break;
                }
                Thread.Sleep(50);
            }

        }
        public void SubLogic()
        {        
            int rand_x = random.Next(5, 48 + 1);
            int rand_y = random.Next(5, 48 + 1);
            // 1 : 왼쪽 -> 오른쪽 2 : 오른쪽 -> 왼쪽 3: 위 -> 밑 4: 밑 -> 위
            int dir = 1;
            int dir2 = 4;
            for(int i=0;i<10; i++)
            {
                if (dir == 1)
                {
                    subX[i].sub_x++;
                }
                else if (dir == 2)
                {
                    subX[i].sub_x--;
                }
                if (dir2 == 4)
                {
                    subY[i].sub_y++;
                }
                else if(dir2 == 6)
                {
                    subY[i].sub_y--;
                }
            }
        }
        public void StartAvoid()
        {
            Console.Clear();
            Console.SetCursorPosition(Width / 2, Height / 2 - 4);
            Console.WriteLine("피하기 게임");
            Console.SetCursorPosition(Width / 2, Height / 2 - 2);
            Console.WriteLine("피하기 게임을 시작합니다.");
            Console.SetCursorPosition(Width / 2, Height / 2 );
            Console.WriteLine("주어진 시간안에 버티면 승리 못버티면 패배");
            Console.SetCursorPosition(Width / 2, Height / 2 + 2);
            Console.WriteLine("승리할 경우 체력이 +1 증가하며");
            Console.SetCursorPosition(Width / 2, Height / 2 + 4);
            Console.WriteLine("사망했을경우 체력이 -1 깎입니다.");
            AvoidMap();
            Console.ReadKey();
        }
        //public void EndAvoid(bool win)
        //{
        //    if (win)
        //    {
        //        view.ShowWin(player, 50, 30);
        //    }
        //    else
        //    {
        //        view.ShowLoose(player, 50, 30);
        //    }
        //    view.MiniGameFrame();
        //}
        public void AvoidMap()
        {
            for (int i = 5; i <= (30); i++)
            {
                Console.SetCursorPosition(i * 2, 5);
                Console.Write("□");
            }
            for (int i = 5; i <= (30); i++)
            {
                Console.SetCursorPosition(i * 2, (30));
                Console.Write("□");
            }
            for (int i = 5; i <= (30); i++)
            {
                Console.SetCursorPosition(5 * 2, i);
                Console.Write("□");
            }
            for (int i = 5; i <= (30); i++)
            {
                Console.SetCursorPosition(30 * 2, i);
                Console.Write("□");
            }
        }
        public bool AvoidMain()
        {
            Console.Clear();
            time_cnt = 300;
            StartAvoid();
            Subinit1();
            Subinit2();
            MainLogic();
            if (win)
            {
                return true;
            }
            else
                return false;
        }

    }
}
