using System;

namespace 状态模式
{
    //    步骤 1
    //创建一个接口。
    public interface State
    {
        void doAction(Context context);
    }

    //    步骤 2
    //创建实现接口的实体类。
    public class StartState : State
    {
        public void doAction(Context context)
        {
            Console.WriteLine("Player is in start state");
            context.setState(this);
        }

        public override string ToString()
        {
            return "Start State";
        }
    }

    public class StopState : State
    {
        public void doAction(Context context)
        {
            Console.WriteLine("Player is in stop state");
            context.setState(this);
        }

        public override string ToString()
        {
            return "Stop State";
        }
    }

    //    步骤 3
    //创建 Context 类。
    public class Context
    {
        private State state;

        public Context()
        {
            state = null;
        }

        public void setState(State state)
        {
            this.state = state;
        }

        public State getState()
        {
            return state;
        }
    }

    //    步骤 4
    //使用 Context 来查看当状态 State 改变时的行为变化。
    public class Program
    {
        private static void Main(string[] args)
        {
            Context context = new Context();

            StartState startState = new StartState();
            startState.doAction(context);
            Console.WriteLine(context.getState().ToString());

            StopState stopState = new StopState();
            stopState.doAction(context);

            Console.WriteLine(context.getState().ToString());
            Console.ReadKey();
        }
    }
}