using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Övningsuppgift2.Models;

namespace Övningsuppgift2.Controllers
{
    public class DataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewsList()
        {
            List<News> newsList = new List<News>();
            News news1 = new News("FBI: ”Kan inte betala informatörer”", "Agenter inom den amerikanska federala polisen FBI klagar på att nedstängningen av delar av den amerikanska statsapparaten påverkar deras arbete.");
            News news2 = new News("Brist på bränsle kan stänga sjukhus i Gaza", "Den svåra bränslekrisen i Gaza äventyrar patienters liv och hälsa, varnar Världshälsoorganisationen WHO. Brist på elektricitet och snabbt krympande bränslereserver hotar enligt FN-organet arbetet vid 14 av den palestinska enklavens sjukhus.");
            News news3 = new News("Tågstationen på Kastrup ska byggas ut", "Det är trångt för tågtrafiken på Kastrups flygplats. Den danska regeringen vill bygga ut stationen från två till fyra spår. Tåg mot Sverige ska stanna vid den nuvarande stationen, tåg från Sverige vid den nybyggda lite längre bort.");

            newsList.Add(news1);
            newsList.Add(news2);
            newsList.Add(news3);

            return View(newsList);
        }

        public IActionResult NewsDetails(int id)
        {
            News news1 = new News("FBI: ”Kan inte betala informatörer”", "Agenter inom den amerikanska federala polisen FBI klagar på att nedstängningen av delar av den amerikanska statsapparaten påverkar deras arbete." + "\nthis is ID " +id);
            return View(news1);
        }
    }
}