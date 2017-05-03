using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace CarApp.Models
{
    public class OwnerEditViewModel
    {
        public Owner Owner { get; set; }

        public List<Car> Cars { get; set; }
    }
}