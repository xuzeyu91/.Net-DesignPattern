using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//auth:xuzeyu 
/*
 介绍
意图：提供一个创建一系列相关或相互依赖对象的接口，而无需指定它们具体的类。
主要解决：主要解决接口选择的问题。
何时使用：系统的产品有多于一个的产品族，而系统只消费其中某一族的产品。
如何解决：在一个产品族里面，定义多个产品。
关键代码：在一个工厂里聚合多个同类产品。
应用实例：工作了，为了参加一些聚会，肯定有两套或多套衣服吧，比如说有商务装（成套，一系列具体产品）、时尚装（成套，一系列具体产品），甚至对于一个家庭来说，可能有商务女装、商务男装、时尚女装、时尚男装，这些也都是成套的，即一系列具体产品。假设一种情况（现实中是不存在的，要不然，没法进入共产主义了，但有利于说明抽象工厂模式），在您的家中，某一个衣柜（具体工厂）只能存放某一种这样的衣服（成套，一系列具体产品），每次拿这种成套的衣服时也自然要从这个衣柜中取出了。用 OO 的思想去理解，所有的衣柜（具体工厂）都是衣柜类的（抽象工厂）某一个，而每一件成套的衣服又包括具体的上衣（某一具体产品），裤子（某一具体产品），这些具体的上衣其实也都是上衣（抽象产品），具体的裤子也都是裤子（另一个抽象产品）。
优点：当一个产品族中的多个对象被设计成一起工作时，它能保证客户端始终只使用同一个产品族中的对象。
缺点：产品族扩展非常困难，要增加一个系列的某一产品，既要在抽象的 Creator 里加代码，又要在具体的里面加代码。
使用场景： 1、QQ 换皮肤，一整套一起换。 2、生成不同操作系统的程序。
注意事项：产品族难扩展，产品等级易扩展。
     */

namespace 抽象工厂模式
{
    class Program
    {
        static void Main(string[] args)
        {
            //获取形状工厂
            AbstractFactory shapeFactory = FactoryProducer.getFactory("SHAPE");

            //获取形状为 Circle 的对象
            Shape shape1 = shapeFactory.getShape("CIRCLE");

            //调用 Circle 的 draw 方法
            shape1.Draw();

            //获取形状为 Rectangle 的对象
            Shape shape2 = shapeFactory.getShape("RECTANGLE");

            //调用 Rectangle 的 draw 方法
            shape2.Draw();

            //获取形状为 Square 的对象
            Shape shape3 = shapeFactory.getShape("SQUARE");

            //调用 Square 的 draw 方法
            shape3.Draw();

            //获取颜色工厂
            AbstractFactory colorFactory = FactoryProducer.getFactory("COLOR");

            //获取颜色为 Red 的对象
            Color color1 = colorFactory.getColor("RED");

            //调用 Red 的 fill 方法
            color1.Fill();

            //获取颜色为 Green 的对象
            Color color2 = colorFactory.getColor("GREEN");

            //调用 Green 的 fill 方法
            color2.Fill();

            //获取颜色为 Blue 的对象
            Color color3 = colorFactory.getColor("BLUE");

            //调用 Blue 的 fill 方法
            color3.Fill();

            Console.ReadKey();
        }
    }

    /// <summary>
    /// 步骤 1 为形状创建一个接口。
    /// </summary>
    public interface Shape
    {
        void Draw();
    }
    /// <summary>
    /// 步骤 2 创建实现接口的实体类。三种不同的实现方式
    /// </summary>
    public class Rectangle : Shape
    {
        void Shape.Draw()
        {
            Console.WriteLine("Inside Rectangle::draw() method.");
        }
    }
    public class Square : Shape
    {
        void Shape.Draw()
        {
            Console.WriteLine("Inside Square::draw() method.");
        }
    }
    public class Circle : Shape
    {
        void Shape.Draw()
        {
            Console.WriteLine("Inside Circle::draw() method.");
        }
    }


    /// <summary>
    /// 步骤 3 为颜色创建一个接口
    /// </summary>
    public interface Color
    {
        void Fill();
    }
    /// <summary>
    /// 步骤4 创建实现接口的实体类。
    /// </summary>
    public class Red : Color
    {
        void Color.Fill()
        {
            Console.WriteLine("Inside Red::fill() method.");
        }
    }
    public class Green : Color
    {
        void Color.Fill()
        {
            Console.WriteLine("Inside Green::fill() method.");
        }
    }
    public class Blue : Color
    {
        void Color.Fill()
        {
            Console.WriteLine("Inside Blue::fill() method.");
        }
    }

    /// <summary>
    /// 步骤 5 为 Color 和 Shape 对象创建抽象类来获取工厂。
    /// </summary>
    public abstract class AbstractFactory
    {
        public abstract Color getColor(String color);
        public abstract Shape getShape(String shape);
    }

    /// <summary>
    /// 步骤 6  创建扩展了 AbstractFactory 的工厂类，基于给定的信息生成实体类的对象。
    /// </summary>
    public class ShapeFactory : AbstractFactory
    {
        public override Shape getShape(String shapeType)
        {
            if (shapeType == null)
            {
                return null;
            }
            if (shapeType.SequenceEqual("CIRCLE"))
            {
                return new Circle();
            }
            else if (shapeType.SequenceEqual("RECTANGLE"))
            {
                return new Rectangle();
            }
            else if (shapeType.SequenceEqual("SQUARE"))
            {
                return new Square();
            }
            return null;
        }


        public override Color getColor(String color)
        {
            return null;
        }
    }

    public class ColorFactory : AbstractFactory
    {
        public override Shape getShape(String shapeType)
        {
            return null;
        }
   
        public override Color getColor(String color)
        {
            if (color == null)
            {
                return null;
            }
            if (color.SequenceEqual("RED"))
            {
                return new Red();
            }
            else if (color.SequenceEqual("GREEN"))
            {
                return new Green();
            }
            else if (color.SequenceEqual("BLUE"))
            {
                return new Blue();
            }
            return null;
        }
    }

    /// <summary>
    /// 步骤 7  创建一个工厂创造器/生成器类，通过传递形状或颜色信息来获取工厂。
    /// </summary>
    public class FactoryProducer
    {
        public static AbstractFactory getFactory(String choice)
        {
            if (choice.SequenceEqual("SHAPE"))
            {
                return new ShapeFactory();
            }
            else if (choice.SequenceEqual("COLOR"))
            {
                return new ColorFactory();
            }
            return null;
        }
    }
}
