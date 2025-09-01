using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace WebApplication1.Models
{
    public class Depratment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Dno { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public Manages? Manager { get; set; }

    //project
    public ICollection<Project> Projects { get; set; }
    }
}
