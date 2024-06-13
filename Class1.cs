using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formulaire
{
    public class Class1
    {
        public string Genre { get; set; }
        public string Paysdenaissance { get; set; }
        public string Email { get; set; }
        public string Nom { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
        public string Message { get; set; }
        public string product { get; set; }
        public string ProductId { get; set; }
        public string Loisir { get; set; }
    }
    public class Address
    {
        public int Num { get; set; }
        public string NomRue { get; set; }
        public int CodePostal { get; set; }
    }
}
