using System;
using System.Collections.Generic;
using System.Text;

namespace AspEfCore.Domain
{
    public class Mayor
    {
        public int CityId { get; set; }
        public int Id { get;set; }
        public string FirstName { set; get; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public Gender Gender { get; set; }
    }
}
