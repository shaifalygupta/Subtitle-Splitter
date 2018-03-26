using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SubtitleSplitter;
using Newtonsoft.Json;
using System.Text;
using TitleSplitterAPI.Models;

namespace TitleSplitterAPI.Controllers
{
    [RoutePrefix("api/Splitter")]
    public class SplitterController : ApiController
    {
        [HttpPost, Route("GetParseData")]
        public HttpResponseMessage GetParseData()
        {
            string textData= Request.Content.ReadAsStringAsync().Result;
            string[] parseData;
            List<SplitterModel> parseDataList = new List<SplitterModel>();
            SplitterModel SM;
            HttpResponseMessage res;
            try
            {
                SubtitleSplitter.SubtitleParser sp = new SubtitleParser();
                parseData = sp.Parse(textData);
                foreach (string s in parseData)
                {
                    SM = new SplitterModel();
                    SM.titleString = s;
                    parseDataList.Add(SM);
                }

                res = Request.CreateResponse(HttpStatusCode.OK);
                var json = JsonConvert.SerializeObject(parseDataList);
                res.Content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            }
            catch(Exception e)
            {
                res = Request.CreateResponse(HttpStatusCode.InternalServerError);                
            }
           
            return res;

        }
    }
}
