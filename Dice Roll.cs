using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceAdventure
{
    public class Dice_Roll
    {
        private int dice_number;
        // 주사위를 굴린다.
        public int Dice_number
        {
            get { return this.dice_number; }
            set { this.dice_number = value; }
            
        }
        public int RollDice()
        {
            Random random= new Random();
            Dice_number = random.Next(1,6+1);
            return Dice_number;
        }
    }
}
