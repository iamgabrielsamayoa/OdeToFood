﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        //To validate this is not null, and has varchar 255
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Display(Name="Type of Food")]
        public CuisineType Cuisine { get; set; }


    }
}
