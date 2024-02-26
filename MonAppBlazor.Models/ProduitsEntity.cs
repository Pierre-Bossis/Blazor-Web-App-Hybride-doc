using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonAppBlazor.Models
{
    public class ProduitsEntity
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Icone { get; set; }
        public string Source { get; set; }
        public int Rarete { get; set; }
    }

    public class ProduitsForm
    {
        public string Nom { get; set; }
        public string Source { get; set; }
        public int Rarete { get; set; }
    }
}
