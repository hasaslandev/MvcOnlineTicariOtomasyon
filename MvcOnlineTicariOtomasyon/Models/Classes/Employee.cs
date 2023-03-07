using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Display(Name ="Personel Adı")]
        public string EmployeeName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Display(Name = "Personel Soyadı")]
        public string EmployeeLastName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        [Display(Name = "Personel Görseli")]
        public string EmployeeImage { get; set; }
        public ICollection<SalesMovement> salesMovements { get; set; }
        public int DepartmentId { get; set; }
        [Display(Name = "Departman")]
        public virtual Department department { get; set; }
    }
}