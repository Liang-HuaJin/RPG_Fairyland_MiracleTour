using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RPG_Fairyland_MiracleTour
{
    /// <summary>
    /// 游戏角色类
    /// </summary>
    class GameRoles
    {
        //游戏角色名字
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        //游戏角色血量
        private int HP;
        public int Hp
        {
            get { return HP; }
            set { HP = value; }
        }
        //游戏角色的攻击力
        private int attack;
        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }
        //游戏角色的防御力
        private int defense;
        public int Defense
        {
            get { return defense; }
            set { defense = value; }
        }
        /// <summary>
        /// 游戏角色的被攻击行为
        /// </summary>
        public virtual void Bcombat(GameRoles BRole )
        {
            
        }
        //用来判断是否在战斗中查看技能，如果是真，查看技能后返回到选择页面
        public static bool panduan = true;
    }
    /// <summary>
    /// 游戏玩家角色类
    /// </summary>
    class PlayerRoles:GameRoles
    {
        //玩家经验值
        private int experience;
        public int Experience
        {
            get { return experience; }
            set { experience = value; }
        }
        //玩家金钱
        private int money;
        public int Money
        {
            get { return money; }
            set { money = value; }
        }
        //玩家等级
        private int grade;
        public int Grade
        {
            get { return grade; }
            set { grade = value; }
        }
        /// <summary>
        /// 玩家被攻击行为
        /// </summary>
        public override void Bcombat(GameRoles BRole)
        {
            //伤害值等于这个怪物伤害
            int attackcound = BRole.Attack;
            //判断玩家角色
            if (Program.Enum_GamePlayerRoles == Enum_GameRoles.Enum_Warrior)
            {
                //如果怪物攻击小于玩家的防御
                if (attackcound< Program._RolesWarrior.Defense)
                {
                    //让怪物攻击等于玩家防御，防止玩家血量增加
                    attackcound = Program._RolesWarrior.Defense;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t怪物的攻击值太低了，你没有遭到伤害");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                //玩家现有血量
                Program._RolesWarrior.Hp = Program._RolesWarrior.Hp - attackcound+ Program._RolesWarrior.Defense;
                //如果玩家血量小于0
                if (Program._RolesWarrior.Hp <= 0)
                    Program._RolesWarrior.Hp = 0;
                Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
                Thread.Sleep(400);
                Console.WriteLine("\n\t怪物：" + BRole.Name + "  对玩家：" + Program._PlayerRoles.Name + "进行攻击    造成了：" + attackcound + "点伤害    " + "玩家剩余HP:" + Program._RolesWarrior.Hp);
                if(Program._RolesWarrior.Hp==0)
                {
                    Thread.Sleep(400);
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t战斗失败");
                    Console.BackgroundColor = ConsoleColor.White;
                    //玩家死亡后，进入返回页面
                    Program.GameChoice();
                }
            }
            else
            {
                if(attackcound < Program._RolesWizard.Defense)
                {
                    attackcound= Program._RolesWizard.Defense;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t怪物的攻击值太低了，你没有遭到伤害");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Program._RolesWizard.Hp = Program._RolesWizard.Hp - attackcound+ Program._RolesWizard.Defense;
                if (Program._RolesWizard.Hp <= 0)
                    Program._RolesWizard.Hp = 0;
                Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
                Thread.Sleep(400);
                Console.WriteLine("\n怪物：" + BRole.Name + "  对玩家：" + Program._PlayerRoles.Name + "进行攻击    造成了：" + attackcound + "点伤害    " + "玩家剩余HP:" + Program._RolesWizard.Hp);
                if(Program._RolesWizard.Hp == 0)
                {
                    Thread.Sleep(400);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t战斗失败");
                    Console.ForegroundColor = ConsoleColor.White;
                    Program.GameChoice();
                }
            }
        }
    }
    /// <summary>
    /// 电脑rpg角色类
    /// </summary>
    class ComputerRoles:GameRoles
    {
        //保存随机生成的怪物
        public static List<ComputerRoles> ListComputerRoles = new List<ComputerRoles>();
        /// <summary>
        /// 在生成怪物时，给怪物随机生成名字 血量  BOSS 等
        /// </summary>
        public ComputerRoles()
        {
            //随机数用来判断生成小怪还是Boss
            Random sjs = new Random();
            int Sjs = sjs.Next(1, 11);
            //如果玩家等级大于5级，生成高级怪物
            if (Program._RolesWarrior.Grade>=5|| Program._RolesWizard.Grade >=5)
            {
                //如果生成的随机数大于9，就生成BOSS，生成几率10%
                if (Sjs > 9)
                {
                    Name = "BOSS:变异的军人" + sjs.Next(100, 9999);
                    //随机生成怪物的血量 攻击力 和防御力
                    Hp = sjs.Next(3000, 5000);
                    Attack = sjs.Next(160, 290);
                    Defense = sjs.Next(25, 129);
                }
                else
                {
                    Name = "叛军" + sjs.Next(100, 9999);
                    //随机生成怪物的血量 攻击力 和防御力
                    Hp = sjs.Next(1500, 2500);
                    Attack = sjs.Next(120, 230);
                    Defense = sjs.Next(20, 92);
                }
            }
            else
            {
                //如果生成的随机数大于9，就生成BOSS，生成几率10%
                if (Sjs > 9)
                {
                    Name = "BOSS:发疯的猎犬" + sjs.Next(100, 9999);
                    //随机生成怪物的血量 攻击力 和防御力
                    Hp = sjs.Next(1500, 2500);
                    Attack = sjs.Next(120, 230);
                    Defense = sjs.Next(20, 92);
                }
                else
                {
                    Name = "流浪犬" + sjs.Next(100, 9999);
                    //随机生成怪物的血量 攻击力 和防御力
                    Hp = sjs.Next(200, 800);
                    Attack = sjs.Next(60, 120);
                    Defense = sjs.Next(12, 39);
                }
            }
        }

        /// 游戏角色的被攻击行为
        /// </summary>
        public override void Bcombat(GameRoles BRole)
        {
            //声明一个变量保存玩家对怪物的伤害值
            int attackcound;
            //判断是否使用了技能，如果使用了进入
            if (Program.Bskill)
            {
                //伤害值等于技能的返回值
                attackcound =jineng();
                //怪物被攻击后剩余血量=原有血量-攻击伤害+防御
                int HPsheng2 = Hp - attackcound + Defense;
                //怪物血量等于怪物剩余血量
                Hp = HPsheng2;
                //如果怪物剩余血量小于或者等于0，让血量等于零
                if (HPsheng2 <= 0)
                    HPsheng2 = 0;
                Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
                Thread.Sleep(400);
                //输出怪物受到攻击后的属性
                Console.WriteLine("\n\t玩家：" + Program._PlayerRoles.Name + "对怪物：" + Name + "进行攻击，造成了：" + attackcound + "点伤害     \n\n\t怪物" + Name + ":的剩余HP为：" + HPsheng2);
                //让是否选择了技能为假，下次如果没选择使用技能，自动进入没有技能
                Program.Bskill = false;
            }
            //如果没有使用技能
            else
            {
                //伤害值等于玩家攻击值
                attackcound = BRole.Attack;
                //如果攻击值小于防御值，让攻击值等于防御值，也就是攻击等于0
                if (attackcound <= Defense)
                {
                    attackcound = Defense;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t您的攻击值太低了，对方没有遭到伤害");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                //怪物剩余血量
                int HPsheng = Hp - attackcound + Defense;
                //怪物血量同步
                Hp = HPsheng;
                //如果剩余血量小于0，让血量等于0
                if (HPsheng <= 0)
                    HPsheng = 0;
                Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
                Thread.Sleep(400);
                //输出信息
                Console.WriteLine("\n\t玩家：" + Program._PlayerRoles.Name + "对怪物：" + Name + "进行攻击，造成了：" + attackcound + "点伤害    \n\n\t" + Name + " :的剩余HP为：" + HPsheng);

            }
        }
        /// <summary>
        /// 如果玩家选择了使用技能，进入
        /// </summary>
        /// <returns></returns>
        public static int jineng()
        {
            //用来判断是否在战斗中查看技能，如果是真，查看技能后就不返回到选择页面
            panduan = false;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t请选择按键进行释放技能");
            Console.ForegroundColor = ConsoleColor.White;
            //声明一个变量保存技能伤害值，用于返回
            int shanghai = 0;
            //判断玩家选择的角色
            if (Program.Enum_GamePlayerRoles==Enum_GameRoles.Enum_Warrior)
            {
                //展示技能（战士）
                WarriorSkill.WarriorSkillShow();
                //判断输入的是否正确，正确就退出
                while (true)
                {
                    ConsoleKeyInfo Downkey1 = Console.ReadKey(true);
                    if (Downkey1.Key.Equals(ConsoleKey.D1)|| Downkey1.Key.Equals(ConsoleKey.NumPad1))
                    {
                        Console.WriteLine("\n\t您选择的是刃风技能");
                        //将这个技能的伤害值返回
                        shanghai = 78;
                        break;
                    }
                    else if (Downkey1.Key.Equals(ConsoleKey.D2) || Downkey1.Key.Equals(ConsoleKey.NumPad2))
                    {
                        //判断输入的是否大于技能列表含有的技能
                        if (WarriorSkill.DicSkillWarrior.Count>=2)
                        {
                            Console.WriteLine("\n\t您选择的是震天技能");
                            // 将这个技能的伤害值返回
                            shanghai = 226;
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Thread.Sleep(500);
                            Console.WriteLine("\n\t很抱歉，您输入的有误，您还没有学习此技能");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else if (Downkey1.Key.Equals(ConsoleKey.D3) || Downkey1.Key.Equals(ConsoleKey.NumPad3))
                    {
                        if (WarriorSkill.DicSkillWarrior.Count >= 3)
                        {
                            Console.WriteLine("\n\t您选择的是必杀技能");
                            // 将这个技能的伤害值返回
                            shanghai = 426;
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Thread.Sleep(500);
                            Console.WriteLine("\n\t很抱歉，您输入的有误，您还没有学习此技能");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Thread.Sleep(500);
                        Console.WriteLine("\n\t很抱歉，您输入的有误，该技能不存在");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
            //如果玩家选择角色是法师进入
            else
            {
                //展示技能（法师）
                WizardSkill.WizardSkillShow();
                //判断输入的是否正确，正确就退出
                ConsoleKeyInfo Downkey1 = Console.ReadKey(true);
                while(true)
                {
                    if (Downkey1.Key.Equals(ConsoleKey.D1)|| Downkey1.Key.Equals(ConsoleKey.NumPad1))
                    {
                        Console.WriteLine("\n\t您选择的是裂痕技能");
                        //将这个技能的伤害值返回
                        shanghai = 128;
                        break;
                    }
                    else if (Downkey1.Key.Equals(ConsoleKey.D2) || Downkey1.Key.Equals(ConsoleKey.NumPad2))
                    {
                        if (WizardSkill.DicSkillWizard.Count >= 2)
                        {
                            Console.WriteLine("\n\t您选择的是地狱火技能");
                            //将这个技能的伤害值返回
                            shanghai = 268;
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Thread.Sleep(500);
                            Console.WriteLine("\n\t很抱歉，您输入的有误，您还没有学习此技能");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else if (Downkey1.Key.Equals(ConsoleKey.D3) || Downkey1.Key.Equals(ConsoleKey.NumPad3))
                    {
                        if (WizardSkill.DicSkillWizard.Count >= 3)
                        {
                            Console.WriteLine("\n\t您选择的是诱惑之光技能");
                            //将这个技能的伤害值返回
                            shanghai = 328;
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Thread.Sleep(500);
                            Console.WriteLine("\n\t很抱歉，您输入的有误，您还没有学习此技能");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Thread.Sleep(500);
                        Console.WriteLine("\n\t很抱歉，您输入的有误，该技能不存在");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
            //将技能伤害值返回
            return shanghai;
        }
    }
    /// <summary>
    /// 游戏角色管理，用于管理攻击 升级 属性展示 死亡判断 角色信息展示等
    /// </summary>
    class GameRolesManager
    {
        Program program = new Program();
        /// <summary>
        /// 展示游戏角色的 等级 金钱 属性等
        /// </summary>
        public static void Information(string name, int hp, int attack, int defense, int experience, int money, int grade,bool a=true)
        {
            Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            Console.WriteLine("\n\t角色姓名：  " + name);
            Thread.Sleep(400);
            Console.WriteLine("\n\t当前血量：  " + hp);
            Thread.Sleep(400);
            Console.WriteLine("\n\t当前攻击力：  " + attack);
            Thread.Sleep(400);
            Console.WriteLine("\n\t当前防御力：  " + defense);
            //判断是玩家还是怪物，如果是玩家就输出玩家的经验 金钱 等级
            if (grade != 0)
            {
                Thread.Sleep(400);
                Console.WriteLine("\n\t当前经验值：  " + experience);
                Thread.Sleep(400);
                Console.WriteLine("\n\t当前金钱：  " + money);
                Thread.Sleep(400);
                Console.WriteLine("\n\t当前等级：  " + grade);
            }
            Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            //判断是否在战斗中查看自身属性，如果不是，查看后就返回选择页面
            if (a)
            {
                Program.GameChoice();
            }
        }
        /// <summary>
        /// 控制玩家是否升级
        /// </summary>
        /// <param name="a"></param>
        public static void Up(bool a)
        {
            //玩家的角色战士
            if (a)
            {
                if(Program._RolesWarrior.Experience/40>0)
                {
                    Thread.Sleep(400);
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n\t玩家：" + Program._PlayerRoles.Name + "恭喜你升级了！！！");
                    Console.BackgroundColor = ConsoleColor.White;
                    Program._RolesWarrior.Grade += 1;
                    Program._RolesWarrior.Hp +=200;
                    Program._RolesWarrior.Attack +=25;
                    Program._RolesWarrior.Defense += 12;
                    //保存角色临时血量的变量值更改
                    Program.HPTemp = Program._RolesWarrior.Hp;
                }
            }
            //玩家的角色法师
            else
            {
                if (Program._RolesWizard.Experience / 40 > 0)
                {
                    Thread.Sleep(400);
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n\t玩家" + Program._PlayerRoles.Name + "恭喜你升级了！！！");
                    Console.BackgroundColor = ConsoleColor.White;
                    Program._RolesWizard.Grade += 1;
                    Program._RolesWizard.Hp += 160;
                    Program._RolesWizard.Attack += 28;
                    Program._RolesWizard.Defense += 14;
                    Program.HPTempWizard = Program._RolesWizard.Hp;
                }
            }
        }
    }
}
