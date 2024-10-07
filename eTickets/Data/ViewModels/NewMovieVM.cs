using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using eTickets.Data.Base;
using eTickets.Models.Data;

namespace eTickets.Models
{
    public class NewMovieVM
    {
        public int Id { get; set; }

        [Display(Name = "Movie Name")]
        [Required(ErrorMessage = "Name is required")]

        public string Name { get; set; }

        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Movie Poster url")]
        [Required(ErrorMessage = "Movie Poster url is required")]
        public string ImageURL { get; set; }

        [Display(Name = "movie Start Date")]
        [Required(ErrorMessage = "StartDate is required")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "movie End Date")]
        [Required(ErrorMessage = "End Date is required")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Display(Name = "select catagory")]
        [Required(ErrorMessage = "Catagory is required")]
        public MovieCategory MovieCategory { get; set; }

        [Display(Name = "Select actor(s)")]
        [Required(ErrorMessage = "Movie actor(s) is required")]
        //Relationiship
        public List<int> ActorIds { get; set; }

        [Display(Name = "select a cinema")]
        [Required(ErrorMessage = "Movie cinema is required")]
        //Cinema
        public int CinemaId { get; set; }

        [Display(Name = "Select a producer")]
        [Required(ErrorMessage = "movie producer is required")]
        //Producer
        public int ProducerId { get; set; }



    }
}