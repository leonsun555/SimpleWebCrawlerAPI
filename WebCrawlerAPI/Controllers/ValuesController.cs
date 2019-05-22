using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCrawlerAPI.Model;
using Newtonsoft.Json;
using HtmlAgilityPack;

namespace WebCrawlerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IRepository _repo;
        public ValuesController(IRepository repo)
        {
            _repo = repo;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<string>> GetAsync()
        {
            //透過IRepository介面與DBContext互動
            List<NewsList> newsLists = await _repo.GetAllAsync();
            //將取出之newsLists轉成Json字串
            string results = JsonConvert.SerializeObject(newsLists, Formatting.Indented);
            return results;
        }

        // GET api/values/Create
        [HttpGet("Create")]
        public ActionResult<string> Create()
        {
            string link, XPath;

            link = "https://gnn.gamer.com.tw/";
            XPath = "//*[@id='BH-master']/div[2]";

            var htmlWeb = new HtmlWeb();

            //載入連結
            var doc = htmlWeb.Load(link);

            //建立HtmlDocument物件 from HtmlAgilityPack
            HtmlDocument hdc = new HtmlDocument();

            //載入欲查詢的Html範圍並裝進HtmlDocument物件
            hdc.LoadHtml(doc.DocumentNode.SelectSingleNode(XPath).InnerHtml);
            
            //分別對內文需求建立迴圈NodeCollection
            HtmlNodeCollection htnodeContent = hdc.DocumentNode.SelectNodes(".//div[@class='GN-lbox2B']");
            HtmlNodeCollection htnodeDate = hdc.DocumentNode.SelectNodes(".//p[@class='GN-lbox2A']");

            foreach (HtmlNode currDate in htnodeDate)
            {
                foreach (HtmlNode currContent in htnodeContent)
                {
                    //產生隨機主鍵Guid
                    Guid newGuid = Guid.NewGuid();
                    //擷取目標Html內文
                    string dataD = currDate.InnerText;
                    string check = currContent.SelectSingleNode(".//p").InnerText;
                    string check1 = currContent.SelectSingleNode(".//div/a/img").Attributes["src"].Value;
                    string check2 = currContent.SelectSingleNode(".//div/a").Attributes["href"].Value;

                    try
                    {
                        //呼叫IRepository與DBContext互動
                        _repo.AddAsync(new NewsList
                        {
                            id = newGuid,
                            date = dataD,
                            description = check,
                            imgUrl = check1,
                            contextUrl = check2
                        });
                    }
                    catch (Exception ex)
                    {
                        string err = ex.Message;
                    }

                }
            }
            return "Create Complete!";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
