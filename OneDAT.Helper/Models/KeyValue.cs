using OneDAT.Helper.IModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneDAT.Helper.Models
{
    public class KeyValue : IKeyValue
    {
        public KeyValue(string id, string name)
        {
            Id = id;
            Name = name;
        }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
