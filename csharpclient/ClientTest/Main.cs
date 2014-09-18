using System;
using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints;
using ServiceStack.ServiceClient.Web;


namespace ServiceTest
{
    class MainClass
    {
        private static readonly string address = "http://localhost:9200/";

        public static void Main(string[] args)
        {

            using (var client = new JsonServiceClient(address))
            {



                var response = client.Send<LayerListResponse>(new LayerList()
                    {
                        LayerName = "123"
                    });
                var response2 = client.Get(new LayerList()
                    {
                        LayerName = "Abc"
                    });
                var response3 = client.Get(new LayerListAll());

            }




        }
    }





}


