using LoggerApp.Models.Enums;

namespace LoggerApp.Models.Contracts
{
   public interface ILevelable
    {
        ErrorLevel Level { get; }
    }
}
