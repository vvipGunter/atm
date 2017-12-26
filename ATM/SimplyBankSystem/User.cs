using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using SimplyBankSystem;

//public delegate string  HelloDelegate();
namespace Sbankaount
{
    public class User                  //��ͨ�û���Ϊ����
    {
        public readonly double max1 = 1000;    //���ÿ�
        public readonly double max2 = 10000;    //����
        public readonly double max3 = 100000;   //��
        protected string CusName;
        protected string CusNub;         //��ʱ��Ϊ8λ��ͨ���˻���Ϊ15��18λ�����������������
        protected string CusPassWord;    //ͨ����Ϊ��λ
        protected double CusMoney;
        public string UserName        //�û�������
        {
            get { return CusName; }
            set { CusName = value; }
        }
        public string UserNub         //�û��˺�����
        {
            get { return CusNub; }
            set { CusNub = value; }
        }
        public double UserMoney       //�û���������
        {
            get { return CusMoney; }
            set { CusMoney = value; }
        }
        public string UserPassWord   //�û���������
        {
            get { return CusPassWord; }
            set { CusPassWord = value; }
        }
        public User()                 //���ط���
        { }
        public User(string name)      //����һ��ֻ��1�������ķ���
        {
            CusName = name;
        }
        public User(string nub,double  money)
        {
            CusNub = nub;
            CusMoney += money;
        }
        //public User(string name, double money)              //����һ����2�������ķ���
        //{
        //    CusName = name;
        //    CusMoney = 0;
        //}
        public User(string nub, string name, double money) //����һ����3���˻��ţ����뼰���������ķ���
        {
            CusNub = nub;
            CusName = name;
            CusMoney = money;
        }
        //public User(string name, string password)    //����һ����2�����������룩�������ķ������ɽ��в�ѯ�ȹ���
        //{
        //    CusName = name;
        //    CusPassWord = password;
        //}
       
        public virtual void Qu_Kuan()           //����ȡ�����ͨ����
        {
            Console.WriteLine("������6λ������ɵ����룺");
            string pass = Console.ReadLine();
            Regex regExpression = new Regex(@"^\d*[0-9]{6}$");
            Match m = regExpression.Match(pass);
            if (m.Success)
            {
                if (String.Equals(pass, CusPassWord))
                {

                    Console.WriteLine("������Ҫȡ�Ľ�����Ϊ100������(����ȡ0)");
                    string temp = Console.ReadLine();   //����Ҫȡ�Ľ��
                    Regex regExpression1 = new Regex(@"^(([1-9]\d*00)|0)$");
                    Match n = regExpression1.Match(temp);
                    if (n.Success)
                    {
                        double num = Convert.ToDouble(temp);
                        if (num < CusMoney)    //Ҫȡ�Ľ��ܴ��ڿͻ����еĽ��
                        {
                            CusMoney -= num;
                            string datatime = DateTime.Now.ToString();
                            Console.WriteLine("�û�" + CusName + "���Ѿ���" + datatime + "�ɹ�ȡ�ߣ���" + temp);
                            CardInfomation("******");
                        }
                        else
                        {

                            Console.WriteLine("���Ĵ������������ȡ��!");
                        }

                    }
                    else
                    {

                        Console.WriteLine("�������벻�Ϸ�������ʧ��");
                    }

                }
            }
            else { Console.WriteLine("�����������벻�Ϸ�"); }
        }
        public static User OpenUser()                     //�������û�
        {
            Console.WriteLine("****  1 ��ͨ�û�     2 ���ÿ��˻�      ****");
            Console.WriteLine("****  3 �����û�     4 ���˻�    5����****");
            Console.WriteLine("��ѡ����Ҫ�½����˻�����");
            string temp = Console.ReadLine();
            if (temp == "1")
            {
                Console.WriteLine("�������˻�����:");        //��ʵ��ҲӦ���ж�
                string name = Console.ReadLine();
                Console.WriteLine("�������˻���(15��18λ����������)��������ʱ��Ϊ8λ:");
                string nub = Console.ReadLine();
                Regex regExpression = new Regex(@"^\d*[0-9]{8}$");
                Match m = regExpression.Match(nub);
                if (m.Success)
                {
                    Console.WriteLine("��������λ�������ֵ�����(0-9):");
                    string password = Console.ReadLine();
                    Console.WriteLine("����������˻�Ҫ��Ľ��:����ʱ�����Ǯ,������0");
                    double money = Convert.ToDouble(Console.ReadLine());
                    if (money == 0)
                    {
                        User cus = new User(name, nub, password, money);
                    //string path = @"D:\\TestFile.txt";
                    //    using (StreamWriter sw = new StreamWriter(path))
                    //    {
                    //        if (File.Exists(path))
                    //        {
                    //            Console.WriteLine("�ļ��Ƿ��Ѿ��ɹ�����:{0}", File.Exists(path));
                    //            sw.Write("The date is: ");
                    //            sw.WriteLine(DateTime.Now);
                    //            sw.WriteLine("******�洢�û��ʻ���Ϣ*********");
                    //            sw.WriteLine("�û���\t\t�ʺ�\t\t����\t\t�������");
                    //            sw.WriteLine("zhangqiang\t12345678\t******\t0");
                    //            sw.WriteLine("zhaosunafa\t45678231\t******\t0");
                    //            sw.Close();
                    //        }
                    //        else Console.WriteLine("�ļ�������");
                    //    }
                    //    using (StringReader sr = new StringReader(path))
                    //    {
                    //        if (File.Exists(path))
                    //        {
                    //            sr.ReadToEnd();
                    //            Console.WriteLine("����");
                    //            sr.Close();
                    //        }

                    //    }
                    //    Console.WriteLine("�½��˻��ɹ����Ѿ��������ļ���");
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
                    //            Console.WriteLine("�ļ��Ƿ��Ѿ��ɹ�����:{0}", File.Exists(path));
                    //            sw.Write("The date is: ");
                    //            sw.WriteLine(DateTime.Now);
                    //            sw.WriteLine("******�洢�û��ʻ���Ϣ*********");
                    //            sw.WriteLine("�û���\t\t�ʺ�\t\t����\t\t�������");
                    //            sw.WriteLine("zhangqiang\t12345678\t******\t100000");
                    //            sw.WriteLine("zhaosun\t45678231\t******\t200000");
                    //            sw.Close();
                    //        }
                    //        else Console.WriteLine("�ļ�������");
                    //    }
                    //    using (StringReader sr = new StringReader(path))
                    //    {
                    //        if (File.Exists(path))
                    //        {
                    //            sr.ReadToEnd();
                    //            Console.WriteLine("����");
                    //            sr.Close();
                    //        }

                    //    }
                        Console.WriteLine("�½���ͨ�˻��ɹ����Ѿ��������ļ��У��㲻��͸֧");
                        return cus;
                    }
                   
                }
                else
                {
                    Console.WriteLine("�˻������������޷����������������´���");
                    return null;
                }

            }
            if (temp == "2")
            {
                Console.WriteLine("�������˻�����:");//��ʵ��ҲӦ���ж�
                string name = Console.ReadLine();
                Console.WriteLine("�������˻���(15��18λ����������)�������������ʱ��Ϊ8λ:");
                string nub = Console.ReadLine();
                Regex regExpression = new Regex(@"^\d*[0-9]{8}$");
                Match m = regExpression.Match(nub);
                if (m.Success)
                {
                    Console.WriteLine("��������λ�������ֵ�����(0-9):");
                    string password = Console.ReadLine();
                    Console.WriteLine("�������˻�Ҫ��Ľ��:����ʱ�����Ǯ,������0");
                    double money = Convert.ToDouble(Console.ReadLine());
                    if (money == 0)
                    {
                        CreditUser cus = new CreditUser(name, nub, password, money);
                        Console.WriteLine("�½����ÿ��˻��ɹ����������͸֧��:10000");
                        return cus;
                    }
                    else
                    {
                        CreditUser cus = new CreditUser(name, nub, password, money);
                        Console.WriteLine("�½����ÿ��˻��ɹ����������͸֧��:10000");
                        return cus;
                    }
                }
                else
                {
                    Console.WriteLine("�˻�����������,�����û�ʧ��");
                    return null;
                }
            }
            else if(temp=="3")
            { 
                Console.WriteLine("�������˻�����:");//��ʵ��ҲӦ���ж�
                string name = Console.ReadLine();
                Console.WriteLine("�������˻���(15��18λ����������)�������������ʱ��Ϊ8λ:");
                string nub = Console.ReadLine();
                Regex regExpression = new Regex(@"^\d*[0-9]{8}$");
                Match m = regExpression.Match(nub);
                if (m.Success)
                {
                    Console.WriteLine("��������λ�������ֵ�����(0-9):");
                    string password = Console.ReadLine();
                    Console.WriteLine("�������˻�Ҫ��Ľ��:����ʱ�����Ǯ,������0");
                    double money = Convert.ToDouble(Console.ReadLine());
                    if (money == 0)
                    {
                        SilverCardUser cus = new SilverCardUser(name, nub, password, money);
                        Console.WriteLine("�½������˻��ɹ����������͸֧��:10000");
                        return cus;
                    }
                    else
                    {
                        SilverCardUser  cus = new SilverCardUser(name, nub, password, money);
                        Console.WriteLine("�½������˻��ɹ����������͸֧��:10000");
                        return cus;
                    }
                }
                else
                {
                    Console.WriteLine("�˻�����������,�����û�ʧ��");
                    return null;
                }
            
            }
            else if (temp == "4")
            {
                Console.WriteLine("�������˻�����:");//��ʵ��ҲӦ���ж�
                string name = Console.ReadLine();
                Console.WriteLine("�������˻���(15��18λ����������)�������������ʱ��Ϊ8λ:");
                string nub = Console.ReadLine();
                Regex regExpression = new Regex(@"^\d*[0-9]{8}$");
                Match m = regExpression.Match(nub);
                if (m.Success)
                {
                    Console.WriteLine("��������λ�������ֵ�����(0-9):");
                    string password = Console.ReadLine();
                    Console.WriteLine("�������˻�Ҫ��Ľ��:����ʱ�����Ǯ,������0");
                    double money = Convert.ToDouble(Console.ReadLine());
                    if (money == 0)
                    {
                        GoldCardUser cus = new GoldCardUser(name, nub, password, money);
                        Console.WriteLine("�½����˻��ɹ�,�������͸֧��:100000");
                        return cus;
                    }
                    else
                    {
                       GoldCardUser cus = new GoldCardUser(name, nub, password, money);
                       Console.WriteLine("�½����˻��ɹ�,�������͸֧��:100000");
                        return cus;
                    }
                }
                else
                {
                    Console.WriteLine("�˻�����������,�����û�ʧ��");
                    return null;
                }
            }
            else if (temp == "5")
            {
                Console.WriteLine("�����˻�������ʱδ��ͨ���Բ���");
            }
            return null;
           
        }
        
        public void ChangePassWord()    //�����û��ĳ�ʼ����
        {

            Console.WriteLine("������6λ������ɵľ����룺");
            string pass = Console.ReadLine();
            Regex regExpression = new Regex(@"^\d*[0-9]{6}$");
            Match m = regExpression.Match(pass);
            if (m.Success)
            {
                if (String.Equals(pass, CusPassWord))

                    Console.WriteLine("�����������޸�Ϊ��������:\n");
                string newpassword1 = Console.ReadLine();
                Console.WriteLine("���ٴ����������޸�Ϊ����������ȷ��:\n");
                string newpassword2 = Console.ReadLine();
                if (String.Equals(newpassword1, newpassword2))
                    CusPassWord = newpassword1;
                else Console.WriteLine("2�����벻һ�£��������޸�");
            }
            else Console.WriteLine("������������д���");
        }
        public User(string name, string nub, string password, double money) //4�εķ���
        {
            CusName = name;
            CusNub = nub;
            CusPassWord = password;
            CusMoney = money;
        }
        public void CardInfomation(string password)         //��ӡ���ʻ���Ϣ
        {
            CusPassWord = password;
            Console.WriteLine("�˺�" + ":" + CusNub);
            Console.WriteLine("�û�����" + CusName);
            Console.WriteLine("���Ͻ��" + ":" + "{0:c}", CusMoney);
        }
        public virtual string SaveInfo()
        {
            string temp = this.CusName + "\t" + this.CusPassWord + "\t" + this.CusMoney + "\tcommon";
            return temp;

        }

        public void Add_Money()       //���������ͨ����
        {
            Console.WriteLine("������Ҫ��Ľ�����Ϊ100��������(�򲻴�0):");
            string temp = Console.ReadLine();
            Regex regExpression = new Regex(@"^(([1-9]\d*00)|0)$");
            Match m = regExpression.Match(temp);
            if (m.Success)
            {
                CusMoney += Convert.ToDouble(temp);
                string datatime = DateTime.Now.ToString();
                Console.WriteLine("�û�" + CusName + "���Ѿ���" + datatime + "�ɹ����룤" + temp);
                Console.WriteLine("��Ǯ���ʻ�����ϢΪ��");
                CardInfomation("******");
            }
            else
            {
                Console.WriteLine("�������벻�Ϸ���û�д�������˻�");
            }

        }
        private void Infomation(string p) //���������Ϣ
        {
            throw new Exception("The method or operation is not implemented.");
        }
        
        public class Test         //�����࣬��Ҫ��������        
        {
            public static void Main(string[] args)
            {
                
                while (true)
                {
                    Cai_Dan(); Console.ReadLine();
                 }
                
            }
            public static void Cai_Dan()           //���ò˵����ø�����
            {
                Console.WriteLine(" \t\t��ӭʹ��������������!");
                Console.WriteLine("***Self-service bank serve in 24 hours***");
                User cus = null;
                while (true)
                {
                    Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");//�����޸�����
                    Console.WriteLine("@@��ͨ��  1����  2��Ǯ   3ȡǮ  4 ��ѯ���  5 �޸����� 6 ת�� 7���� 0�˳� @@@");
                    Console.WriteLine("@@���ÿ���1����  2��Ǯ   3ȡǮ  4 ��ѯ���  5 �޸����� 6 ת�� 7���� 0�˳� @@@");
                    Console.WriteLine("@@������  1����  2��Ǯ   3ȡǮ  4 ��ѯ���  5 �޸����� 6 ת�� 7���� 0�˳� @@@");
                    Console.WriteLine("@@�𿨣�  1����  2��Ǯ   3ȡǮ  4 ��ѯ���  5 �޸����� 6 ת�� 7���� 0�˳� @@@");
                    Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("������Ӧ�Ĳ����ţ�������Ӧ�Ĳ�����");
                    string index = Console.ReadLine();
                    switch (index)
                    {
                        case "0": break;
                        case "1":
                            if (cus == null)
                            {
                                cus = User.OpenUser(); //����ʹ��ʱ���½�һ���˻�

                            }
                            else
                            {
                                Console.WriteLine("���Ѿ��½���һ���û�");//�Ƿ��ٿ�һ���˻�

                            }
                            continue;
                        case "2":
                            if (cus == null)
                            {
                                Console.WriteLine("�Բ���,����ʹ��ʱ���½�һ���˻�");
                            }
                            else
                            {
                                cus.Add_Money();
                            }
                            continue;
                        case "3":
                            if (cus == null)
                            {
                                Console.WriteLine("�Բ���,����ʹ��ʱ���½�һ���˻�");
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
                                Console.WriteLine("�Բ���,����ʹ��ʱ���½�һ���˺�");
                            }
                            else
                            {
                                cus.CardInfomation("******");
                            }
                            continue;
                        case "5":                              //�޸�����,�Ѿ�ʵ�� 
                            if (cus == null)
                            {
                                Console.WriteLine("�Բ���,����ʹ��ʱ���½�һ���˺�");
                            }
                            else
                            {
                                cus.ChangePassWord();
                            }
                            continue;
                          //case "6":                        //ת��
                          //  if (cus == null) 
                          //   {
                          //      Console.WriteLine("�Բ���,����ʹ��ʱ���½�һ���˺�");
                          //    }
                          //   else
                          //  {
                          //    cus.TurnMoneyToAnotherAccout();
                          //    }
                          //continue;
                        case "7":
                            if (cus == null)
                            {
                                Console.WriteLine("�˻�û�п�����������");
                            }
                            else
                            {
                                Console.WriteLine("�Ѿ��ɹ�����");
                                cus = null;
                            }
                            continue;
                        default: Console.WriteLine("���벻�Ϸ�,����������!");
                            continue;

                    }
                    break;
                }
               
                Console.WriteLine("����������˳�");
            }

           
        }
    }
}