using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApp.Data
{
    [Table("User")]
    public class User
    {
       
        public int id { get; set; }

        
        public string userName { get; set; }

        public string userPassword { get; set; }

       
 
    }
}
       