using System;
using System.Collections.Generic;
using System.Text;

namespace AspEfCore.Domain
{
    public class Cities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AreaCode { get; set; }

        public int ProvinceId { get; set; }
        public Province Province { get; set; }

        public List<CitiesProvince> CitiesProvinces { set; get; }
        public Mayor Mayor { get; set; }
    }
}
