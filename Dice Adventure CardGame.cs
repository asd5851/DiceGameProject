using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DiceAdventure
{
    public class CardGame
    {
        FrameView frame = new FrameView();
        private int[] trumpCardSet;
        private string[] trumpCardSetMark;
        private int board_w = 50;
        private int board_h = 30;
        int i;
        public CardGame() {
            SetTrumpCards();
        }
        private void RollCards()
        {
            Random random= new Random();
            int s_index = random.Next(0,trumpCardSet.Length);
            int d_index = random.Next(0,trumpCardSet.Length);

            int temp = trumpCardSet[s_index];
            trumpCardSet[s_index] = trumpCardSet[d_index];
            trumpCardSet[d_index] = temp;
        }
        private void ShuffleCards()
        {
            for(int i = 0; i < 100; i++)
            {
                RollCards();
            }
        }
        private void SetTrumpCards()
        {
            Console.Clear();
            trumpCardSet = new int[52];
            for (int i = 0; i < trumpCardSet.Length; i++)
            {
                trumpCardSet[i] = i + 1;

            }// loop : 카드를 셋업하는 루프
            // 트럼프 카드의 마크를 셋업
            trumpCardSetMark = new string[4] { "♥", "♠", "◆", "♣" };
        }
        private int ChoiceCard(bool Whois, bool loca)
        {
            ShuffleCards();
            string Who;
            int card = trumpCardSet[0];
            string cardMark = trumpCardSetMark[(card - 1) / 13];
            string cardNumber = Math.Ceiling(card % (13.1)).ToString();
            switch (cardNumber)
            {
                case "11":
                    cardNumber = "J";
                    break;
                case "12":
                    cardNumber = "Q";
                    break;
                case "13":
                    cardNumber = "K";
                    break;
                default:
                    /* Do Nothing */
                    break;
            }
            if (Whois == true)
            {
                Who = "[플레이어]";
            }
            else
            {
                Who = "[컴퓨터]";
            }
            if(loca == true)
            {
                Console.SetCursorPosition(board_w / 2, board_h / 2 - 6);
                Console.WriteLine("{0} 가 뽑은 카드는 {1}{2} 입니다.", Who, cardMark, cardNumber);
                Console.SetCursorPosition(board_w / 2, board_h / 2 - 5);
                Console.WriteLine(" ----");
                Console.SetCursorPosition(board_w / 2, board_h / 2 - 4);
                Console.WriteLine("|{0} {1}|", cardMark, cardNumber);
                Console.SetCursorPosition(board_w / 2, board_h / 2 - 3);
                Console.WriteLine("|    |");
                Console.SetCursorPosition(board_w / 2, board_h / 2 - 2);
                Console.WriteLine("|{0} {1}|", cardNumber, cardMark);
                Console.SetCursorPosition(board_w / 2, board_h / 2 - 1);
                Console.WriteLine(" ----");
            }
            else
            {
                Console.SetCursorPosition(board_w / 2, board_h / 2 + 2);
                Console.WriteLine("{0} 가 뽑은 카드는 {1}{2} 입니다.", Who, cardMark, cardNumber);
                Console.SetCursorPosition(board_w / 2, board_h / 2 + 3);
                Console.WriteLine(" ----");
                Console.SetCursorPosition(board_w / 2, board_h / 2 + 4);
                Console.WriteLine("|{0} {1}|", cardMark, cardNumber);
                Console.SetCursorPosition(board_w / 2, board_h / 2 + 5);
                Console.WriteLine("|    |");
                Console.SetCursorPosition(board_w / 2, board_h / 2 + 6);
                Console.WriteLine("|{0} {1}|", cardNumber, cardMark);
                Console.SetCursorPosition(board_w / 2, board_h / 2 + 7);
                Console.WriteLine(" ----");
            }
            switch (cardNumber)
            {
                case "J":
                    cardNumber = "11";
                    break;
                case "Q":
                    cardNumber = "12";
                    break;
                case "K":
                    cardNumber = "13";
                    break;
                default:
                    /* Do Nothing */
                    break;
            }
            int.TryParse(cardNumber, out int card_num);
            Console.ReadLine();
            return card_num;
        }
        private void Scene()
        {
            frame.MiniGameFrame();
            Console.SetCursorPosition(board_w - board_w / 4, board_h / 2 - 3);
            Console.WriteLine("\t\t카드 뽑기 게임");
            Console.SetCursorPosition(board_w - board_w / 4, board_h / 2 - 1);
            Console.WriteLine("플레이어와 컴퓨터가 카드를 한장씩 뽑아서");
            Console.SetCursorPosition(board_w - board_w / 4, board_h / 2 + 1);
            Console.WriteLine("숫자가 높은쪽이 승리하는 게임입니다.");
            Console.SetCursorPosition(board_w - board_w / 4, board_h / 2 + 3);
            Console.WriteLine("플레이어는 컴퓨터의 카드보다 높아야 승리");
            Console.SetCursorPosition(board_w - board_w / 4, board_h / 2 + 5);
            Console.WriteLine("플레이어의 숫자가 컴퓨터보다 작거나 같다면 패배입니다.");
            Console.SetCursorPosition(board_w - board_w / 4, board_h / 2 + 7);
            Console.WriteLine("\t\tPress Any Key");
            Console.ReadKey(true);
            Console.Clear();
        }
        public bool CardGameMain()
        {
            Console.Clear();
            Scene();
            frame.MiniGameFrame();
            int compare_first = 0;
            int compare_second = 0;
            compare_first = ChoiceCard(true, true);
            compare_second = ChoiceCard(false, false);
            
            if(compare_first <= compare_second)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
    }
}
