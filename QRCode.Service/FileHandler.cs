using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using QRCode.Common.Configs;
using QRCode.Common.Enums;

namespace QRCode.Service
{
    public class FileHandler : IFileHandler
    {
        public async Task<(OperationStatus Status, byte[] Data)> GetFileDataAsync(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return (OperationStatus.FileNotFound, null);
            }

            var extension = Path.GetExtension(filePath)?
                .ToLower();

            if (!SupportedFileTypes.FileExtensions.Contains(extension))
            {
                return (OperationStatus.UnsupportedFileType, null);
            }

            try
            {
                var data = await File.ReadAllBytesAsync(filePath);
                return (OperationStatus.Success, data);
            }
            catch (Exception e)
            {
                //TODO: log error
                return (OperationStatus.ErrorWhileReadingFile, null);
            }
        }
    }
}
