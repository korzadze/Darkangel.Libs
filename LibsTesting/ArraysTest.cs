using System;
using Xunit;
using Darkangel.Arrays;

namespace LibsTesting
{
    public class ArraysTest
    {
        class ByteGenerator : IValueGenerator<byte>
        {
            public byte Generate(long index)
            {
                return (byte)(index * 2);
            }
        }

        [Fact]
        public void ArrayHelper_SimpleFill_Test()
        {
            var arr = new byte[4];
            arr.Fill((byte)0);
            arr.Fill((byte)1, 1, 2);
            Assert.True((arr[0] == 0) && (arr[1] == 1) && (arr[2] == 1) && (arr[3] == 0));
        }

        [Fact]
        public void ArrayHelper_IfaceFillAndSplice_Test()
        {
            var arr = new byte[4];
            var gen = new ByteGenerator();
            arr.Fill(gen);
            for (var i = 0; i < arr.Length; i++)
            {
                Assert.True(arr[i] == gen.Generate(i));
            }
            const int Shift = 2;
            var part = arr.Splice(Shift);
            for (var i = 0; i < part.Length; i++)
            {
                Assert.True(part[i] == gen.Generate(i + Shift));
            }
        }

        [Theory]
        [InlineData(new byte[] { 1, 2, 3 }, 1)]
        [InlineData(new byte[] { 1, 2, 3, 4 }, 0)]
        [InlineData(new byte[] { 1, 2, 3, 4, 5 }, -1)]
        public void ArrayHelper_Compare_Test(byte[] data, int res)
        {
            byte[] Value1234 = new byte[] { 1, 2, 3, 4 };

            Assert.Equal(Value1234.CompareWith(data), res);
        }
        [Theory]
        [InlineData(new byte[] { 1, 2, 3 }, 3, 0)]
        [InlineData(new byte[] { 1, 2, 3, 4 }, 4, 0)]
        [InlineData(new byte[] { 1, 2, 3, 4, 5 }, 4, 0)]
        public void ArrayHelper_ComparePart_Test(byte[] data, long lenght,int res)
        {
            byte[] Value1234 = new byte[] { 1, 2, 3, 4 };

            Assert.Equal(Value1234.CompareWith(data, lenght), res);
        }
    }
}
