using AngleSharp.Html.Parser;
using System.Collections.Generic;
using System.Net.Http;

namespace PostScraping.Scraper
{
    public static class PostScraper
    {
        public static List<ResourceItem> Scrape()
        {
            return ParseHtml(GetHtml());

        }
        private static string GetHtml()
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
            };
            using var client = new HttpClient(handler);
            var url = "https://torahmates.org/jewish-resources/";
            var html = client.GetStringAsync(url).Result;
            return html;
        }
        private static List<ResourceItem> ParseHtml(string html)
        {
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);
            var result = document.QuerySelectorAll(".masonry-item");
            var items = new List<ResourceItem>();
            foreach (var div in result)
            {
                var item = new ResourceItem();
                var image = div.QuerySelector("img");
                if (image != null)
                {
                    item.ImageUrl = image.Attributes["src"].Value;
                }
                var title = div.QuerySelector(".entry__title");
                if (title != null)
                {
                    item.Title = title.TextContent;
                    item.Link = title.Children[0].Attributes["href"].Value;
                }
                var body = div.QuerySelector(".entry__excerpt");
                if (body != null)
                {
                    item.Text = body.TextContent;
                }
                items.Add(item);
            }
            return items;
        }
    }
}
