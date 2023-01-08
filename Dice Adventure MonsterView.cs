using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceAdventure
{
    public class MonsterView : View
    {
        Rabbit rabbit = new Rabbit();
        Wolf wolf = new Wolf();
        Goblin goblin = new Goblin();
        Troll troll = new Troll();
        Golem golem = new Golem();
        Dragon dragon = new Dragon();
        FrameView frameview = new FrameView();
        public void MonsterMessage(int Width, int Height, int monster_num)
        {

            Console.SetCursorPosition(1, Height / 2);
            switch (monster_num)
            {
                case 1:
                    rabbit.Script();
                    MonsterFaceRabbit(Width,Height);
                    break;
                case 2:
                    wolf.Script();
                    MonsterFaceWolf (Width, Height);

                    break;
                case 3:
                    goblin.Script();
                    MonsterFaceGoblin (Width, Height);

                    break;
                case 4:
                    troll.Script();
                    //MonsterFace(Width, Height);

                    break;
                case 5:
                    golem.Script();
                    //MonsterFace(Width, Height);

                    break;
                case 6:
                    dragon.Script();
                    //MonsterFace(Width, Height);

                    break;
            }
            Frame(Width, Height);
            Console.ReadLine();

        }
        public void MonsterCompareView(ref Player player, int Width, int Height, int compare_monster, int monster_hp)
        {
            Console.Clear();
            Console.SetCursorPosition(1, Height / 2);

            if (monster_hp < compare_monster) // 내 주사위가 몬스터의 체력보다 크다면
            {
                switch (monster_hp)
                {
                    case 1:
                        rabbit.PlayerWin();
                        break;
                    case 2:
                        wolf.PlayerWin();
                        break;
                    case 3:
                        goblin.PlayerWin();
                        break;
                    case 4:
                        troll.PlayerWin();
                        break;
                    case 5:
                        golem.PlayerWin();
                        break;
                    case 6:
                        dragon.PlayerWin();
                        break;
                }
            }
            else
            {
                switch (monster_hp)
                {
                    case 1:
                        rabbit.PlayerLoose();
                        player.Location = player.Location - (monster_hp - compare_monster) * 2;
                        player.HP = player.HP - (monster_hp - compare_monster);
                        ShowMap(Width, Height, 0, player.Location, false);
                        break;
                    case 2:
                        wolf.PlayerLoose();
                        player.Location = player.Location - (monster_hp - compare_monster) * 2;
                        player.HP = player.HP - (monster_hp - compare_monster);

                        ShowMap(Width, Height, 0, player.Location, false);
                        break;
                    case 3:
                        goblin.PlayerLoose();
                        player.Location = player.Location - (monster_hp - compare_monster) * 2;
                        player.HP = player.HP - (monster_hp - compare_monster);

                        ShowMap(Width, Height, 0, player.Location, false);
                        break;
                    case 4:
                        troll.PlayerLoose();
                        player.Location = player.Location - (monster_hp - compare_monster) * 2;
                        player.HP = player.HP - (monster_hp - compare_monster);

                        ShowMap(Width, Height, 0, player.Location, false);
                        break;
                    case 5:
                        golem.PlayerLoose();
                        player.Location = player.Location - (monster_hp - compare_monster) * 2;
                        player.HP = player.HP - (monster_hp - compare_monster);

                        ShowMap(Width, Height, 0, player.Location, false);
                        break;
                    case 6:
                        dragon.PlayerLoose();
                        player.Location = player.Location - (monster_hp - compare_monster) * 2;
                        player.HP = player.HP - (monster_hp - compare_monster);

                        ShowMap(Width, Height, 0, player.Location, false);
                        break;
                }
            }
            Frame(Width, Height);

            Console.ReadLine();
        }

        public void MonsterFaceRabbit(int Width, int Height)
        {
            Console.SetCursorPosition(Width / 2, Height / 2 - 2);
            Console.WriteLine("      **");
            Console.SetCursorPosition(Width / 2, Height / 2 - 1);
            Console.WriteLine("   **  ** ");
            Console.SetCursorPosition(Width / 2, Height / 2 );
            Console.WriteLine(" **   **");
            Console.SetCursorPosition(Width / 2, Height / 2 + 1);
            Console.WriteLine("** -  ********○");
            Console.SetCursorPosition(Width / 2, Height / 2 + 2);
            Console.WriteLine(" *          *");
            Console.SetCursorPosition(Width / 2, Height / 2 + 3);
            Console.WriteLine("  ************");
            Console.SetCursorPosition(Width / 2, Height / 2 + 4);
            Console.WriteLine("    **      **");
        } 
        public void MonsterFaceWolf(int Width, int Height)
        {
            Console.SetCursorPosition(Width / 2, Height / 2 - 4);
            Console.WriteLine(" ****             *****");
            Console.SetCursorPosition(Width / 2, Height / 2 - 3);
            Console.WriteLine(" *    *          *    *");
            Console.SetCursorPosition(Width / 2, Height / 2 - 2);
            Console.WriteLine(" *   ** *********     * ");
            Console.SetCursorPosition(Width / 2, Height / 2 - 1);
            Console.WriteLine("  *                  **");
            Console.SetCursorPosition(Width / 2, Height / 2 );
            Console.WriteLine("    *                 *");
            Console.SetCursorPosition(Width / 2, Height / 2 + 1);
            Console.WriteLine("    *  ◎      ◎    ** *");
            Console.SetCursorPosition(Width / 2, Height / 2 + 2);
            Console.WriteLine("    *               *");
            Console.SetCursorPosition(Width / 2, Height / 2 + 3);
            Console.WriteLine("     *     ●       *");
            Console.SetCursorPosition(Width / 2, Height / 2 + 4);
            Console.WriteLine("      *            *");
            Console.SetCursorPosition(Width / 2, Height / 2 + 5);
            Console.WriteLine("       ***  ㅡ ***");
        }
        public void MonsterFaceGoblin(int Width, int Height)
        {

            Console.SetCursorPosition(Width / 2, Height / 2 - 2);
            Console.WriteLine("     ****** ");
            Console.SetCursorPosition(Width / 2, Height / 2 - 1);
            Console.WriteLine("*** *      *  ***");
            Console.SetCursorPosition(Width / 2, Height / 2);
            Console.WriteLine(" ** *◎ ◎  * **");
            Console.SetCursorPosition(Width / 2, Height / 2 + 1);
            Console.WriteLine("    * ●    *");
            Console.SetCursorPosition(Width / 2, Height / 2 + 2);
            Console.WriteLine("     * ㅡ  *");
            Console.SetCursorPosition(Width / 2, Height / 2 + 3);
            Console.WriteLine("      ****");
            Console.SetCursorPosition(Width / 2, Height / 2 + 4);
            Console.WriteLine("        / |／ ");
            Console.SetCursorPosition(Width / 2, Height / 2 + 5);
            Console.WriteLine("         / │");
        }
    }
}
