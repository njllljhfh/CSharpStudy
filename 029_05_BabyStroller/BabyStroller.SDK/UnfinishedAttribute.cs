using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyStroller.SDK
{
    // 用于标记未完成的类
    // 用 [Unfinished] 标记 第三方插件中的未完成的类（标记时，后缀 Attribute 可以不用写）。
    // Attribute: 反射时，用于识别这个类是否有某个 Attribute 标记，从而判断后续要执行的逻辑
    public class UnfinishedAttribute : Attribute  // 要继承 Attribute 类
    {
    }
}
