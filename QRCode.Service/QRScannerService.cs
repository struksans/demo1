using System.Threading.Tasks;
using QRCode.Common.Enums;

namespace QRCode.Service
{
    public class QRScannerService : IQRScannerService
    {
        private readonly IFileHandler _fileHandler;
        private readonly IQRServerClient _client;

        public QRScannerService(IFileHandler fileHandler, IQRServerClient client)
        {
            _fileHandler = fileHandler;
            _client = client;
        }

        public async Task<(OperationStatus Status, string Result)> ScanQRCodeAsync(string fileName)
        {
            var (fileStatus, fileData) = await _fileHandler.GetFileDataAsync(fileName);
            if (fileStatus != OperationStatus.Success)
            {
                return (fileStatus, null);
            }

            //Since method signatures matches, can be just returned
            //can be deconstructed for additional logic
            return await _client.ScanAsync(fileData);
        }
    }
}
