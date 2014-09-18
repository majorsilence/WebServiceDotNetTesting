using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceHost;

namespace ServiceTest
{

    public class LayerListService : Service
    {
        public LayerListResponse Get(LayerList request)
        {
            var response = new LayerListResponse();

            return response;

        }


        public List<LayerListResponse> Get(LayerListAll request)
        {
            var response = new List<LayerListResponse>();

            return response;
        }


        public object Post(LayerList request)
        {
            var response = new LayerListResponse();

            return response;
        }

        public object Put(LayerList request)
        {
            var response = new LayerListResponse();

            return response;
        }

        public object Delete(LayerList request)
        {

            var response = new LayerListResponse();

            return response;

        }

    }


    [DataContract]
    public class LayerListResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public LayerListResponse()
        {
            Info = new List<LayerListInfo>();
        }

        /// <summary>
        /// List of all request layer info.
        /// </summary>
        [DataMember]
        public List<LayerListInfo> Info { get; set; }

    }

    [DataContract]
    public class LayerList : IReturn<LayerListResponse>
    {
        public string LayerName { get; set; }
    }

    [DataContract]
    public class LayerListAll : IReturn<List<LayerListResponse>> { }

    [DataContract]
    public class LayerListInfo
    {

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string TableName { get; set; }
    }

}
