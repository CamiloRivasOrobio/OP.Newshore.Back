using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Newshore.Application.Wrappers
{
    public class Response<T>
    {
        public Response()
        {

        }
        public Response(T journey, string message = null)
        {
            Succeeded = true;
            Message = message;
            Journey = journey;
        }
        public Response(string message)
        {
            Succeeded = false;
            Message = message;
        }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Erros { get; set; }
        public T Journey { get; set; }
    }
}
