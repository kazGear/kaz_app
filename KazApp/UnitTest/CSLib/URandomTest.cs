using CSLib.Lib;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Xunit.Abstractions;

namespace UnitTest.Lib
{
    public class URandomTest
    {
        private readonly ITestOutputHelper _output;

        public URandomTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact(DisplayName = "int型乱数　生成範囲が正しいか")]
        public void ID001()
        {
            URandom random = new URandom();
            int countMinus = 0;
            int countExpect = 0;
            int countOver100 = 0;

            for (int i = 0; i < 10000; i++)
            {
                int randVal = random.RandomInt(0, 101);

                if (randVal < 0) countMinus++;
                else if (randVal > 100) countOver100++;
                else countExpect++;
            }
            Assert.True(countMinus <= 0);
            Assert.True(countOver100 <= 0);
            Assert.True(countExpect == 10000);
        }

        [Fact(DisplayName = "int型乱数　同じ値が連続していないか")]
        public void ID001_1()
        {
            URandom random = new URandom();
            int before = 0;
            int sameCount = 0;
            int sameLimit = 2; // 同じ値が連続して良い回数

            for (int i = 0; i < 10000; i++)
            {
                int randVal = random.RandomInt(0, 101);
                _output.WriteLine(randVal.ToString());

                if (before == randVal)
                {
                    sameCount++;
                    if (sameCount > sameLimit) Assert.True(false);
                }
                sameCount = 0;
                before = randVal;
            }
        }

        [Fact(DisplayName = "double型乱数　生成範囲が正しいか")]
        public void ID002()
        {
            URandom random = new URandom();
            int countMinus = 0;
            int countExpect = 0;
            int countOver100 = 0;

            for (int i = 0; i < 10000; i++)
            {
                double randVal = random.RandomDouble(0, 100);

                if (randVal < 0) countMinus++;
                else if (randVal > 100) countOver100++;
                else countExpect++;
            }
            Assert.True(countMinus <= 0);
            Assert.True(countOver100 <= 0);
            Assert.True(countExpect == 10000);
        }

        [Fact(DisplayName = "double型乱数　同じ値が連続していないか")]
        public void ID002_1()
        {
            URandom random = new URandom();
            double before = 0.0;
            int sameCount = 0;
            int sameLimit = 2; // 同じ値が連続して良い回数

            for (int i = 0; i < 10000; i++)
            {
                double randVal = random.RandomDouble(0, 101);
                _output.WriteLine(randVal.ToString());

                if (before == randVal)
                {
                    sameCount++;
                    if (sameCount > sameLimit) Assert.True(false);
                }
                sameCount = 0;
                before = randVal;
            }
        }

        [Theory(DisplayName = "対象の数値を rate(%) に応じて増減させる")]
        [InlineData(100, 0.0)] // 100を0％以内で増減
        [InlineData(100, 0.05)] // 100を5％以内で増減
        [InlineData(100, 1.0)]
        [InlineData(10, 0.1)]
        [InlineData(10, 0.09)]
        public void ID003(int target, double rate)
        {
            URandom random = new URandom();          
            int countExpect = 0;
            int countNotExpect = 0;

            for (int i = 0; i < 30000; i++)
            {
                int changed = random.RandomChangeInt(target, rate);

                if (target == 100 && rate == 0.0)
                {
                    if (changed == 100)
                        countExpect++;
                    else
                        countNotExpect++;
                }
                else if (target == 100 && rate == 0.05)
                {
                    if (95 <= changed && changed <= 105)
                        countExpect++;
                    else
                        countNotExpect++;
                }
                else if (target == 100 && rate == 1.0)
                {
                    if (0 <= changed && changed <= 200)
                        countExpect++;
                    else
                        countNotExpect++;
                }
                else if (target == 10 && rate == 0.1)
                {
                    if (9 <= changed && changed <= 11)
                        countExpect++;
                    else
                        countNotExpect++;
                }
                else if (target == 10 && rate == 0.09)
                {
                    if (10 <= changed && changed <= 10)
                        countExpect++;
                    else
                        countNotExpect++;
                }
            }
            Assert.True(countExpect >= 30000);
            Assert.True(countNotExpect == 0);
        }

        [Fact(DisplayName = "bool型乱数　true/false のいずれかを生成 ")]
        public void ID004()
        {
            URandom random = new URandom();
            int countTrue = 0;
            int countFalse = 0;
            int countNull = 0;

            for (int i = 0; i < 10000; i++)
            {
                bool randomBool = random.RandomBool();

                if (randomBool) countTrue++;
                else if (!randomBool) countFalse++;
                else countNull++;
            }
            Assert.True(countTrue >= 3000);
            Assert.True(countFalse >= 3000);
            Assert.True(countNull == 0);
        }

        [Fact(DisplayName = "bool型乱数　同じ値が連続していないか")]
        public void ID004_1()
        {
            URandom random = new URandom();
            bool before = false;
            int sameCount = 0;
            int sameLimit = 5; // 同じ値が連続して良い回数

            for (int i = 0; i < 10000; i++)
            {
                bool randVal = random.RandomBool();
                _output.WriteLine(randVal.ToString());

                if (before == randVal)
                {
                    sameCount++;
                    if (sameCount > sameLimit) Assert.True(false);
                }
                sameCount = 0;
                before = randVal;
            }
        }

    }
}
