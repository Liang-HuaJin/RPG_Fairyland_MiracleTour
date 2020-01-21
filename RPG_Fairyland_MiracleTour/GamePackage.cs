using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RPG_Fairyland_MiracleTour
{
    class GamePackage
    {
        //玩家的背包列表
        private static Dictionary<string, int> dicPackageGoods = new Dictionary<string, int>();
        public static Dictionary<string, int> DicPackageGoods1
        {
            get
            {
                return dicPackageGoods;
            }

            set
            {
                dicPackageGoods = value;
            }
        }
        /// <summary>
        /// 给玩家背包付物品初值
        /// </summary>
        public GamePackage()
        {
            dicPackageGoods["能量甘饮"] = 1;
            dicPackageGoods["止痛药"] = 1;

        }
        /// <summary>
        /// 用来输出玩家背包内物品
        /// </summary>
        public void PackageToUp()
        {
            Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            Console.WriteLine("\n\t名称");
            foreach (var packageGoods in dicPackageGoods)
            {
                Thread.Sleep(500);
                Console.WriteLine("\n\t" + packageGoods.Key+"       "+ packageGoods.Value+"个");
            }
            Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            Program.GameChoice();
        }
    }
}
