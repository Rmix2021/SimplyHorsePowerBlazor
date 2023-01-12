using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SimplyHorsePower.Data;

namespace SimplyHorsePower.Models
{
    public class AddCategory
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public Category ToCategory()
        {
            return new Category
            {
                CategoryID = CategoryID,
                CategoryName = CategoryName
            };
        }
    }
}
