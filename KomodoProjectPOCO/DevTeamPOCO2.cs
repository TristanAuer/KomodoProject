using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoProjectPOCO
{
    public class DevTeamPOCO
    {
        public int TeamId { get; set; }
        public List<DeveloperPOCO> Developers { get; set; }
        public string TeamName { get; set; }


        public DevTeamPOCO() { }

        public DevTeamPOCO(int teamId, List<DeveloperPOCO> developers, string teamName)
        {
            TeamId = teamId;
            Developers = developers;
            TeamName = teamName;
        }
    }
}
