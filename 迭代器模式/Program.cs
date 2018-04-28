using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//auth:xuzeyu
/*
 介绍
意图：提供一种方法顺序访问一个聚合对象中各个元素, 而又无须暴露该对象的内部表示。
主要解决：不同的方式来遍历整个整合对象。
何时使用：遍历一个聚合对象。
如何解决：把在元素之间游走的责任交给迭代器，而不是聚合对象。
关键代码：定义接口：hasNext, next。
应用实例：JAVA 中的 iterator。
优点： 1、它支持以不同的方式遍历一个聚合对象。 2、迭代器简化了聚合类。 3、在同一个聚合上可以有多个遍历。 4、在迭代器模式中，增加新的聚合类和迭代器类都很方便，无须修改原有代码。
缺点：由于迭代器模式将存储数据和遍历数据的职责分离，增加新的聚合类需要对应增加新的迭代器类，类的个数成对增加，这在一定程度上增加了系统的复杂性。
使用场景： 1、访问一个聚合对象的内容而无须暴露它的内部表示。 2、需要为聚合对象提供多种遍历方式。 3、为遍历不同的聚合结构提供一个统一的接口。
注意事项：迭代器模式就是分离了集合对象的遍历行为，抽象出一个迭代器类来负责，这样既可以做到不暴露集合的内部结构，又可让外部代码透明地访问集合内部的数据。
     */
namespace 迭代器模式
{
    class Program
    {
        /// <summary>
        /// 步骤 3 使用 NameRepository 来获取迭代器，并打印名字。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            NameRepository namesRepository = new NameRepository();

            for (Iterator iter = namesRepository.GetIterator(); iter.HasNext();)
            {
                string name = (string)iter.Next();
                Console.WriteLine("Name : " + name);
            }
            Console.ReadKey();
        }
    }

    /// <summary>
    /// 步骤 1 创建接口。
    /// </summary>
    public interface Iterator
    {
        bool HasNext();
        object Next();
    }

    public interface Container
    {
        Iterator GetIterator();
    }

    /// <summary>
    /// 步骤 2 创建实现了 Container 接口的实体类。该类有实现了 Iterator 接口的内部类 NameIterator。
    /// </summary>
    public class NameRepository : Container
    {
        public static string[] names = { "Robert", "John", "Julie", "Lora" };

        public Iterator GetIterator()
        {
            return new NameIterator();
        }

        private class NameIterator : Iterator
        {
            int index;

            public bool HasNext()
            {
                if (index < names.Length)
                {
                    return true;
                }
                return false;
            }
            public object Next()
            {
                if (this.HasNext())
                {
                    return names[index++];
                }
                return null;
            }
        }
    }
}
