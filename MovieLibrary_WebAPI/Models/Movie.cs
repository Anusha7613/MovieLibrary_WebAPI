using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieLibrary_WebAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }

      

        public string Name { get; set; }

       
        public string DirectorName { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public Genre Genre { get; set; }//reference of table


        public int GenreId { get; set; }
     
     

    }
}