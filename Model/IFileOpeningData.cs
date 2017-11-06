using System;

namespace Model
{
    public interface IFileOpeningData
    {
        Guid Id { get; set; }
        DateTime Opening { get; set; }
        string FileName { get; set; }
    }
}
