using System.Runtime.Serialization;

namespace Our.Umbraco.ContentRelations.ViewModels
{
    [DataContract(Name = "content", Namespace = "")]
    public class ContentViewModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
