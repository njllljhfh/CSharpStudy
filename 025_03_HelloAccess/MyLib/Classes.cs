using System;

namespace MyLib
{

    /*
    类成员的访问级别是以类的访问级别为上线的。
    internal 级别的 Vehicle2 类在这个 程序集外是无法访问的，那么即便 Owner 是 public 的，程序集外部也无法访问。
    */
    internal class Vehicle2
    {
        public string Owner { get; set; }
    }

    public class Vehicle
    {
        // public 修饰符，谁都可以访问
        public string Owner { get; set; }

        // internal 修饰符，在本程序集中可以访问。外部无法访问（将成员限制在本程序集内）。
        internal string Owner2 { get; set; }

        // private 修饰符，只能在本类中访问，子类也无法访问（将成员限制在本类的类体内）
        // 如果成员前面没有修饰符，默认访问级别是 private
        private string Owner3 { get; set; }

        protected int _rpm;  // 发动机转速
        private int _fuel;
        public void Refuel()
        {
            _fuel += 100;
        }

        // 对于 Burn 这个方法，是不应该public出来给外部调用的
        // protected 修饰符，类外部无法访问。只能在本类以及子类中访问（将成员限制在继承链上），子类可以跨程序集访问父类的 protected 成员。
        // protected 更多用在 方法上
        // protected 和 internal 可以组合使用，组合使用时是 或 的关系（既可以被子类访问，也可以被程序集中的所有其他类访问）
        // 现在的新版本，还有其他的 访问级别组合~~~ 自行学习！！！
        protected void Burn(int fuel)  // 烧油
        {
            _fuel -= fuel;
        }

        public void Accelerate()  // 普通加速
        {
            Burn(1);
            _rpm += 1000;
        }

        public int Speed { get { return _rpm / 100; } }  // 只读属性
    }

    public class Car : Vehicle
    {
        public void ShowOwner()
        {
            Console.WriteLine(this.Owner2);

            // 子类无法访问 private 修饰的父类的属性
            //Console.WriteLine(this.Owner3); 
        }

        public void TurboAccelerate()  // 涡轮增压加速
        {
            Burn(2);
            Burn(2);
            _rpm += 3000;
        }
    }
}
