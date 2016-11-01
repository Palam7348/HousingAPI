using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HousingApi.Models;

namespace HousingApi.Controllers
{
    public class StreetsController : ApiController
    {
        /*Get all streets*/
        [HttpGet]
        [ActionName("getall")]
        public HttpResponseMessage All(string id)
        {
            string s = id.Remove(0, 4);
            if (s == "314")
                return Request.CreateResponse(HttpStatusCode.OK, DbDataSource.All.Streets);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, s);
        }

        /*Get street by id*/
        [HttpGet]
        [ActionName("get")]
        public HttpResponseMessage Get(string id)
        {
            string key = id.Remove(0, 4);
            key = key.Remove(key.IndexOf(","), key.Length - key.IndexOf(","));
            if (key == "314")
            {
                int n = int.Parse(id.Remove(0, id.IndexOf(",") + 4));
                return Request.CreateResponse(HttpStatusCode.OK, DbDataSource.All.Streets.Where(e => e.StreetId == n));
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error");
        }

        /*Get several streets by region id*/
        [HttpGet]
        [ActionName("getbyregion")]
        public HttpResponseMessage GetBy(string id)
        {
            string key = id.Remove(0, 4);
            key = key.Remove(key.IndexOf(","), key.Length - key.IndexOf(","));
            if (key == "314")
            {
                int n = int.Parse(id.Remove(0, id.IndexOf(",") + 4));
                return Request.CreateResponse(HttpStatusCode.OK, DbDataSource.All.Streets.Where(e => e.SubRegionId == n));
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error");
        }

    }
}
