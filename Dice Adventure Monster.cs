using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DiceAdventure
{
    public class Monster
    {
        protected string Name;
        protected int HP;
        public virtual void PlayerWin()
        {}
        public virtual void PlayerLoose()
        {}
        public virtual void PlayerDraw()
        {}
        public virtual void Script()
        {}
        public virtual void BattleMonster()
        {}
    }
    public class Rabbit : Monster {
        public Rabbit() {
            this.Name = "토끼";
            this.HP = 1;
        }
        
        public override void Script()
        {
            Console.WriteLine("\t{0}를(을) 만났다!", this.Name);
            Console.WriteLine("\t{0}과의 전투가 시작되었다!",this.Name);
            Console.WriteLine("\t{0} : 토끼잇 토끼잇!",this.Name);
            Console.WriteLine("\t{0}의 체력은 {1} 입니다.",this.Name ,this.HP);

        }
        public override void PlayerWin()
        {
            Console.WriteLine("\t플레이어가 승리했습니다!\n");
            Console.WriteLine("\t{0} : 끼잉끼잉 ㅜㅜ", this.Name);
        }
        public override void PlayerLoose()
        {
            Console.WriteLine("\t플레이어가 패배했습니다!");
            Console.WriteLine();
            Console.WriteLine("\tㅋㅋㅋㅋㅋ 개못함");
            Console.WriteLine();
            Console.WriteLine("\t숫자의 차이만큼 뒤로갑니다!");
        }
        public override void PlayerDraw()
        {
            Console.WriteLine("\t비겼습니다!");
            Console.WriteLine();
            Console.WriteLine("\t다..다음에 다시보자!");
            Console.WriteLine();
            Console.WriteLine("\t{0}가 도망갔습니다!!",this.Name);
        }
    }
    public class Wolf : Monster{
        public Wolf()
        {
            this.Name = "늑대";
            this.HP = 2;
        }

        public override void Script()
        {
            Console.WriteLine("\t{0}를(을) 만났다!", this.Name);
            Console.WriteLine("\t{0}과의 전투가 시작되었다!", this.Name);
            Console.WriteLine("\t{0} : 아우우우우 ~ !", this.Name);
            Console.WriteLine("\t{0}의 체력은 {1} 입니다.", this.Name,this.HP);
        }
        public override void PlayerWin()
        {
            Console.WriteLine("\t플레이어가 승리했습니다!\n");
            Console.WriteLine("\t{0} : 끼잉 끼잉 끼잉 ㅜㅜ",this.Name);
        }
        public override void PlayerLoose()
        {
            Console.WriteLine("\t플레이어가 패배했습니다!");
            Console.WriteLine();
            Console.WriteLine("\tㅋㅋㅋㅋㅋ 개못함");
            Console.WriteLine();
            Console.WriteLine("\t숫자의 차이만큼 뒤로갑니다");
        }
        public override void PlayerDraw()
        {
            Console.WriteLine("\t비겼습니다!");
            Console.WriteLine();
            Console.WriteLine("\t컹컹! 컹컹!");
            Console.WriteLine();
            Console.WriteLine("\t{0}가 도망갔습니다!!", this.Name);
        }
    }
    public class Goblin : Monster {
        public Goblin()
        {
            this.HP = 3;
            this.Name = "고블린";
        }
        public override void Script()
        {
            Console.WriteLine("\t{0}를(을) 만났다!", this.Name);
            Console.WriteLine("\t{0}과의 전투가 시작되었다!", this.Name);
            Console.WriteLine("\t{0} : 키릭 키릭 키이릭!", this.Name);
            Console.WriteLine("\t{0}의 체력은 {1} 입니다.", this.Name,this.HP);
        }
        public override void PlayerWin()
        {
            Console.WriteLine("\t플레이어가 승리했습니다!\n");
            Console.WriteLine("\t{0} : 크에엑 크엑 !", this.Name);
        }
        public override void PlayerLoose()
        {
            Console.WriteLine("\t플레이어가 패배했습니다!");
            Console.WriteLine();
            Console.WriteLine("\tㅋㅋㅋㅋㅋ 뭐함?");
            Console.WriteLine();
            Console.WriteLine("\t숫자의 차이만큼 뒤로갑니다");
        }
        public override void PlayerDraw()
        {
            Console.WriteLine("\t비겼습니다!");
            Console.WriteLine();
            Console.WriteLine("\t다..다음에 다시보자!");
            Console.WriteLine();
            Console.WriteLine("\t{0}가 도망갔습니다!!", this.Name);
        }
    }
    public class Troll : Monster {
        public Troll()
        {
            this.HP = 4;
            this.Name = "트롤";
        }
        public override void Script()
        {
            Console.WriteLine("\t{0}를(을) 만났다!", this.Name);
            Console.WriteLine("\t{0}과의 전투가 시작되었다!", this.Name);
            Console.WriteLine("\t{0} : 트으로올 트으로올 !", this.Name);
            Console.WriteLine("\t{0}의 체력은 {1} 입니다.",this.Name ,this.HP);
        }
        public override void PlayerWin()
        {
            Console.WriteLine("\t플레이어가 승리했습니다!\n");
            Console.WriteLine("\t{0} : 끄엑 끄억 ", this.Name);
        }
        public override void PlayerLoose()
        {
            Console.WriteLine("\t플레이어가 패배했습니다!");
            Console.WriteLine();
            Console.WriteLine("\t트로오? 트로오?");
            Console.WriteLine();
            Console.WriteLine("\t숫자의 차이만큼 뒤로갑니다");
        }
        public override void PlayerDraw()
        {
            Console.WriteLine("\t비겼습니다!");
            Console.WriteLine();
            Console.WriteLine("\t다..다음에 다시보자!");
            Console.WriteLine();
            Console.WriteLine("\t{0}가 도망갔습니다!!", this.Name);
        }
    }
    public class Golem : Monster {
        public Golem()
        {
            this.HP = 5;
            this.Name = "골렘";
        }
        public override void Script()
        {
            Console.WriteLine("\t{0}를(을) 만났다!", this.Name);
            Console.WriteLine("\t{0}과의 전투가 시작되었다!", this.Name);
            Console.WriteLine("\t{0} : 고우우울렘 고우웅울렘!", this.Name);
            Console.WriteLine("\t{0}의 체력은 {1} 입니다.", this.Name,this.HP);
        }
        public override void PlayerWin()
        {
            Console.WriteLine("\t플레이어가 승리했습니다!\n");
            Console.WriteLine("\t{0} : 쿠쿠구구구구궁 ! ", this.Name);
        }
        public override void PlayerLoose()
        {
            Console.WriteLine("\t플레이어가 패배했습니다!");
            Console.WriteLine();
            Console.WriteLine("\tㅋㅋㅋㅋㅋ 허졉");
            Console.WriteLine();
            Console.WriteLine("\t숫자의 차이만큼 뒤로갑니다");
        }
        public override void PlayerDraw()
        {
            Console.WriteLine("\t비겼습니다!");
            Console.WriteLine();
            Console.WriteLine("\t고우울 고우울?!");
            Console.WriteLine();
            Console.WriteLine("\t{0}가 도망갔습니다!!", this.Name);
        }
    }
    public class Dragon : Monster {
        public Dragon()
        {
            this.HP = 6;
            this.Name = "드래곤";       
        }
        public override void Script()
        {
            Console.WriteLine("\t{0}를(을) 만났다!", this.Name);
            Console.WriteLine("\t{0}과의 전투가 시작되었다!", this.Name);
            Console.WriteLine("\t{0} : 래곤! 래곤!", this.Name);
            Console.WriteLine("\t{0}의 체력은 {1} 입니다.", this.Name, this.HP);
        }
        public override void PlayerWin()
        {
            Console.WriteLine("\t플레이어가 승리했습니다!\n");
            Console.WriteLine("\t{0} : 끼잉끼잉 ㅜㅜ", this.Name);
        }
        public override void PlayerLoose()
        {
            Console.WriteLine("\t플레이어가 패배했습니다!");
            Console.WriteLine();
            Console.WriteLine("\tㅋㅋㅋㅋㅋㅋ 이것도 못이김");
            Console.WriteLine();
            Console.WriteLine("\t숫자의 차이만큼 뒤로갑니다");
        }
        public override void PlayerDraw()
        {
            Console.WriteLine("\t비겼습니다!");
            Console.WriteLine();
            Console.WriteLine("\t인간 주제에 제법이군");
            Console.WriteLine();
            Console.WriteLine("\t{0}가 도망갔습니다!!", this.Name);
        }
    }
}
