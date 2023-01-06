using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DiceAdventure
{
    public class View
    {
        Rabbit rabbit = new Rabbit();
        Wolf wolf = new Wolf();
        Goblin goblin = new Goblin();
        Troll troll = new Troll();
        Golem golem = new Golem();
        Dragon dragon = new Dragon();
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
            Console.Clear();
        }
        public void Frame(int Width, int Height)
        {
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

            for (int i = Height + 1; i < Height + 1 + Height / 2; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("|");
            }
            for (int i = Height + 1; i < Height + 1 + Height / 2; i++)
            {
                Console.SetCursorPosition(Width + 2, i);
                Console.Write("|");
            }
            for (int i = 1; i <= (Width + 2); i++)
            {
                Console.SetCursorPosition(i, Height + 1 + Height / 2);
                Console.Write("-");
            }
            Console.WriteLine();
            Console.WriteLine();

        }
        public void WaitView(int Width, int Height)
        {

            Frame(Width, Height);
        }
        public void DiceFrame(int Width, int Height)
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
        public void DiceFrame2(int Width, int Height)
        {
            Console.Clear();

        }
        public void DiceView(int Width, int Height)
        {
            DiceFrame(Width, Height);
            Frame(Width, Height);
        }

        // 주사위를 굴려주세요 라는 메시지를 출력한다.
        public void MessageDice(int Width, int Height)
        {
            Console.Clear();
            Console.SetCursorPosition(Width / 2 - Width / 8, Height / 3 + 1);
            Console.WriteLine("   주사위를 굴려 주세요   ");
            Console.SetCursorPosition(Width / 2 - Width / 8, Height / 3 + 4);
            Console.WriteLine("      Press Any Key");
            Frame(Width, Height);
            Console.ReadLine();


        }

        public void PrintForward(int Width, int Height)
        {
            Console.SetCursorPosition(Width / 2, Height / 2);

            Console.WriteLine("좋은 신발을 발견했습니다.");
            Console.SetCursorPosition(Width / 2, Height / 2 + 1);
            Console.WriteLine("앞으로 전진 합니다!");
            Frame(Width, Height);

        }
        public void PrintBack(int Width, int Height)
        {
            Console.SetCursorPosition(Width / 2, Height / 2);
            Console.WriteLine("플레이어 : 으엑 똥 밟았다.");
            Console.SetCursorPosition(Width / 2, Height / 2 + 1);
            Console.WriteLine("똥을 밟아서 미끄러졌습니다.");
            Console.SetCursorPosition(Width / 2, Height / 2 + 1);
            Console.WriteLine("뒤로 후퇴합니다.");
            Frame(Width, Height);
        }

        // 주사위의 틀
        
        // 지도상에서 플레이어의 위치를 보여준다.
        public void PlayerView(int Width, int Height, int location, int playerx)
        {
            for (int i = 0; i <= location * 2; i++)
            {
                Console.SetCursorPosition(playerx + i, Height + Height / 3);
                if (i % 2 == 0)
                    Console.Write("☆");
                else
                    Console.Write("★");
                Frame(Width, Height);
                Thread.Sleep(500);
            }
            Thread.Sleep(500);
        }

        public void PlayerBackView(int Width, int Height, int location, int playerx)
        {
            for (int i = 0; i <= location * 2; i++)
            {
                Console.SetCursorPosition(playerx - i, Height + Height / 3);
                if (i % 2 == 0)
                    Console.Write("☆");
                else
                    Console.Write("★");
                Frame(Width, Height);
                Thread.Sleep(500);
            }

        }

        // 지도를 보여준다.
        public void ShowMap(int Width, int Height, int location, int playerx, bool front)
        {
            if (front)
            {
                for (int i = Width / 2 - Width / 4; i <= Width / 2 + Width / 4; i++)
                {
                    Console.SetCursorPosition(i, Height + Height / 3 + 1);
                    Console.Write("□");
                }
                Console.WriteLine();
                PlayerView(Width, Height, location, playerx);
            }
            else
            {
                for (int i = Width / 2 - Width / 4; i <= Width / 2 + Width / 4; i++)
                {
                    Console.SetCursorPosition(i, Height + Height / 3 + 1);
                    Console.Write("□");
                }
                Console.WriteLine();
                PlayerBackView(Width, Height, location, playerx);
            }


        }

        // 무슨 주사위가 나왔느냐에 따라서 주사위의 View를 보여준다.
        public void RollDiceOne(int Width, int Height, int location, bool move, int playerx)
        {
            Console.Clear();
            DiceFrame(Width, Height);
            Console.SetCursorPosition(Width / 2, Height / 2);
            Console.Write("■");
            // 움직일때만 맵을 출력한다.
            if (move)
            {
                ShowMap(Width, Height, location, playerx, true);
            }
            Frame(Width, Height);
           Thread.Sleep(500);

        }
        public void RollDiceTwo(int Width, int Height, int location, bool move, int playerx)
        {
            Console.Clear();
            DiceFrame(Width, Height);
            Console.SetCursorPosition(Width / 2 - 2, Height / 2);
            Console.Write("■");

            Console.SetCursorPosition(Width / 2 + 2, Height / 2);
            Console.Write("■");
            if (move)
                ShowMap(Width, Height, location, playerx, true);

            Frame(Width, Height);
            Console.ReadLine();


        }
        public void RollDiceThree(int Width, int Height, int location, bool move, int playerx)
        {
            Console.Clear();
            DiceFrame(Width, Height);
            Console.SetCursorPosition(Width / 2 - 2, Height / 2 + 1);
            Console.Write("■");

            Console.SetCursorPosition(Width / 2 + 2, Height / 2 + 1);
            Console.Write("■");

            Console.SetCursorPosition(Width / 2, Height / 2 - 1);
            Console.Write("■");
            if (move)
                ShowMap(Width, Height, location, playerx, true);
            Frame(Width, Height);
            Console.ReadLine();

        }
        public void RollDiceFour(int Width, int Height, int location, bool move, int playerx)
        {
            Console.Clear();
            DiceFrame(Width, Height);
            Console.SetCursorPosition(Width / 2 - 2, Height / 2 + 1);
            Console.Write("■");
            Console.SetCursorPosition(Width / 2 - 2, Height / 2 - 1);
            Console.Write("■");
            Console.SetCursorPosition(Width / 2 + 2, Height / 2 + 1);
            Console.Write("■");
            Console.SetCursorPosition(Width / 2 + 2, Height / 2 - 1);
            Console.Write("■");
            if (move)
                ShowMap(Width, Height, location, playerx, true);

            Frame(Width, Height);
            Console.ReadLine();

        }
        public void RollDiceFive(int Width, int Height, int location, bool move, int playerx)
        {
            Console.Clear();
            DiceFrame(Width, Height);
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
            if (move)
                ShowMap(Width, Height, location, playerx, true);
            Frame(Width, Height);
            Console.ReadLine();

        }
        public void RollDiceSix(int Width, int Height, int location, bool move, int playerx)
        {
            Console.Clear();
            DiceFrame(Width, Height);
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
            if (move)
                ShowMap(Width, Height, location, playerx, true);

            Frame(Width, Height);
            Console.ReadLine();
        }

        // 출력문을 시작할 위치설청
        public void MonsterMessage(int Width, int Height, int monster_num)
        {

            Console.SetCursorPosition(1, Height / 2);
            switch (monster_num)
            {
                case 1:
                    rabbit.Script();
                    break;
                case 2:
                    wolf.Script();
                    break;
                case 3:
                    goblin.Script();
                    break;
                case 4:
                    troll.Script();
                    break;
                case 5:
                    golem.Script();
                    break;
                case 6:
                    dragon.Script();
                    break;
            }
            Frame(Width, Height);
            Console.ReadLine();

        }
        public void MonsterCompareView(ref Player player, int Width, int Height, int compare_monster, int monster_hp)
        {
            Console.Clear();
            Console.SetCursorPosition(1, Height / 2);

            if (monster_hp < compare_monster) // 내 주사위가 몬스터의 체력보다 크다면
            {
                switch (monster_hp)
                {
                    case 1:
                        rabbit.PlayerWin();
                        break;
                    case 2:
                        wolf.PlayerWin();
                        break;
                    case 3:
                        goblin.PlayerWin();
                        break;
                    case 4:
                        troll.PlayerWin();
                        break;
                    case 5:
                        golem.PlayerWin();
                        break;
                    case 6:
                        dragon.PlayerWin();
                        break;
                }
            }
            else
            {
                switch (monster_hp)
                {
                    case 1:
                        rabbit.PlayerLoose();
                        player.Location = player.Location - (monster_hp - compare_monster) * 2;
                        player.HP = player.HP - (monster_hp - compare_monster);
                        ShowMap(Width, Height, 0, player.Location, false);
                        break;
                    case 2:
                        wolf.PlayerLoose();
                        player.Location = player.Location - (monster_hp - compare_monster) * 2;
                        player.HP = player.HP - (monster_hp - compare_monster);

                        ShowMap(Width, Height, 0, player.Location, false);
                        break;
                    case 3:
                        goblin.PlayerLoose();
                        player.Location = player.Location - (monster_hp - compare_monster) * 2;
                        player.HP = player.HP - (monster_hp - compare_monster);

                        ShowMap(Width, Height, 0, player.Location, false);
                        break;
                    case 4:
                        troll.PlayerLoose();
                        player.Location = player.Location - (monster_hp - compare_monster) * 2;
                        player.HP = player.HP - (monster_hp - compare_monster);

                        ShowMap(Width, Height, 0, player.Location, false);
                        break;
                    case 5:
                        golem.PlayerLoose();
                        player.Location = player.Location - (monster_hp - compare_monster) * 2;
                        player.HP = player.HP - (monster_hp - compare_monster);

                        ShowMap(Width, Height, 0, player.Location, false);
                        break;
                    case 6:
                        dragon.PlayerLoose();
                        player.Location = player.Location - (monster_hp - compare_monster) * 2;
                        player.HP = player.HP - (monster_hp - compare_monster);

                        ShowMap(Width, Height, 0, player.Location, false);
                        break;
                }
            }
            Frame(Width, Height);

            Console.ReadLine();
        }
    }
}
