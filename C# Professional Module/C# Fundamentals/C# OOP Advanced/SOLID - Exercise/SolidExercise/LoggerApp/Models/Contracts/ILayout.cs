﻿namespace LoggerApp.Models.Contracts
{
    public interface ILayout
    {
        string FormatError(IError error);
    }
}