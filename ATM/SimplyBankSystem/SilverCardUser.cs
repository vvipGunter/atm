using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Sbankaount;

namespace SimplyBankSystem
{
    public class SilverCardUser:User
    {

             public SilverCardUser()
            {
            }
            public SilverCardUser(string name, string nub, string password, double money) 
            {
                CusName = name;
                CusNub = nub;
                CusPassWord = password;
                CusMoney = money;
            }
            public override string SaveInfo()
            {
                return this.CusName + "\t" + this.CusPassWord + "\t" + this.CusMoney + "\tcredit";
            }
            public override void Qu_Kuan()
            {
                Console.WriteLine("请输入6位数字组成的密码：");
                string pass = Console.ReadLine();
                Regex regExpression = new Regex(@"^\d*[0-9]{6}$");
                Match m = regExpression.Match(pass);
                if (m.Success)
                {
                    if (String.Equals(pass, CusPassWord))
                    {
                        Console.WriteLine("请输入要取的金额，必须为100整数倍");
                        string temp = Console.ReadLine();//代表要取的金额
                        Regex regExpression2 = new Regex(@"^[1-9]\d*00$");
                        Match a = regExpression2.Match(temp);
                        if (a.Success)
                        {
                            double num = Convert.ToDouble(temp);
                            if (num - CusMoney <= max2)  //要取的金额不能大于客户已有的金额
                            {
                                CusMoney -= num;
                                string datatime = DateTime.Now.ToString();
                                Console.WriteLine("用户" + CusName + "您已经在" + datatime + "成功取走￥：" + temp);
                                CardInfomation("******");
                            }
                            else
                            {
                                Console.WriteLine("您的储蓄金额不够，操作失败!");
                            }

                        }
                        else
                        {
                            Console.WriteLine("您的输入不合法，操作失败");
                        }
                    }
                    else { Console.WriteLine("密码错误"); }
                }
                else
                {
                    Console.WriteLine("密码输入格式有误");
                }
            }
        }
    }
