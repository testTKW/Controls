using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC_Http_Openapi
{
    class Result
    {
        private int code;
        public int Code
        {
            get { return code; }
            set { code = value; }
        }
        private string msg;
        public string Msg
        {
            get { return msg; }
            set { msg = value; }
        }
        private object data;
        public object Data
        {
            get { return data; }
            set { data = value; }
        }

    }
}
