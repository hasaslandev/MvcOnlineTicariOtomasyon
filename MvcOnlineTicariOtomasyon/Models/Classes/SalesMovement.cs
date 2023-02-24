using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class SalesMovement
    {
        [Key]
        public int SalesId { get; set; }
        public DateTime Date { get; set; }
        public int Total { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public int ProductId { get; set; }
        public int CurrentId { get; set; }
        public int EmployeeId { get; set; }
        public virtual Product products { get; set; }
        public virtual Current currents { get; set; }
        public  virtual Employee employees { get; set; }
    }
}