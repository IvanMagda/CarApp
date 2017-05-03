using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Model
{
    public enum CarType
    {
        Cargo, Passenger
    }

    public class Car
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a car Model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Please enter a car Brand")]
        public string Brand { get; set; }

        public CarType CarType { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter a car ProductionYear")]
        public int ProductionYear { get; set; }


        public virtual ICollection<Owner> Owners { get; set; }
        public Car()
        {
            Owners = new List<Owner>();
        }
    }
}
