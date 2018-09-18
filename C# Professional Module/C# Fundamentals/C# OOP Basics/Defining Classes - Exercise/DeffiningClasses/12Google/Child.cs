using System;
using System.Collections.Generic;
using System.Text;
class Child
{
    public string Name { get; set; }
    public string Birthday { get; set; }
    public Child(string name, string birthday)
    {
        this.Name = name;
        this.Birthday = birthday;
    }
}
