using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWebServer.Server.Http
{
    public class HeaderCollection
    {
        private readonly Dictionary<string, Header> headers;
        public HeaderCollection()
            => this.headers = new Dictionary<string, Header>();

        public int Count => this.headers.Count;
        public void Add(string name, string value)
        {
            var headers = new Header(name, value);
            this.headers.Add(name, headers);
        }
    }
}