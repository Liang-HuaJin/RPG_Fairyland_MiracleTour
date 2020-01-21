using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RPG_Fairyland_MiracleTour
{
    /// <summary>
    /// 职业枚举变量 用于判断选择的职业
    /// </summary>
    enum Enum_GameRoles
    {
        Enum_Warrior,
        Enum_Wizard
    }
    class Program
    {
        //生成一个玩家角色
        public static PlayerRoles _PlayerRoles = new PlayerRoles();
        //生成一个战士类变量
        public static PlayerRoles _RolesWarrior = new PlayerRoles();
        //生成一个法师类变量
        public static PlayerRoles _RolesWizard = new PlayerRoles();
        //生成一个玩家背包
        public static GamePackage _PlayerPackage = new GamePackage();
        //生成一个武器商店
        public static WeaponStore _WeaponStore = new WeaponStore();
        //生成一个技能
        public static Skill _Skill = new Skill();
        //声明一个用于保存玩家选择角色的枚举
        public static Enum_GameRoles Enum_GamePlayerRoles;
        //判断角色是否选择了使用技能的变量
        public static bool Bskill;
        //玩家的角色等级变量，用于判断是否解锁新场景
        static int PGrade = 1;
        //武士的Hp临时变量，用于在战斗前保存Hp，并在战斗后恢复
        public static int HPTemp = 1000;
        //法师的Hp临时变量，用于在战斗前保存Hp，并在战斗后恢复
        public static int HPTempWizard = 800;
        static void Main(string[] args)
        {
            Start();
            Console.ReadKey();
        }
        /// <summary>
        /// 开始游戏函数
        /// </summary>
        static void Start()
        {
            //更改控制台 抬头
            Console.Title = "RPG-奇迹之城";
            Console.WriteLine("\n\t**************欢迎进入游戏**************");
            Thread.Sleep(1000);
            Console.WriteLine("\n   是否开始游戏？     Y.我已准备好了     N.我再想想看");
            //判断玩家的按键，是否退出
            ConsoleKeyInfo Downkey = Console.ReadKey(true);
            //玩家如果选择了退出游戏，就返回这个函数，退出游戏
            if (Downkey.Key.Equals(ConsoleKey.N))
            {
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t**************下次再见，谢谢(^_^)************");
                return;
            }
            //玩家如果选择了继续游戏，调用加载延时函数，出现一个load加载画面
            Load();
            //等待延时，制作游戏加载的假象
            Thread.Sleep(1000);
            //提示玩家输入一个角色的姓名
            Console.WriteLine("\n\n\t**************请输入角色姓名**************");
            Console.Write("\n\t**************角色姓名为：");
            //获取玩家输入的角色姓名，并且更改玩家角色类中的玩家角色姓名
            _PlayerRoles.Name = Console.ReadLine();
            //用于判断用户选择的职业，如果选择错误，将不退出这个死循环
            while (true)
            {
                //等待延时，制作游戏加载的假象
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\t请选择职业：1.战士\t2.法师");
                //判断玩家的按键，获得玩家选择职业
                ConsoleKeyInfo Downkey1 = Console.ReadKey(true);
                //如果选择1，生成战士
                if (Downkey1.Key.Equals(ConsoleKey.D1)|| Downkey1.Key.Equals(ConsoleKey.NumPad1))
                {
                    //进入战士函数，生成一个战士
                    GameWarrior();
                    break;
                }
                //如果选择2，生成法师
                else if (Downkey1.Key.Equals(ConsoleKey.D2) || Downkey1.Key.Equals(ConsoleKey.NumPad2))
                {
                    //进入法师函数，生成一个法师
                    GameWizard();
                    break;
                }
                //选择其他，提示输入错误，重新输入，直到输入正确退出这个死循环
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Thread.Sleep(500);
                    Console.WriteLine("\n\t很抱歉，您输入的有误，当前职业不存在");
                }
            }
        }
        /// <summary>
        /// 游戏背景函数
        /// </summary>
        static void GameBackground()
        {
            Console.WriteLine("\n\t**************游戏马上开始**************");
            //调用加载延时函数，出现一个load加载画面
            Load();
            //游戏背景对话
            Thread.Sleep(1000);
            Console.Write("\n\n\n\t\t好黑!!!");
            Thread.Sleep(400);
            Console.WriteLine("我这是在哪？∑(°Д°)");
            Thread.Sleep(1000);
            Console.WriteLine("\n\t\t嗷呜~~~嗷呜~~~");
            Thread.Sleep(1000);
            Console.WriteLine("\n\t\t啊！！！狼！！！！！！！！！");
            Thread.Sleep(1000);
            Console.WriteLine("\n\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            Console.ReadKey();
            Thread.Sleep(1000);
            Console.WriteLine("\n\n\n\t\t迷迷糊糊睁开眼······");
            Thread.Sleep(1000);
            Console.WriteLine("\n\t\t你醒了？");
            Thread.Sleep(1000);
            Console.WriteLine("\n\t\t我怎么了？我这是在哪？？？");
            Thread.Sleep(1000);
            Console.WriteLine("\n\t\t别害怕，这是我家，我在城外的森林里发现的你的时候你已经晕倒了。");
            Thread.Sleep(1000);
            Console.WriteLine("\n\t\t我怎么什么都不记得了？？？");
            Thread.Sleep(1000);
            Console.WriteLine("\n\n\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * ");
            Console.ReadKey();
            Thread.Sleep(1000);
            Console.WriteLine("\n\n\t\t* * * * * * * * * 一年之后* * * * * * * * *");
            Thread.Sleep(500);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t* * * * * * * 解锁新场景小村村 * * * * * * * ");
            Console.ForegroundColor = ConsoleColor.White;
            //调用选择判断函数,引导玩家进行选择判断
            GameChoice();
        }
        /// <summary>
        /// 生成一个玩家 角色是战士
        /// </summary>
        static void GameWarrior()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t**************选择成功，您选择的职业是战士");
            Console.ForegroundColor = ConsoleColor.White;
            //战士的血量
            _RolesWarrior.Hp = 1000;
            //战士的攻击力
            _RolesWarrior.Attack =63;
            //战士的防御力
            _RolesWarrior.Defense = 65;
            //战士的金钱
            _RolesWarrior.Money = 30000;
            //战士的经验
            _RolesWarrior.Experience = 0;
            //战士的等级
            _RolesWarrior.Grade = 10;
            //给玩家角色枚举赋值 战士枚举
            Enum_GamePlayerRoles = Enum_GameRoles.Enum_Warrior;
            Thread.Sleep(1000);
            //调用游戏背景函数
            GameBackground();
        }
        /// <summary>
        /// 生成一个玩家 角色是法师
        /// </summary>
        static void GameWizard()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t**************选择成功，您选择的职业是法师");
            Console.ForegroundColor = ConsoleColor.White;
            //法师的血量
            _RolesWizard.Hp = 800;
            //法师的攻击力
            _RolesWizard.Attack = 65;
            //法师的防御力
            _RolesWizard.Defense = 35;
            //法师的金钱
            _RolesWizard.Money = 300;
            //法师的经验
            _RolesWizard.Experience = 0;
            //法师的等级
            _RolesWizard.Grade = 1;
            //给玩家角色枚举赋值 法师枚举
            Enum_GamePlayerRoles = Enum_GameRoles.Enum_Wizard;
            Thread.Sleep(1000);
            //调用游戏背景函数
            GameBackground();
        }
        /// <summary>
        /// 提示玩家选择，1.开始战斗 2.进入商城 3.查看当前属性
        /// </summary>
        public static void GameChoice()
        {
            //清除所有生成的怪物
            ComputerRoles.ListComputerRoles.Clear();
            //判断玩家的等级是否等于5级，如果等于5级就解锁新场景
            if (_RolesWarrior.Grade == 5 || _RolesWizard.Grade == 5)
            {
                //判断是否解锁过新场景，如果解锁过，就不再次解锁
                if (PGrade==1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t**************解锁场景失落的古城**************");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\t解锁新怪物 叛军  BOSS:变异的军人 ");
                    //进入场景后，用于判断玩家等级是否升级的计数器进行增加
                    PGrade++;
                }
            }
            //判断玩家选择角色，在玩家每次战斗结束后，恢复玩家血量
            if (Enum_GamePlayerRoles == Enum_GameRoles.Enum_Warrior)
            {
                //恢复战士的HP
                _RolesWarrior.Hp = HPTemp;
            }
            else if (Enum_GamePlayerRoles == Enum_GameRoles.Enum_Wizard)
            {
                //恢复法师的HP
                _RolesWizard.Hp = HPTempWizard;
            }
            //加载延时，模仿真实游戏加载
            Thread.Sleep(500);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n\t\t* * * * * * * * *欢迎回来\t" + _PlayerRoles.Name);
            Console.ForegroundColor = ConsoleColor.White;
            //进入一个死循环，用于判断玩家的选择是否是给出的选择，如果不是则不退出，如果是则执行相对应的函数
            while (true)
            {
                Thread.Sleep(400);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\t请选择您要进行的操作  \n\n\t1.进入战斗  2.进入商城  \n\n\t3.查看当前属性  4.查看当前背包物品  \n\n\t5.技能查看   6.技能学习");
                //判断玩家的按键，获得玩家选择
                ConsoleKeyInfo Downkey1 = Console.ReadKey(true);
                if (Downkey1.Key.Equals(ConsoleKey.D1)|| Downkey1.Key.Equals(ConsoleKey.NumPad1))
                {
                    //判断玩家选择角色，然后进行判断，在战斗前存储玩家Hp，用于在战斗结束后恢复
                    if (Enum_GamePlayerRoles == Enum_GameRoles.Enum_Warrior)
                    {
                        //保存战士的HP
                        HPTemp = _RolesWarrior.Hp;
                    }
                    else if (Enum_GamePlayerRoles == Enum_GameRoles.Enum_Wizard)
                    {
                        //保存法师的HP
                        HPTempWizard = _RolesWizard.Hp;
                    }
                    Thread.Sleep(400);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t**************您选择的是进入战斗");
                    Console.ForegroundColor = ConsoleColor.White;
                    //加载动画
                    Load();
                    //进入战斗场景
                    Combat();
                    break;
                }
                else if (Downkey1.Key.Equals(ConsoleKey.D2) || Downkey1.Key.Equals(ConsoleKey.NumPad2))
                {
                    Thread.Sleep(400);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t**************您选择的是进入商城");
                    Console.ForegroundColor = ConsoleColor.White;
                    //加载动画
                    Load();
                    _WeaponStore.PanDuan();
                    break;
                }
                else if (Downkey1.Key.Equals(ConsoleKey.D3) || Downkey1.Key.Equals(ConsoleKey.NumPad3))
                {
                    Thread.Sleep(400);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t**************您选择的是查看当前属性");
                    Console.ForegroundColor = ConsoleColor.White;
                    //加载动画
                    Load();
                    //根据玩家选择的是法师还是战士，展示不同的属性
                    if(Enum_GamePlayerRoles== Enum_GameRoles.Enum_Warrior)
                    {
                        //战士的角色信息展示
                        GameRolesManager.Information(_PlayerRoles.Name, _RolesWarrior.Hp, _RolesWarrior.Attack, _RolesWarrior.Defense, _RolesWarrior.Experience, _RolesWarrior.Money, _RolesWarrior.Grade);
                    }
                    else if(Enum_GamePlayerRoles == Enum_GameRoles.Enum_Wizard)
                    {
                        //法师的角色信息展示
                        GameRolesManager.Information(_PlayerRoles.Name, _RolesWizard.Hp, _RolesWizard.Attack, _RolesWizard.Defense, _RolesWizard.Experience, _RolesWizard.Money, _RolesWizard.Grade);
                    }
                    break;
                }
                else if(Downkey1.Key.Equals(ConsoleKey.D4) || Downkey1.Key.Equals(ConsoleKey.NumPad4))
                {
                    Thread.Sleep(400);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t**************您选择的是查看背包");
                    Console.ForegroundColor = ConsoleColor.White;
                    //加载动画
                    Load();
                    _PlayerPackage.PackageToUp();
                    break;
                }
                else if (Downkey1.Key.Equals(ConsoleKey.D5) || Downkey1.Key.Equals(ConsoleKey.NumPad5))
                {
                    Thread.Sleep(400);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t**************您选择的是查看技能");
                    Console.ForegroundColor = ConsoleColor.White;
                    //加载动画
                    Load();
                    //根据玩家选择的是法师还是战士，展示不同的技能
                    if (Enum_GamePlayerRoles == Enum_GameRoles.Enum_Warrior)
                    {
                        //战士的技能列表
                        WarriorSkill.WarriorSkillShow();
                    }
                    else if (Enum_GamePlayerRoles == Enum_GameRoles.Enum_Wizard)
                    {
                        //法师的技能列表
                        WizardSkill.WizardSkillShow();
                    }
                    break;
                }
                else if (Downkey1.Key.Equals(ConsoleKey.D6)||Downkey1.Key.Equals(ConsoleKey.NumPad6))
                {
                    Thread.Sleep(400);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t**************您选择的是学习技能");
                    Console.ForegroundColor = ConsoleColor.White;
                    //加载动画
                    Load();
                    //根据玩家选择的是法师还是战士，学习不同的技能
                    if (Enum_GamePlayerRoles == Enum_GameRoles.Enum_Warrior)
                    {
                        WarriorSkill.StartWarriorSkill();
                        //战士的技能学习
                    }
                    else if (Enum_GamePlayerRoles == Enum_GameRoles.Enum_Wizard)
                    {

                        WizardSkill.StartWizardSkill();
                        //法师的技能学习
                    }
                    break;
                }
                //选择错误就提示错误，并回到开头，重新选择
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Thread.Sleep(500);
                    Console.WriteLine("\n\t**************很抱歉，您输入的有误，当前选择不存在");
                }
            }

        }
        /// <summary>
        /// 延时加载，用于场景切换加载
        /// </summary>
        public static void Load()
        {
            Thread.Sleep(500);
            Console.Write("\n\t········Loading");
            //通过循环，加载延时，每0.4秒加载一个点
            for (int i = 1; i <= 8; i++)
            {
                Thread.Sleep(400);
                Console.Write("·");
            }
        }
        /// <summary>
        /// 战斗场景，当玩家选择战斗后进入
        /// </summary>
        public static void Combat()
        {
            //生成随机数
            Random sjs = new Random();
            //计数器，用来统计局数
            int countNum = 1;
            //判断用户选择角色是否为战士
            bool Rolse = (Enum_GamePlayerRoles == Enum_GameRoles.Enum_Warrior);
            //进入战争循环，直到玩家或者所有怪物死亡，退出
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t战争开始了");
                Console.ForegroundColor = ConsoleColor.White;
                int ntemp = sjs.Next(1, 4);
                //用来随机生成敌人（1-3个）
                for (int i = 1; i <= ntemp; i++)
                {
                    //生成一个敌人变量
                    ComputerRoles computerRoles = new ComputerRoles();
                    Thread.Sleep(400);
                    //输出敌人变量的名字
                    Console.WriteLine("\n\t遇到敌人:    " + computerRoles.Name);
                    //把敌人加到敌人列表中
                    ComputerRoles.ListComputerRoles.Add(computerRoles);
                    Thread.Sleep(400);
                }
                //判断玩家输入的是否正确，输入正确后退出循环
                while (true)
                {
                    //显示游戏进行了几次
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t第" + countNum + "回合");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(400);
                    //提示玩家进行输入
                    s: Console.WriteLine("\n\t请按键选择要执行的行为： \n\n\t1.普通攻击  2.技能攻击  3.显示敌方属性  \n\n\t4.显示己方属性  5.逃跑   6.使用补血药品");
                    //判断玩家输入的是否正确
                    ConsoleKeyInfo Downkey1 = Console.ReadKey(true);
                    //玩家输入后进入攻击方法
                    if (Downkey1.Key.Equals(ConsoleKey.D1)|| Downkey1.Key.Equals(ConsoleKey.NumPad1))
                    {
                        Thread.Sleep(400);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t您选择的是普通攻击，请按键选择攻击目标：");
                        Console.ForegroundColor = ConsoleColor.White;
                        //输出生成的所有敌人，供玩家选择攻击
                        for (int i = 0; i < ComputerRoles.ListComputerRoles.Count; i++)
                        {
                            Console.WriteLine("\n\t" + (i + 1) + ":" + ComputerRoles.ListComputerRoles[i].Name);
                        }
                        //判断输入的是否正确
                        int Ninttemp;
                        while (true)
                        {
                            //接受玩家的输入信息
                            string strTemp = Console.ReadLine();
                            //判断玩家输入的是否为数字，如果是就退出循环
                            if (int.TryParse(strTemp, out Ninttemp))
                            {
                                //判断玩家输入的是否超过了小怪列表的长度
                                if (ComputerRoles.ListComputerRoles.Count >= Ninttemp)
                                {
                                    break;
                                }
                                else
                                {
                                    Thread.Sleep(400);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\t很抱歉，您选择的对象不存在，请重新选择");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                            }
                            else
                            {
                                Thread.Sleep(400);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t很抱歉，您输入的有误，请重新选择");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        //判断玩家选择的角色，在攻击中对怪物进行不同上海
                        if (Rolse)
                        {
                            //给被攻击对象方法传入：战士
                            ComputerRoles.ListComputerRoles[Ninttemp - 1].Bcombat(_RolesWarrior);

                        }
                        else
                        {
                            //给被攻击对象方法传入：法师
                            ComputerRoles.ListComputerRoles[Ninttemp - 1].Bcombat(_RolesWizard);
                        }

                    }
                    else if (Downkey1.Key.Equals(ConsoleKey.D2) || Downkey1.Key.Equals(ConsoleKey.NumPad2))
                    {
                        Thread.Sleep(400);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t您选择的是技能攻击，请按键选择攻击目标：");
                        Console.ForegroundColor = ConsoleColor.White;
                        for (int i = 0; i < ComputerRoles.ListComputerRoles.Count; i++)
                        {
                            Console.WriteLine("\n\t" + (i + 1) + ":" + ComputerRoles.ListComputerRoles[i].Name);
                        }
                        //判断输入的是否正确
                        int Ninttemp;
                        while (true)
                        {
                            //接受玩家输入的选择目标，并进行判断
                            string strTemp = Console.ReadLine();
                            if (int.TryParse(strTemp, out Ninttemp))
                            {
                                if (ComputerRoles.ListComputerRoles.Count >= Ninttemp)
                                {
                                    break;
                                }
                                else
                                {
                                    Thread.Sleep(400);
                                    Console.WriteLine("\n\t很抱歉，您输入的有误，请重新选择");
                                }
                            }
                            else
                            {
                                Thread.Sleep(400);
                                Console.WriteLine("\n\t很抱歉，您输入的有误，请重新选择");
                            }
                        }
                        if (Rolse)
                        {
                            //改变参数，传递使用了技能攻击
                            Bskill = true;
                            ComputerRoles.ListComputerRoles[Ninttemp - 1].Bcombat(_RolesWarrior);
                        }
                        else
                        {
                            //改变参数，传递使用了技能攻击
                            Bskill = true;
                            ComputerRoles.ListComputerRoles[Ninttemp - 1].Bcombat(_RolesWizard);
                        }
                    }
                    else if (Downkey1.Key.Equals(ConsoleKey.D3) || Downkey1.Key.Equals(ConsoleKey.NumPad3))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t您选择的是显示敌方属性");
                        Console.ForegroundColor = ConsoleColor.White;
                        Load();
                        //加载出所有怪物的属性
                        for (int i = 0; i < ComputerRoles.ListComputerRoles.Count; i++)
                        {
                            GameRolesManager.Information(ComputerRoles.ListComputerRoles[i].Name, ComputerRoles.ListComputerRoles[i].Hp, ComputerRoles.ListComputerRoles[i].Attack, ComputerRoles.ListComputerRoles[i].Defense, 0, 0, 0, false);
                        }
                    }
                    else if (Downkey1.Key.Equals(ConsoleKey.D4) || Downkey1.Key.Equals(ConsoleKey.NumPad4))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t您选择的是显示己方属性");
                        Console.ForegroundColor = ConsoleColor.White;
                        Load();
                        if (Rolse)
                        {
                            //战士的角色信息展示
                            GameRolesManager.Information(_PlayerRoles.Name, _RolesWarrior.Hp, _RolesWarrior.Attack, _RolesWarrior.Defense, _RolesWarrior.Experience, _RolesWarrior.Money, _RolesWarrior.Grade, false);
                        }
                        else if (!Rolse)
                        {
                            //法师的角色信息展示
                            GameRolesManager.Information(_PlayerRoles.Name, _RolesWizard.Hp, _RolesWizard.Attack, _RolesWizard.Defense, _RolesWizard.Experience, _RolesWizard.Money, _RolesWizard.Grade, false);
                        }

                    }
                    else if (Downkey1.Key.Equals(ConsoleKey.D5) || Downkey1.Key.Equals(ConsoleKey.NumPad5))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t正在为您加速逃跑中");
                        Console.ForegroundColor = ConsoleColor.White;
                        Load();
                        int temp = sjs.Next(1, 3);
                        if (temp == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n\n\t逃跑成功………………");
                            Console.ForegroundColor = ConsoleColor.White;
                            GameChoice();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n\n\t逃跑失败………………");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else if(Downkey1.Key.Equals(ConsoleKey.D6) || Downkey1.Key.Equals(ConsoleKey.NumPad6))
                    {
                        Console.WriteLine("\n\t您选择的是使用补血药品");
                        Load();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t请选择您要使用的补血药品");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n\t1.能量甘饮");
                        Console.WriteLine("\n\t2.止痛药");
                        ConsoleKeyInfo Downkey4 = Console.ReadKey(true);
                        if (Downkey4.Key.Equals(ConsoleKey.D1)|| Downkey4.Key.Equals(ConsoleKey.NumPad1))
                        {
                            if(GamePackage.DicPackageGoods1.ContainsKey("能量甘饮"))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t您已成功使用能量甘饮，您的血量增加了120");
                                Console.ForegroundColor = ConsoleColor.White;
                                int count = GamePackage.DicPackageGoods1["能量甘饮"];
                                GamePackage.DicPackageGoods1["能量甘饮"] = count - 1;
                                _RolesWarrior.Hp += 120;
                                _RolesWizard.Hp += 120;
                                //判断加血是否超过了最大血量
                                if (_RolesWarrior.Hp>ntemp)
                                {
                                    _RolesWarrior.Hp = ntemp;
                                }
                                if(_RolesWizard.Hp>HPTempWizard)
                                {
                                    _RolesWizard.Hp = HPTempWizard;
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t您的背包中没有此物品，您可以去商店购买");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else if(Downkey4.Key.Equals(ConsoleKey.D2) || Downkey4.Key.Equals(ConsoleKey.NumPad2))
                        {
                            if (GamePackage.DicPackageGoods1.ContainsKey("止痛药"))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t您已成功使用止痛药，您的血量增加了240");
                                Console.ForegroundColor = ConsoleColor.White;
                                int count = GamePackage.DicPackageGoods1["止痛药"];
                                GamePackage.DicPackageGoods1["止痛药"] = count - 1;
                                _RolesWarrior.Hp += 240;
                                _RolesWizard.Hp += 240;
                                //判断加血是否超过了最大血量
                                if (_RolesWarrior.Hp > ntemp)
                                {
                                    _RolesWarrior.Hp = ntemp;
                                }
                                if (_RolesWizard.Hp > HPTempWizard)
                                {
                                    _RolesWizard.Hp = HPTempWizard;
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t您的背包中没有此物品，您可以去商店购买");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Thread.Sleep(500);
                            Console.WriteLine("\n\t很抱歉，您输入的有误，请重新选择");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Thread.Sleep(500);
                        Console.WriteLine("\n\t很抱歉，您输入的有误，请重新选择");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto s;
                    }
                    //判断生成怪物是否被消灭
                    for (int i = 0; i < ComputerRoles.ListComputerRoles.Count; i++)
                    {
                        if (ComputerRoles.ListComputerRoles[i].Hp <= 0)
                        {
                            Thread.Sleep(400);
                            Console.WriteLine("\n\t"+ComputerRoles.ListComputerRoles[i].Name + "被消灭了");
                            //如果消灭了就删掉这个怪物
                            ComputerRoles.ListComputerRoles.RemoveAt(i);
                            i--;
                        }
                    }
                    //如果所有怪物被消灭
                    if (ComputerRoles.ListComputerRoles.Count == 0)
                    {
                        Thread.Sleep(400);
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t战斗结束，你获胜了！！！");
                        Console.BackgroundColor = ConsoleColor.White;
                        //随机生成经验和金钱
                        int jie2 = sjs.Next(10, 20);
                        int jie3 = sjs.Next(5, 200);
                        //给不同角色分别增加金钱和经验
                        if (Rolse)
                        {
                            _RolesWarrior.Experience+=jie2;
                            Thread.Sleep(400);
                            Console.WriteLine("\n\t本次战争获得经验" + jie2);
                            _RolesWarrior.Money += jie3;
                            Thread.Sleep(400);
                            Console.WriteLine("\n\t本次战争获得金钱" + jie3);
                          
                        }
                        else
                        {
                            _RolesWizard.Experience += jie2;
                            Thread.Sleep(400);
                            Console.WriteLine("\n\t本次战争获得经验" + jie2);
                            _RolesWizard.Money += jie3;
                            Thread.Sleep(400);
                            Console.WriteLine("\n\t本次战争获得金钱" + jie3);

                        }
                        //随机生成物品
                        int jie1 = sjs.Next(1, 10);
                        if (jie1 == 9 || jie1 == 7)
                        {
                            Thread.Sleep(400);
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n\t本次战争获得能量甘饮1瓶，已自动为您放入背包");
                            Console.BackgroundColor = ConsoleColor.White;
                            //给玩家背包增加这个物品
                            int count = GamePackage.DicPackageGoods1["能量甘饮"];
                            GamePackage.DicPackageGoods1["能量甘饮"] = count + 1;
                        }
                        if (jie1 == 5)
                        {
                            Thread.Sleep(400);
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n\t本次战争获得止痛药1瓶，已自动为您放入背包");
                            Console.BackgroundColor = ConsoleColor.White;
                            int count = GamePackage.DicPackageGoods1["止痛药"];
                            //给玩家背包增加这个物品
                            GamePackage.DicPackageGoods1["止痛药"] = count + 1;
                        }
                        //判断角色是否可以升级
                        GameRolesManager.Up(Rolse);
                        //回到选择页面，等待玩家再次选择
                        GameChoice();
                    }
                    //如果怪物没有被消灭
                    else
                    {
                        //局数增加
                        countNum++;
                        foreach (var guaiwu in ComputerRoles.ListComputerRoles)
                        {
                            //如果怪物的HP大于0，攻击玩家
                            if (guaiwu.Hp > 0)
                            {
                                if (Rolse)
                                {
                                    //传递对玩家伤害的怪物
                                    _RolesWarrior.Bcombat(guaiwu);
                                }
                                else if (!Rolse)
                                {
                                    _RolesWizard.Bcombat(guaiwu);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
