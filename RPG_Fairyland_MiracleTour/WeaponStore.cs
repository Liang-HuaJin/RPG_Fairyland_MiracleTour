using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RPG_Fairyland_MiracleTour
{
    /// <summary>
    /// 武器商店类
    /// </summary>
    class WeaponStore
    {
        /// <summary>
        /// 用于判断用户选择的角色 进入不同的武器商店
        /// </summary>
        public void PanDuan()
        {
            Console.WriteLine("\n\n\t" + Program._PlayerRoles.Name+"你好，欢迎光临武器铺");
            //判断是玩家职业是法师还是武士，分别进入不同的武器商店
            if (Program.Enum_GamePlayerRoles == Enum_GameRoles.Enum_Warrior)
            {

                WarriorWeaponStore.ShowWarrior();
                
            }
            else if (Program.Enum_GamePlayerRoles == Enum_GameRoles.Enum_Wizard)
            {
                WizardWeaponStore.ShowWizard();
            }
        }
        /// <summary>
        /// 用于商店所有物品的输出显示
        /// </summary>
        public static void Exprot1()
        {
            Thread.Sleep(500);
            Console.WriteLine("\n\t 1.狼牙棒");
            Thread.Sleep(500);
            Console.WriteLine("\n\t 2.破魂刀");
            Thread.Sleep(500);
            Console.WriteLine("\n\t 3.修罗战斧");
            Thread.Sleep(500);
            Console.WriteLine("\n\t 4.能量甘饮");
            Thread.Sleep(500);
            Console.WriteLine("\n\t 5.止痛药");
        }
        public static void Exprot2()
        {
            Thread.Sleep(500);
            Console.WriteLine("\n\t 1.摄魂");
            Thread.Sleep(500);
            Console.WriteLine("\n\t 2.紫月圣君");
            Thread.Sleep(500);
            Console.WriteLine("\n\t 3.天神杖");
            Thread.Sleep(500);
            Console.WriteLine("\n\t 4.能量甘饮");
            Thread.Sleep(500);
            Console.WriteLine("\n\t 5.止痛药");
        }
    }
    /// <summary>
    /// 战士武器商店
    /// </summary>
    class WarriorWeaponStore:WeaponStore
    {
        static WarriorWeapon warriorweapon = new WarriorWeapon();
        public static void ShowWarrior()
        {
            //死循环可一直查看武器属性，知道用户退出
            while (true)
            {
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t输入序号可查看该武器的属性,输入N退出,输入B进入购买");
                Console.ForegroundColor = ConsoleColor.White;
                //进入输出函数
                Exprot1();
                //判断用户按键是否正确，正确就退出循环
                while (true)
                {
                    ConsoleKeyInfo Downkey2 = Console.ReadKey(true);
                    //根据按键给武器属性赋值
                    if (Downkey2.Key.Equals(ConsoleKey.D1)|| Downkey2.Key.Equals(ConsoleKey.NumPad1))
                    {
                        warriorweapon.WeaponName = "狼牙棒";
                        warriorweapon.WeaponATK = 68;
                        warriorweapon.WeaponPrice = 500;
                        warriorweapon.ShowArms();
                        break;
                    }
                    //根据按键给武器属性赋值
                    else if (Downkey2.Key.Equals(ConsoleKey.D2) || Downkey2.Key.Equals(ConsoleKey.NumPad2))
                    {
                        warriorweapon.WeaponName = "破魂刀";
                        warriorweapon.WeaponATK = 128;
                        warriorweapon.WeaponPrice = 2300;
                        warriorweapon.ShowArms();
                        break;
                    }
                    //根据按键给武器属性赋值
                    else if (Downkey2.Key.Equals(ConsoleKey.D3) || Downkey2.Key.Equals(ConsoleKey.NumPad3))
                    {
                        warriorweapon.WeaponName = "修罗战斧";
                        warriorweapon.WeaponATK = 228;
                        warriorweapon.WeaponPrice = 6800;
                        warriorweapon.ShowArms();
                        break;
                    }
                    else if(Downkey2.Key.Equals(ConsoleKey.D4) || Downkey2.Key.Equals(ConsoleKey.NumPad4))
                    {
                        Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
                        Thread.Sleep(500);
                        Console.WriteLine("\n\t药品名称：    能量甘饮" );
                        Thread.Sleep(500);
                        Console.WriteLine("\n\t药品作用：    一次性回复血量80");
                        Thread.Sleep(500);
                        Console.WriteLine("\n\t药品价格：    500");
                        Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
                        break;
                    }
                    else if (Downkey2.Key.Equals(ConsoleKey.D5) || Downkey2.Key.Equals(ConsoleKey.NumPad5))
                    {
                        Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
                        Thread.Sleep(500);
                        Console.WriteLine("\n\t药品名称：    止痛药");
                        Thread.Sleep(500);
                        Console.WriteLine("\n\t药品作用：    一次性回复血量180");
                        Thread.Sleep(500);
                        Console.WriteLine("\n\t药品价格：    900");
                        Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
                        break;
                    }
                    else if(Downkey2.Key.Equals(ConsoleKey.N))
                    {
                        //返回玩家选择页面
                        Program.GameChoice();
                    }
                    else  if (Downkey2.Key.Equals(ConsoleKey.B))
                    {
                        //进入购买页面
                        StoreManager.WeaponBuy(true);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Thread.Sleep(500);
                        Console.WriteLine("\n\t**************很抱歉，您输入的有误，该武器不存在");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
        }
    }
    /// <summary>
    /// 法师武器商店
    /// </summary>
    class WizardWeaponStore:WeaponStore
    {
        static WizardWeapon wizardWeapon = new WizardWeapon();
        public static void ShowWizard()
        {
            while(true)
            {
                //死循环可一直查看武器属性，知道用户退出
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t输入序号可查看该武器的属性,输入N退出,输入B进入购买");
                Console.ForegroundColor = ConsoleColor.White;
                //进入输出函数
                Exprot2();
                //判断用户按键是否正确，正确就退出循环
                while (true)
                {
                    ConsoleKeyInfo Downkey2 = Console.ReadKey(true);
                    //根据按键给武器属性赋值
                    if (Downkey2.Key.Equals(ConsoleKey.D1)|| Downkey2.Key.Equals(ConsoleKey.NumPad1))
                    {
                        wizardWeapon.WeaponName = "摄魂";
                        wizardWeapon.WeaponATK = 95;
                        wizardWeapon.WeaponPrice = 500;
                        wizardWeapon.ShowArms();
                        break;
                    }
                    //根据按键给武器属性赋值
                    else if (Downkey2.Key.Equals(ConsoleKey.D2) || Downkey2.Key.Equals(ConsoleKey.NumPad2))
                    {
                        wizardWeapon.WeaponName = "紫月圣君";
                        wizardWeapon.WeaponATK = 188;
                        wizardWeapon.WeaponPrice = 2300;
                        wizardWeapon.ShowArms();
                        break;
                    }
                    //根据按键给武器属性赋值
                    else if (Downkey2.Key.Equals(ConsoleKey.D3) || Downkey2.Key.Equals(ConsoleKey.NumPad3))
                    {
                        wizardWeapon.WeaponName = "天神杖";
                        wizardWeapon.WeaponATK = 342;
                        wizardWeapon.WeaponPrice = 6800;
                        wizardWeapon.ShowArms();
                        break;
                    }
                    //输出补血药饮
                    else if (Downkey2.Key.Equals(ConsoleKey.D4) || Downkey2.Key.Equals(ConsoleKey.NumPad4))
                    {
                        Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
                        Thread.Sleep(500);
                        Console.WriteLine("\n\t药品名称：    能量甘饮");
                        Thread.Sleep(500);
                        Console.WriteLine("\n\t药品作用：    一次性回复血量120");
                        Thread.Sleep(500);
                        Console.WriteLine("\n\t药品价格：    500");
                        Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
                        break;
                    }
                    //输出补血药饮
                    else if (Downkey2.Key.Equals(ConsoleKey.D5) || Downkey2.Key.Equals(ConsoleKey.NumPad5))
                    {
                        Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
                        Thread.Sleep(500);
                        Console.WriteLine("\n\t药品名称：    止痛药");
                        Thread.Sleep(500);
                        Console.WriteLine("\n\t药品作用：    一次性回复血量240");
                        Thread.Sleep(500);
                        Console.WriteLine("\n\t药品价格：    900");
                        Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
                        break;
                    }
                    else if (Downkey2.Key.Equals(ConsoleKey.N))
                    {
                        //返回玩家选择页面
                        Program.GameChoice();
                    }
                    else if (Downkey2.Key.Equals(ConsoleKey.B))
                    {
                        //进入购买页面
                        StoreManager.WeaponBuy(false);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Thread.Sleep(500);
                        Console.WriteLine("\n\t**************很抱歉，您输入的有误，该武器不存在");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
        }
    }

    /// <summary>
    /// 武器商店管理，用于判断和输出
    /// </summary>
    class StoreManager
    {
       public static void WeaponBuy(bool a)
        {
            //如果真，进入战士购买系统
            if (a)
            {
                Program.Load();
                //调用商品展示函数（战士类）
                WeaponStore.Exprot1();
                while (true)
                {
                    Console.WriteLine("\n\t请输入序号进行购买，输入N退出");
                    ConsoleKeyInfo Downkey1 = Console.ReadKey(true);
                    //如果按下1键
                    if (Downkey1.Key.Equals(ConsoleKey.D1)|| Downkey1.Key.Equals(ConsoleKey.NumPad1))
                    {
                        //如果玩家的金钱大于500，进入
                        if (Program._RolesWarrior.Money >= 500)
                        {
                            //查找玩家的背包中有没有此商品，如果有就不能购买
                            bool jie = GamePackage.DicPackageGoods1.ContainsKey("狼牙棒");
                            if (jie)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t您当前已经拥有此商品,无需重复购买");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (!jie)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t购买成功，您已成功购买狼牙棒，已为您自动装备，可以在背包中查看");
                                Console.ForegroundColor = ConsoleColor.White;
                                //购买成功，玩家的背包中多一个此武器
                                GamePackage.DicPackageGoods1.Add("狼牙棒", 1);
                                //玩家金钱减少500
                                Program._RolesWarrior.Money = Program._RolesWarrior.Money - 500;
                                //玩家攻击力增加68
                                Program._RolesWarrior.Attack = Program._RolesWarrior.Attack + 68;
                            }
                        }
                        // 如果玩家的金钱小于500，进入
                        else if (Program._RolesWarrior.Money < 500)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\t您的金钱不足以购买当前商品");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    //如果按下2键
                    else if (Downkey1.Key.Equals(ConsoleKey.D2)|| Downkey1.Key.Equals(ConsoleKey.NumPad2))
                    {
                        //如果玩家的金钱大于2300，进入
                        if (Program._RolesWarrior.Money >= 2300)
                        {
                            //如果玩家的等级大于3级，进入
                            if (Program._RolesWarrior.Grade>=3)
                            {
                                //查找玩家背包中是否有该装备，如果有就不能购买
                                bool jie = GamePackage.DicPackageGoods1.ContainsKey("破魂刀");
                                if(jie)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\t您当前已经拥有此商品，无需重复购买");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                else if(!jie)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\t购买成功，您已成功购买破魂刀，已为您自动装备，可以在背包中查看");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    //购买成功，玩家的背包中多一个此武器
                                    GamePackage.DicPackageGoods1.Add("破魂刀", 1);
                                    //玩家金钱减少2300
                                    Program._RolesWarrior.Money = Program._RolesWarrior.Money - 2300;
                                    //玩家攻击力128
                                    Program._RolesWarrior.Attack = Program._RolesWarrior.Attack + 128;
                                }
                            }
                            else if(Program._RolesWarrior.Grade < 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t本商品需要3级以上才可购买，您的等级不足以购买当前商品，请尽快升级");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else if(Program._RolesWarrior.Money < 2300)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\t您的金钱不足以购买当前商品");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    //如果按下3键
                    else if (Downkey1.Key.Equals(ConsoleKey.D3)|| Downkey1.Key.Equals(ConsoleKey.NumPad3))
                    {
                        //如果玩家的金钱大于6800，进入
                        if (Program._RolesWarrior.Money >= 6800)
                        {
                            //如果玩家的等级大于6级，进入
                            if (Program._RolesWarrior.Grade >= 6)
                            {
                                //查找玩家背包中是否有该装备，如果有就不能购买
                                bool jie = GamePackage.DicPackageGoods1.ContainsKey("修罗战斧");
                                if(jie)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\t您当前已经拥有此商品");
                                    Console.ForegroundColor = ConsoleColor.White;
                               }
                                else if(!jie)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\t购买成功，您已成功购买修罗战斧，已为您自动装备，可以在背包中查看");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    //购买成功，玩家的背包中多一个此武器
                                    GamePackage.DicPackageGoods1.Add("修罗战斧", 1);
                                    //玩家金钱减少6800
                                    Program._RolesWarrior.Money = Program._RolesWarrior.Money - 6800;
                                    //玩家攻击力增加228
                                    Program._RolesWarrior.Attack = Program._RolesWarrior.Attack + 228;
                                }
                            }
                            else if(Program._RolesWarrior.Grade < 6)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t本商品需要6级以上才可购买，您的等级不足以购买当前商品，请尽快升级");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else if (Program._RolesWarrior.Money < 6800)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\t您的金钱不足以购买当前商品");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    //如果按下4键
                    else if (Downkey1.Key.Equals(ConsoleKey.D4)|| Downkey1.Key.Equals(ConsoleKey.NumPad4))
                    {
                        if (Program._RolesWarrior.Money >= 500)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\t购买成功，您已成功购买能量甘饮，已为放入背包，可以在背包中查看");
                            Console.ForegroundColor = ConsoleColor.White;
                            int count = GamePackage.DicPackageGoods1["能量甘饮"];
                            GamePackage.DicPackageGoods1["能量甘饮"] = count + 1;
                            Program._RolesWarrior.Money = Program._RolesWarrior.Money - 500;
                        }
                        else if (Program._RolesWarrior.Money < 500)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\t您的金钱不足以购买当前商品");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else if (Downkey1.Key.Equals(ConsoleKey.D5) || Downkey1.Key.Equals(ConsoleKey.NumPad5))
                    {
                        if(Program._RolesWarrior.Money >= 900)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\t购买成功，您已成功购买止痛药，已为放入背包，可以在背包中查看");
                            Console.ForegroundColor = ConsoleColor.White;
                            int count = GamePackage.DicPackageGoods1["止痛药"];
                            GamePackage.DicPackageGoods1["止痛药"] = count + 1;
                            Program._RolesWarrior.Money = Program._RolesWarrior.Money - 800;
                        }
                        else if (Program._RolesWarrior.Money < 900)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\t您的金钱不足以购买当前商品");
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
                        Console.WriteLine("\n\t**************很抱歉，您输入的有误，该商品不存在");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                //购买结束后回到选择页面
            }
            
            //如果真，进入法师购买系统
            else if (!a)
            {
                Program.Load();
                //调用商品展示函数（法师类）
                WeaponStore.Exprot2();
                while (true)
                {
                    Console.WriteLine("\n\t请输入序号进行购买，输入N退出");
                    ConsoleKeyInfo Downkey1 = Console.ReadKey(true);
                    //如果按下1键
                    if (Downkey1.Key.Equals(ConsoleKey.D1)|| Downkey1.Key.Equals(ConsoleKey.NumPad1))
                    {
                        //如果玩家的金钱大于500，进入
                        if (Program._RolesWizard.Money >= 500)
                        {
                            //查找玩家的背包中有没有此商品，如果有就不能购买
                            bool jie = GamePackage.DicPackageGoods1.ContainsKey("摄魂");
                            if (jie)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t您当前已经拥有此商品");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (!jie)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t购买成功，您已成功购买摄魂，已为您自动装备，可以在背包中查看");
                                Console.ForegroundColor = ConsoleColor.White;
                                //购买成功，玩家的背包中多一个此武器
                                GamePackage.DicPackageGoods1.Add("摄魂", 1);
                                //玩家金钱减少500
                                Program._RolesWizard.Money = Program._RolesWizard.Money - 500;
                                //玩家攻击力增加68
                                Program._RolesWizard.Attack = Program._RolesWizard.Attack + 95;
                            }
                        }
                        // 如果玩家的金钱小于500，进入
                        else if (Program._RolesWizard.Money < 500)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\t您的金钱不足以购买当前商品");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    //如果按下2键
                    else if (Downkey1.Key.Equals(ConsoleKey.D2)|| Downkey1.Key.Equals(ConsoleKey.NumPad2))
                    {
                        //如果玩家的金钱大于2300，进入
                        if (Program._RolesWizard.Money >= 2300)
                        {
                            //如果玩家的等级大于3级，进入
                            if (Program._RolesWizard.Grade >= 3)
                            {
                                //查找玩家背包中是否有该装备，如果有就不能购买
                                bool jie = GamePackage.DicPackageGoods1.ContainsKey("紫月圣君");
                                if (jie)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\t您当前已经拥有此商品");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                else if (!jie)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\t购买成功，您已成功购买紫月圣君，已为您自动装备，可以在背包中查看");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    //购买成功，玩家的背包中多一个此武器
                                    GamePackage.DicPackageGoods1.Add("紫月圣君", 1);
                                    //玩家金钱减少2300
                                    Program._RolesWizard.Money = Program._RolesWizard.Money - 2300;
                                    //玩家攻击力128
                                    Program._RolesWizard.Attack = Program._RolesWizard.Attack + 188;
                                }
                            }
                            else if (Program._RolesWizard.Grade < 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t本商品需要3级以上才可购买，您的等级不足以购买当前商品，请尽快升级");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else if (Program._RolesWizard.Money < 2300)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\t您的金钱不足以购买当前商品");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    //如果按下3键
                    else if (Downkey1.Key.Equals(ConsoleKey.D3)|| Downkey1.Key.Equals(ConsoleKey.NumPad3))
                    {
                        //如果玩家的金钱大于6800，进入
                        if (Program._RolesWizard.Money >= 6800)
                        {
                            //如果玩家的等级大于6级，进入
                            if (Program._RolesWizard.Grade >= 6)
                            {
                                //查找玩家背包中是否有该装备，如果有就不能购买
                                bool jie = GamePackage.DicPackageGoods1.ContainsKey("天神杖");
                                if (jie)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\t您当前已经拥有此商品");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                else if (!jie)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\t购买成功，您已成功购买天神杖，已为您自动装备，可以在背包中查看");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    //购买成功，玩家的背包中多一个此武器
                                    GamePackage.DicPackageGoods1.Add("天神杖", 1);
                                    //玩家金钱减少6800
                                    Program._RolesWizard.Money = Program._RolesWizard.Money - 6800;
                                    //玩家攻击力增加228
                                    Program._RolesWizard.Attack = Program._RolesWizard.Attack + 342;
                                }
                            }
                            else if (Program._RolesWizard.Grade < 6)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t本商品需要6级以上才可购买，您的等级不足以购买当前商品，请尽快升级");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else if (Program._RolesWizard.Money < 6800)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\t您的金钱不足以购买当前商品");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    //如果按下4键
                    else if (Downkey1.Key.Equals(ConsoleKey.D4)|| Downkey1.Key.Equals(ConsoleKey.NumPad4))
                    {
                        if (Program._RolesWizard.Money >= 500)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\t购买成功，您已成功购买能量甘饮，已为放入背包，可以在背包中查看");
                            Console.ForegroundColor = ConsoleColor.White;
                            int count = GamePackage.DicPackageGoods1["能量甘饮"];
                            GamePackage.DicPackageGoods1["能量甘饮"] = count + 1;
                            Program._RolesWizard.Money = Program._RolesWizard.Money - 500;
                        }
                        else if (Program._RolesWizard.Money < 500)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\t您的金钱不足以购买当前商品");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else if (Downkey1.Key.Equals(ConsoleKey.D5) || Downkey1.Key.Equals(ConsoleKey.NumPad5))
                    {
                        if (Program._RolesWizard.Money >= 900)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\t购买成功，您已成功购买止痛药，已为放入背包，可以在背包中查看");
                            Console.ForegroundColor = ConsoleColor.White;
                            int count = GamePackage.DicPackageGoods1["止痛药"];
                            GamePackage.DicPackageGoods1["止痛药"] = count + 1;
                            Program._RolesWizard.Money = Program._RolesWizard.Money - 900;
                        }
                        else if (Program._RolesWizard.Money < 900)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\t您的金钱不足以购买当前商品");
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
                        Console.WriteLine("\n\t**************很抱歉，您输入的有误，该商品不存在");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                //购买结束后回到选择页面
            }
        }
    }
}
