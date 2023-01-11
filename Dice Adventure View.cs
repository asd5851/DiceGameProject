using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
/*
 * 모델이 가지고 있는 정보를 따로 저장하지 않는다.
 * 모델이나 컨트롤러와 같이 다른 구성요소들을 몰라야 한다.
 */
namespace DiceAdventure
{
    public class View : FrameView
    {
        Rabbit rabbit = new Rabbit();
        Wolf wolf = new Wolf();
        Goblin goblin = new Goblin();
        Troll troll = new Troll();
        Golem golem = new Golem();
        Dragon dragon = new Dragon();

        // 플레이어의 위치를 보여준다.
        public void LocationView(Player player, int Width, int Height)
        {
            Console.SetCursorPosition(5, 2 * Height - 1);
            Console.WriteLine("{0} 위치 : {1}", player.Name, player.Location);
        }

        // 플레이어와 컴퓨터의 체력을 보여준다.
        public void HPview(Player player, int Width, int Height)
        {
            if (player.Name.Equals("악당"))
            {
                Console.SetCursorPosition(5, 2 * Height - 3);
                Console.WriteLine("{0}의 체력 : {1}", player.Name, player.HP);
            }
            else
            {
                Console.SetCursorPosition(5, 2 * Height - 2);
                Console.WriteLine("{0}의 체력 : {1}", player.Name, player.HP);
            }
        }

        // 플레이어가 미니게임에서 졌을 때 보여주는 함수
        public void ShowLoose(Player player, int board_w, int board_h)
        {
            Console.Clear();
            Console.SetCursorPosition(board_w / 2, board_h / 2);
            Console.WriteLine("미니게임에서 패배했습니다.");
            Console.SetCursorPosition(board_w / 2, board_h / 2 + 2);
            Console.WriteLine("체력을 잃었습니다.");
            Console.SetCursorPosition(board_w / 2, board_h / 2 + 4);
            Console.WriteLine("현재 체력 : {0}",player.HP);
            Console.SetCursorPosition(board_w / 2, board_h / 2 + 6);
            Console.WriteLine("Presss Any Key");
            MiniGameFrame();
            Console.ReadKey(true);
        }

        // 플레이어가 미니게임에서 이겼을 때 보여주는 함수
        public void ShowWin(Player player, int board_w, int board_h)
        {
            Console.Clear();
            Console.SetCursorPosition(board_w / 2, board_h / 2);
            Console.WriteLine("미니게임에서 승리했습니다.");
            Console.SetCursorPosition(board_w / 2, board_h / 2 + 2);
            Console.WriteLine("체력을 획득 합니다.");
            Console.SetCursorPosition(board_w / 2, board_h / 2 + 4);
            Console.WriteLine("현재 체력 : {0}", player.HP);
            Console.SetCursorPosition(board_w / 2, board_h / 2 + 6);
            Console.WriteLine("Press Any Key");
            MiniGameFrame();
            Console.ReadKey(true);
        }

        // 플레이어가 앞으로 갈 떄
        public void PlayerView(Player player, int Width, int Height, int location, int playerx)
        {

            for (int i = 0; i <= location * 2; i++)
            {
                if (player.Name.Equals("악당"))
                {
                    Console.SetCursorPosition(playerx + i, Height + Height / 3 - 1);
                }
                else
                {

                    Console.SetCursorPosition(playerx + i, Height + Height / 3);
                }
                if (i % 2 == 0)
                    Console.Write("☆");
                else
                    Console.Write("★");
                Frame(Width, Height);
                Console.SetCursorPosition(5, 2 * Height - 1);
                Console.WriteLine("{0}의 위치 : {1}", player.Name, (playerx + i) / 2);
                Thread.Sleep(500);
            }
            Thread.Sleep(500);
        }

        // 플레이어가 뒤로 후퇴할떄
        public void PlayerBackView(Player player, int Width, int Height, int location, int playerx)
        {
            for (int i = 0; i <= location * 2; i++)
            {
                if (player.Name.Equals("악당"))
                {
                    Console.SetCursorPosition(playerx - i, Height + Height / 3 - 1);
                }
                else
                {
                    Console.SetCursorPosition(playerx - i, Height + Height / 3);
                }
                if (i % 2 == 0)
                    Console.Write("☆");
                else
                    Console.Write("★");

                Console.SetCursorPosition(5, 2 * Height - 1);
                Console.WriteLine("{0}의 위치 : {1}", player.Name, (playerx - i) / 2);


                Frame(Width, Height);
                Thread.Sleep(500);
            }
            Thread.Sleep(500);
        }
        public void ShowOnlyMap(Player player, int Width, int Height)
        {
            for (int i = 3; i <= Width - 2; i++)
            {
                Console.SetCursorPosition(i, Height + Height / 3 + 1);
                Console.Write("□");
            }
            if (player.Name.Equals("악당"))
            {
                Console.SetCursorPosition(player.Location, Height + Height / 3 - 1);
                Console.Write("★");
            }
            else
            {
                Console.SetCursorPosition(player.Location, Height + Height / 3);
                Console.Write("★");
            }
        }
        public void ShowOnlyPlayer(Player player, int Width, int Height)
        {
            
            if (player.Name.Equals("악당"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(player.Location, Height + Height / 3 - 1);
                Console.Write("★");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadKey(true);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(player.Location, Height + Height / 3);
                Console.Write("★");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadKey(true);
            }
           
        }
        // 지도를 보여준다.
        public void ShowMap(Player player, int Width, int Height, int location, int playerx, bool front)
        {
            if (front)
            {
                for (int i = 3; i <= Width - 2; i++)
                {
                    Console.SetCursorPosition(i, Height + Height / 3 + 1);
                    Console.Write("□");
                }
                PlayerView(player, Width, Height, location, playerx);
            }
            else
            {
                for (int i = 3; i <= Width - 2; i++)
                {
                    Console.SetCursorPosition(i, Height + Height / 3 + 1);
                    Console.Write("□");
                }
                PlayerBackView(player, Width, Height, location, playerx);
            }


        }
        public void MessageDice(Player player, int Width, int Height)
        {
            Console.Clear();
            Console.SetCursorPosition(Width / 2 - Width / 7, Height / 3 + 1);
            Console.WriteLine("{0}의 주사위를 굴려 주세요   ", player.Name);
            Console.SetCursorPosition(Width / 2 - Width / 8, Height / 3 + 4);
            Console.WriteLine("      Press Any Key");
            Frame(Width, Height);
            ShowOnlyMap(player, Width, Height);
            Console.ReadKey(true);


        }

        // 무슨 주사위가 나왔느냐에 따라서 주사위의 View를 보여준다.


        /* 주사위 눈 1 ~ 6 */
        public void RollDiceOne(Player player, int Width, int Height, int location, bool move, int playerx)
        {
            Console.Clear();
            DiceFrame(Width, Height);
            Console.SetCursorPosition(Width / 2, Height / 2);
            Console.Write("■");
            // 움직일때만 맵을 출력한다.
            if (move)
            {
                ShowMap(player, Width, Height, location, playerx, true);
            }
            Frame(Width, Height);
            Thread.Sleep(500);

        }
        public void RollDiceTwo(Player player, int Width, int Height, int location, bool move, int playerx)
        {
            Console.Clear();
            DiceFrame(Width, Height);
            Console.SetCursorPosition(Width / 2 - 2, Height / 2);
            Console.Write("■");

            Console.SetCursorPosition(Width / 2 + 2, Height / 2);
            Console.Write("■");
            if (move)
                ShowMap(player, Width, Height, location, playerx, true);

            Frame(Width, Height);
            Console.ReadKey(true);


        }
        public void RollDiceThree(Player player, int Width, int Height, int location, bool move, int playerx)
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
                ShowMap(player, Width, Height, location, playerx, true);
            Frame(Width, Height);
            Console.ReadKey(true);

        }
        public void RollDiceFour(Player player, int Width, int Height, int location, bool move, int playerx)
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
                ShowMap(player, Width, Height, location, playerx, true);

            Frame(Width, Height);
            Console.ReadKey(true);

        }
        public void RollDiceFive(Player player, int Width, int Height, int location, bool move, int playerx)
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
                ShowMap(player, Width, Height, location, playerx, true);
            Frame(Width, Height);
            Console.ReadKey(true);

        }
        public void RollDiceSix(Player player, int Width, int Height, int location, bool move, int playerx)
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
                ShowMap(player, Width, Height, location, playerx, true);

            Frame(Width, Height);
            Console.ReadKey(true);
        }
        /* 주사위 눈 1 ~ 6 */

    }
}



