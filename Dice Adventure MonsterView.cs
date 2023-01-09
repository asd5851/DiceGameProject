using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
        View view = new View();
        public void MonsterMessage(int Width, int Height, int monster_num)
        {
            Console.SetCursorPosition(1, Height / 2);
            switch (monster_num)
            {
                case 1:
                    rabbit.Script();
                    MonsterFaceRabbit(Width, Height);
                    break;
                case 2:
                    wolf.Script();
                    MonsterFaceWolf(Width, Height);

                    break;
                case 3:
                    goblin.Script();
                    MonsterFaceGoblin(Width, Height);

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
            Console.SetCursorPosition(1, Height / 2 - 2);

            if (monster_hp < compare_monster) // 내 주사위가 몬스터의 체력보다 크다면
            {
                switch (monster_hp)
                {
                    case 1:
                        rabbit.PlayerWin();
                        view.HPview(player, Width, Height);
                        break;
                    case 2:
                        wolf.PlayerWin();
                        view.HPview(player, Width, Height);
                        break;
                    case 3:
                        goblin.PlayerWin();
                        view.HPview(player, Width, Height);
                        break;
                    case 4:
                        troll.PlayerWin();
                        view.HPview(player, Width, Height);
                        break;
                    case 5:
                        golem.PlayerWin();
                        view.HPview(player, Width, Height);
                        break;
                    case 6:
                        dragon.PlayerWin();
                        view.HPview(player, Width, Height);
                        break;
                }
            }
            else
            {
                switch (monster_hp)
                {
                    case 1:
                        rabbit.PlayerLoose();
                        LooseLogic(ref player, Width, Height, compare_monster, monster_hp);
                        break;
                    case 2:
                        wolf.PlayerLoose();
                        LooseLogic(ref player, Width, Height, compare_monster, monster_hp);
                        break;
                    case 3:
                        goblin.PlayerLoose();
                        LooseLogic(ref player, Width, Height, compare_monster, monster_hp);
                        break;
                    case 4:
                        troll.PlayerLoose();
                        LooseLogic(ref player, Width, Height, compare_monster, monster_hp);
                        break;
                    case 5:
                        golem.PlayerLoose();
                        LooseLogic(ref player, Width, Height, compare_monster, monster_hp);
                        break;
                    case 6:
                        dragon.PlayerLoose();
                        LooseLogic(ref player, Width, Height, compare_monster, monster_hp);
                        break;
                }
            }
            Frame(Width, Height);

            Console.ReadLine();
        }
        public void LooseLogic(ref Player player, int Width, int Height, int compare_monster, int monster_hp)
        {
            player.Location = player.Location - (monster_hp - compare_monster) * 2;
            player.HP = player.HP - (monster_hp - compare_monster);
            ShowMap(player, Width, Height, 0, player.Location, false);
            view.HPview(player, Width, Height);
        }
        public void MonsterFaceRabbit(int Width, int Height)
        {
            Console.SetCursorPosition(Width / 2, Height / 2 - 2);
            Console.WriteLine("      **");
            Console.SetCursorPosition(Width / 2, Height / 2 - 1);
            Console.WriteLine("   **  ** ");
            Console.SetCursorPosition(Width / 2, Height / 2);
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
            Console.SetCursorPosition(Width / 2, Height / 2);
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
