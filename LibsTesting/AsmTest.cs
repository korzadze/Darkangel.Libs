using Darkangel.Assembler;
using System;
using Xunit;

namespace LibsTesting
{
    public class AsmTest
    {
        [Theory]
        [InlineData(1,-1,0x80)]
        [InlineData(0xf0, 4, 0x0f)]
        [InlineData(0xf0, -4, 0x0f)]
        public void AsmHelper_RotateBits(byte src, int shift, byte dst)
        {
            Assert.Equal(src.RotateBits(shift), dst);
        }

    }
}
