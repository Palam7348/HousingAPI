using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HousingApi.Models;

namespace HousingApi.Controllers
{
    public class HousesController : ApiController
    {

        /*get all houses*/
        [HttpGet]
        [ActionName("getall")]
        public HttpResponseMessage All(string id)
        {
            string s = id.Remove(0, 4);
            if (s == "314")
                return Request.CreateResponse(HttpStatusCode.OK, DbDataSource.All.Houses);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, s);
        }

        /*get by house id*/
        [HttpGet]
        [ActionName("get")]
        public HttpResponseMessage Get(string id)
        {
            string key = id.Remove(0, 4);
            key = key.Remove(key.IndexOf(","), key.Length - key.IndexOf(","));
            if (key == "314")
            {
                int n = int.Parse(id.Remove(0, id.IndexOf(",") + 4));
                return Request.CreateResponse(HttpStatusCode.OK, DbDataSource.All.Houses.Where(e => e.HouseId == n));
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error");
        }


        /*Get several houses by street id*/
        [HttpGet]
        [ActionName("getbystreet")]
        public HttpResponseMessage GetBy(string id)
        {
            string key = id.Remove(0, 4);
            key = key.Remove(key.IndexOf(","), key.Length - key.IndexOf(","));
            if (key == "314")
            {
                int n = int.Parse(id.Remove(0, id.IndexOf(",") + 4));
                return Request.CreateResponse(HttpStatusCode.OK, DbDataSource.All.Houses.Where(e => e.StreetId == n));
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error");
        }
    }
}
