using LoggerApp.Models.Enums;
using System;

namespace LoggerApp.Models.Contracts
{
    public interface IError : ILevelable
    {
        DateTime DateTime { get; }
        string Message { get; }
    }
}