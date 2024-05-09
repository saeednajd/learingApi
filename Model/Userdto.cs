using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thirdapi.Model
{
    public class Userdto
    {
       
        public int Id { get; init; }
        public string Username { get; init; }
        public string Role { get; init; }

        public DateTime Joindate { get; init; }

    }
}