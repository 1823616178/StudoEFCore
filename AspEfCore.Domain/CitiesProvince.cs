using System;
using System.Collections.Generic;
using System.Text;

namespace AspEfCore.Domain
{
    public class CitiesProvince
    {
        public int Id { set; get; }
        public int CitiesId { set; get; }
        public int CompanyId { set; get; }

        public Cities Cities { set; get; }
        public Province province { set; get; }
    }
}
