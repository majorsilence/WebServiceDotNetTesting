using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceTest
{
    // The route must be register in Main.AppHost for this to work
    public class ByeService : BaseService<ByeResponse, Bye>
    {

        public override ByeResponse MyExecute(Bye request)
        {

            var res = new ByeResponse();
            res.Result = "Hi there " + request.Name;

            return res;
        }
    }



    public class ByeResponse
    {
        public string Result { get; set; }
    }


    public class Bye
    {
        public string Name { get; set; }
    }
}
