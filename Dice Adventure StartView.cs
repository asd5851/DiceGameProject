using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceAdventure
{
    
    // 시작화면 (스타트 화면)
    public class StartView
    {
        private void StartPrint()
        {
            Console.WriteLine();
            Console.WriteLine("\t\t\t ■■■■\t\t■\t\t ■■■■\t\t■■■■■");
            Console.WriteLine("\t\t\t ■      ■\t\t■\t\t■       ■\t\t■");
            Console.WriteLine("\t\t\t ■       ■\t\t■\t\t■\t\t\t■■■■■");
            Console.WriteLine("\t\t\t ■       ■\t\t■\t\t■\t\t\t■");
            Console.WriteLine("\t\t\t ■      ■\t\t■\t\t■       ■\t\t■");
            Console.WriteLine("\t\t\t ■■■■\t\t■\t\t ■■■■\t\t■■■■■");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("\t    ■\t\t ■■■■\t■        ■\t■■■■■■\t■\t■\t■■■■\t■■■■■");
            Console.WriteLine("\t  ■  ■\t ■\t ■ \t ■      ■\t     ■\t\t■\t■\t■\t■\t■");
            Console.WriteLine("\t ■    ■\t ■\t  ■\t  ■    ■\t     ■\t\t■\t■\t■■■■\t■");
            Console.WriteLine("\t■■■■■\t ■\t  ■\t   ■  ■\t     ■\t\t■\t■\t■  ■\t\t■■■■■");
            Console.WriteLine("\t■      ■\t ■\t ■\t    ■■\t     ■\t\t■\t■\t■    ■\t■");
            Console.WriteLine("\t■      ■\t ■■■■\t     ■\t\t     ■\t\t■■■■■\t■      ■\t■■■■■");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


            // Console.Clear();
        }
        private void StartPrint2()
        {
            Console.WriteLine();
            Console.WriteLine("\t\t\t □□□□\t\t□\t\t □□□□\t\t□□□□□");
            Console.WriteLine("\t\t\t □      □\t\t□\t\t□       □\t\t□");
            Console.WriteLine("\t\t\t □       □\t\t□\t\t□\t\t\t□□□□□");
            Console.WriteLine("\t\t\t □       □\t\t□\t\t□\t\t\t□");
            Console.WriteLine("\t\t\t □      □\t\t□\t\t□       □\t\t□");
            Console.WriteLine("\t\t\t □□□□\t\t□\t\t □□□□\t\t□□□□□");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("\t    □\t\t □□□□\t□        □\t□□□□□□\t□\t□\t□□□□\t□□□□□");
            Console.WriteLine("\t  □  □\t □\t □ \t □      □\t     □\t\t□\t□\t□\t□\t□");
            Console.WriteLine("\t □    □\t □\t  □\t  □    □\t     □\t\t□\t□\t□□□□\t□");
            Console.WriteLine("\t□□□□□\t □\t  □\t   □  □\t     □\t\t□\t□\t□  □\t\t□□□□□");
            Console.WriteLine("\t□      □\t □\t □\t    □□\t     □\t\t□\t□\t□    □\t□");
            Console.WriteLine("\t□      □\t □□□□\t     □\t\t     □\t\t□□□□□\t□      □\t□□□□□");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
        public void BlingStartView()
        {
            for (int i = 0; i < 15; i++)
            {
                StartPrint();
                Thread.Sleep(100);
                Console.Clear();
                StartPrint2();
                Thread.Sleep(100);
                Console.Clear();
            }
            StartPrint();
            Console.WriteLine("\t\t\t\t\t\tPress Any Button");
            Console.ReadLine();
            Console.Clear();
        }
    }
    public class StartStory
    {
        int Width = 50;
        int Height = 30;
       public void ShowStory()
        {
            SnakeGAME snake= new SnakeGAME();
            Console.SetCursorPosition(Width / 2, Height / 2 - 6);
            Console.WriteLine("주사위 용사는 공주님을 구출하고 악의 소굴을 탈출해야한다!");
            Console.SetCursorPosition(Width / 2, Height / 2 - 4);
            Console.WriteLine("공주님은 이 맵의 끝에 위치해있다!");
            Console.SetCursorPosition(Width / 2, Height / 2  - 2);
            Console.WriteLine("따라오는 악당을 물리치고 공주님을 구출하여 악당의 성에서 탈출하자!");

            Console.SetCursorPosition(Width / 2, Height / 2 + 2);
            Console.WriteLine("※ 주사위 어드벤쳐는 턴제 보드게임 방식 입니다. ");
            Console.SetCursorPosition(Width / 2, Height / 2 + 4);
            Console.WriteLine("※ 주사위를 던져서 각 타일에 도착했을 경우 이벤트가 발생합니다. ");
            Console.SetCursorPosition(Width / 2, Height / 2 + 6);
            Console.WriteLine("※ 이벤트는 전투, 이동, 퀴즈, 미니게임 등 다양하게 구성되어있습니다. ");
            Console.SetCursorPosition(Width / 2, Height / 2 + 8);
            Console.WriteLine("※ 플레이 도중 악당을 만나면 주사위로 전투를 실행합니다. ");
            Console.SetCursorPosition(Width / 2, Height / 2 + 10);
            Console.WriteLine("※ 대부분의 이벤트는 엔터로 진행을 하시면 됩니다. ");
            Console.SetCursorPosition(Width / 2, Height / 2 + 12);
            Console.WriteLine("\t\t   PRESS ANY KEY ");
            snake.SnakeBoard(50,30);
            Console.ReadLine();



        }

    }
}
