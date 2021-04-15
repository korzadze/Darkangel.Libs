using System;
using Xunit;
using Darkangel.IntegerX;
using Darkangel.Arrays;

namespace LibsTesting
{
    public class IntegerXTest
    {
        [Theory]
        [InlineData(new byte[] { 1, 2, 3, 4 }, 0x04030201U)]
        [InlineData(new byte[] { 5, 6, 1, 3 }, 0x03010605U)]
        [InlineData(new byte[] { 0, 0, 0, 0x80 }, 0x80000000U)]
        public void IntegerX_GetUInt32_Test(byte[] data, UInt32 value)
        {
            Assert.Equal(data.GetUInt32(), value);
        }
        [Theory]
        [InlineData(new byte[] { 1, 2, 3, 4 }, 0x04030201U)]
        [InlineData(new byte[] { 5, 6, 1, 3 }, 0x03010605U)]
        [InlineData(new byte[] { 0, 0, 0, 0x80 }, 0x80000000U)]
        public void IntegerX_GetBytesUInt32_Test(byte[] data, UInt32 value)
        {
            Assert.True(data.CompareWith(value.GetBytes()) == 0);
        }
        [Theory]
        [InlineData(0x01020304U, 0x04030201U)]
        [InlineData(0x05060103U, 0x03010605U)]
        [InlineData(0x00000080U, 0x80000000U)]
        public void IntegerX_SwapUInt32_Test(UInt32 value, UInt32 res)
        {
            Assert.Equal(value.Swap(), res);
        }
    }
}
