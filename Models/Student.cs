using MachinePratice.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace MachinePratice.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(50)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50) ")]
        public String Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public String Address { get; set; }
    }
}


