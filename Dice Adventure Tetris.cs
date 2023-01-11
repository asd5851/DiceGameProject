using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceAdventure
{
    /*
     * 블록의 값 -> 맵에 넣어
     * 1을 오른쪽 키를 누르면 오른쪽으로 가 
     */
    public class MakeBlock
    {
        public void MBlock()
        {
            int[,] st_mino = new int[4, 4];
            st_mino[0, 0] = 1;
            st_mino[1, 0] = 1;
            st_mino[2, 0] = 1;
            st_mino[3, 0] = 1;

            int[,] sq_mino = new int[4, 4];
            st_mino[0, 0] = 1;
            st_mino[0, 1] = 1;
            st_mino[1, 0] = 1;
            st_mino[1, 1] = 1;
        }
    }
    public class TetrisMap
    {
        int[,] map = new int[15, 10];
        int width = 10;
        int height = 15;
        public void MakeMap()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == height - 1)
                    { 
                        map[i, j] = 1;
                    }
                    else
                    {
                        map[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
    public class TetrisView
    {

    }// class : TetrisView -> 테트리스가 눈에 보이는 부분

    public class Tetris
    {
        TetrisMap map = new TetrisMap();
        ConsoleKeyInfo keyinfo = new ConsoleKeyInfo();
        int width = 10;
        int height = 15;


        char key;
        public void TetrisMain()
        {
            int[,] st_mino = new int[4, 4];
            int X=0, Y=0;
            st_mino[0, 0] = 1;
            st_mino[1, 0] = 1;
            st_mino[2, 0] = 1;
            st_mino[3, 0] = 1;
            map.MakeMap();
            while (true)
            {
                Input();
                switch (key)
                {
                    case 'w':
                        Y--;
                        for(int i = 0; i < 4; i++)
                        {
                            for(int j=0;j<4; j++)
                            {
                                st_mino[i + X, j + Y];
                            }
                        }
                        
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
            }
        }
        public void HowMove()
        {

        }
        public void Input()
        {
            if (Console.KeyAvailable)
            {
                keyinfo = Console.ReadKey(true);
                key = keyinfo.KeyChar;
            }
        }
    }
}
