using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Файл ZIP-архива</para>
    /// </summary>
    public class ZipFile
    {
        private readonly Dictionary<long, ConstructorInfo> _RecordsFactory = new();
        private readonly Dictionary<int, ConstructorInfo> _ExtraDataFactory = new();
        private Stream _Stream = null;
        /// <summary>
        /// <para>Поток исходных данных</para>
        /// </summary>
        public Stream Stream => _Stream;
        private readonly List<ZipRecord> _Records = new();
        /// <summary>
        /// <para>Имя файла архива, если загрузка прошла из файла</para>
        /// </summary>
        public string FileName { get; private set; }
        /// <summary>
        /// <para>Загрузить объект из файла</para>
        /// </summary>
        /// <param name="fileName">Имя файла архива</param>
        public void Load(string fileName)
        {
            Load(File.OpenRead(fileName));
            FileName = fileName;
        }
        /// <summary>
        /// <para>Конструктор объекта по-умолчанию</para>
        /// </summary>
        public ZipFile()
        {
            RegisterRecords();
            RegisterExtra();
        }
        /// <summary>
        /// <para>Создать объект и загрузить данные из потока</para>
        /// </summary>
        /// <param name="input">Входной поток</param>
        public ZipFile(Stream input) : this()
        {
            Load(input);
        }

        /// <summary>
        /// <para>Создать объект и загрузить данные из файла</para>
        /// </summary>
        /// <param name="fileName">Имя файла архива</param>
        public ZipFile(string fileName)
        {
            Load(fileName);
        }
        private void CleanData()
        {
            if (_Stream != null)
            {
                _Stream.Dispose();
                _Stream = null;
            }
            if (_Records.Count > 0)
            {
                _Records.Clear();
            }
            FileName = null;
        }
        /// <summary>
        /// <para>Зарегистрировать новый тип записи</para>
        /// </summary>
        /// <typeparam name="T">Тип записи</typeparam>
        public void RegisterRecordType<T>()
            where T : ZipRecord
        {
            Type type = typeof(T);
            var ci = type.GetConstructor(Type.EmptyTypes);
            _ = ci ?? throw new ZipRecordCtorException(string.Format(StringResources.ZipRecordCtorMessageFormat, type.FullName));
            var rec = (ZipRecord)ci.Invoke(null);
            _RecordsFactory.Add(rec.Id, ci);
        }
        /// <summary>
        /// <para>Создать объект записи архива по его идентификатору</para>
        /// </summary>
        /// <param name="id">Идентификатор записи</param>
        /// <returns>Объект записи</returns>
        /// <exception cref="InvalidZipRecordIdException"/>
        public ZipRecord CreateRecordById(long id)
        {
            if(!_RecordsFactory.ContainsKey(id))
            {
                throw new InvalidZipRecordIdException(id);
            }
            var rec = (ZipRecord)_RecordsFactory[id].Invoke(null);
            rec.Owner = this;
            return rec;
        }
        /// <summary>
        /// <para>Зарегистрировать новый тип дополнительных данных</para>
        /// </summary>
        /// <typeparam name="T">Тип дополнительных данных</typeparam>
        public void RegisterExtraFieldType<T>()
            where T : ZipExtraField
        {
            Type type = typeof(T);
            var ci = type.GetConstructor(Type.EmptyTypes);
            _ = ci ?? throw new ExtraFieldCtorException(string.Format(StringResources.ZipRecordCtorMessageFormat, type.FullName));
            var rec = (ZipExtraField)ci.Invoke(null);
            _ExtraDataFactory.Add(rec.Id, ci);
        }
        /// <summary>
        /// <para>Создать объект дополнительной информации по его идентификатору</para>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Объект дополнительной информации</returns>
        /// <exception cref="InvalidZipExtraDataIdException"/>
        public ZipExtraField CreateExtraDataById(int id)
        {
            if (!_ExtraDataFactory.ContainsKey(id))
            {
                return new UnknownZipExtraField(id);
            }
            return (ZipExtraField)_ExtraDataFactory[id].Invoke(null);
        }
        /// <summary>
        /// <para>Зарегистрировать все известные типы записей</para>
        /// </summary>
        protected virtual void RegisterRecords()
        {
            RegisterRecordType<LocalFileHeader>();
            RegisterRecordType<CentralDirectoryFileHeader>();
            RegisterRecordType<DigitalSignature>();
            RegisterRecordType<EndOfCentralDirectory>();
            RegisterRecordType<Zip64EndOfCentralDirectory>();
            RegisterRecordType<Zip64EndOfCentralDirectoryLocator>();
            RegisterRecordType<ArchiveDecryption>();
        }
        /// <summary>
        /// <para>Зарегистрировать все известные типы дополнительной информации</para>
        /// </summary>
        protected virtual void RegisterExtra()
        {
            RegisterExtraFieldType<AS400UncompressedAttributes>();
            RegisterExtraFieldType<AS400СompressedAttributes>();
            RegisterExtraFieldType<AVInfo>();
            RegisterExtraFieldType<CentralDirectoryX509Certificate>();
            RegisterExtraFieldType<ExtendedLanguageEncoding>();
            RegisterExtraFieldType<IndividualX509Certificate>();
            RegisterExtraFieldType<NTFSExtraData>();
            RegisterExtraFieldType<OpenVMSExtraData>();
            RegisterExtraFieldType<OS2ExtraData>();
            RegisterExtraFieldType<PatchDescriptor>();
            RegisterExtraFieldType<PKCS7CertificatesStore>();
            RegisterExtraFieldType<PKCS7RecipientCertificateList>();
            RegisterExtraFieldType<PolicyDecryptionKey>();
            RegisterExtraFieldType<POSZIP4690>();
            RegisterExtraFieldType<RecordManagementControls>();
            RegisterExtraFieldType<SmartcryptKeyProvider>();
            RegisterExtraFieldType<SmartcryptPolicyKey>();
            RegisterExtraFieldType<StrongEncryptionHeader>();
            RegisterExtraFieldType<TimestampRecord>();
            RegisterExtraFieldType<UNIXExtraData>();
            RegisterExtraFieldType<Zip64ExtendedInformation>();
        }
        /// <summary>
        /// <para>Загрузить объект из потока</para>
        /// </summary>
        /// <param name="input">Входной поток</param>
        public void Load(Stream input)
        {
            CleanData();

            _Stream = input;
            if(!input.CanSeek)
            {
                throw new FileLoadException("Can't read unseekable stream");
            }

            throw new NotImplementedException();
        }
    }
}
