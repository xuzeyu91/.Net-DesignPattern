using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 访问者模式
{
    //访问者模式
    //在访问者模式（Visitor Pattern）中，我们使用了一个访问者类，它改变了元素类的执行算法。通过这种方式，
    //元素的执行算法可以随着访问者改变而改变。这种类型的设计模式属于行为型模式。根据模式，元素对象已接受访问者对象，
    //这样访问者对象就可以处理元素对象上的操作。

    /// <summary>
    /// 步骤 1
    ///定义一个表示元素的接口。
    /// </summary>
    public interface ComputerPart
    {
        void Accept(ComputerPartVisitor computerPartVisitor);
    }

    /// <summary>
    /// 步骤 2
    ///创建扩展了上述类的实体类。
    /// </summary>
    public class Keyboard  : ComputerPart
    {
        void ComputerPart.Accept(ComputerPartVisitor computerPartVisitor)
        {
            computerPartVisitor.visit(this);
        }
    }

    public class Monitor : ComputerPart
    {
        void ComputerPart.Accept(ComputerPartVisitor computerPartVisitor)
        {
            computerPartVisitor.visit(this);
        }
    }

    public class Mouse  : ComputerPart
    {
        void ComputerPart.Accept(ComputerPartVisitor computerPartVisitor)
        {
            computerPartVisitor.visit(this);
        }
    }

    public class Computer : ComputerPart
    {
        ComputerPart[]
        parts;
        public Computer()
        {
            parts = new ComputerPart[] { new Mouse(), new Keyboard(), new Monitor() };
        }
        public void Accept(ComputerPartVisitor computerPartVisitor)
        {
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i].Accept(computerPartVisitor);
            }
            computerPartVisitor.visit(this);
        }
    }

    /// <summary>
    /// 步骤 3
    /// 定义一个表示访问者的接口。
    /// </summary>
    public interface ComputerPartVisitor
    {
        void visit(Mouse mouse);
        void visit(Keyboard keyboard);
        void visit(Monitor monitor);
        void visit(Computer computer);
    }

    /// <summary>
    /// 步骤 4
    ///创建实现了上述类的实体访问者。
    /// </summary>
    public class ComputerPartDisplayVisitor : ComputerPartVisitor
    {
        public void visit(Mouse mouse)
        {
            Console.WriteLine("Displaying Computer.");
        }

        public void visit(Keyboard keyboard)
        {
            Console.WriteLine("Displaying Mouse.");
        }

        public void visit(Monitor monitor)
        {
            Console.WriteLine("Displaying Keyboard.");
        }

        public void visit(Computer computer)
        {
            Console.WriteLine("Displaying Monitor.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ComputerPart computer = new Computer();
            computer.Accept(new ComputerPartDisplayVisitor());
            Console.ReadKey();
        }
    }
}
