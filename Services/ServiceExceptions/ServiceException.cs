using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceExceptions
{
    public class ServiceException : Exception
    {
        public ServiceException(String message):base(message) { }
    }
}
