using System;
using System.Numerics;
using System.Windows;
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

        static void Main(string[] args)
        {
            Random random = new Random(); // 랜덤인자
            Player player = new Player(); // 플레이어 클래스 
            Player computer = new Player();
            Dice_Roll d_roll = new Dice_Roll();

            Go go = new Go();
            View view = new View();
            StartStory startstory = new StartStory();
            StartView startview = new StartView();
            MonsterView monsterview = new MonsterView();

            GameLogic gamelogic = new GameLogic();
            player.HP = 10;
            player.Location = 3;// 3 ~ 108
            player.Name = "플레이어";

            computer.HP = 15;
            computer.Location = 3;
            computer.Name = "악당";
            go.GoMain();
            //startview.BlingStartView();
            //startstory.ShowStory();
            //gamelogic.Game(player,computer, view, d_roll, monsterview);


        }
    }
}