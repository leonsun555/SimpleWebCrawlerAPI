using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json;
using WebCrawlerAPI.Model;

namespace WebCrawlerAPI.Controllers
{
    public class CrawlerCore
    {
        private readonly IRepository _repo;

        public CrawlerCore()
        {
        }

        public CrawlerCore(IRepository repo)
        {
            _repo = repo;
        }
        public void CreateData()
        {
            string link, XPath;

            link = "https://gnn.gamer.com.tw/";
            XPath = "//*[@id='BH-master']/div[2]";

            // 指定來源網頁
            var htmlWeb = new HtmlWeb();
            //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            // 將網頁來源資料暫存到記憶體內
            //MemoryStream ms = new MemoryStream(url.DownloadData(link));
            var doc = htmlWeb.Load(link);
            //選擇的ul整個區塊
            // 使用 UTF8 編碼讀入 HTML 
            //HtmlDocument doc = new HtmlDocument();
            //doc.Load(ms, Encoding.UTF8);

            // 裝載第一層查詢結果 
            HtmlDocument hdc = new HtmlDocument();
            JsonSerializer serializer = new JsonSerializer();
            // XPath 來解讀它
            hdc.LoadHtml(doc.DocumentNode.SelectSingleNode(XPath).InnerHtml);
            HtmlNodeCollection htnodeContent = hdc.DocumentNode.SelectNodes(".//div[@class='GN-lbox2B']");
            HtmlNodeCollection htnodeDate = hdc.DocumentNode.SelectNodes(".//p[@class='GN-lbox2A']");
            //string jsonRe = "";
            
            foreach (HtmlNode currDate in htnodeDate)
            {
                foreach (HtmlNode currContent in htnodeContent)
                {
                    Guid newGuid = Guid.NewGuid();
                    string dataD = currDate.InnerText;
                    string check = currContent.SelectSingleNode(".//p").InnerText;
                    string check1 = currContent.SelectSingleNode(".//div/a/img").Attributes["src"].Value;
                    string check2 = currContent.SelectSingleNode(".//div/a").Attributes["href"].Value;
                    
                    //var notExsist = _webCrawler.NewsLists.Where(c => c.description != currContent.SelectSingleNode(".//p").InnerText);
                    try
                    {
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
        }
    }
}
