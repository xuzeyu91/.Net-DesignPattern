using System;

namespace 策略模式
{
    //    步骤 1
    //创建一个接口。
    public interface Strategy
    {
        int doOperation(int num1, int num2);
    }

    //    步骤 2
    //创建实现接口的实体类。
    public class OperationAdd : Strategy
    {
        public int doOperation(int num1, int num2)
        {
            return num1 + num2;
        }
    }

    public class OperationSubstract : Strategy
    {
        public int doOperation(int num1, int num2)
        {
            return num1 - num2;
        }
    }

    public class OperationMultiply : Strategy
    {
        public int doOperation(int num1, int num2)
        {
            return num1 * num2;
        }
    }

    //    步骤 3
    //创建 Context 类。
    public class Context
    {
        private Strategy strategy;

        public Context(Strategy strategy)
        {
            this.strategy = strategy;
        }

        public int executeStrategy(int num1, int num2)
        {
            return strategy.doOperation(num1, num2);
        }
    }


    //    步骤 4
    //使用 Context 来查看当它改变策略 Strategy 时的行为变化。
    public class Program
    {
        private static void Main(string[] args)
        {
            Context context = new Context(new OperationAdd());
            Console.WriteLine("10 + 5 = " + context.executeStrategy(10, 5));

            context = new Context(new OperationSubstract());
            Console.WriteLine("10 - 5 = " + context.executeStrategy(10, 5));

            context = new Context(new OperationMultiply());
            Console.WriteLine("10 * 5 = " + context.executeStrategy(10, 5));

            Console.ReadKey();
        }
    }
}