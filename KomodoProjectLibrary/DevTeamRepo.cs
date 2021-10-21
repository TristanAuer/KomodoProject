using KomodoPOCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoProjectLibrary
{
    public class DevTeamRepo
    {
        private List<DevTeamPOCO> _listOfTeams = new List<DevTeamPOCO>();

        //Create Team
        public void AddTeams(DevTeamPOCO teamInfo)
        {
            _listOfTeams.Add(teamInfo);
        }

        //Read Teams
        public List<DevTeamPOCO> GetTeamsList()
        {
            return _listOfTeams;
        }

        //Update Teams
        public bool UpdateTeamInfo(int originalInfo, DevTeamPOCO newInfo)
        {
            DevTeamPOCO oldInfo = GetTeamById(originalInfo);
            if (oldInfo != null)
            {
                oldInfo.TeamId = newInfo.TeamId;
                oldInfo.Developers = newInfo.Developers;
                oldInfo.TeamName = newInfo.TeamName;
                return true;
            }
            else
            {
                return false;
            }
        }


        //Delete Teams
        public bool RemoveTeams(int teamId)
        {
            DevTeamPOCO info = GetTeamById(teamId);

            if (info == null)
            {
                return false;
            }
            int initalCount = _listOfTeams.Count;
            _listOfTeams.Remove(info);
            if (initalCount > _listOfTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Helper Method
        private DevTeamPOCO GetTeamById(int teamId)
        {
            foreach (DevTeamPOCO info in _listOfTeams)
            {
                if (info.TeamId == teamId)
                {
                    return info;
                }
            }
            return null;
        }
    }
}
