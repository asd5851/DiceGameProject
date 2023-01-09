using System;
using System.Collections.Generic;
using System.Linq;
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
        FrameView frame = new FrameView();
        BattleComputer battlecomputer = new BattleComputer();
        Player player_temp = new Player();
        Player computer_temp = new Player();
        public static int[] arr = new int[111];
        public static int m_width = 110;
        public static int m_height = 10;

        public void Game(Player player, Player computer, View view, Dice_Roll d_roll, MonsterView monsterview)
        {
            player_temp = player;
            computer_temp = computer;
            bool player_turn = true;
            bool game_clear = player.HP > 0 && player.Location < m_width && computer.HP > 0 && computer.Location < m_width;
            while (game_clear)
            {
                view.MessageDice(player, m_width, m_height); // 주사위를 굴려달라는 메시지 출력
                view.ShowMap(player, m_width, m_height, 0, player.Location, true); // 주사위를 굴리면 맵을 보여준다.
                MovePlayer(player, view, d_roll, true); // 주사위를 굴리고 플레이어의 위치 이동

                if (player_turn)
                {
                    view.ShowOnlyPlayer(computer_temp, m_width, m_height);
                }
                else
                {
                    view.ShowOnlyPlayer(player_temp, m_width, m_height);
                }
                Console.Clear();

                // 플레이어의 턴 일때, 플레이어와 컴퓨터의과거 위치가 같다면
                if(player_turn)
                {
                    if (player.Location == computer_temp.Location)
                    {
                        //battlecomputer.GameLogic(player, view, d_roll, false);
                        /* 싸운다 */
                    }
                }
                // 컴퓨터의 턴 일때, 컴퓨터와 플레이어의 과거위치가 같다면
                else if(!player_turn)
                {
                    if(player.Location == player_temp.Location)
                    {
                        /* 싸운다 */
                    }
                }
                
                // 싸우고나서 다시 진행

                if (EratosCheck(player.Location / 2))
                {
                    if (player_turn)
                    {
                        /*미니게임실행*/
                        Random random= new Random();
                        int choice = random.Next(1, 2 + 1);
                        switch(choice)
                        {
                            case 1:
                                slide.Slidegame();
                                break;
                            case 2:
                                snake.SnakeMain();
                                break;
                        }
                    }
                }
                else
                {
                    switch ((player.Location / 2) % 10)
                    {
                        case 0:
                            MonsterBattleLogic(player, view, d_roll, monsterview);
                            break;
                        case 1:
                            /*퀴즈실행*/
                            if (player_turn)
                            {
                                quest.QuestMessage(true);
                                quest.Quest(player, random.Next(1, 8 + 1), false);
                            }
                            break;
                        case 2:
                            /*몬스터배틀*/
                            MonsterBattleLogic(player, view, d_roll, monsterview);
                            break;
                        case 3:
                            /*체력깎는퀴즈*/
                            if (player_turn)
                            {
                                quest.QuestMessage(true);
                                quest.Quest(player, random.Next(1, 8 + 1), false);
                            }
                            break;
                        case 4:
                            MonsterBattleLogic(player, view, d_roll, monsterview);

                            break;
                        case 5:
                            /*몬스터배틀*/
                            MonsterBattleLogic(player, view, d_roll, monsterview);
                            break;
                        case 6:
                            MonsterBattleLogic(player, view, d_roll, monsterview);

                            break;
                        case 7:
                            /*태초*/
                            GoFirst(player);
                            break;
                        case 8:
                            MonsterBattleLogic(player, view, d_roll, monsterview);

                            break;
                        case 9:
                            if (player_turn)
                            {
                                /*체력채워주는퀴즈*/
                                quest.QuestMessage(false);
                                quest.Quest(player, random.Next(1, 8 + 1), true);
                            }
                            break;
                    }
                }
                // 플레이어가 턴을 다쓰면 temp에 플레이어의 정보를 저장하고 플레이어를 컴퓨터로 바꿔서 진행
                if (player_turn)
                {
                    player_temp = player;
                    player = computer;
                    player_turn = false;
                }
                else // 컴퓨터의 턴을 다쓰면 플레이어temp에있는 정보를 다시 플레이어한테 덮어써서 진행
                {
                    computer_temp = computer;
                    player = player_temp;
                    player_turn = true;
                }
            }
        }
        public void MonsterBattleLogic(Player player, View view, Dice_Roll d_roll, MonsterView monsterview)
        {
            int monster_temp = default;
            int compare_monster = default;
            if (player.Location < m_width)
            {
                monster_temp = random.Next(1, 3 + 1); // 1 ~ 3 까지 랜덤 인수를 받아서
                monsterview.MonsterMessage(m_width, m_height, monster_temp); // 어떤 몬스터를 만나는지 출력
                view.MessageDice(player,m_width, m_height); // 몬스터를 만나면 주사위를 굴리라는 메세지 출력
                compare_monster = MovePlayer(player, view, d_roll, false); // 주사위를 굴린다.
                monsterview.MonsterCompareView(ref player, m_width, m_height, compare_monster, monster_temp); // 굴린 주사위와 몬스터의 눈 비교
            }
            else if (player.Location >= m_width)
            {
                monster_temp = random.Next(1, 6 + 1); // 1 ~ 6까지 랜덤 인수 받아서
                monsterview.MonsterMessage(m_width, m_height, monster_temp); // 어떤 몬스터를 만나는지
                view.MessageDice(player, m_width, m_height);
                compare_monster = MovePlayer(player, view, d_roll, false); // 주사위를 굴린다.
                monsterview.MonsterCompareView(ref player, m_width, m_height, compare_monster, monster_temp);
            }
        }
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
        public void GoFirst(Player player)
        {
            player.Location = 3;
            Console.SetCursorPosition(m_width / 2, m_height / 2);
            Console.WriteLine("함정에 빠졌다!");
            Console.SetCursorPosition(m_width / 2, m_height / 261);
            Console.WriteLine("태초로 돌아갑니다.");
            frame.Frame(m_width, m_height);
            Console.ReadLine();
        }
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


