using System.Threading.Tasks;
using QRCode.Common.Enums;

namespace QRCode.Service
{
    public interface IFileHandler
    {
        Task<(OperationStatus Status, byte[] Data)> GetFileDataAsync(string filePath);
    }
}
