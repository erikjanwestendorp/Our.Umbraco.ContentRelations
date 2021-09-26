using System.Runtime.Serialization;
using J2N.Collections.Generic;

namespace Our.Umbraco.ContentRelations.ViewModels
{
    [DataContract(Name = "permission")]
    public class PermissionViewModel
    {
        [DataMember(Name = "allowed")]
        public bool Allowed { get; set; }

        [DataMember(Name = "userGroups")]
        public List<string> UseGroups { get; set; }

        [DataMember(Name = "key")]
        public string Key { get; set; }

        public PermissionViewModel(string key)
        {
            Key = key;
            UseGroups = new List<string>();
        }
        
    }
}
