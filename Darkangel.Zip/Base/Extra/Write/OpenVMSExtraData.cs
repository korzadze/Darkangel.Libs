﻿using System;
using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>OpenVMS extra data</para>
    /// </summary>
    public class OpenVMSExtraData : ZipExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x000c;
        /// <inheritdoc/>
        public override int DataSize => throw new NotImplementedException();
        /// <inheritdoc/>
        public override void Load(Stream stream, int size)
        {
            throw new NotImplementedException();
        }
        /*
                  CRC        4 bytes    32-bit CRC for remainder of the block
         Tag1       2 bytes    OpenVMS attribute tag value #1
         Size1      2 bytes    Size of attribute #1, in bytes
         (var)      Size1      Attribute #1 data
         .
         .
         .
         TagN       2 bytes    OpenVMS attribute tag value #N
         SizeN      2 bytes    Size of attribute #N, in bytes
         (var)      SizeN      Attribute #N data
          */
    }
}
