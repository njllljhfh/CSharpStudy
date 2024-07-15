using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
文件夹名字 MyNamespace，是一个命名空间
*/

namespace MyLib.MyNamespace
{
    // class没有修饰符，默认是 internal
    // 当命名空间内没有任何东西 暴露给外面，那这个命名空间在外部也看不到（在外部项目中，敲代码时候，没有提示）

    // public: 类访问级别修饰符，外部项目可以调用
    public class Calculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }
    }

    //class Calculator2 和 internal class Calculator2 一样
    //    - internal：类访问级别修饰符，在本项目中，可以自由访问。 当前这个项目 编译完 就是一个 Assembly(程序集/装配集)
    internal class Calculator2
    {
        public double Add(double a, double b)
        {
            return a + b;
        }
    }
}
