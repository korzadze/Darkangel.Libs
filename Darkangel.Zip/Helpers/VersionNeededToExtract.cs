using System;
using System.Collections.Generic;
using System.Linq;
using Darkangel;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Minimal feature versions needed to extract</para>
    /// </summary>
    public class VersionNeededToExtract
    {
        private static readonly Dictionary<Feature, ApiVersion> _AllFeatures = new()
        {
            { Feature.Default, ApiVersion.Version10 },
            { Feature.FileIsAVolumeLabel, ApiVersion.Version11 },
            { Feature.FileIsAFolder, ApiVersion.Version20 },
            { Feature.CompressionDeflate, ApiVersion.Version20 },
            { Feature.TraditionalEncryption, ApiVersion.Version20 },
            { Feature.CompressionDeflate64, ApiVersion.Version21 },
            { Feature.CompressionDCLImplode, ApiVersion.Version25 },
            { Feature.UsePatchDataSet, ApiVersion.Version27 },
            { Feature.ZIP64FormatExtensions, ApiVersion.Version45 },
            { Feature.CompressionBZIP2, ApiVersion.Version46 },
            { Feature.EncryptionDES, ApiVersion.Version50 },
            { Feature.Encryption3DES, ApiVersion.Version50 },
            { Feature.EncryptionOriginalRC2, ApiVersion.Version50 },
            { Feature.EncryptionRC4, ApiVersion.Version50 },
            { Feature.EncryptionAES, ApiVersion.Version51 },
            { Feature.EncryptionCorrectedRC2, ApiVersion.Version51 },
            { Feature.EncryptionCorrectedRC2_64, ApiVersion.Version52 },
            { Feature.EncryptionNonOAEPKeyWrapping, ApiVersion.Version61 },
            { Feature.CentralDirectoryEncryption, ApiVersion.Version62 },
            { Feature.CompressionLZMA, ApiVersion.Version63 },
            { Feature.CompressionPPMd, ApiVersion.Version63 },
            { Feature.EncryptionBlowfish, ApiVersion.Version63 },
            { Feature.EncryptionTwofish, ApiVersion.Version63 },
        };
        private readonly Dictionary<Feature, ApiVersion> _Features = new()
        {
            { Feature.Default, _AllFeatures[Feature.Default] }
        };
        /// <summary>
        /// <para>Задать версию по функционалу</para>
        /// </summary>
        /// <param name="feature"></param>
        public void Set(Feature feature) =>
            _Features[feature] = _AllFeatures[feature];
        /// <summary>
        /// <para>Проверка, поддерживается функционал в текущей версии</para>
        /// </summary>
        /// <param name="feature">Функционал</param>
        /// <returns>Результат проверки</returns>
        public bool IsSet(Feature feature) =>
            (_AllFeatures[feature] <= _Features.Values.Max()) ;
        /// <summary>
        /// <para>Отменить поддержку функционала</para>
        /// </summary>
        /// <remarks>Отмена может и не произойти, если включена поддержка другого функционала той же версии или выше</remarks>
        /// <param name="feature"></param>
        public void Unset(Feature feature) =>
            _Features.Remove(feature);
        /// <summary>
        /// <para>Version for selected feature</para>
        /// </summary>
        public ApiVersion Value
        {
            get => _Features.Values.Max();
            set
            {
                _Features.Clear();
                var featByVersion = from f in _AllFeatures
                                    where f.Value <= value
                                    select f;
                foreach (var feat in featByVersion)
                {
                    _Features.Add(feat.Key, feat.Value);
                }
            }
        }
        /// <summary>
        /// <para>Reset features to default</para>
        /// </summary>
        public void Reset()
        { 
            _Features.Clear();
            Set(Feature.Default);
        }
        /// <summary>
        /// <para>Создать экземпляр класса по-умолчанию</para>
        /// </summary>
        public VersionNeededToExtract()
        {
            Reset();
        }
        /// <summary>
        /// <para>Создать экземпляр класса с указанием минимальной версии API</para>
        /// </summary>
        /// <param name="version">Минимальная версия API</param>
        public VersionNeededToExtract(UInt16 version)
        {
            Value = (ApiVersion)version;
        }
    }
}
