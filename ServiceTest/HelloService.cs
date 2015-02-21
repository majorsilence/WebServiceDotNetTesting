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

public class HelloService : Service
{

	public object Any(Hello request)
	{
        // this method is never called as it it is overridden with the Get, Post, Put methods
		HelloResponse a = new HelloResponse();
		a.Result = "Hello, " + Convert.ToString(request.Name);
		
		var req = this.RequestContext.Get<IHttpRequest>();
		string id = req.Items["userid"].ToString();
			
		a.Result += System.Environment.NewLine + System.Environment.NewLine;
		a.Result += " " + id;
			
		return a;
	}


    public HelloResponse Get(Hello request)
    {
        var response = new HelloResponse();
        response.Result = "Get Response: " + request.Name;
        return response;

    }


    public HelloResponse Post(Hello request)
    {
        var response = new HelloResponse();
        response.Result = "Post Response " + request.Name;
        return response;
    }

    public HelloResponse Put(Hello request)
    {
        var response = new HelloResponse();
        response.Result = "Put Response" + request.Name;
        return response;
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

