using System;
using System.Collections.Generic;
using System.Text;

namespace Tournament.Exceptions
{
    public class NameException : Exception
    {
        public string NameArgument { get; set; }
        public NameException(string msg) : base(msg) { }
        public NameException(string msg, string param) : base(msg) 
        {
            NameArgument = param;
        }

    }
    public class SurnameException : Exception
    {
        public string SurnameArgument { get; set; }
        public SurnameException(string msg) : base(msg) { }
        public SurnameException(string msg, string param) : base(msg)
        {
           SurnameArgument = param;
        }
    }
    public class IDException : Exception
    {
        public string IDArgument { get; set; }
        public IDException(string msg) : base(msg) { }
        public IDException(string msg, string param) : base(msg)
        {
            IDArgument = param;
        }
    }
}
