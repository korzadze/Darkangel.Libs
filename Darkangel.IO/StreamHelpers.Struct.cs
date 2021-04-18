using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Darkangel.IO
{
    public static partial class StreamHelpers
    {
        /// <summary>
        /// <para>Прочитать структуру из двоичного потока</para>
        /// </summary>
        /// <typeparam name="T">Тип структуры</typeparam>
        /// <param name="rd">Двоичный поток</param>
        /// <returns>Экземпляр структуры</returns>
        /// <remarks>2021-04-18</remarks>
        public static T ReadStruct<T>(this Stream rd)
            where T : struct
        {
            T stt;
            int dataSize = Marshal.SizeOf(typeof(T));
            byte[] bytes = rd.ReadBytes(dataSize);
            GCHandle pinned = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                stt = (T)Marshal.PtrToStructure(pinned.AddrOfPinnedObject(), typeof(T));
            }
            finally
            {
                pinned.Free();
            }
            return stt;
        }
        /// <summary>
        /// <para>Записать структуру в двоичных поток</para>
        /// </summary>
        /// <typeparam name="T">Тип структуры</typeparam>
        /// <param name="wr">Двоичный поток</param>
        /// <param name="data">Экземпляр структуры</param>
        /// <remarks>2021-04-18</remarks>
        public static void WriteStruct<T>(this Stream wr, T data)
        {
            byte[] bytes;
            int dataSize = Marshal.SizeOf(data);
            IntPtr ptr = Marshal.AllocHGlobal(dataSize);
            try
            {
                Marshal.StructureToPtr(data, ptr, false);
                bytes = new byte[dataSize];
                Marshal.Copy(ptr, bytes, 0, bytes.Length);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
            wr.WriteBytes(bytes);
        }
    }
}
