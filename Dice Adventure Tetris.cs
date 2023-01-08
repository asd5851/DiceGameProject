using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceAdventure
{
    enum MapBlock
    {
        Void,
        Wall,
        Block
    }
    public class MakeBlock
    {
        public void Imino()
        {

        }
    }
    public class TetrisView
    {
        List<List<MapBlock>> list = new List<List<MapBlock>>();
        public TetrisView(int x, int y)  
        {
            for (int i = 0; i < y; i++)
            {
                list.Add(new List<MapBlock>());
                for (int j = 0; j < x; j++)
                {
                    if (i == 0)
                    {
                        list[i].Add(MapBlock.Wall);
                    }
                    else if (i == y - 1)
                    {
                        list[i].Add(MapBlock.Wall);
                    }
                    else
                    {
                        list[i].Add(MapBlock.Void);
                    }
                }
            }
        } // 생성자 : TetrisView -> 생성되면 이뜻을 따라야 한다.

        public void ViewMap()
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Count; j++)
                {
                    switch (list[i][j])
                    {
                        case MapBlock.Void:
                            Console.Write("□");
                            break;
                        case MapBlock.Wall:
                            Console.Write("■");
                            break;
                        case MapBlock.Block:
                            Console.Write("＠");
                            break;
                    }
                }
                Console.WriteLine();
            }
        } // Func : ViewMap -> 테트리스 블록, 맵을 눈에 보여주는 func
        public void SetBlockView(int y, int x)
        {
            list[y][x] = MapBlock.Block;
        }
    }// class : TetrisView -> 테트리스가 눈에 보이는 부분

    public class Tetris
    {
        public static int m_boardX = 10;
        public static int m_boardY = 20;
        TetrisView tview = new TetrisView(m_boardX, m_boardY);
        public void TetrisMain()
        {
            tview.SetBlockView(3, 3);
            tview.ViewMap();
        }
    }
}
