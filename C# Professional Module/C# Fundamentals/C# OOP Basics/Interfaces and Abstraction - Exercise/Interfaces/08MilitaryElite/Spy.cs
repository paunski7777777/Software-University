﻿using System;
public class Spy : Soldier, ISpy
{
    public int CodeNumber { get; private set; }
    public Spy(int id, string firstName, string lastName, int codeNumber)
        : base(id, firstName, lastName)
    {
        this.CodeNumber = codeNumber;
    }
    public override string ToString()
    {
        return $"{base.ToString()}{Environment.NewLine}Code Number: {this.CodeNumber}";
    }
}

