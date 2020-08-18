namespace QRCode.Common.Enums
{
    public enum OperationStatus
    {
        Success = 1,

        FileNotFound = 20,
        UnsupportedFileType = 21,
        ErrorWhileReadingFile = 22,

        UnableToProcessImage = 30,
        ExternalApiError = 31
    }
}
