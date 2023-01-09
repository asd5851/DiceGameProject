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
            Console.SetCursorPosition(board_w - board_w/4, board_h/2);
            Console.WriteLine("상대방을 마주쳤습니다!");

            Console.SetCursorPosition(board_w-board_w/4, board_h / 2+1);
            Console.WriteLine("배틀을 시작합니다!");

            BattleBoard();
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
        public void GameLogic(Player player, Player computer, View view)
        {
            Dice_Roll d_roll  = new Dice_Roll();
            int player_dice_num;
            int computer_dice_num;
            // 주사위를 굴린다는 메세지를 출력
            view.MessageDice(player, 110, 10);
            // 주사위를 굴린다.
            player_dice_num = MovePlayer(player, view ,d_roll, false);
            // 주사위를 굴린다.
            computer_dice_num = MovePlayer(computer, view, d_roll, false);

            // 컴퓨터의 주사위와 나의 주사위를 비교하여 내 주사위가 작으면 후퇴
            if(player_dice_num < computer_dice_num)
            {
                view.PlayerBackView(player, 110, 10, computer_dice_num - player_dice_num, player.Location);
            }
        }
    }
}
