using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SimplyHorsePower.Data;

namespace SimplyHorsePower.Models
{
    public class AddMake
    {
        [Key]
        public int MakeId { get; set; }

        [Required]
        public string MakeName { get; set; }

        public Make ToMake()
        {
            return new Make
            {
                MakeId = MakeId,
                MakeName = MakeName
            };
        }
    }
}
