using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TitleSplitterWeb;
using TitleSplitterWeb.Models;

namespace TitleSplitterWeb.Controllers
{
    public class TitleTextController : Controller
    {
        // GET: TitleText
        [HttpPost]
        public ActionResult TitleTextDetail()
        {
            string Inputtext = Convert.ToString(Request["txtSubTitle"]);
            
            List<TitleTextModel> TitleParseInfo = new List<TitleTextModel>();
            // string[] Title = { };
            string nURI = System.Configuration.ConfigurationManager.AppSettings["APIURL"];// "http://localhost:3880/";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(nURI);
            var content = new StringContent(Inputtext);

            HttpResponseMessage response = client.PostAsync("api/Splitter/GetParseData", content).Result;
            
            if (response.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var TitleResponse = response.Content.ReadAsStringAsync().Result;
                TitleParseInfo = JsonConvert.DeserializeObject<List<TitleTextModel>>(TitleResponse);
               //return RedirectToAction("Index",);
            }
            else
            {
                TitleTextModel TM = new TitleTextModel();
                TM.titleString = "Getting Error while calling API";
                TitleParseInfo.Add(TM);
            }

            return View("Index", TitleParseInfo);

        }
        public ActionResult Index()
        {
            return View();
           
        }
    }
}