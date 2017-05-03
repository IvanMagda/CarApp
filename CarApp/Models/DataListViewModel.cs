using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace CarApp.Models
{
    public class DataListViewModel
    {
        public List<Owner> Owners { get; set; }
        public List<Car> Cars { get; set; }
    }
}