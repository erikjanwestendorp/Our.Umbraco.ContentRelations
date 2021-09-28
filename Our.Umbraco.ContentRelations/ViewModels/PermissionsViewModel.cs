using System.Runtime.Serialization;

namespace Our.Umbraco.ContentRelations.ViewModels
{
    [DataContract(Name = "settings")]
    public class PermissionsViewModel
    {
        [DataMember(Name = "delete")]
        public PermissionViewModel Delete { get; set; }
    }


}
