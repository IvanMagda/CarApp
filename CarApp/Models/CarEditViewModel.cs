using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace CarApp.Models
{
    public class CarEditViewModel
    {
        public Car Car { get; set; }

        public List<Owner> Owners { get; set; }
    }
}