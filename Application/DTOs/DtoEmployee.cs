using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class DtoEmployee
    {
        public int IdEmployee { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfEntry { get; set; }
        public string AFP { get; set; }
        public string Rol { get; set; }
        public string Salary { get; set; }
    }
}
