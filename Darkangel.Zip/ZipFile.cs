using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darkangel.Zip
{
    public class ZipFile
    {
        public void RegisterRecordType<T>()
            where T : ZipRecord
        {

        }
        public IEnumerable<ZipRecord> ReadArchive(Stream input)
        {
            throw new NotImplementedException();
        }
    }
}
