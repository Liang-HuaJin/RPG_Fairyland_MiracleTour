using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RPG_Fairyland_MiracleTour
{
    /// <summary>
    /// 武器类
    /// </summary>
    class Weapon
    {
        //武器价格  
        private int weaponPrice;
        public int WeaponPrice
        {
            get { return weaponPrice; }
            set { weaponPrice = value; }
        }
        //武器攻击力 
        private int weaponATK;
        public int WeaponATK
        {
            get { return weaponATK; }
            set { weaponATK = value; }
        }
        //武器名称  
        private string weaponName;
        public string WeaponName
        {
            get { return weaponName; }
            set { weaponName = value; }
        }
  
    }
    /// <summary>
    /// 法师武器类
    /// </summary>
    class WizardWeapon : Weapon
    {
        //用于输出武器属性
        public void ShowArms()
        {
            Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            Thread.Sleep(500);
            Console.WriteLine("\n\t武器名称：    " + WeaponName);
            Thread.Sleep(500);
            Console.WriteLine("\n\t武器攻击力：    " + WeaponATK);
            Thread.Sleep(500);
            Console.WriteLine("\n\t武器价格：    " + WeaponPrice);
            Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
        }
    }
    /// <summary>
    /// 战士武器类
    /// </summary>
    class WarriorWeapon : Weapon
    {
        public void ShowArms()
        {
            Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            Thread.Sleep(500);
            Console.WriteLine("\n\t武器名称：    " + WeaponName);
            Thread.Sleep(500);
            Console.WriteLine("\n\t武器攻击力：    " + WeaponATK);
            Thread.Sleep(500);
            Console.WriteLine("\n\t武器价格：    " + WeaponPrice);
            Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
        }
    }
}
