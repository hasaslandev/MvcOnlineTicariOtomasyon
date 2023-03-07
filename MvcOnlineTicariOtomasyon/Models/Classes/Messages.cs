﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Messages
    {
        [Key]
        public int MessageId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Sender { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Recipient { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Subject { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string Content { get; set; }
        [Column(TypeName = "Smalldatetime")]
        public DateTime Date { get; set; }
    }
}