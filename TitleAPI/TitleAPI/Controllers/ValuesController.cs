using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TitleAPI.Models;

namespace TitleAPI.Controllers
{
    public class ValuesController : ApiController
    {
        TitlesEntities db = new TitlesEntities();

        [HttpGet]
        [Route("api/title")]
        public List<Title> GetAll()
        {
            var titleTable = db.Titles.ToList();
            var titleList = new List<Title>();

            foreach(var title in titleTable)
            {
                titleList.Add(new Title 
                { 
                    TitleId = title.TitleId,
                    TitleName = title.TitleName,
                    TitleNameSortable = title.TitleNameSortable,
                    TitleTypeId = title.TitleTypeId,
                    ReleaseYear = title.ReleaseYear,
                    ProcessedDateTimeUTC = title.ProcessedDateTimeUTC
                });
            }

            return titleList;
        }
    }
}
