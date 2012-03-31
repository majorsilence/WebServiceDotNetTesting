using System;
using ServiceStack;
using ServiceStack.ServiceHost;

using System.ComponentModel;
using System.Runtime.Serialization;
using ServiceStack.WebHost.Endpoints;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;

namespace ServiceTest
{

public class HelloService : ServiceBase<Hello>
{

	protected override object Run(Hello request)
	{

		HelloResponse a = new HelloResponse();
		a.Result = "Hello, " + Convert.ToString(request.Name);
		
		var req = this.RequestContext.Get<IHttpRequest>();
		string id = req.Items["userid"].ToString();
			
		a.Result += System.Environment.NewLine + System.Environment.NewLine;
		a.Result += " " + id;
			
		return a;
	}
}

	
	
	public class HelloResponse
	{
	    public string Result { get; set; }
	}
	
	
	public class Hello
	{
	    public string Name { get; set; }
	}
	
}

