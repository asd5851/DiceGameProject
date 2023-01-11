using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DiceAdventure
{
    public class GameLogic
    {
        NQuest quest = new NQuest();
        Random random = new Random();

        SlideGame slide = new SlideGame();
        SnakeGAME snake = new SnakeGAME();
        CardGame card = new CardGame();
        AvoidGame avoid = new AvoidGame();
        ShootingGame shot = new ShootingGame();

        FrameView frame = new FrameView();
        BattleComputer battlecomputer = new BattleComputer();
        Player player_temp = new Player();
        Player computer_temp = new Player();
        public static int[] arr = new int[111];
        public static int m_width = 110;
        public static int m_height = 10;
        int m_minigame_width = 50;
        int m_minigame_height = 30;

        // 게임을 실행하는 로직
        public void Game(Player player, Player computer, View view, Dice_Roll d_roll, MonsterView monsterview)
        {
            player_temp = player; // 플레이어의 정보를 담아두는 temp
            computer_temp = computer; // 컴퓨터의 정보를 담아두는 temp
            bool player_turn = true;

            int cnt = 1;
            bool game_clear = player.HP > 0 && player.Location < m_width && computer.HP > 0 && computer.Location < m_width;
            while (game_clear)
            {
                view.MessageDice(player, m_width, m_height); // 주사위를 굴려달라는 메시지 출력
                view.ShowMap(player, m_width, m_height, 0, player.Location, true); // 주사위를 굴리면 맵을 보여준다.
                MovePlayer(player, view, d_roll, true); // 주사위를 굴리고 플레이어의 위치 이동
                // 플레이어의 턴
                if (player_turn)
                {
                    // 컴퓨터의 위치를 보여준다
                    view.ShowOnlyPlayer(computer_temp, m_width, m_height);
                    // 플레이어의 턴 일때, 플레이어와 컴퓨터의 위치가 같다면
                    if (player.Location == computer_temp.Location)
                    {
                        /* 싸운다 */
                        battlecomputer.GameLogic(player, computer_temp, view);
                    }
                }
                // 컴퓨터의 턴
                else if (!player_turn)
                {
                    // 플레이어의 위치를 보여준다.
                    view.ShowOnlyPlayer(player_temp, m_width, m_height);
                    // 컴퓨터의 턴 일떄, 플레이어와 컴퓨터의 위치가 같다면
                    if (player.Location == player_temp.Location)
                    {
                        /* 싸운다 */
                        battlecomputer.GameLogic(player_temp, computer, view);
                    }
                }
                Console.Clear();
                // 싸우고나서 다시 진행

                // 플레이어의 위치가 소수라면
                if (EratosCheck(player.Location / 2))
                {
                    if (player_turn)
                    {
                        ///*미니게임실행*/
                        Random random = new Random();
                        int choice = random.Next(1, 5 + 1);
                        switch (choice)
                        {
                            case 1:
                                CheckGameWin(player, view, slide.Slidegame());
                                break;
                            case 2:
                                CheckGameWin(player, view, snake.SnakeMain());
                                break;
                            case 3:
                                CheckGameWin(player, view, card.CardGameMain());
                                break;
                            case 4:
                                CheckGameWin(player, view, avoid.AvoidMain());
                                break;
                            case 5:
                                CheckGameWin(player, view, shot.ShootMain());
                                break;
                        }
                    }
                }
                else
                {
                    // 플레이어의 위치에 따른 이벤트 실행
                    switch ((player.Location / 2) % 10)
                    {
                        case 0:
                            /* 몬스터 배틀 */
                            MonsterBattleLogic(player, view, d_roll, monsterview);
                            break;
                        case 1:
                            /* 위치바꾸기 */
                            if (player_turn)
                            {
                                SwapLocation(player, computer_temp);
                            }
                            else
                            {
                                SwapLocation(player, player_temp);
                            }
                            break;
                        case 2:
                            /* 몬스터배틀 */
                            MonsterBattleLogic(player, view, d_roll, monsterview);
                            break;
                        case 3:
                            /* 전부다 태초 */
                            if (player_turn)
                            {
                                AllGoFirst(player, computer_temp);
                            }
                            else
                            {
                                AllGoFirst(player, player_temp);
                            }
                            break;
                        case 4:
                            /* 퀴즈 */
                            if (player_turn)
                            {
                                quest.QuestMessage(false);
                                quest.Quest(player, random.Next(1, 11 + 1), false);
                            }
                            break;
                        case 5:
                            /* 몬스터배틀 */
                            MonsterBattleLogic(player, view, d_roll, monsterview);
                            break;
                        case 6:
                            /* 퀴즈 */
                            if (player_turn)
                            {
                                quest.QuestMessage(false);
                                quest.Quest(player, random.Next(1, 11 + 1), false);
                            }
                            break;
                        case 7:
                            /* 태초 */
                            GoFirst(player);
                            break;
                        case 8:
                            MonsterBattleLogic(player, view, d_roll, monsterview);

                            break;
                        case 9:
                            /* 퀴즈 */
                            if (player_turn)
                            {
                                quest.QuestMessage(true);
                                quest.Quest(player, random.Next(1, 11 + 1), true);
                            }
                            break;
                    }
                }
                // 플레이어가 턴을 다쓰면 temp에 플레이어의 정보를 저장하고 플레이어를 컴퓨터로 바꿔서 진행
                if (player_turn)
                {
                    player_temp = player;
                    player = computer_temp;
                    player_turn = false;
                }
                else // 컴퓨터의 턴을 다쓰면 컴퓨터temp에 컴퓨터의 정보 저장
                     // 플레이어temp에있는 정보를 다시 플레이어한테 덮어써서 진행
                {
                    computer_temp = computer;
                    player = player_temp;
                    player_turn = true;
                }
                
            }
        }
        public void CheckGameWin(Player player, View view, bool win)
        {
            if (win)
            {
                player.HP = player.HP + 1;
                view.ShowWin(player, m_minigame_width, m_minigame_height);
            }
            else
            {
                player.HP = player.HP - 1;
                view.ShowLoose(player, m_minigame_width, m_minigame_height);
            }
        }
        // 몬스터의 배틀로직
        // 몬스터의 체력과 주사위의 눈을 비교하여 승리, 패배, 드로우 진행
        public void MonsterBattleLogic(Player player, View view, Dice_Roll d_roll, MonsterView monsterview)
        {
            int monster_temp = default;
            int compare_monster = default;
            // 플레이어의 위치가 절반도 오지 않았다면 약한 몬스터 출현
            if (player.Location < m_width / 2)
            {
                monster_temp = random.Next(1, 4 + 1); // 1 ~ 3 까지 랜덤 인수를 받아서
                monsterview.MonsterMessage(m_width, m_height, monster_temp); // 어떤 몬스터를 만나는지 출력
                view.MessageDice(player, m_width, m_height); // 몬스터를 만나면 주사위를 굴리라는 메세지 출력
                compare_monster = MovePlayer(player, view, d_roll, false); // 주사위를 굴린다.
                monsterview.MonsterCompareView(ref player, m_width, m_height, compare_monster, monster_temp); // 굴린 주사위와 몬스터의 눈 비교
            }
            // 플레이어의 위치가 절반이상 왔다면 강한 몬스터 출현
            else if (player.Location >= m_width / 2)
            {
                monster_temp = random.Next(3, 6 + 1); // 3 ~ 6까지 랜덤 인수 받아서
                monsterview.MonsterMessage(m_width, m_height, monster_temp); // 어떤 몬스터를 만나는지
                view.MessageDice(player, m_width, m_height);
                compare_monster = MovePlayer(player, view, d_roll, false); // 주사위를 굴린다.
                monsterview.MonsterCompareView(ref player, m_width, m_height, compare_monster, monster_temp);
            }
        }
        // 플레이어가 주사위를 둘려서 움직이는 로직
        public int MovePlayer(Player player, View view, Dice_Roll d_roll, bool move)
        {
            int result;
            switch (result = d_roll.RollDice())
            {
                case 1:
                    view.RollDiceOne(player, 110, 10, 1, move, player.Location);
                    if (move) player.Location += 1 * 2;
                    break;
                case 2:
                    view.RollDiceTwo(player, 110, 10, 2, move, player.Location);
                    if (move) player.Location += 2 * 2;
                    break;
                case 3:
                    view.RollDiceThree(player, 110, 10, 3, move, player.Location);
                    if (move) player.Location += 3 * 2;
                    break;
                case 4:
                    view.RollDiceFour(player, 110, 10, 4, move, player.Location);
                    if (move) player.Location += 4 * 2;
                    break;
                case 5:
                    view.RollDiceFive(player, 110, 10, 5, move, player.Location);
                    if (move) player.Location += 5 * 2;
                    break;
                case 6:
                    view.RollDiceSix(player, 110, 10, 6, move, player.Location);
                    if (move) player.Location += 6 * 2;
                    break;
            }
            return result;

        }
        // 함정에빠져서 처음으로 돌아가는 로직
        public void GoFirst(Player player)
        {
            Console.Clear();
            player.Location = 3;
            frame.Frame(m_width, m_height);
            Console.SetCursorPosition(m_width / 2 - m_width / 4, m_height / 2);
            Console.WriteLine("{0}가(이) 함정에 빠졌다!",player.Name);
            Console.SetCursorPosition(m_width / 2 - m_width / 4, m_height / 2 + 2);
            Console.WriteLine("태초로 돌아갑니다.");
            Console.SetCursorPosition(m_width / 2 - m_width / 4, m_height / 2 + 4);
            Thread.Sleep(1000);
            Console.WriteLine("Press Any Key");
            Console.ReadKey(true);
        }
        public void AllGoFirst(Player player, Player computer)
        {
            Console.Clear();
            player.Location = 3;
            computer.Location = 3;
            frame.Frame(m_width, m_height);
            Console.SetCursorPosition(m_width / 2 - m_width / 4, m_height / 2);
            Console.WriteLine("{0}가(이) 함정에 빠졌다!",player.Name);
            Console.SetCursorPosition(m_width / 2 - m_width / 4, m_height / 2 + 2);
            Console.WriteLine("{0} : 혼자 죽을 수 없지!");
            Console.SetCursorPosition(m_width / 2 - m_width / 4, m_height / 2 + 2);
            Console.WriteLine("물귀신 작전! 둘이 함께 태초로 돌아갑니다.");
            Console.SetCursorPosition(m_width / 2 - m_width / 4, m_height / 2 + 4);
            Thread.Sleep(1000);
            Console.WriteLine("Press Any Key");
            Console.ReadKey(true);
        }
        public void SwapLocation(Player player, Player computer)
        {
            Console.Clear();
            frame.Frame(m_width, m_height);
            Console.SetCursorPosition(m_width / 2 - m_width / 4, m_height / 2);
            Console.WriteLine("{0}는(은) 어지러움을 느낍니다.", player.Name);
            Console.SetCursorPosition(m_width / 2 - m_width / 4, m_height / 2 + 2);
            Console.WriteLine("알 수 없는 힘에의해 둘의 위치가 바뀌어버립니다.");
            Console.SetCursorPosition(m_width / 2 - m_width / 4, m_height / 2 + 4);
            Thread.Sleep(1000);
            Console.WriteLine("Press Any Key");
            Player temp = new Player();
            temp.Location = player.Location;
            player.Location = computer.Location;
            computer.Location = temp.Location;
            Console.ReadKey(true);
        }

        // 에라토스테네스의 체를 구현하여 소수를 판별한다.
        public static void Eratos()
        {
            for (int i = 2; i <= m_width; i++)
            {
                arr[i] = i;
            }
            for (int i = 2; i <= m_width; i++)
            {
                for (int j = i * 2; j <= m_width; j = j + i)
                {
                    arr[j] = 0;
                }
            }
        }
        public static bool EratosCheck(int player_location)
        {
            Eratos();
            for (int i = 2; i <= m_width; i++)
            {
                if (arr[i] == player_location)
                {
                    return true;
                }
            }
            return false;
        }
    }

}


