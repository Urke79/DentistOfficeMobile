using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Domain_Models
{
    public class Intervention
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string InterventionDescription { get; set; }
        public string Note { get; set; }
        public int Price { get; set; }
        //public Client Client { get; set; }
        public int ClientId { get; set; }
    }
}
