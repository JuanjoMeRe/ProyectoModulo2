using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoGamesCodexASP.Models;

namespace VideoGamesCodexASP.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Videogames> games = Videogames.GetGames();
            return View(games);
        }

        // GET : VER

        public ActionResult Show(int id = 0)
        {
            if (id==0)
            {
                return Redirect("~/Home/");
            }
            else
            {
                Videogames game = Videogames.GetGame(id);
                return View(game);
            }
        }

        //CREAR
        public ActionResult Crear()
        {
            Videogames videogames = new Videogames();
            return View("~/Views/Home/VideoGamesForm.cshtml", videogames);
        }


        public ActionResult Edit(int id = 0)
        {
            Videogames game=Videogames.GetGame(id);
            if (game==null)
            {
                return Redirect("~/Home/show");
            }
            else
            {
                return View("~/Views/Home/VideoGamesForm.cshtml", game);
            }

        }
         //GUARDAR
        public ActionResult Save(Videogames videogames)
        {
            //guardar datos en db
            videogames.Save();
            //Rediccionar a una vista
            return Redirect("~/Home/Show/" + videogames.id);
        }

        public ActionResult Remove(int id = 0)
        {
            //Eleminar datos de la db
            Videogames videogames = Videogames.GetGame(id);
            if (videogames != null)
            {
                //borrar
                videogames.Remove();
            }

            return Redirect("~/Home");
        }

        public ActionResult Ranking()
        {
            List<Videogames> games = Videogames.Getranking();

            return View(games);
        }

        //BUSCADOR
        //public ActionResult Buscar (string palabra)
        //{
        //    IEnumerable<Videogames> videogames;
        //    using (var bd = new GamesContext())
        //    {
        //        videogames = bd.Videogames;
        //        if (!String.IsNullOrEmpty(palabra))
        //        {
        //            videogames = videogames.Where(x => x.name.ToLower().Contains(palabra.ToLower()));

                
        //        return View(videogames);
        //    }
        //}

           
        //}
    }


  
    
    

    
}