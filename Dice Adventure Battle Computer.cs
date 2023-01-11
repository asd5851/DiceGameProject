using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceAdventure
{
    
    
    public class BattleComputer
    {
        int board_w = 50;
        int board_h = 30;
        public void StartBattle()
        {
            Console.Clear();
            Console.SetCursorPosition(board_w - board_w/4, board_h/2);
            Console.WriteLine("상대방을 마주쳤습니다!");

            Console.SetCursorPosition(board_w-board_w/4, board_h / 2+4);
            Console.WriteLine("배틀을 시작합니다!");

            BattleBoard();
            Console.ReadKey(true);
        }
        public void BattleBoard()
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
        // 컴퓨터와 플레이어의 위치가 같다면 싸운다.
        // 서로의 주사위를 굴려서 그 차이만큼 상대의 체력을 감소시킨다.
        public void GameLogic(Player player, Player computer, View view)
        {
            Dice_Roll d_roll  = new Dice_Roll();
            int player_dice_num;
            int computer_dice_num;


            StartBattle();
            while (true)
            {
                // 플레이어의 주사위를 굴린다.
                view.MessageDice(player, 110, 10);
                player_dice_num = MovePlayer(player, view, d_roll, false);
                // 컴퓨터의 주사위를 굴린다.
                view.MessageDice(computer, 110, 10);
                computer_dice_num = MovePlayer(computer, view, d_roll, false);

                // 컴퓨터의 주사위가 더 큰 경우
                // 플레이어의 hp를 깎고 플레이어의 위치를 숫자의 차이만큼 후퇴한다.
                if (player_dice_num < computer_dice_num)
                {
                    player.HP = player.HP - (computer_dice_num - player_dice_num);
                    player.Location = player.Location - (computer_dice_num - player_dice_num) * 2;
                    view.ShowMap(player, 110, 10, 0, player.Location, false);
                    view.HPview(player, 110, 10);
                    view.HPview(computer, 110, 10);
                    break;
                }

                // 플레이어의 주사위가 더 큰 경우
                // 컴퓨터의 hp를 깎고 컴퓨터의 위치를 숫자의 차이만큼 후퇴한다.
                else if (player_dice_num > computer_dice_num)
                {
                    computer.HP = computer.HP - (player_dice_num - computer_dice_num);
                    computer.Location = computer.Location - (player_dice_num - computer_dice_num)*2;
                    view.ShowMap(computer, 110, 10, 0, computer.Location, false);
                    view.HPview(player, 110, 10);
                    view.HPview(computer, 110, 10);
                    break;
                }
                else
                {
                    /* Do Nothing */
                }
            }       
        }
    }
}
