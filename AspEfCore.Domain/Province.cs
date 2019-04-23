using System;
using System.Collections.Generic;
using System.Text;

namespace AspEfCore.Domain
{
    public class Province
    {
        public Province()
        {
            Citieses = new List<Cities>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }

        public List<Cities> Citieses { get; set; }
    }
}
