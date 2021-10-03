using System.Runtime.Serialization;

namespace Our.Umbraco.ContentRelations.ViewModels
{
    [DataContract(Name = "userGroup", Namespace = "")]
    public class UserGroupViewModel
    {
        [DataMember(Name = "alias")]
        public string Alias { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
        
    }
}
