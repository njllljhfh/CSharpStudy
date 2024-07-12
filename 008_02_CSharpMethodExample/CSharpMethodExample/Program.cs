using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMethodExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator c = new Calculator();
            Console.WriteLine(c.GetCircleArea(10));
        }
    }

    class Calculator
    {
        public double GetCircleArea(double r)
        {
            //计算圆面积
            return Math.PI * r * r; 
        }

        // 方法复用
        public double GetCylinderVolume(double r, double h)
        {
            //计算圆柱体积
            return GetCircleArea(r) * h;
        }

        // 方法复用
        public double GetConeVolume0(double r, double h)
        {
            //计算圆锥体积
            return GetCylinderVolume(r,h) / 3;
        }

        ////方法不复用的情况
        //public double GetCylinderVolume0(double r,double h)
        //{
        //    //计算圆柱体积
        //    return 3.14 * r * r * h;
        //}

        ////方法不复用的情况
        //public double GetConeVolume0(double r, double h)
        //{
        //    //计算圆锥体积
        //    return 3.14 * r * r * h / 3;
        //}
    }
}
