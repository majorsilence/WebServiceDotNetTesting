using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceTest
{
    public abstract class BaseService<TResponse,TRequest> : Service
    {
        public object Any(TRequest request)
        {

            TResponse response = MyExecute(request);

            return response;
        }

        public abstract TResponse MyExecute(TRequest request);



    }
}
