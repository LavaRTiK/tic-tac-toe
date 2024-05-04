using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Lobby
    {
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Status { get; set; }

        public Lobby(string name1,string name2,string status)
        {
            this.Name1 = name1;
            this.Name2 = name2;
            this.Status = status;
        }


    }
}
