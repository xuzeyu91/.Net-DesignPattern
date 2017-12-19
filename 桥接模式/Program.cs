using System;

//xuzeyu
/*
 介绍
意图：将抽象部分与实现部分分离，使它们都可以独立的变化。
主要解决：在有多种可能会变化的情况下，用继承会造成类爆炸问题，扩展起来不灵活。
何时使用：实现系统可能有多个角度分类，每一种角度都可能变化。
如何解决：把这种多角度分类分离出来，让它们独立变化，减少它们之间耦合。
关键代码：抽象类依赖实现类。
应用实例： 1、猪八戒从天蓬元帅转世投胎到猪，转世投胎的机制将尘世划分为两个等级，即：灵魂和肉体，前者相当于抽象化，后者相当于实现化。生灵通过功能的委派，调用肉体对象的功能，使得生灵可以动态地选择。 2、墙上的开关，可以看到的开关是抽象的，不用管里面具体怎么实现的。
优点： 1、抽象和实现的分离。 2、优秀的扩展能力。 3、实现细节对客户透明。
缺点：桥接模式的引入会增加系统的理解与设计难度，由于聚合关联关系建立在抽象层，要求开发者针对抽象进行设计与编程。
使用场景： 1、如果一个系统需要在构件的抽象化角色和具体化角色之间增加更多的灵活性，避免在两个层次之间建立静态的继承联系，通过桥接模式可以使它们在抽象层建立一个关联关系。 2、对于那些不希望使用继承或因为多层次继承导致系统类的个数急剧增加的系统，桥接模式尤为适用。 3、一个类存在两个独立变化的维度，且这两个维度都需要进行扩展。
注意事项：对于两个独立变化的维度，使用桥接模式再适合不过了。
     */

namespace 桥接模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape redCircle = new Circle(100, 100, 10, new RedCircle());
            Shape greenCircle = new Circle(100, 100, 10, new GreenCircle());

            redCircle.Draw();
            greenCircle.Draw();

            Console.ReadKey();
        }

        /// <summary>
        /// 步骤 1 创建桥接实现接口。
        /// </summary>
        public interface DrawAPI
        {
            void DrawCircle(int radius, int x, int y);
        }

        /// <summary>
        /// 步骤 2  创建实现了 DrawAPI 接口的实体桥接实现类。
        /// </summary>
        public class RedCircle : DrawAPI
        {
            public void DrawCircle(int radius, int x, int y)
            {
                Console.WriteLine("Drawing Circle[ color: red, radius: " + radius + ", x: " + x + ", " + y + "]");
            }
        }
      
        public class GreenCircle : DrawAPI
        {
            public void DrawCircle(int radius, int x, int y)
            {
                Console.WriteLine("Drawing Circle[ color: green, radius: " + radius + ", x: " + x + ", " + y + "]");
            }
        }

        /// <summary>
        /// 步骤 3 使用 DrawAPI 接口创建抽象类 Shape。
        /// </summary>
        public abstract class Shape
        {
            protected DrawAPI drawAPI;
            public Shape(DrawAPI drawAPI)
            {
                this.drawAPI = drawAPI;
            }
            public abstract void Draw();
        }

        /// <summary>
        /// 步骤 4 创建实现了 Shape 接口的实体类。
        /// </summary>
        public class Circle : Shape
        {
            private int x, y, radius;

            public Circle(int x, int y, int radius, DrawAPI drawAPI) : base(drawAPI)
            {
                this.x = x;
                this.y = y;
                this.radius = radius;
            }

            public override void Draw()
            {
                drawAPI.DrawCircle(radius, x, y);
            }
        }

    }
}

