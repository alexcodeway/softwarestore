using System.Collections.Generic;
using System.Linq;
using SoftwareStore.DataManager;
using SoftwareStore.Models;

namespace SoftwareStore.Services
{
    public interface ISoftwareService
    {
        IEnumerable<Software> GetAll();
        IEnumerable<Software> GetSoftwareGreaterThan(string version);
    }

    public class SoftwareService : ISoftwareService
    {
        private readonly ISoftwareManager _softwareManager;

        public SoftwareService(ISoftwareManager softwareManager)
        {
            _softwareManager = softwareManager;
        }

        public IEnumerable<Software> GetAll()
        {
            return _softwareManager.GetAllSoftware();
        }

        public IEnumerable<Software> GetSoftwareGreaterThan(string versionInput)
        {
            return _softwareManager.GetAllSoftware().Where(x => IsVersionGreater(x.Version, versionInput)).ToList();
        }

        private bool IsVersionGreater(string v1, string v2)
        {
            // could use System.Version, or a library, but....
            v1 = v1.TrimEnd('.');
            v2 = v2.TrimEnd('.');
            var version1 = v1.Split('.');
            var version2 = v2.Split('.');

            var maxLength = new[] { version1.Length, version2.Length }.Max();

            for (var i = 0; i < maxLength; i++)
            {
                if (!int.TryParse(version1.ElementAtOrDefault(i), out int v1Int)) v1Int = 0;
                if (!int.TryParse(version2.ElementAtOrDefault(i), out int v2Int)) v2Int = 0;
                if (v1Int > v2Int)
                {
                    return true;
                }
                else if (v1Int == v2Int)
                {
                    continue;
                }
                else
                {
                    break;
                }
                    
            }

            return false;
        }
    }
}
