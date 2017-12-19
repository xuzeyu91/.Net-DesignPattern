using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

//auth:xuzeyu 
/*
 介绍
意图：用原型实例指定创建对象的种类，并且通过拷贝这些原型创建新的对象。
主要解决：在运行期建立和删除原型。
何时使用： 1、当一个系统应该独立于它的产品创建，构成和表示时。 2、当要实例化的类是在运行时刻指定时，例如，通过动态装载。 3、为了避免创建一个与产品类层次平行的工厂类层次时。 4、当一个类的实例只能有几个不同状态组合中的一种时。建立相应数目的原型并克隆它们可能比每次用合适的状态手工实例化该类更方便一些。
如何解决：利用已有的一个原型对象，快速地生成和原型对象一样的实例。
关键代码： 1、实现克隆操作，在 JAVA 继承 Cloneable，重写 clone()，在 .NET 中可以使用 Object 类的 MemberwiseClone() 方法来实现对象的浅拷贝或通过序列化的方式来实现深拷贝。 2、原型模式同样用于隔离类对象的使用者和具体类型（易变类）之间的耦合关系，它同样要求这些"易变类"拥有稳定的接口。
应用实例： 1、细胞分裂。 2、JAVA 中的 Object clone() 方法。
优点： 1、性能提高。 2、逃避构造函数的约束。
缺点： 1、配备克隆方法需要对类的功能进行通盘考虑，这对于全新的类不是很难，但对于已有的类不一定很容易，特别当一个类引用不支持串行化的间接对象，或者引用含有循环结构的时候。 2、必须实现 Cloneable 接口。 3、逃避构造函数的约束。
使用场景： 1、资源优化场景。 2、类初始化需要消化非常多的资源，这个资源包括数据、硬件资源等。 3、性能和安全要求的场景。 4、通过 new 产生一个对象需要非常繁琐的数据准备或访问权限，则可以使用原型模式。 5、一个对象多个修改者的场景。 6、一个对象需要提供给其他对象访问，而且各个调用者可能都需要修改其值时，可以考虑使用原型模式拷贝多个对象供调用者使用。 7、在实际项目中，原型模式很少单独出现，一般是和工厂方法模式一起出现，通过 clone 的方法创建一个对象，然后由工厂方法提供给调用者。原型模式已经与 Java 融为浑然一体，大家可以随手拿来使用。
注意事项：与通过对一个类进行实例化来构造新对象不同的是，原型模式是通过拷贝一个现有对象生成新对象的。浅拷贝实现 Cloneable，重写，深拷贝是通过实现 Serializable 读取二进制流。
     */
namespace 原型模式
{
    class Program
    {
        static void Main(string[] args)
        {
            ShapeCache.LoadCache();

            Shape clonedShape = (Shape)ShapeCache.GetShape("1");
            Console.WriteLine("Shape : " + clonedShape.Type);

            Shape clonedShape2 = (Shape)ShapeCache.GetShape("2");
            Console.WriteLine("Shape : " + clonedShape2.Type);

            Shape clonedShape3 = (Shape)ShapeCache.GetShape("3");
            Console.WriteLine("Shape : " + clonedShape3.Type);

            Console.ReadKey();
        }
    }

    /// <summary>
    /// 步骤 1 创建一个实现了 Clonable 接口的抽象类。
    /// </summary>
    public abstract class Shape : ICloneable
    {
        private string id;
        private string type;

        public string Id { get => id; set => id = value; }
        public string Type { get => type; set => type = value; }

        public abstract void Draw();

        public object Clone()
        {
            Object clone = null;
            try
            {
                clone = this.MemberwiseClone();
            }
            catch (Exception e)
            {

            }
            return clone;
        }
    }

    /// <summary>
    /// 步骤 2 创建扩展了上面抽象类的实体类。
    /// </summary>
    public class Rectangle : Shape
    {
        public Rectangle()
        {
            Type = "Rectangle";
        }

        public override void Draw()
        {
            Console.WriteLine("Inside Rectangle::draw() method.");
        }
    }

    public class Square : Shape
    {
        public Square()
        {
            Type = "Square";
        }
        public override void Draw()
        {
            Console.WriteLine("Inside Square::draw() method.");
        }
    }

    public class Circle : Shape
    {
        public Circle()
        {
            Type = "Circle";
        }
        public override void Draw()
        {
            Console.WriteLine("Inside Circle::draw() method.");
        }
    }

    /// <summary>
    /// 步骤 3 创建一个类，从数据库获取实体类，并把它们存储在一个 Hashtable 中。
    /// </summary>
    public class ShapeCache
    {

        private static Hashtable shapeMap = new Hashtable();

        public static Shape GetShape(string shapeId)
        {
            Shape cachedShape = shapeMap[shapeId] as Shape;
            return (Shape)cachedShape.Clone();
        }

        // 对每种形状都运行数据库查询，并创建该形状
        // shapeMap.put(shapeKey, shape);
        // 例如，我们要添加三种形状
        public static void LoadCache()
        {
            Circle circle = new Circle();
            circle.Id="1";
            shapeMap.Add(circle.Id, circle);

            Square square = new Square();
            square.Id="2";
            shapeMap.Add(square.Id, square);

            Rectangle rectangle = new Rectangle();
            rectangle.Id="3";
            shapeMap.Add(rectangle.Id, rectangle);
        }
    }
}
