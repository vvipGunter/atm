using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using SimplyBankSystem;

//public delegate string  HelloDelegate();
namespace Sbankaount
{
    public class User                  //普通用户，为基类
    {
        public readonly double max1 = 1000;    //信用卡
        public readonly double max2 = 10000;    //银卡
        public readonly double max3 = 100000;   //金卡
        protected string CusName;
        protected string CusNub;         //暂时设为8位，通常账户号为15或18位，并且是随机产生的
        protected string CusPassWord;    //通常设为六位
        protected double CusMoney;
        public string UserName        //用户名属性
        {
            get { return CusName; }
            set { CusName = value; }
        }
        public string UserNub         //用户账号属性
        {
            get { return CusNub; }
            set { CusNub = value; }
        }
        public double UserMoney       //用户金额的属性
        {
            get { return CusMoney; }
            set { CusMoney = value; }
        }
        public string UserPassWord   //用户密码属性
        {
            get { return CusPassWord; }
            set { CusPassWord = value; }
        }
        public User()                 //重载方法
        { }
        public User(string name)      //构造一个只传1个参数的方法
        {
            CusName = name;
        }
        public User(string nub,double  money)
        {
            CusNub = nub;
            CusMoney += money;
        }
        //public User(string name, double money)              //构造一个传2个参数的方法
        //{
        //    CusName = name;
        //    CusMoney = 0;
        //}
        public User(string nub, string name, double money) //构造一个传3（账户号，密码及金额）个参数的方法
        {
            CusNub = nub;
            CusName = name;
            CusMoney = money;
        }
        //public User(string name, string password)    //构造一个传2（姓名和密码）个参数的方法，可进行查询等功能
        //{
        //    CusName = name;
        //    CusPassWord = password;
        //}
       
        public virtual void Qu_Kuan()           //定义取款的普通方法
        {
            Console.WriteLine("请输入6位数字组成的密码：");
            string pass = Console.ReadLine();
            Regex regExpression = new Regex(@"^\d*[0-9]{6}$");
            Match m = regExpression.Match(pass);
            if (m.Success)
            {
                if (String.Equals(pass, CusPassWord))
                {

                    Console.WriteLine("请输入要取的金额，必须为100整数倍(或不想取0)");
                    string temp = Console.ReadLine();   //代表要取的金额
                    Regex regExpression1 = new Regex(@"^(([1-9]\d*00)|0)$");
                    Match n = regExpression1.Match(temp);
                    if (n.Success)
                    {
                        double num = Convert.ToDouble(temp);
                        if (num < CusMoney)    //要取的金额不能大于客户已有的金额
                        {
                            CusMoney -= num;
                            string datatime = DateTime.Now.ToString();
                            Console.WriteLine("用户" + CusName + "您已经在" + datatime + "成功取走￥：" + temp);
                            CardInfomation("******");
                        }
                        else
                        {

                            Console.WriteLine("您的储蓄金额不够，不能取款!");
                        }

                    }
                    else
                    {

                        Console.WriteLine("您的输入不合法，操作失败");
                    }

                }
            }
            else { Console.WriteLine("您的密码输入不合法"); }
        }
        public static User OpenUser()                     //创建新用户
        {
            Console.WriteLine("****  1 普通用户     2 信用卡账户      ****");
            Console.WriteLine("****  3 银卡用户     4 金卡账户    5其它****");
            Console.WriteLine("请选择你要新建的账户类型");
            string temp = Console.ReadLine();
            if (temp == "1")
            {
                Console.WriteLine("请输入账户姓名:");        //事实上也应该判断
                string name = Console.ReadLine();
                Console.WriteLine("请输入账户号(15或18位的整数数字)，现在暂时设为8位:");
                string nub = Console.ReadLine();
                Regex regExpression = new Regex(@"^\d*[0-9]{8}$");
                Match m = regExpression.Match(nub);
                if (m.Success)
                {
                    Console.WriteLine("请输入六位整数数字的密码(0-9):");
                    string password = Console.ReadLine();
                    Console.WriteLine("请随便输入账户要存的金额:如暂时不想存钱,请输入0");
                    double money = Convert.ToDouble(Console.ReadLine());
                    if (money == 0)
                    {
                        User cus = new User(name, nub, password, money);
                    //string path = @"D:\\TestFile.txt";
                    //    using (StreamWriter sw = new StreamWriter(path))
                    //    {
                    //        if (File.Exists(path))
                    //        {
                    //            Console.WriteLine("文件是否已经成功创建:{0}", File.Exists(path));
                    //            sw.Write("The date is: ");
                    //            sw.WriteLine(DateTime.Now);
                    //            sw.WriteLine("******存储用户帐户信息*********");
                    //            sw.WriteLine("用户名\t\t帐号\t\t密码\t\t卡上余额");
                    //            sw.WriteLine("zhangqiang\t12345678\t******\t0");
                    //            sw.WriteLine("zhaosunafa\t45678231\t******\t0");
                    //            sw.Close();
                    //        }
                    //        else Console.WriteLine("文件不存在");
                    //    }
                    //    using (StringReader sr = new StringReader(path))
                    //    {
                    //        if (File.Exists(path))
                    //        {
                    //            sr.ReadToEnd();
                    //            Console.WriteLine("读出");
                    //            sr.Close();
                    //        }

                    //    }
                    //    Console.WriteLine("新建账户成功并已经保存在文件中");
                    //    return cus;
                        
                    //}
                    //else
                    //{
                    //    User cus = new User(name, nub, password, money);
                    //    string path = @"D:\\TestFile.txt";
                    //    using (StreamWriter sw = File.AppendText(path))
                    //    {
                    //        if (File.Exists(path))
                    //        {
                    //            Console.WriteLine("文件是否已经成功创建:{0}", File.Exists(path));
                    //            sw.Write("The date is: ");
                    //            sw.WriteLine(DateTime.Now);
                    //            sw.WriteLine("******存储用户帐户信息*********");
                    //            sw.WriteLine("用户名\t\t帐号\t\t密码\t\t卡上余额");
                    //            sw.WriteLine("zhangqiang\t12345678\t******\t100000");
                    //            sw.WriteLine("zhaosun\t45678231\t******\t200000");
                    //            sw.Close();
                    //        }
                    //        else Console.WriteLine("文件不存在");
                    //    }
                    //    using (StringReader sr = new StringReader(path))
                    //    {
                    //        if (File.Exists(path))
                    //        {
                    //            sr.ReadToEnd();
                    //            Console.WriteLine("读出");
                    //            sr.Close();
                    //        }

                    //    }
                        Console.WriteLine("新建普通账户成功并已经保存在文件中，你不能透支");
                        return cus;
                    }
                   
                }
                else
                {
                    Console.WriteLine("账户号输入有误，无法创建，您可以重新创建");
                    return null;
                }

            }
            if (temp == "2")
            {
                Console.WriteLine("请输入账户姓名:");//事实上也应该判断
                string name = Console.ReadLine();
                Console.WriteLine("请输入账户号(15或18位的整数数字)，方便起见，暂时设为8位:");
                string nub = Console.ReadLine();
                Regex regExpression = new Regex(@"^\d*[0-9]{8}$");
                Match m = regExpression.Match(nub);
                if (m.Success)
                {
                    Console.WriteLine("请输入六位整数数字的密码(0-9):");
                    string password = Console.ReadLine();
                    Console.WriteLine("请输入账户要存的金额:如暂时不想存钱,请输入0");
                    double money = Convert.ToDouble(Console.ReadLine());
                    if (money == 0)
                    {
                        CreditUser cus = new CreditUser(name, nub, password, money);
                        Console.WriteLine("新建信用卡账户成功，你最多能透支￥:10000");
                        return cus;
                    }
                    else
                    {
                        CreditUser cus = new CreditUser(name, nub, password, money);
                        Console.WriteLine("新建信用卡账户成功，你最多能透支￥:10000");
                        return cus;
                    }
                }
                else
                {
                    Console.WriteLine("账户号输入有误,创建用户失败");
                    return null;
                }
            }
            else if(temp=="3")
            { 
                Console.WriteLine("请输入账户姓名:");//事实上也应该判断
                string name = Console.ReadLine();
                Console.WriteLine("请输入账户号(15或18位的整数数字)，方便起见，暂时设为8位:");
                string nub = Console.ReadLine();
                Regex regExpression = new Regex(@"^\d*[0-9]{8}$");
                Match m = regExpression.Match(nub);
                if (m.Success)
                {
                    Console.WriteLine("请输入六位整数数字的密码(0-9):");
                    string password = Console.ReadLine();
                    Console.WriteLine("请输入账户要存的金额:如暂时不想存钱,请输入0");
                    double money = Convert.ToDouble(Console.ReadLine());
                    if (money == 0)
                    {
                        SilverCardUser cus = new SilverCardUser(name, nub, password, money);
                        Console.WriteLine("新建银卡账户成功，你最多能透支￥:10000");
                        return cus;
                    }
                    else
                    {
                        SilverCardUser  cus = new SilverCardUser(name, nub, password, money);
                        Console.WriteLine("新建银卡账户成功，你最多能透支￥:10000");
                        return cus;
                    }
                }
                else
                {
                    Console.WriteLine("账户号输入有误,创建用户失败");
                    return null;
                }
            
            }
            else if (temp == "4")
            {
                Console.WriteLine("请输入账户姓名:");//事实上也应该判断
                string name = Console.ReadLine();
                Console.WriteLine("请输入账户号(15或18位的整数数字)，方便起见，暂时设为8位:");
                string nub = Console.ReadLine();
                Regex regExpression = new Regex(@"^\d*[0-9]{8}$");
                Match m = regExpression.Match(nub);
                if (m.Success)
                {
                    Console.WriteLine("请输入六位整数数字的密码(0-9):");
                    string password = Console.ReadLine();
                    Console.WriteLine("请输入账户要存的金额:如暂时不想存钱,请输入0");
                    double money = Convert.ToDouble(Console.ReadLine());
                    if (money == 0)
                    {
                        GoldCardUser cus = new GoldCardUser(name, nub, password, money);
                        Console.WriteLine("新建金卡账户成功,你最多能透支￥:100000");
                        return cus;
                    }
                    else
                    {
                       GoldCardUser cus = new GoldCardUser(name, nub, password, money);
                       Console.WriteLine("新建金卡账户成功,你最多能透支￥:100000");
                        return cus;
                    }
                }
                else
                {
                    Console.WriteLine("账户号输入有误,创建用户失败");
                    return null;
                }
            }
            else if (temp == "5")
            {
                Console.WriteLine("其他账户类型暂时未开通，对不起");
            }
            return null;
           
        }
        
        public void ChangePassWord()    //更改用户的初始密码
        {

            Console.WriteLine("请输入6位数字组成的旧密码：");
            string pass = Console.ReadLine();
            Regex regExpression = new Regex(@"^\d*[0-9]{6}$");
            Match m = regExpression.Match(pass);
            if (m.Success)
            {
                if (String.Equals(pass, CusPassWord))

                    Console.WriteLine("请输入你想修改为的新密码:\n");
                string newpassword1 = Console.ReadLine();
                Console.WriteLine("请再次输入你想修改为的新密码以确定:\n");
                string newpassword2 = Console.ReadLine();
                if (String.Equals(newpassword1, newpassword2))
                    CusPassWord = newpassword1;
                else Console.WriteLine("2次输入不一致，请重新修改");
            }
            else Console.WriteLine("你的密码输入有错误！");
        }
        public User(string name, string nub, string password, double money) //4参的方法
        {
            CusName = name;
            CusNub = nub;
            CusPassWord = password;
            CusMoney = money;
        }
        public void CardInfomation(string password)         //打印出帐户信息
        {
            CusPassWord = password;
            Console.WriteLine("账号" + ":" + CusNub);
            Console.WriteLine("用户名：" + CusName);
            Console.WriteLine("卡上金额" + ":" + "{0:c}", CusMoney);
        }
        public virtual string SaveInfo()
        {
            string temp = this.CusName + "\t" + this.CusPassWord + "\t" + this.CusMoney + "\tcommon";
            return temp;

        }

        public void Add_Money()       //定义存款的普通方法
        {
            Console.WriteLine("请输入要存的金额，必须为100的整数倍(或不存0):");
            string temp = Console.ReadLine();
            Regex regExpression = new Regex(@"^(([1-9]\d*00)|0)$");
            Match m = regExpression.Match(temp);
            if (m.Success)
            {
                CusMoney += Convert.ToDouble(temp);
                string datatime = DateTime.Now.ToString();
                Console.WriteLine("用户" + CusName + "您已经在" + datatime + "成功存入￥" + temp);
                Console.WriteLine("存钱后帐户的信息为：");
                CardInfomation("******");
            }
            else
            {
                Console.WriteLine("您的输入不合法，没有存入你的账户");
            }

        }
        private void Infomation(string p) //处理出错信息
        {
            throw new Exception("The method or operation is not implemented.");
        }
        
        public class Test         //测试类，主要用来测试        
        {
            public static void Main(string[] args)
            {
                
                while (true)
                {
                    Cai_Dan(); Console.ReadLine();
                 }
                
            }
            public static void Cai_Dan()           //利用菜单调用各方法
            {
                Console.WriteLine(" \t\t欢迎使用自助服务银行!");
                Console.WriteLine("***Self-service bank serve in 24 hours***");
                User cus = null;
                while (true)
                {
                    Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");//还有修改密码
                    Console.WriteLine("@@普通：  1开户  2存钱   3取钱  4 查询余额  5 修改密码 6 转账 7销卡 0退出 @@@");
                    Console.WriteLine("@@信用卡：1开户  2存钱   3取钱  4 查询余额  5 修改密码 6 转账 7销卡 0退出 @@@");
                    Console.WriteLine("@@银卡：  1开户  2存钱   3取钱  4 查询余额  5 修改密码 6 转账 7销卡 0退出 @@@");
                    Console.WriteLine("@@金卡：  1开户  2存钱   3取钱  4 查询余额  5 修改密码 6 转账 7销卡 0退出 @@@");
                    Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("输入相应的操作号，进行相应的操作：");
                    string index = Console.ReadLine();
                    switch (index)
                    {
                        case "0": break;
                        case "1":
                            if (cus == null)
                            {
                                cus = User.OpenUser(); //初次使用时请新建一个账户

                            }
                            else
                            {
                                Console.WriteLine("你已经新建了一个用户");//是否再开一个账户

                            }
                            continue;
                        case "2":
                            if (cus == null)
                            {
                                Console.WriteLine("对不起,初次使用时请新建一个账户");
                            }
                            else
                            {
                                cus.Add_Money();
                            }
                            continue;
                        case "3":
                            if (cus == null)
                            {
                                Console.WriteLine("对不起,初次使用时请新建一个账户");
                            }
                            else
                            {
                                CreditUser zh = cus as CreditUser;
                                SilverCardUser slv = cus as SilverCardUser;
                                GoldCardUser gld = cus as GoldCardUser;
                                if (zh != null)
                                {
                                    zh.Qu_Kuan();
                                }
                                else
                                {
                                    cus.Qu_Kuan();
                                }
                                if (slv != null)
                                {
                                    slv.Qu_Kuan();
                                }
                                else
                                {
                                    cus.Qu_Kuan();
                                }
                                if (gld != null)
                                {
                                    gld.Qu_Kuan();
                                }
                                else
                                {
                                    cus.Qu_Kuan();
                                }
                            }
                            continue;
                        case "4":
                            if (cus == null)
                            {
                                Console.WriteLine("对不起,初次使用时请新建一个账号");
                            }
                            else
                            {
                                cus.CardInfomation("******");
                            }
                            continue;
                        case "5":                              //修改密码,已经实现 
                            if (cus == null)
                            {
                                Console.WriteLine("对不起,初次使用时请新建一个账号");
                            }
                            else
                            {
                                cus.ChangePassWord();
                            }
                            continue;
                          //case "6":                        //转账
                          //  if (cus == null) 
                          //   {
                          //      Console.WriteLine("对不起,初次使用时请新建一个账号");
                          //    }
                          //   else
                          //  {
                          //    cus.TurnMoneyToAnotherAccout();
                          //    }
                          //continue;
                        case "7":
                            if (cus == null)
                            {
                                Console.WriteLine("账户没有开，无需销卡");
                            }
                            else
                            {
                                Console.WriteLine("已经成功销户");
                                cus = null;
                            }
                            continue;
                        default: Console.WriteLine("输入不合法,请重新输入!");
                            continue;

                    }
                    break;
                }
               
                Console.WriteLine("输入任意键退出");
            }

           
        }
    }
}