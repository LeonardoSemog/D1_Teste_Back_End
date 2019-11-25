using System;
using System.Collections.Generic;
using System.Text;

namespace AppD1.Models
{
    public class NetSocial
    {
        public int Id { get; set; }
        public string NetName { get; set; }
        public string NetAddress { get; set; }
        public List<Client> Clients { get; set; }
    }
}
