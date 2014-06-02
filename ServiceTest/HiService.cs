using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceTest
{
    // The route must be register in Main.AppHost for this to work
    public class HiService : BaseService<HiResponse, Hi>
    {

        public override HiResponse MyExecute (Hi request)
	    {

            var res = new HiResponse();
            res.Result = "Hi there " + request.Name;

            return res;
	    }
    }

	
	
	public class HiResponse
	{
	    public string Result { get; set; }
	}
	
	
	public class Hi
	{
	    public string Name { get; set; }
	}
    
}
