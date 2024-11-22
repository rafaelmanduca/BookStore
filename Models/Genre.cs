﻿using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Genre
    {
        public int Id { get; set; }

		[Display(Name = "Nome")]
        [Required(ErrorMessage="O campo {0} é Obrigatório")]
		public string Name { get; set; }

        [Display(Name = "Livros")]
        public ICollection<Book> Books { get; set; } = new List<Book>();

        public Genre() 
        {


        }

        public Genre (int id, string name)
        {
            Id = id;    
            Name = name;
        }
    }
}
