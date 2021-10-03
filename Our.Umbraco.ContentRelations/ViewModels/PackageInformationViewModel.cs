using System.Runtime.Serialization;

namespace Our.Umbraco.ContentRelations.ViewModels
{
    [DataContract(Name = "packageInformation", Namespace = "")]
    public class PackageInformationViewModel
    {
        [DataMember(Name = "version")]
        public string Version { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
