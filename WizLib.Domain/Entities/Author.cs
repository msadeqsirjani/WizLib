using System;
using WizLib.Domain.Common;

namespace WizLib.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Fullname => $"{Forename} {Surname}";
        public DateTime Birthdate { get; set; }
        public string Location { get; set; }

    }
}
