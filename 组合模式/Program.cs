using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//auth :xuzeyu
/*
 介绍
意图：将对象组合成树形结构以表示"部分-整体"的层次结构。组合模式使得用户对单个对象和组合对象的使用具有一致性。
主要解决：它在我们树型结构的问题中，模糊了简单元素和复杂元素的概念，客户程序可以向处理简单元素一样来处理复杂元素，从而使得客户程序与复杂元素的内部结构解耦。
何时使用： 1、您想表示对象的部分-整体层次结构（树形结构）。 2、您希望用户忽略组合对象与单个对象的不同，用户将统一地使用组合结构中的所有对象。
如何解决：树枝和叶子实现统一接口，树枝内部组合该接口。
关键代码：树枝内部组合该接口，并且含有内部属性 List，里面放 Component。
应用实例： 1、算术表达式包括操作数、操作符和另一个操作数，其中，另一个操作符也可以是操作树、操作符和另一个操作数。 2、在 JAVA AWT 和 SWING 中，对于 Button 和 Checkbox 是树叶，Container 是树枝。
优点： 1、高层模块调用简单。 2、节点自由增加。
缺点：在使用组合模式时，其叶子和树枝的声明都是实现类，而不是接口，违反了依赖倒置原则。
使用场景：部分、整体场景，如树形菜单，文件、文件夹的管理。
注意事项：定义时为具体类。
     */

namespace 组合模式
{
    class Program
    {
        /// <summary>
        /// 步骤 2 使用 Employee 类来创建和打印员工的层次结构。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Employee CEO = new Employee("John", "CEO", 30000);

            Employee headSales = new Employee("Robert", "Head Sales", 20000);

            Employee headMarketing = new Employee("Michel", "Head Marketing", 20000);

            Employee clerk1 = new Employee("Laura", "Marketing", 10000);
            Employee clerk2 = new Employee("Bob", "Marketing", 10000);

            Employee salesExecutive1 = new Employee("Richard", "Sales", 10000);
            Employee salesExecutive2 = new Employee("Rob", "Sales", 10000);

            CEO.Add(headSales);
            CEO.Add(headMarketing);

            headSales.Add(salesExecutive1);
            headSales.Add(salesExecutive2);

            headMarketing.Add(clerk1);
            headMarketing.Add(clerk2);

            //打印该组织的所有员工
            Console.WriteLine(CEO.ToString());
            foreach (Employee headEmployee in CEO.GetSubordinates())
            {
                Console.WriteLine(headEmployee.ToString());
                foreach (Employee employee in headEmployee.GetSubordinates())
                {
                    Console.WriteLine(employee.ToString());
                }
            }

            Console.ReadKey();
        }
    }

    /// <summary>
    /// 步骤 1 创建 Employee 类，该类带有 Employee 对象的列表。
    /// </summary>
    public class Employee
    {
        private string name;
        private string dept;
        private int salary;
        private List<Employee> subordinates;

        //构造函数
        public Employee(string name, string dept, int sal)
        {
            this.name = name;
            this.dept = dept;
            this.salary = sal;
            subordinates = new List<Employee>();
        }

        public void Add(Employee e)
        {
            subordinates.Add(e);
        }

        public void Remove(Employee e)
        {
            subordinates.Remove(e);
        }

        public List<Employee> GetSubordinates()
        {
            return subordinates;
        }

        public new string ToString()
        {
            return ("Employee :[ Name : " + name
            + ", dept : " + dept + ", salary :"
            + salary + " ]");
        }
    }
}
