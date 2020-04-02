namespace RazorPagesMovie.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Movie
    {
        #region Public Properties

        public int ID { get; set; }

        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public string Genre { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public string Rating { get; set; }

        #endregion Public Properties
    }
}