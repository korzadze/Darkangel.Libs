using System;
using Xunit;
using Darkangel.IntegerX;
using Darkangel.Arrays;
using System.IO;

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
            Assert.Equal(data.GetUInt32(isLittleEndian: true), value);
        }
        [Theory]
        [InlineData(new byte[] { 1, 2, 3, 4 }, 0x04030201U)]
        [InlineData(new byte[] { 5, 6, 1, 3 }, 0x03010605U)]
        [InlineData(new byte[] { 0, 0, 0, 0x80 }, 0x80000000U)]
        public void IntegerX_GetBytesUInt32_Test(byte[] data, UInt32 value)
        {
            Assert.True(data.CompareWith(value.GetBytes(isLittleEndian: true)) == 0);
        }
        [Theory]
        [InlineData(0x01020304U, 0x04030201U)]
        [InlineData(0x05060103U, 0x03010605U)]
        [InlineData(0x00000080U, 0x80000000U)]
        public void IntegerX_SwapUInt32_Test(UInt32 value, UInt32 res)
        {
            Assert.Equal(value.Swap(), res);
        }
        [Theory]
        [InlineData(new byte[] { 0x02, 0x00, 0xF7, 0x02, 0x5B, 0x25, 0xF7, 0xBD }, 0x0002)]
        [InlineData(new byte[] { 0xF7, 0x02, 0x5B, 0x25, 0xF7, 0xBD }, 0x02F7)]
        [InlineData(new byte[] { 0x5B, 0x25, 0xF7, 0xBD }, 0x255B)]
        [InlineData(new byte[] { 0xF7, 0xBD }, 0xBDF7)]
        public void IntegerX_Read_Test(byte[] data, int res)
        {
            using MemoryStream rd = new(data);
            Assert.Equal(res, rd.ReadUInt16(isLittleEndian: true));
        }
    }
}
