using System.Threading.Tasks;
using QRCode.Common.Enums;

namespace QRCode.Service
{
    public interface IQRScannerService
    {
        Task<(OperationStatus Status, string Result)> ScanQRCodeAsync(string fileName);
    }
}