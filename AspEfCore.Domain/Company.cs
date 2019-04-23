using System;
using System.Collections.Generic;
using System.Text;

namespace AspEfCore.Domain
{
    public class Company
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public DateTime EstablishDate { set; get; }
        public string Person { set; get; }
    }
}
