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
            MovePlayer moveplayer = new MovePlayer(); // 플레이어 움직이는 클래스
            Dice_Roll d_roll = new Dice_Roll();
            BattleComputer battlecomputer = new BattleComputer();
            CardGame card = new CardGame();

            View view = new View();
            StartStory startstory = new StartStory();
            StartView startview = new StartView();
            MonsterView monsterview = new MonsterView();

            SlideGame slidegame = new SlideGame();
            SnakeGAME snakegame = new SnakeGAME();
            AvoidGame avoid = new AvoidGame();
            ShootingGame shot = new ShootingGame();

            NQuest quest = new NQuest();
            GameLogic gamelogic = new GameLogic();
            int compare_monster = 0;
            int compare_move = 0;
            int monster_temp = 0;
            player.HP = 10;
            player.Location = 3;// 3 ~ 108
            player.Name = "플레이어";
            computer.HP = 15;
            computer.Location = 3;
            computer.Name = "악당";
           
            //startview.BlingStartView();
            //startstory.ShowStory();
            gamelogic.Game(player,computer, view, d_roll, monsterview);
            
        }
    }
}