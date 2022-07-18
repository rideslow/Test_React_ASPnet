using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_React_ASPnet.Domain.Entity;

namespace Test_React_ASPnet.Domain.ViewModels
{
    public class Tool_UserVM
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int User_id { get; set; }

        public Tool Tool { get; set; }
        public int Tool_id { get; set; }
        public int? CountTools { get; set; }
    }
}
