using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC_Http_Openapi.Util
{
    public class Request
    {
        private Method method;
        private string host;
        private string path;
        private string appKey;
        private string appSecret;
        private int timeout;
        private Dictionary<string, string> headers;
        private Dictionary<string, string> querys;
        private Dictionary<string, string> bodys;
        private string stringBody;
        private byte[] bytesBody;
        private List<string> signHeaderPrefixList;

        public Request()
        {
        }

        public Request(Method method, string host, string path, string appKey, string appSecret, int timeout)
        {
            this.method = method;
            this.host = host;
            this.path = path;
            this.appKey = appKey;
            this.appSecret = appSecret;
            this.timeout = timeout;
        }

        public Method Method
        {
            get
            {
                return method;
            }

            set
            {
                method = value;
            }
        }

        public string Host
        {
            get
            {
                return host;
            }

            set
            {
                host = value;
            }
        }

        public string Path
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
            }
        }

        public string AppKey
        {
            get
            {
                return appKey;
            }

            set
            {
                appKey = value;
            }
        }

        public string AppSecret
        {
            get
            {
                return appSecret;
            }

            set
            {
                appSecret = value;
            }
        }

        public int Timeout
        {
            get
            {
                return timeout;
            }

            set
            {
                timeout = value;
            }
        }

        public Dictionary<string, string> Headers
        {
            get
            {
                return headers;
            }

            set
            {
                headers = value;
            }
        }

        public Dictionary<string, string> Querys
        {
            get
            {
                return querys;
            }

            set
            {
                querys = value;
            }
        }

        public Dictionary<string, string> Bodys
        {
            get
            {
                return bodys;
            }

            set
            {
                bodys = value;
            }
        }

        public string StringBody
        {
            get
            {
                return stringBody;
            }

            set
            {
                stringBody = value;
            }
        }

        public byte[] BytesBody
        {
            get
            {
                return bytesBody;
            }

            set
            {
                bytesBody = value;
            }
        }

        public List<string> SignHeaderPrefixList
        {
            get
            {
                return signHeaderPrefixList;
            }

            set
            {
                signHeaderPrefixList = value;
            }
        }
    }
}
