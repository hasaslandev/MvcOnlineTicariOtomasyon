using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; } //ÜrünId
        [Column(TypeName="Varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }//ÜrünAdı
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Brand { get; set; }//Marka
        public short Stock { get; set; } //short'un SQL karşılığı smallint olur.
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public bool Status { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string ProductImage { get; set; }
        public int CategoryId { get; set; }
        public virtual Category category { get; set; }
        public ICollection<SalesMovement> salesMovements { get; set; }

    }
}