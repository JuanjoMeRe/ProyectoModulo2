namespace VideoGamesCodexASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Videogames
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string publisher { get; set; }

        public int year { get; set; }

        public int genre { get; set; }
        public Genre Genre
        {
            get { return (Genre)genre; }
            set { genre = (int)value; }
        }
        // VER
        internal static Videogames GetGame(int id)
        {
            Videogames game = null;
            try
            {
                GamesContext  Context = new GamesContext();
                game = Context.Videogames.Where(x => x.id == id).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            return game;
        }

       

        public int platform { get; set; }
        public Platform Platform
        {
            get { return (Platform)platform; }
            set { platform = (int)value; }
        }

        public int score { get; set; }

        public bool online { get; set; }

        public int pegi { get; set; }
        public PEGI PEGI
        {
            get { return (PEGI)pegi; }
            set { pegi = (int)value; }
        }

        public static List<Videogames> GetGames()
        {
         List<Videogames> games = new List<Videogames>();
        GamesContext context = new GamesContext();

            try
            {
                games = context.Videogames.OrderBy(x=>x.name).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return games;
        }

        internal static List<Videogames> Getranking()
        {
            List<Videogames> games = new List<Videogames>();
            GamesContext context = new GamesContext();

            try
            {
                games = context.Videogames.OrderByDescending(x => x.score).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return games;
        }

        //SAVE

        public void Save()
        {
            bool create = this.id == 0;
            try
            {
                GamesContext context = new GamesContext();
                if (create)
                {
                    context.Entry(this).State = System.Data.Entity.EntityState.Added;
                }
                else
                {
                    context.Entry(this).State = System.Data.Entity.EntityState.Modified;
                }

                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Remove()
        {
            try
            {
                GamesContext context = new GamesContext();

                context.Entry(this).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

            
        }
    }
    


}




