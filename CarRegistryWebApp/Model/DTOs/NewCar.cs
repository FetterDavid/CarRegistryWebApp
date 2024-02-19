using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class NewCar
    {
        public Car Car { get; set; }
        public int OwnerId { get; set; }
    }
}
