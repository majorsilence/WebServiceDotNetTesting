using System;
using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints;


namespace ServiceTest
{
	class MainClass
	{
		private static readonly string ListeningOn = "http://localhost:9200/";
		
		public static void Main (string[] args)
		{
			//Initialize app host
			var appHost = new AppHost();
			appHost.Init();
			appHost.Start(ListeningOn);
			
			Console.WriteLine("Started listening on: " + ListeningOn);
			Console.WriteLine("AppHost Created at {0}, listening on {1}", DateTime.Now, ListeningOn);
	
			Console.ReadKey();
		}
	}
	
	
	
	public class AppHost : AppHostHttpListenerBase
	{
		public AppHost()
			: base("StarterTemplate HttpListener", typeof(HelloService).Assembly) { }
			public override void Configure(Funq.Container container)
		{
	
			
			this.RequestFilters.Add((req, res, dto) =>
			{
				
				var sessionKey = "Hello Session" + "/" + System.Guid.NewGuid().ToString("N");
				
				//set session for this request (as no cookies will be set on this request)
				req.Items["userid"] = sessionKey;
							
				
			
			});
			
			//register user-defined REST-ful urls
            Routes
              .Add<Hello>("/hello")
              .Add<Hello>("/hello/{Name}");
			
		}
	}

}


