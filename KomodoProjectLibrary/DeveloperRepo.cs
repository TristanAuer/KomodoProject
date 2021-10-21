using KomodoPOCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoProjectLibrary
{
    public class DeveloperRepo
    {
        private List<DeveloperPOCO> _listOfDevelopers = new List<DeveloperPOCO>();

        // Create new developer
        public void AddDeveloper(DeveloperPOCO devInfo)
        {
            _listOfDevelopers.Add(devInfo);
        }

        // See all Dev
        public List<DeveloperPOCO> GetDeveloper()
        {
            return _listOfDevelopers;
        }

        // Update dev info
        public bool UpdateDevInfo(int originalInfo, DeveloperPOCO newInfo)
        {
            DeveloperPOCO oldInfo = GetDeveloperById(originalInfo);
            if (oldInfo != null)
            {
                oldInfo.DeveloperId = newInfo.DeveloperId;
                oldInfo.FirstName = newInfo.FirstName;
                oldInfo.LastName = newInfo.LastName;
                oldInfo.PluralSightAccess = newInfo.PluralSightAccess;

                return true;
            }
            else
            {
                return false;
            }

        }

        // Delete devs
        public bool RemoveDeveloper(int developerId)
        {
            DeveloperPOCO info = GetDeveloperById(developerId);

            if (info == null)
            {
                return false;
            }
            int initialCount = _listOfDevelopers.Count;
            _listOfDevelopers.Remove(info);

            if (initialCount > _listOfDevelopers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Helper method
        public DeveloperPOCO GetDeveloperById(int developerId)
        {
            foreach (DeveloperPOCO info in _listOfDevelopers)
            {
                if (info.DeveloperId == developerId)
                {
                    return info;
                }
            }

            return null;
        }
    }
}
