using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Model
{
    public class Owner
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a LastName")]
        public string LastName { get; set; }

        public int DrivingExperience { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
        public Owner()
        {
            Cars = new List<Car>();
        }
    }
}
