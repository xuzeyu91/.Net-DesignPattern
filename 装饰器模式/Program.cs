using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//auth:xuzeyu
/*
介绍
意图：动态地给一个对象添加一些额外的职责。就增加功能来说，装饰器模式相比生成子类更为灵活。
主要解决：一般的，我们为了扩展一个类经常使用继承方式实现，由于继承为类引入静态特征，并且随着扩展功能的增多，子类会很膨胀。
何时使用：在不想增加很多子类的情况下扩展类。
如何解决：将具体功能职责划分，同时继承装饰者模式。
关键代码： 1、Component 类充当抽象角色，不应该具体实现。 2、修饰类引用和继承 Component 类，具体扩展类重写父类方法。
应用实例： 1、孙悟空有 72 变，当他变成"庙宇"后，他的根本还是一只猴子，但是他又有了庙宇的功能。 2、不论一幅画有没有画框都可以挂在墙上，但是通常都是有画框的，并且实际上是画框被挂在墙上。在挂在墙上之前，画可以被蒙上玻璃，装到框子里；这时画、玻璃和画框形成了一个物体。
优点：装饰类和被装饰类可以独立发展，不会相互耦合，装饰模式是继承的一个替代模式，装饰模式可以动态扩展一个实现类的功能。
缺点：多层装饰比较复杂。
使用场景： 1、扩展一个类的功能。 2、动态增加功能，动态撤销。
注意事项：可代替继承。
     */
namespace 装饰器模式
{
    class Program
    {
        /// <summary>
        /// 步骤 5 使用 RedShapeDecorator 来装饰 Shape 对象。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Shape circle = new Circle();

            Shape redCircle = new RedShapeDecorator(new Circle());

            Shape redRectangle = new RedShapeDecorator(new Rectangle());
            Console.WriteLine("Circle with normal border");
            circle.Draw();

            Console.WriteLine("\nCircle of red border");
            redCircle.Draw();

            Console.WriteLine("\nRectangle of red border");
            redRectangle.Draw();

            Console.ReadKey();
        }
    }

    /// <summary>
    /// 步骤 1 创建一个接口。
    /// </summary>
    public abstract class Shape
    {
         public abstract void Draw();
    }

    /// <summary>
    /// 步骤 2 创建实现接口的实体类。
    /// </summary>
    public class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Shape: Rectangle");
        }
    }

    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Shape: Circle");
        }
    }

    /// <summary>
    /// 步骤 3 创建实现了 Shape 接口的抽象装饰类。
    /// </summary>
    public abstract class ShapeDecorator : Shape
    {
        protected Shape decoratedShape;

        public ShapeDecorator(Shape decoratedShape)
        {
            this.decoratedShape = decoratedShape;
        }

        public override void Draw()
        {
            decoratedShape.Draw();
        }
    }

    /// <summary>
    /// 步骤 4 创建扩展了 ShapeDecorator 类的实体装饰类。
    /// </summary>
    public class RedShapeDecorator : ShapeDecorator
    {
        public RedShapeDecorator(Shape decoratedShape):base(decoratedShape)
        {
        }

        public override void Draw()
        {
            decoratedShape.Draw();
            setRedBorder(decoratedShape);
        }

        private void setRedBorder(Shape decoratedShape)
        {
            Console.WriteLine("Border Color: Red");
        }
    }


}
