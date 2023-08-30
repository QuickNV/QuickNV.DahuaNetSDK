using System;
using System.Collections.Generic;
using System.Text;

namespace QuickNV.DahuaNetSDK.Api
{
    public class DahuaException : Exception
    {
        public DahuaException(string message) : base(message) { }
    }
}
