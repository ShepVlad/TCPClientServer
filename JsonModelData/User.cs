using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonModelData
{
    public class User
    {
        public string Name { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return String.Format("Message:{0} .From User:{1} ",Message,Name);
        }

    }
}