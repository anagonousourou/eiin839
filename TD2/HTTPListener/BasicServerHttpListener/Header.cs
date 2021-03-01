using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BasicServerHTTPlistener
{
    class Header
    {
        private IDictionary<string, string> headers;

        public Header(IDictionary<string, string> headers)
        {
            this.headers = headers;
        }


        public string GetHeader(string key)
        {

            string result;

            this.headers.TryGetValue(key.ToString(), out result);

            return result;
            
        }

        public override string ToString()
        {
            return $@"Header (
                    {headers}
                )";
        }
    }
}
