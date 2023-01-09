using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceAdventure
{
    public class Player
    {
        private int location;
        private int hp;
        private string name;
        public int Location
        {
            get
            {
                return this.location;
            }
            set
            {
                location = value;
            }
        }
        public int HP
        {
            get
            {
                return this.hp;
            }
            set
            {
                hp = value;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                name = value;
            }
        }
    }
  
    public class MovePlayer : Player
    {
        public void MoveForwardEvent(Player player)
        {
            Random random = new Random();
            player.Location = player.Location + random.Next(0, 3 + 1) * 2;
        }
        public void MoveBackwardEvent(Player player)
        {
            Random random = new Random();
            player.Location = player.Location - random.Next(-3, 0 + 1) * 2;
        }
    }
    public class HP_Player : Player
    {
        public void Change_HP(int monster)
        {
            HP = HP - monster;
        }
    }
}
