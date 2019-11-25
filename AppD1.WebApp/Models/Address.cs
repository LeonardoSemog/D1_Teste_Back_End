﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppD1.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public List<Client> Clients { get; set; }
    }
}
