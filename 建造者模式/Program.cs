using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//auth:xuzeyu 
/*
 介绍
意图：将一个复杂的构建与其表示相分离，使得同样的构建过程可以创建不同的表示。
主要解决：主要解决在软件系统中，有时候面临着"一个复杂对象"的创建工作，其通常由各个部分的子对象用一定的算法构成；由于需求的变化，这个复杂对象的各个部分经常面临着剧烈的变化，但是将它们组合在一起的算法却相对稳定。
何时使用：一些基本部件不会变，而其组合经常变化的时候。
如何解决：将变与不变分离开。
关键代码：建造者：创建和提供实例，导演：管理建造出来的实例的依赖关系。
应用实例： 1、去肯德基，汉堡、可乐、薯条、炸鸡翅等是不变的，而其组合是经常变化的，生成出所谓的"套餐"。 2、JAVA 中的 stringBuilder。
优点： 1、建造者独立，易扩展。 2、便于控制细节风险。
缺点： 1、产品必须有共同点，范围有限制。 2、如内部变化复杂，会有很多的建造类。
使用场景： 1、需要生成的对象具有复杂的内部结构。 2、需要生成的对象内部属性本身相互依赖。
注意事项：与工厂模式的区别是：建造者模式更加关注与零件装配的顺序。
     */

namespace 建造者模式
{
    class Program
    {
        /// <summary>
        ///  步骤 7 BuiderPatternDemo 使用 MealBuider 来演示建造者模式（Builder Pattern）。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MealBuilder mealBuilder = new MealBuilder();

            Meal vegMeal = mealBuilder.PrepareVegMeal();
            Console.WriteLine("Veg Meal");
            vegMeal.ShowItems();
            Console.WriteLine("Total Cost: " + vegMeal.GetCost());

            Meal nonVegMeal = mealBuilder.PrepareNonVegMeal();
            Console.WriteLine("\n\nNon-Veg Meal");
            nonVegMeal.ShowItems();
            Console.WriteLine("Total Cost: " + nonVegMeal.GetCost());
            Console.ReadKey();
        }
    }

    /// <summary>
    /// 步骤 1  创建一个表示食物条目和食物包装的接口。
    /// </summary>
    public interface Item
    {
        string Name();
        Packing Packing();
        float Price();
    }

    public interface Packing
    {
        string Pack();
    }

    /// <summary>
    /// 步骤 2 创建实现 Packing 接口的实体类。
    /// </summary>
    public class Wrapper : Packing
    {
        public string Pack()
        {
            return "Wrapper";
        }
    }

    public class Bottle : Packing
    {
        public string Pack()
        {
            return "Bottle";
        }
    }

    /// <summary>
    /// 步骤 3 创建实现 Item 接口的抽象类，该类提供了默认的功能。
    /// </summary>
    public abstract class Burger : Item
    {
        public Packing Packing()
        {
            return new Wrapper();
        }

        public abstract float Price();

        public abstract string Name();
    }

    public abstract class ColdDrink : Item
    {
        public Packing Packing()
        {
            return new Bottle();
        }
        public abstract float Price();
        public abstract string Name();
    }

    /// <summary>
    /// 步骤 4  创建扩展了 Burger 和 ColdDrink 的实体类。
    /// </summary>
    public class VegBurger : Burger
    {   
        public override float Price()
        {
            return 25.0f;
        }

        public override string Name()
        {
            return "Veg Burger";
        }
    }

    public class ChickenBurger : Burger
    {
        public override float Price()
        {
            return 50.5f;
        }

        public override string Name()
        {
            return "Chicken Burger";
        }
    }

    public class Coke : ColdDrink
    {
        public override float Price()
        {
            return 30.0f;
        }

        public override string Name()
        {
            return "Coke";
        }
    }

    public class Pepsi : ColdDrink
    {
        public override float Price()
        {
            return 35.0f;
        }

        public override string Name()
        {
            return "Pepsi";
        }
    }

    /// <summary>
    /// 步骤 5  创建一个 Meal 类，带有上面定义的 Item 对象。
    /// </summary>
    public class Meal
    {
        private List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public float GetCost()
        {
            float cost = 0.0f;
            foreach (Item item in items)
            {
                cost += item.Price();
            }
            return cost;
        }

        public void ShowItems()
        {
            foreach (Item item in items)
            {
                Console.Write("Item : " + item.Name());
                Console.Write(", Packing : " + item.Packing().Pack());
                Console.Write(", Price : " + item.Price());
            }
        }
    }

    /// <summary>
    /// 步骤 6  创建一个 MealBuilder 类，实际的 builder 类负责创建 Meal 对象。
    /// </summary>
    public class MealBuilder
    {
        public Meal PrepareVegMeal()
        {
            Meal meal = new Meal();
            meal.AddItem(new VegBurger());
            meal.AddItem(new Coke());
            return meal;
        }

        public Meal PrepareNonVegMeal()
        {
            Meal meal = new Meal();
            meal.AddItem(new ChickenBurger());
            meal.AddItem(new Pepsi());
            return meal;
        }
    }

}
