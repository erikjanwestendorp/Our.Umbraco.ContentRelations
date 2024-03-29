﻿using System.Collections.Generic;
using System.Runtime.Serialization;


namespace Our.Umbraco.ContentRelations.ViewModels
{
    [DataContract(Name = "permission")]
    public class PermissionViewModel
    {
        [DataMember(Name = "allowed")]
        public bool Allowed { get; set; }

        [DataMember(Name = "userGroups")]
        public List<string> UserGroups { get; set; }

        [DataMember(Name = "key")]
        public string Key { get; set; }

        public PermissionViewModel(string key)
        {
            Key = key;
            UserGroups = new List<string>();
        }
        
    }
}
