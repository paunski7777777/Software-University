using System;
using System.Collections.Generic;
using System.Text;
public class Robot : IIdenticable
{
    public string Model { get; set; }
    public string Id { get; private set; }
    public Robot(string model, string id)
    {
        this.Model = model;
        this.Id = id;
    }
}

