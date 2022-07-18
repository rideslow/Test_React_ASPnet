using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_React_ASPnet.Domain.Entity
{
    public class Tool_User
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User_id")]
        public User User { get; set; }
        public int User_id { get; set; }

        [ForeignKey("Tool_id")]
        public Tool Tool { get; set; }
        public int Tool_id { get; set; }

        public int? CountTools { get; set; }
    }
}
