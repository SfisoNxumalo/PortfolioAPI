using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AuthUserEntity
    {
        public int Id { get; set; }
        public required string Uid { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public bool Completed_reg { get; set; } = false;


    }
}
