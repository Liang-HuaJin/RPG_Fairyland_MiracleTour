using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RPG_Fairyland_MiracleTour
{
    /// <summary>
    /// 玩家技能类
    /// </summary>
    class Skill
    {
        //技能名称
        private static string skillName;
        public static string SkillName
        {
            get { return skillName; }
            set { skillName = value; }
        }
        //技能攻击力
        private static int skillATK;
        public static int SkillATK
        {
            get { return skillATK; }
            set { skillATK = value; }
        }
        //技能价格
        private static int skillPrice;
        public static int SkillPrice
        {
            get { return skillPrice; }
            set { skillPrice = value; }
        }
        //生成一个法师技能
        public static WizardSkill _wizardSkill = new WizardSkill();
        //生成一个战士技能
        public static WarriorSkill _warriorSkill = new WarriorSkill();
        /// <summary>
        /// 法师可以学习的所有技能
        /// </summary>
        public static void WizardExport()
        {
            Thread.Sleep(500);
            Console.WriteLine("\n\t 1.地狱火");
            Thread.Sleep(500);
            Console.WriteLine("\n\t 2.诱惑之光");
        }
        /// <summary>
        /// 武士可以学的所有技能
        /// </summary>
        public static void WarriorExport()
        {
            Thread.Sleep(500);
            Console.WriteLine("\n\t 1.震天");
            Thread.Sleep(500);
            Console.WriteLine("\n\t 2.必杀");
        }
        /// <summary>
        /// 技能展示输出
        /// </summary>
        public static void SkillShow()
        {
            Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            Thread.Sleep(500);
            Console.WriteLine("\n\t技能名称：    " + SkillName);
            Thread.Sleep(500);
            Console.WriteLine("\n\t技能攻击力：    " + SkillATK);
            Thread.Sleep(500);
            Console.WriteLine("\n\t技能价格：    " + SkillPrice);
            Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
        }
    }
    /// <summary>
    /// 法师技能
    /// </summary>
    class WizardSkill : Skill
    {
        /// <summary>
        /// 玩家技能字典
        /// </summary>
        private static Dictionary<string, int> dicSkillWizard = new Dictionary<string, int>();

        public static Dictionary<string, int> DicSkillWizard
        {
            get
            {
                return dicSkillWizard;
            }

            set
            {
                dicSkillWizard = value;
            }
        }

        public WizardSkill()
        {
            dicSkillWizard["裂痕"] = 128;
        }
        /// <summary>
        /// 法师的技能列表展示
        /// </summary>
        public static void WizardSkillShow()
        {
            Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            Console.WriteLine("\n\t名称");
            foreach (var skillWizard in dicSkillWizard)
            {
                //用于展示第几个技能
                int i = 1;
                Thread.Sleep(500);
                Console.WriteLine("\n\t" +i+":   "+ skillWizard.Key + "\t攻击伤害值\t" + skillWizard.Value);
                i++;
            }
            Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            //判断是否在战斗中查看技能，如果不是，查看技能后返回选择页面
            if (GameRoles.panduan)
            {
                //返回选择
                Program.GameChoice();
            }
            //让判断等于真
            GameRoles.panduan = true;
        }
        /// <summary>
        /// 法师的技能查看
        /// </summary>
        public static void StartWizardSkill()
        {
            //玩家可以循环查看技能详情，直到玩家选择退出
            while (true)
            {
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n\t输入序号可查看该技能的属性,输入N退出,输入B进入学习");
                Console.ForegroundColor = ConsoleColor.White;
                //进入输出函数
                WizardExport();
                //判断用户按键是否正确，正确就退出循环
                while (true)
                {
                    ConsoleKeyInfo Downkey2 = Console.ReadKey(true);
                    //根据按键给武器属性赋值
                    if (Downkey2.Key.Equals(ConsoleKey.D1)|| Downkey2.Key.Equals(ConsoleKey.NumPad1))
                    {
                        SkillName = "地狱火";
                        SkillATK = 268;
                        SkillPrice = 5300;
                        SkillShow();
                        break;
                    }
                    //根据按键给武器属性赋值
                    else if (Downkey2.Key.Equals(ConsoleKey.D2) || Downkey2.Key.Equals(ConsoleKey.NumPad2))
                    {
                        SkillName = "诱惑之光";
                        SkillATK = 328;
                        SkillPrice = 8900;
                        SkillShow();
                        break;
                    }

                    else if (Downkey2.Key.Equals(ConsoleKey.N))
                    {
                        //返回玩家选择页面
                        Program.GameChoice();
                    }
                    else if (Downkey2.Key.Equals(ConsoleKey.B))
                    {
                        //进入学习页面
                        StudyWizardSkill();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Thread.Sleep(500);
                        Console.WriteLine("\n\t**************很抱歉，您输入的有误，该技能不存在");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
        }
        /// <summary>
        /// 法师的技能学习
        /// </summary>
        public static void StudyWizardSkill()
        {
            //加载动画
            Program.Load();
            //加载可以学习的技能列表
            WizardExport();
            while (true)
            {
                Console.WriteLine("\n\t请输入序号进行学习，输入N退出");
                ConsoleKeyInfo Downkey1 = Console.ReadKey(true);
                //如果按下1键
                if (Downkey1.Key.Equals(ConsoleKey.D1)|| Downkey1.Key.Equals(ConsoleKey.NumPad1))
                {
                    //如果玩家的等级大于5级，进入
                    if (Program._RolesWizard.Grade >= 5)
                    {
                       if(Program._RolesWizard.Money>= 5300)
                        {
                            //查找玩家的技能列表中有没有此技能，如果有就不能学习
                            bool jie = DicSkillWizard.ContainsKey("地狱火");
                            if (jie)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t您当前已经学过此技能");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (!jie)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t学习成功，您已成功学习地狱火技能，可以在技能详情中查看");
                                Console.ForegroundColor = ConsoleColor.White;
                                //学习成功，玩家的技能列表中多一个此技能
                                DicSkillWizard.Add("地狱火", 268);
                                //玩家金钱减少5300
                                Program._RolesWizard.Money = Program._RolesWizard.Money - 5300;
                            }
                        }
                       else if(Program._RolesWizard.Money < 5300)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\t您的金钱不足");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                    }
                    // 如果玩家的等级小于5，进入
                    else if (Program._RolesWizard.Grade < 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t您的等级无法学习该技能");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (Downkey1.Key.Equals(ConsoleKey.D2) || Downkey1.Key.Equals(ConsoleKey.NumPad2))
                {
                    //如果玩家的等级大于5级，进入
                    if (Program._RolesWizard.Grade >= 8)
                    {
                        if (Program._RolesWizard.Money >= 8900)
                        {
                            //查找玩家的技能列表中有没有此技能，如果有就不能学习
                            bool jie = DicSkillWizard.ContainsKey("诱惑之光");
                            if (jie)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t您当前已经学过此技能");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (!jie)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t学习成功，您已成功学习诱惑之光，可以在技能详情中查看");
                                Console.ForegroundColor = ConsoleColor.White;
                                //学习成功，玩家的技能列表中多一个此技能
                                DicSkillWizard.Add("诱惑之光", 328);
                                //玩家金钱减少5300
                                Program._RolesWizard.Money = Program._RolesWizard.Money - 8900;
                            }
                        }
                        else if (Program._RolesWizard.Money < 8900)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\t您的金钱不足");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                    }
                    // 如果玩家的等级小于5，进入
                    else if (Program._RolesWizard.Grade < 8)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t您的等级无法学习该技能");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                //回到选择页面
                else if (Downkey1.Key.Equals(ConsoleKey.N))
                {
                    Program.GameChoice();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Thread.Sleep(500);
                    Console.WriteLine("\n\t**************很抱歉，您输入的有误，该技能不存在");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
    /// <summary>
    /// 战士技能
    /// </summary>
    class WarriorSkill : Skill
    {
        private static Dictionary<string, int> dicSkillWarrior = new Dictionary<string, int>();

        public static Dictionary<string, int> DicSkillWarrior
        {
            get
            {
                return dicSkillWarrior;
            }

            set
            {
                dicSkillWarrior = value;
            }
        }

        public WarriorSkill()
        {
            dicSkillWarrior["刃风"] = 78;
        }
        /// <summary>
        /// 战士的技能列表
        /// </summary>
        public static void WarriorSkillShow()
        {
            Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            Console.WriteLine("\n\t名称");
            foreach (var skillWarrior in dicSkillWarrior)
            {
                //显示第几个技能
                int i = 1;
                Thread.Sleep(500);
                Console.WriteLine("\n\t"+i+":   "+ skillWarrior.Key + "\t攻击伤害值\t" + skillWarrior.Value);
                //循环后增加一次
                i++;
            }
            Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            //判断是否在战斗中查看技能，如果不是，查看技能后返回选择页面
            if (GameRoles.panduan)
            {
                //返回选择
                Program.GameChoice();
            }
            //让判断等于真
            GameRoles.panduan = true;
        }
        /// <summary>
        /// 战士的技能查看
        /// </summary>
        public static void StartWarriorSkill()
        {
            //玩家可以循环查看技能详情，直到玩家选择退出
            while (true)
            {
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n\t输入序号可查看该技能的属性,输入N退出,输入B进入学习");
                Console.ForegroundColor = ConsoleColor.White;
                //进入输出函数
                WarriorExport();
                //判断用户按键是否正确，正确就退出循环
                while (true)
                {
                    ConsoleKeyInfo Downkey2 = Console.ReadKey(true);
                    //根据按键给武器属性赋值
                    if (Downkey2.Key.Equals(ConsoleKey.D1)|| Downkey2.Key.Equals(ConsoleKey.NumPad1))
                    {
                        SkillName = "震天";
                        SkillATK = 226;
                        SkillPrice = 5300;
                        SkillShow();
                        break;
                    }
                    //根据按键给武器属性赋值
                    else if (Downkey2.Key.Equals(ConsoleKey.D2) || Downkey2.Key.Equals(ConsoleKey.NumPad2))
                    {
                        SkillName = "必杀";
                        SkillATK = 426;
                        SkillPrice = 8900;
                        SkillShow();
                        break;
                    }

                    else if (Downkey2.Key.Equals(ConsoleKey.N))
                    {
                        //返回玩家选择页面
                        Program.GameChoice();
                    }
                    else if (Downkey2.Key.Equals(ConsoleKey.B))
                    {
                        //进入学习页面
                        StudyWarriorSkill();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Thread.Sleep(500);
                        Console.WriteLine("\n\t**************很抱歉，您输入的有误，该技能不存在");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
        }
        /// <summary>
        /// 战士的技能学习
        /// </summary>
        public static void StudyWarriorSkill()
        {
            //加载动画
            Program.Load();
            //加载可以学习的技能列表
            WarriorExport();
            //判断用户输入是否正确，直到正确为止退出
            while (true)
            {
                Console.WriteLine("\n\t请输入序号进行学习，输入N退出");
                ConsoleKeyInfo Downkey1 = Console.ReadKey(true);
                //如果按下1键
                if (Downkey1.Key.Equals(ConsoleKey.D1)|| Downkey1.Key.Equals(ConsoleKey.NumPad1))
                {
                    //如果玩家的等级大于5级，进入
                    if (Program._RolesWarrior.Grade >= 5)
                    {
                        if (Program._RolesWarrior.Money >= 5300)
                        {
                            //查找玩家的技能列表中有没有此技能，如果有就不能学习
                            bool jie = DicSkillWarrior.ContainsKey("震天");
                            if (jie)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t您当前已经学过此技能");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (!jie)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t学习成功，您已成功学习震天技能，可以在技能详情中查看");
                                Console.ForegroundColor = ConsoleColor.White;
                                //学习成功，玩家的技能列表中多一个此技能
                                DicSkillWarrior.Add("震天", 226);
                                //玩家金钱减少5300
                                Program._RolesWarrior.Money = Program._RolesWarrior.Money - 5300;
                            }
                        }
                        else if (Program._RolesWarrior.Money < 5300)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\t您的金钱不足");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                    }
                    // 如果玩家的等级小于5，进入
                    else if (Program._RolesWarrior.Grade < 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t您的等级无法学习该技能");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (Downkey1.Key.Equals(ConsoleKey.D2) || Downkey1.Key.Equals(ConsoleKey.NumPad2))
                {
                    //如果玩家的等级大于5级，进入
                    if (Program._RolesWarrior.Grade >= 8)
                    {
                        if (Program._RolesWarrior.Money >= 8900)
                        {
                            //查找玩家的技能列表中有没有此技能，如果有就不能学习
                            bool jie = DicSkillWarrior.ContainsKey("必杀");
                            if (jie)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t您当前已经学过此技能");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (!jie)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t学习成功，您已成功学习必杀，可以在技能详情中查看");
                                Console.ForegroundColor = ConsoleColor.White;
                                //学习成功，玩家的技能列表中多一个此技能
                                DicSkillWarrior.Add("必杀", 426);
                                //玩家金钱减少5300
                                Program._RolesWarrior.Money = Program._RolesWarrior.Money - 8900;
                            }
                        }
                        else if (Program._RolesWarrior.Money < 8900)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\t您的金钱不足");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                    }
                    // 如果玩家的等级小于8，进入
                    else if (Program._RolesWarrior.Grade < 8)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t您的等级无法学习该技能");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                //回到选择页面
                else if (Downkey1.Key.Equals(ConsoleKey.N))
                {
                    Program.GameChoice();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Thread.Sleep(500);
                    Console.WriteLine("\n\t**************很抱歉，您输入的有误，该技能不存在");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
