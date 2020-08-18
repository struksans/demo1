using System.Threading.Tasks;
using QRCode.Common.Enums;

namespace QRCode.Service
{
    public interface IQRServerClient
    {
        Task<(OperationStatus Status, string Result)> ScanAsync(byte[] data);
    }
}
