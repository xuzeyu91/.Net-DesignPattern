using System;

namespace 空对象模式
{
    //步骤 1
    //创建一个抽象类。
    public abstract class AbstractCustomer
    {
        protected string name;

        public abstract bool isNil();

        public abstract string getName();
    }

    //    步骤 2
    //创建扩展了上述类的实体类。
    public class RealCustomer : AbstractCustomer
    {
        public RealCustomer(string name)
        {
            this.name = name;
        }

        public override string getName()
        {
            return name;
        }

        public override bool isNil()
        {
            return false;
        }
    }

    public class NullCustomer : AbstractCustomer
    {
        public override string getName()
        {
            return "Not Available in Customer Database";
        }

        public override bool isNil()
        {
            return true;
        }
    }

    //    步骤 3
    //创建 CustomerFactory 类。
    public class CustomerFactory
    {
        public static string[] names = { "Rob", "Joe", "Julie" };

        public static AbstractCustomer getCustomer(string name)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].Equals(name))
                {
                    return new RealCustomer(name);
                }
            }
            return new NullCustomer();
        }
    }

//    步骤 4
//使用 CustomerFactory，基于客户传递的名字，来获取 RealCustomer 或 NullCustomer 对象。
    public class Program
    {
        private static void Main(string[] args)
        {
            AbstractCustomer customer1 = CustomerFactory.getCustomer("Rob");
            AbstractCustomer customer2 = CustomerFactory.getCustomer("Bob");
            AbstractCustomer customer3 = CustomerFactory.getCustomer("Julie");
            AbstractCustomer customer4 = CustomerFactory.getCustomer("Laura");

            Console.WriteLine("Customers");
            Console.WriteLine(customer1.getName());
            Console.WriteLine(customer2.getName());
            Console.WriteLine(customer3.getName());
            Console.WriteLine(customer4.getName());
            Console.ReadKey();
        }
    }
}