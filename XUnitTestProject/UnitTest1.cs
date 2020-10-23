using System;
using Xunit;
using MyLib = TestingLibrary;

namespace XUnitTestProject {
    public class UnitTest1 {
        [Theory]
        [InlineData(3, 1, 2)]
        [InlineData(5, 3, 2)]
        [InlineData(0, 7, -7)]
        public void TestMathAdd(int exp, int a, int b) {
            Assert.Equal(exp, MyLib.Math.Add(a, b));        //Applies to all InlineData
                                                            //Assert.Equal(3, MyLib.Math.Add(1, 2));        //Manual/Basic Method

        }

        [Theory]
        [InlineData(5, 7, 2)]
        [InlineData(9, 19, 10)]
        [InlineData(6, 12, 6)]
        public void TestMathSubtract(int exp, int a, int b) {
            Assert.Equal(exp, MyLib.Math.Subtract(a, b));
        }

        [Theory]
        [InlineData(25, 5, 5)]
        [InlineData(50, 5, 10)]
        [InlineData(18, 6, 3)]
        public void TestMathMultiply(int exp, int a, int b) {
            Assert.Equal(exp, MyLib.Math.Multiply(a, b));
        }

        [Theory]
        [InlineData(4, 20, 5)]
        [InlineData(20, 80, 4)]
        [InlineData(6, 18, 3)]
        public void TestMathDivide(int exp, int a, int b) {
            Assert.Equal(exp, MyLib.Math.Divide(a, b));
        }

        [Theory]
        [InlineData(4, 2)]
        [InlineData(9, 3)]
        [InlineData(36, 6)]
        public void TestMathSquared(int exp, int a) {
            Assert.Equal(exp, MyLib.Math.Squared(a));
        }

        [Theory]
        [InlineData(8, 2)]
        [InlineData(27, 3)]
        [InlineData(64, 4)]
        public void TestMathCubed(int exp, int a) {
            Assert.Equal(exp, MyLib.Math.Cubed(a));
        }

        [Theory]
        [InlineData(5, 4)]
        [InlineData(7, 5)]
        [InlineData(8, 3)]
        public void TestMathModulo(int a, int b) {
            Assert.Equal(a % b, MyLib.Math.Modulo(a, b));
        }

        [Theory]
        [InlineData(51, 4)]
        [InlineData(34, 3)]
        [InlineData(21, 2)]
        [InlineData(7, 0)]
        [InlineData(0, 28)]     //Should be out of bounds thus 0
        [InlineData(1546, 27)]
        [InlineData(1437, 26)]
        [InlineData(0, -8)]     //Should be out of bounds thus 0
        [InlineData(84, -7)]
        [InlineData(61, -6)]
        public void TestEquation1(int exp, int a) {
            Assert.Equal(exp, MyLib.Math.Equation1(a));
        }

        }
}
