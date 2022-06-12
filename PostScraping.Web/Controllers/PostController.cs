using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostScraping.Scraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostScraping.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        [HttpGet]
        [Route("getall")]
        public List<ResourceItem> GetAll()
        {
            return PostScraper.Scrape();
        }
    }
}

