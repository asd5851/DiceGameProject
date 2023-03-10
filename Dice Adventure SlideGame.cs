using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceAdventure
{
    internal class SlideGame
    {
        static int board_w = 50;
        static int board_h = 30;
        const int X_SIZE = 3;
        const int Y_SIZE = 3;
        char cnt = '1';
        static int cm_count = 0;
        // 게임의 제목과 화면을 출력한다.
        static void scene()
        {
            Console.SetCursorPosition(board_w - board_w / 4, board_h / 2 - 8);
            Console.WriteLine("=====================================");
            Console.SetCursorPosition(board_w - board_w / 4, board_h / 2 - 6);
            Console.WriteLine("\t\t  슬라이드 게임");
            Console.SetCursorPosition(board_w - board_w / 4, board_h / 2 - 4);
            Console.WriteLine("=====================================");
            Console.SetCursorPosition(board_w - board_w / 2, board_h / 2);
            Console.WriteLine("슬라이드 게임 : 1 , 2 , 3 , 4 , 5 , 6 , 7 , 8을 제자리에 맞춰놓기");
            Console.SetCursorPosition(board_w - board_w / 2, board_h / 2 + 2);
            Console.WriteLine("\tw a s d 를 이용하여 각 숫자를 제자리에 위치시켜야 한다.");
            Console.SetCursorPosition(board_w - board_w / 4, board_h / 2 + 4);
            Console.WriteLine("\t이동횟수가 100 미만이어야 승리한다.");
            Console.SetCursorPosition(board_w - board_w / 4, board_h / 2 + 8);
            Console.WriteLine("\t\t  Press Any Key");
            SlideBoard();
            Console.ReadKey();

        }
        public static void SlideBoard()
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

        // 처음초기상태화면
        // 1~8까지 3x3배열에 넣고 그 가운데에 X를 집어 넣는다.
        // X를 집어넣어야 하기때문에 자료형은 char를 사용하고 숫자도 문자로 대체한다.
        static void init(char[,] arr, char cnt)
        {
            for (int i = 0; i < X_SIZE; i++)
            {
                for (int j = 0; j < Y_SIZE; j++)
                {
                    if (i == 1 && j == 1)
                    {
                        arr[i, j] = 'X'; // 가운데(1,1)에 X를 집어넣는다.
                    }
                    else
                    {
                        arr[i, j] = cnt; // cnt의 초기값은 1
                        cnt++; // arr배열의 칸수 증가함에 따라 cnt를 증가시켜 각각의 배열에
                               // 1~8까지 저장시킨다.
                    }

                }
            }
        }

        // 현재 상태를 보여주는 함수
        // 3x3의 현재 보드상태를 보여준다
        static void view(char[,] arr)
        {
            for (int i = 0; i < X_SIZE; i++)
            {
                for (int j = 0; j < Y_SIZE; j++)
                {
                    Console.SetCursorPosition(board_w + j * 5, board_h / 2 - board_h / 4 + i * 5 - 1);
                    Console.Write(" ___ ");
                    Console.SetCursorPosition(board_w + j * 5, board_h/2 - board_h/4 + i * 5);
                    Console.Write("| {0} |", arr[i, j]);
                    Console.SetCursorPosition(board_w + j * 5, board_h / 2 - board_h / 4 + i * 5 + 1);
                    Console.Write(" ￣￣ ");
                }
                    
            }
            SlideBoard();
        }

        // 게임을 시작하는 함수

        static void startgame(char[,] arr, bool m_checkpoint)
        {
            Console.Clear();
            while (true)
            {
                //scene(); // 제목을 출력하는 함수 호출
                view(arr); // 현재 보드의 상태를 출력하는 함수 호출


                if (m_checkpoint == true)
                {
                    Console.WriteLine("승리했습니다.");
                    break;
                }
                // if :1~8까지 전부 제자리에있나 체크하는 함수가
                //true 라면 게임을 종료하는 문
                Console.SetCursorPosition(board_w - board_w / 4, board_h / 2 - board_h / 4 + 15);
                Console.WriteLine("=========================================");

                // 명령어를 입력하는 입력문
                Console.SetCursorPosition(board_w - board_w/4, board_h / 2 - board_h / 4 + 15 + 1);
                Console.WriteLine("실행한 횟수 : {0}", cm_count);
                cm_count++; // 실행한 횟수를 증가시킨다.
                Console.SetCursorPosition(board_w - board_w/4, board_h / 2 - board_h / 4 + 15+2);

                Console.Write("명령어를 입력하세요(w,a,s,d) : ");
                char.TryParse(Console.ReadLine(), out char command);


                bool flag = true; // swap함수가 두번 실행되는 것을 막는 flag
                // { loop : w,a,s,d를 눌러서 X와 숫자의 자리를 바꾸는 Swap
                for (int i = 0; i < X_SIZE; i++)
                {
                    for (int j = 0; j < Y_SIZE; j++)
                    {
                        if (arr[i, j] == 'X' && flag == true) // 반복문을 돌다가 X를 만나고 반복문이 두번 실행된것이 아닐때
                        {
                            if (command == 'w') // if : 명령어가 w일떄
                            {
                                if (i - 1 != -1) // if: 위쪽으로 이동할때 0를 넘으면 실행하지 않는다. 
                                {
                                    // 숫자와 X를 Swap한다.
                                    char temp = arr[i, j];
                                    arr[i, j] = arr[i - 1, j];
                                    arr[i - 1, j] = temp;
                                    flag = false;
                                }
                                else { continue; }

                            }
                            else if (command == 'a') // if : 명령어가 a일떄
                            {
                                if (j - 1 != -1) // if: 왼쪽으로 이동할때 0를 넘으면 실행하지 않는다. 
                                {
                                    // 숫자와 X를 Swap한다.
                                    char temp = arr[i, j];
                                    arr[i, j] = arr[i, j - 1];
                                    arr[i, j - 1] = temp;
                                    flag = false;
                                }
                                else { continue; }

                            }
                            else if (command == 's') // if : 명령어가 s일떄
                            {
                                if (i + 1 != Y_SIZE) // if: 아래쪽으로 이동할때 2를 넘으면 실행하지 않는다. 
                                {
                                    // 숫자와 X를 Swap한다.
                                    char temp = arr[i, j];
                                    arr[i, j] = arr[i + 1, j];
                                    arr[i + 1, j] = temp;
                                    flag = false;
                                }
                                else { continue; }

                            }
                            else if (command == 'd') // if : 명령어가 d일떄
                            {
                                if (j + 1 != X_SIZE) // if: 오른쪽으로 이동할때 2를 넘으면 실행하지 않는다. 
                                {
                                    // 숫자와 X를 Swap한다.
                                    char temp = arr[i, j];
                                    arr[i, j] = arr[i, j + 1];
                                    arr[i, j + 1] = temp;
                                    flag = false;
                                }
                                else { continue; }
                            }

                        }
                    }
                } //  } loop : w,a,s,d를 눌러서 X와 숫자의 자리를 바꾸는 Swap기능
                m_checkpoint = checkgame(arr); // 1~8까지 전부 제자리에 위치해있는지 확인하는 함수호출
                //Console.Clear();
            }
        }

        //  { 1~8까지 전부 제자리에 있는지 체크하는 함수
        // 1~8까지 전부 제자리에 있다면 true를 반환
        // 그렇지 않다면 false를 반환한다.
        static bool checkgame(char[,] arr)
        {
            int checkcount = 1; // 숫자들의 위치를 확인하는 카운트
            int realcheckcount = 0; // 배열의 숫자들이 순서대로 위치하는지 세는 카운트
            for (int i = 0; i < X_SIZE; i++)
            {
                for (int j = 0; j < Y_SIZE; j++)
                {
                    if (i == X_SIZE - 1 && j == Y_SIZE - 1) // 3x3 배열에서 9가 없기때문에 9는 제외한다.
                    {
                        /* Do Nothing */
                    }
                    else
                    {
                        if (arr[i, j] == '0' + checkcount) // if : 배열의 숫자들이 순서대로 위치하여있다면
                        {
                            realcheckcount++; // 카운트를 센다.

                        }
                    }
                    checkcount++; // 숫자들의 위치를 확인하는 카운트

                    if (realcheckcount == 8) // 배열들의 숫자들이 순서대로 위치하여있다면(1~8) 카운트가 8이 되고
                    {
                        return true; // true 반환한다.
                    }
                }
            }
            return false; // true가 아니면 모두 false로 반환하여 게임을 이어간다.
        }
        //  } 1~8까지 전부 제자리에 있는지 체크하는 함수

        // { 메인함수
        public bool Slidegame()
        {
            char[,] arr = new char[3, 3] { { '4', '1', '2' }, { '3', '5', '7' }, { '6', '8', 'X' } };
            // init(arr,'1'); // 처음 배열을 초기화하는 함수 
            bool m_checkpoint = false; // 게임종료 체크 포인트는 false로 설정해놓는다.
            cm_count= 0;
            scene();
            startgame(arr, m_checkpoint); // 게임을 시작하는 함수 호출
            if(cm_count > 100)
            {
                Console.Clear();
                Console.SetCursorPosition(board_w - board_w / 4, board_h / 2);
                Console.WriteLine("실패했습니다! 체력이 깎입니다.");
                SlideBoard();
                Console.ReadLine();
                return false;
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(board_w - board_w / 4, board_h / 2);
                Console.WriteLine("성공했습니다! 체력이 증가합니다.");
                SlideBoard();
                Console.ReadLine();
                return true;
            }
        }
        // } 메인함수
    }
}

