using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiceAdventure
{
    public class Go
    {
        View view = new View();
        int black_cnt = 0;
        int white_cnt = 0;
        int wx = 0;
        int wy = 0;
        int board_width = 20;
        int board_height = 20;
        string[,] board = new string[26, 26];
        int[,] visited = new int[26, 26];
        static bool wincheck = false;
        public void Ocheck()
        {
            for (int i = 1; i <= board_height; i++)
            {
                for (int j = 1; j <= board_width; j++)
                {
                    if (j + 4 <= board_width && i + 4 <= board_height)
                    {
                        if (visited[i, j] == 1 &&
                       visited[i, j + 1] == 1 &&
                       visited[i, j + 2] == 1 &&
                       visited[i, j + 3] == 1 &&
                       visited[i, j + 4] == 1)
                        {
                            wincheck = true;
                        }
                        else if (visited[i, j] == 1 &&
                            visited[i + 1, j] == 1 &&
                            visited[i + 2, j] == 1 &&
                            visited[i + 3, j] == 1 &&
                            visited[i + 4, j] == 1)
                        {
                            wincheck = true;

                        }
                        else if (visited[i, j] == 1 &&
                            visited[i + 1, j + 1] == 1 &&
                            visited[i + 2, j + 2] == 1 &&
                            visited[i + 3, j + 3] == 1 &&
                            visited[i + 4, j + 4] == 1)
                        {
                            wincheck = true;

                        }
                    }

                }

            }
        }
        public void GoBoard(int x, int y, bool turn)
        {

            for (int i = 0; i <= board_height; i++)
            {
                for (int j = 0; j <= board_width; j++)
                {

                    if (x == j && i == y && turn && visited[i, j] == 0)
                    {
                        visited[i, j] = 1;
                        board[i, j] = "●";
                    }
                    else if (x == j && i == y && !turn && visited[i, j] == 0)
                    {
                        visited[i, j] = 2;
                        board[i, j] = "○";
                    }
                    else if (visited[i, j] == 0)
                    {
                        if (i == 1 && j == 1)
                        {
                            board[i, j] = " ┌ ";
                        }
                        else if (i == board_height && j == board_width)
                        {
                            board[i, j] = "┘ ";
                        }
                        else if (i == 1 && j == board_width)
                        {
                            board[i, j] = "┐ ";
                        }
                        else if (i == board_height && j == 1)
                        {
                            board[i, j] = " └ ";
                        }
                        else if (i == 1 || i == board_height)
                        {
                            board[i, j] = "─ ";
                        }
                        else if (j == 1 || j == board_width)
                        {
                            board[i, j] = " │";
                        }
                        else
                        {
                            board[i, j] = "□";
                        }
                    }


                }
            }
            //view.MiniGameFrame();
        }
        public void algo(int x, int y)
        {
            int[] dx = new int[8] { -1, -1, -1, 1, 1, 1, 0, 0 };
            int[] dy = new int[8] { -1, 1, 0, -1, 1, 0, -1, 1 };
            Random random = new Random();
            wx = x + dx[random.Next(0, 7 + 1)];
            wy = y + dy[random.Next(0, 7 + 1)];

        }
        public void GoLogic(bool turn)
        {
            int a = 0, b = 0;
            if (turn)
            {
                Console.SetCursorPosition(1, board_height + 1);
                Console.WriteLine("좌표 입력해주세요");
                Console.SetCursorPosition(1, board_height + 2);
                int.TryParse(Console.ReadLine(), out int x);
                Console.SetCursorPosition(1, board_height + 3);
                int.TryParse(Console.ReadLine(), out int y);
                GoBoard(x, y, true);
            }


            for (int i = 1; i <= board_height; i++)
            {
                for (int j = 1; j <= board_width; j++)
                {
                    if (visited[i, j] == 1)
                    {
                        a = i;
                        b = j;
                    }
                }
            }
            algo(a, b);
            GoBoard(a, b, false);
            Console.WriteLine("{0} {1}", a, b);

            for (int i = 1; i <= board_height; i++)
            {
                for (int j = 1; j <= board_width; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }

            Ocheck();
            Console.SetCursorPosition(5, board_height + 3);
            Console.WriteLine(wincheck);
        }
        public void GoMain()
        {
            bool turn = true;
            int i = 0;
            while (true)
            {

                GoLogic(true);

                i++;

            }
        }
    }
}
