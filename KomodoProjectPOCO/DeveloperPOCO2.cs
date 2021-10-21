using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoProjectPOCO
{
    public class DeveloperPOCO
    {
        public int DeveloperId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool PluralSightAccess { get; set; }

        public DeveloperPOCO() { }

        public DeveloperPOCO(int developerId, string firstName, string lastName, bool pluralSightAccess)
        {
            DeveloperId = developerId;
            FirstName = firstName;
            LastName = lastName;
            PluralSightAccess = pluralSightAccess;
        }
    }
}
