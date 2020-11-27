using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Domain_Models
{
    public class Client
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
       // public ICollection<Intervention> Interventions { get; set; }
    }
}
