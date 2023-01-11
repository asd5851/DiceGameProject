using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceAdventure
{
    // NPC 클래스 : 퀘스트(문제)를 생성하고 보여준다

    public class NPC
    {
        private int Width = 110;
        private int Height = 10;

        FrameView frameview = new FrameView();
        public NPC() { }
        public virtual void Quest(Player player, int quest_num, bool kind_NPC) { }


    }
    public class NQuest : NPC
    {
        FrameView frameview = new FrameView();
        View view = new View();
        int Width = 110;
        int Height = 10;
        public override void Quest(Player player, int quest_num, bool kind_NPC)
        {
            switch (quest_num)
            {
                case 1:
                    Q1(player, kind_NPC);
                    break;
                case 2:
                    Q2(player, kind_NPC);
                    break;
                case 3:
                    Q3(player, kind_NPC);
                    break;
                case 4:
                    Q4(player, kind_NPC);
                    break;
                case 5:
                    Q5(player, kind_NPC);
                    break;
                case 6:
                    Q6(player, kind_NPC);
                    break;
                case 7:
                    Q7(player, kind_NPC);
                    break;
                case 8:
                    Q8(player, kind_NPC);
                    break;
                case 9:
                    Q9(player, kind_NPC);
                    break;
                case 10:
                    Q10(player, kind_NPC);
                    break;
                case 11:
                    Q11(player, kind_NPC);
                    break;
            }
        }
        public void QuestMessage(bool kind)
        {
            Console.Clear();
            if (kind)
            {
                Console.SetCursorPosition(1, 10 / 2);
                Console.WriteLine("\t누군가 말을 걸어 왔다");
                Thread.Sleep(1000);
                Console.WriteLine("\t저의 문제를 맞추면 체력이 회복될 것이에용");
                Console.WriteLine("\t하지만 제가 내는 문제를 맞추지 못하면 체력이 떨어질거에용 ㅠ");
                ViewNPC2();
            }
            else
            {
                Console.SetCursorPosition(1, 10 / 2);
                Console.WriteLine("\t누군가 말을 걸어 왔다");
                Thread.Sleep(1000);
                Console.WriteLine("\t내가 내는 문제를 맞추면 아무일도 없을것이다!");
                Console.WriteLine("\t하지만 내가 내는 문제를 틀린다면 너의 체력을 빼앗아 가겠다!");
                ViewNPC();

            }
            frameview.Frame(110, 10);
            Thread.Sleep(1000);
            Console.SetCursorPosition(8, 10 / 2 + 4);
            Console.WriteLine("Press Any Key");
            Console.ReadKey(true);
        }
        protected virtual void ViewNPC()
        {
            Console.SetCursorPosition(Width / 2 + Width / 4, Height / 2 - 2);
            Console.WriteLine("      ** **");
            Console.SetCursorPosition(Width / 2 + Width / 4, Height / 2 - 1);
            Console.WriteLine("   **      ** ");
            Console.SetCursorPosition(Width / 2 + Width / 4, Height / 2);
            Console.WriteLine(" **          **");
            Console.SetCursorPosition(Width / 2 + Width / 4, Height / 2 + 1);
            Console.WriteLine("**  ◎    ◎   **");
            Console.SetCursorPosition(Width / 2 + Width / 4, Height / 2 + 2);
            Console.WriteLine(" **    ▲     **");
            Console.SetCursorPosition(Width / 2 + Width / 4, Height / 2 + 3);
            Console.WriteLine("  **   ▽   **");
            Console.SetCursorPosition(Width / 2 + Width / 4, Height / 2 + 4);
            Console.WriteLine("     ****");
        }
        protected virtual void ViewNPC2()
        {
            Console.SetCursorPosition(Width / 2 + Width / 4, Height / 2 - 2);
            Console.WriteLine("      ** **");
            Console.SetCursorPosition(Width / 2 + Width / 4, Height / 2 - 1);
            Console.WriteLine("   **      ** ");
            Console.SetCursorPosition(Width / 2 + Width / 4, Height / 2);
            Console.WriteLine(" **          **");
            Console.SetCursorPosition(Width / 2 + Width / 4, Height / 2 + 1);
            Console.WriteLine("**  ⊙    ⊙   **");
            Console.SetCursorPosition(Width / 2 + Width / 4, Height / 2 + 2);
            Console.WriteLine(" **    ♥     **");
            Console.SetCursorPosition(Width / 2 + Width / 4, Height / 2 + 3);
            Console.WriteLine("  **   ▽   **");
            Console.SetCursorPosition(Width / 2 + Width / 4, Height / 2 + 4);
            Console.WriteLine("     ****");
        }
        private void Q1(Player player, bool kind_NPC)
        {
            Console.Clear();
            frameview.Frame(Width, Height);
            int n_add1 = 0;
            int n_add2 = 0;
            int result = 0;
            Random random = new Random();
            n_add1 = random.Next(0, 101);
            n_add2 = random.Next(0, 101);
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 - 1);
            Console.WriteLine("[Easy]");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2);
            Console.WriteLine("{0} + {1}", n_add1, n_add2);
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 1);
            Console.Write("답을 쓰시오 : ");
            Console.SetCursorPosition(Width / 2 + 1, Height / 2);
            int.TryParse(Console.ReadLine(), out result);
            if (result == n_add1 + n_add2)
            {
                if (kind_NPC)
                {
                    player.HP += 1;
                    CheckQ(player, true, 1);
                }
                else
                {
                    CheckQ(player, true, 0);
                }
            }
            else
            {
                player.HP = player.HP - 1;
                CheckQ(player, false, 1);
            }

        }
        private void Q2(Player player, bool kind_NPC)
        {
            Console.Clear();
            frameview.Frame(Width, Height);
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 - 1);
            Console.WriteLine("[Normal]");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2);
            Console.WriteLine("부모 클래스에 만든 메서드를 자식 클래스에서 다시 새롭게");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 1);
            Console.WriteLine("만들어 사용하는 것을 무엇이라 하는가?");

            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 2);
            Console.Write("답을 쓰시오 : ");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 3);
            string result = Console.ReadLine();
            if (result.Equals("오버라이딩") || result.Equals("오버라이드"))
            {
                if (kind_NPC)
                {
                    player.HP += 1;
                    CheckQ(player, true, 1);
                }
                else
                {
                    CheckQ(player, true, 0);
                }
            }
            else
            {
                player.HP -= 2;
                CheckQ(player, false, 2);
            }

        }
        private void Q3(Player player, bool kind_NPC)
        {
            Console.Clear();
            frameview.Frame(Width, Height);
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 - 1);
            Console.WriteLine("[Normal]");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2);
            Console.WriteLine("같은 이름의 메서드를 가지면서");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 1);
            Console.WriteLine("매개변수의 유형과 갯수가 다르도록 하는 것은 무엇인가?");

            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 2);
            Console.Write("답을 쓰시오 : ");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 3);
            string result = Console.ReadLine();
            if (result.Equals("오버로드") || result.Equals("오버로딩"))
            {
                if (kind_NPC)
                {
                    player.HP += 1;
                    CheckQ(player, true, 1);
                }
                else
                {
                    CheckQ(player, true, 0);
                }
            }
            else
            {
                player.HP -= 2;
                CheckQ(player, false, 2);
            }
        }
        private void Q4(Player player, bool kind_NPC)
        {
            Console.Clear();
            view.Frame(Width, Height);
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 - 1);
            Console.WriteLine("[Normal]");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2);
            Console.WriteLine("객체지향중 객체의 속성과 행위를 하나로 묶고 구현 내용 일부를");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 1);
            Console.WriteLine("외부에 감추어 은닉할 수 있는것을 무엇이라 하는가?");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 2);
            Console.Write("답을 쓰시오 : ");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 3);
            string result = Console.ReadLine();
            if (result.Equals("캡슐화") || result.Equals("encapsulation"))
            {
                if (kind_NPC)
                {
                    player.HP += 1;
                    CheckQ(player, true, 1);
                }
                else
                {
                    CheckQ(player, true, 0);
                }
            }
            else
            {
                player.HP -= 2;
                CheckQ(player, false, 2);
            }
        }
        private void Q5(Player player, bool kind_NPC)
        {
            Console.Clear();
            view.Frame(Width, Height);
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 - 1);
            Console.WriteLine("[Normal]");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2);
            Console.WriteLine("클래스는 다중상속이 불가능지만 이 기능은 다중상속을 지원한다.");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 1);
            Console.WriteLine("여러 부모클래스를 상속받아 다양한 동작을 수행하는 이 기능은 무엇인가?");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 2);
            Console.Write("답을 쓰시오 : ");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 3);
            string result = Console.ReadLine();
            if (result.Equals("인터페이스") || result.Equals("interface"))
            {
                if (kind_NPC)
                {
                    player.HP += 1;
                    CheckQ(player, true, 1);
                }
                else
                {
                    CheckQ(player, true, 0);
                }
            }
            else
            {
                player.HP -= 2;
                CheckQ(player, false, 2);
            }
        }
        private void Q6(Player player, bool kind_NPC)
        {
            Console.Clear();
            view.Frame(Width, Height);
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 - 1);
            Console.WriteLine("[Hard]");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2);
            Console.WriteLine("Java나 C#에서 메모리를 자동으로 해제해주는");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 1);
            Console.WriteLine("이 기능은 무엇인가?");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 2);
            Console.Write("답을 쓰시오 : ");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 3);
            string result = Console.ReadLine();
            if (result.Equals("GC") || result.Equals("gc") || result.Equals("가비지 콜렉터"))
            {
                if (kind_NPC)
                {
                    player.HP += 1;
                    CheckQ(player, true, 1);
                }
                else
                {
                    CheckQ(player, true, 0);
                }
            }
            else
            {
                player.HP -= 3;
                CheckQ(player, false, 3);
            }
        }
        private void Q7(Player player, bool kind_NPC)
        {
            Console.Clear();
            view.Frame(Width, Height);
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 - 1);
            Console.WriteLine("[Hard]");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2);
            Console.WriteLine("메서드를 호출하는 쪽에서 선언만 하고, 초기화 하지않고 전달하면 ");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 1);
            Console.WriteLine("메서드쪽에서 해당 데이터를 초기화해서 넘겨주는 형식은 무엇인가?(키워드)");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 2);
            Console.Write("답을 쓰시오 : ");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 3);
            string result = Console.ReadLine();
            if (result.Equals("반환형전달방식") || result.Equals("out") || result.Equals("반환형전달"))
            {
                if (kind_NPC)
                {
                    player.HP += 1;
                    CheckQ(player, true, 1);
                }
                else
                {
                    CheckQ(player, true, 0);
                }
            }
            else
            {
                player.HP -= 3;
                CheckQ(player, false, 3);
            }
        }
        private void Q8(Player player, bool kind_NPC)
        {
            Console.Clear();
            view.Frame(Width, Height);
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 - 1);
            Console.WriteLine("[Normal]");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2);
            Console.WriteLine("실제 데이터는 매개변수가 선언된 쪽에서만 저장하고, 호출된 메서드");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 1);
            Console.WriteLine("에서는 참조만 하는 형태로 변수이름만 전달하는 형식은?");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 2);
            Console.Write("답을 쓰시오 : ");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 3);
            string result = Console.ReadLine();
            if (result.Equals("ref") || result.Equals("참조전달") || result.Equals("참조전달방식"))
            {
                if (kind_NPC)
                {
                    player.HP += 1;
                    CheckQ(player, true, 1);
                }
                else
                {
                    CheckQ(player, true, 0);
                }
            }
            else
            {
                player.HP -= 2;
                CheckQ(player, false, 2);
            }
        }
        private void Q9(Player player, bool kind_NPC)
        {
            Console.Clear();
            view.Frame(Width, Height);
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 - 1);
            Console.WriteLine("[Hard]");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2);
            Console.WriteLine("사용자에 의해 동적으로 할당되는 메모리 공간이다.");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 1);
            Console.WriteLine("영역의 크기는 런타임에 의해 결정되며 메모리 관리를 잘못할 경우 메모리 누수가 발생한다.");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 2);
            Console.WriteLine("이 영역은 어디인가?");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 3);
            Console.Write("답을 쓰시오 : ");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 4);
            string result = Console.ReadLine();
            if (result.Equals("힙") || result.Equals("heap") || result.Equals("HEAP"))
            {
                if (kind_NPC)
                {
                    player.HP += 1;
                    CheckQ(player, true, 1);
                }
                else
                {
                    CheckQ(player, true, 0);
                }
            }
            else
            {
                player.HP -= 2;
                CheckQ(player, false, 2);
            }
        }
        private void Q10(Player player, bool kind_NPC)
        {
            Console.Clear();
            view.Frame(Width, Height);
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 - 1);
            Console.WriteLine("[Hard]");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2);
            Console.WriteLine("함수의 호출과 관계되는 지역변수와 매개변수가 저장되는 영역이다.");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 1);
            Console.WriteLine("컴파일 타임에의해 크기가 결정되며 크기를 초과할 경우 스택 오버플로우가 발생한다.");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 2);
            Console.WriteLine("이 영역은 어디인가?");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 3);
            Console.Write("답을 쓰시오 : ");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 4);
            string result = Console.ReadLine();
            if (result.Equals("스택") || result.Equals("stack") || result.Equals("STACK"))
            {
                if (kind_NPC)
                {
                    player.HP += 2;
                    CheckQ(player, true, 2);
                }
                else
                {
                    CheckQ(player, true, 0);
                }
            }
            else
            {
                player.HP -= 3;
                CheckQ(player, false, 3);
            }
        }
        private void Q11(Player player, bool kind_NPC)
        {
            Console.Clear();
            view.Frame(Width, Height);
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 - 1);
            Console.WriteLine("[Hard]");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2);
            Console.WriteLine("다양한 길이를 가진 데이터를 고정된 길이를 가진 데이터로 매핑한 값을");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 1);
            Console.WriteLine("무엇이라고 하는가?");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 3);
            Console.Write("답을 쓰시오 : ");
            Console.SetCursorPosition(Width / 2 - Width / 4, Height / 2 + 4);
            string result = Console.ReadLine();
            if (result.Equals("해시") || result.Equals("hash") || result.Equals("HASH"))
            {
                if (kind_NPC)
                {
                    player.HP += 2;
                    CheckQ(player, true, 2);
                }
                else
                {
                    CheckQ(player, true, 0);
                }
            }
            else
            {
                player.HP -= 3;
                CheckQ(player, false, 3);
            }
        }
        protected void CheckQ(Player player, bool check, int minus_hp)
        {
            Console.Clear();
            Console.SetCursorPosition(1, 10 / 2);
            if (check)
            {
                Console.WriteLine("\t정답이다!");
                Console.WriteLine("\t체력이 {0}만큼 회복되었다.", minus_hp);
                view.HPview(player, 110, 10);
            }
            else
            {
                Console.WriteLine("\t틀렸다! 너의 체력을 빼앗아 가겠다");
                Console.WriteLine("\t플레이어의 체력이 {0} 빼앗겼다", minus_hp);
                view.HPview(player, 110, 10);
            }
            frameview.Frame(110, 10);

            Console.ReadKey(true);
        }

    }
}
