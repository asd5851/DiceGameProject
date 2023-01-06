using System;
using System.Numerics;

namespace DiceAdventure
{
    internal class Program
    {
        /*
         * 아이디어 고갈
         * 블랙잭
         * 오목
         * 
         */
        
        public const int m_width = 110;
        public const int m_height = 10;
        public int m_playerX = 0;
        public int m_monster = 0;
        public static int[] arr = new int[100001];
        public static void Eratos()
        {
            for(int i=2;i<=m_width; i++)
            {
                arr[i] = i;
            }
            for(int i=2;i<=m_width; i++)
            {
                for(int j=i*2;j<=m_width; j = j + i)
                {
                    arr[j] = 0;
                }
            }
        }
        public static int MovePlayer(Player player, View view, Dice_Roll d_roll, bool move)
        {
            int result;

            switch (result = d_roll.RollDice())
            {
                case 1:
                    view.RollDiceOne(110, 10, 1, move, player.Location);
                    if(move)player.Location += 1 * 2;


                    break;
                case 2:
                    view.RollDiceTwo(110, 10, 2, move, player.Location);
                    if(move)player.Location += 2 * 2;

                    break;
                case 3:
                    view.RollDiceThree(110, 10, 3, move, player.Location);
                    if (move) player.Location += 3 * 2;

                    break;
                case 4:
                    view.RollDiceFour(110, 10, 4, move, player.Location);
                    if (move) player.Location += 4 * 2;

                    break;
                case 5:
                    view.RollDiceFive(110, 10, 5, move, player.Location);
                    if (move) player.Location += 5 * 2;

                    break;
                case 6:
                    view.RollDiceSix(110, 10, 6, move, player.Location);
                    if (move) player.Location += 6 * 2;

                    break;
            }
            return result;
            
        }
        static void Main(string[] args)
        {
            Random random= new Random();
            Player player = new Player();
            MovePlayer moveplayer = new MovePlayer();
            Dice_Roll d_roll = new Dice_Roll();
            View view = new View();
            Rabbit rabbit = new Rabbit();
            Wolf wolf = new Wolf();
            SlideGame slidegame = new SlideGame();
            SnakeGAME snakegame = new SnakeGAME();
            
            int compare_monster=0;
            int compare_move = 0;
            int monster_temp = 0;
            player.Location = m_width / 2 - m_width / 4; // 55 - 47 = 8
            //snakegame.SnakeBoard(m_width,m_height);
            Eratos(); // 에라토스테네스의 체를 이용해서 소수선별
            view.DiceView(m_width, m_height);
            //view.BlingStartView(); // 시작화면 출력
            ////moveplayer.MoveForwardEvent(player);
            ////moveplayer.MoveBackwardEvent(player);
            //slidegame.Slidegame();
            //while (true)
            //{
            //    view.MessageDice(m_width, m_height); // 주사위를 굴려달라는 메시지 출력
            //    view.ShowMap(m_width, m_height, 0, player.Location, true);
            //    MovePlayer(player, view, d_roll, true); // 주사위를 굴리고 플레이어의 위치 이동

            //    //Console.ReadLine();
            //    Console.Clear();
            //    //moveplayer.MoveForwardEvent(player);
            //    if (player.Location < 40)
            //    {
            //        monster_temp = random.Next(1, 3 + 1); // 1 ~ 3까지 랜덤 인수 받아서
            //        view.MonsterMessage(m_width, m_height, monster_temp); // 어떤 몬스터를 만나는지 출력
            //        view.MessageDice(m_width, m_height);
            //        compare_monster = MovePlayer(player, view, d_roll, false); // 
            //        view.MonsterCompareView(ref player, m_width, m_height, compare_monster, monster_temp);
            //        Console.ReadLine();
            //        //view.ShowMap(m_width, m_height, 0, player.Location, true);

            //       // Console.ReadLine();
            //    }
            //    else if (player.Location >= 40)
            //    {
            //        monster_temp = random.Next(1, 6 + 1); // 1 ~ 6까지 랜덤 인수 받아서
            //        view.MonsterMessage(m_width, m_height, monster_temp); // 어떤 몬스터를 만나는지
            //        view.MessageDice(m_width, m_height);
            //        compare_monster = MovePlayer(player, view, d_roll, false); // 주사위를 굴린다.
            //        view.MonsterCompareView(ref player, m_width, m_height, compare_monster, monster_temp);
            //        Console.ReadLine() ;
            //        //view.ShowMap(m_width, m_height, 0, player.Location,true);
            //        //Console.ReadLine();

            //    }
            //}


           
            //MovePlayer(player, view, d_roll, true);


            //view.ShowMap(11,18,110);

        }
    }
}