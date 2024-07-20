using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;

// 要测试，先要在测试项目中的依赖项中，引入被测试的项目
// 这里用的测试项目是: 单元测试项目（.NET Framework）,视频中用的项目无法正常测试（应该是新版本vs改了？）。
// 用 NuGet，搜索 Moq，安装 Moq
namespace InterfaceExample4.Tests
{
    [TestClass]
    public class PowerLowerThanZero_OK
    {
        [TestMethod]
        public void PowerSupplyLowerThanZero()
        {
            var fan = new DeskFan(new PowerSupplyLowerThanZero());
            var expected = "Won't work.";
            var actual = fan.Work();
            Assert.AreEqual(expected, actual);
            //------------------------------------

            // 使用 Moq：可以不用再单元测试中自己写那些子类（如，PowerSupplyLowerThanZero）
            var mock = new Mock<IPowerSupply>();
            mock.Setup((ps) => ps.GetPower()).Returns(() => 0);  // 这种写法暂时还不懂！！！
            var fan2 = new DeskFan(mock.Object);
            var expected2 = "Won't work.";
            var actual2 = fan2.Work();
            Assert.AreEqual(expected2, actual2);
        }

        [TestMethod]
        public void PowerHigerThan200_Warning()
        {
            var fan = new DeskFan(new PowerSupplyHigherThan200());
            var expected = "Warning!";
            var actual = fan.Work();
            Assert.AreEqual(expected, actual);
            //------------------------------------

            // 使用 Moq 
            var mock = new Mock<IPowerSupply>();
            mock.Setup(ps => ps.GetPower()).Returns(() => 200);
            var fan2 = new DeskFan(mock.Object);
            var expected2 = "Warning!";
            var actual2 = fan2.Work();
            Assert.AreEqual(expected2, actual2);
        }
    }

    class PowerSupplyLowerThanZero : IPowerSupply
    {
        public int GetPower()
        {
            return 0;
        }
    }

    class PowerSupplyHigherThan200 : IPowerSupply
    {
        public int GetPower()
        {
            return 220;
        }
    }
}
