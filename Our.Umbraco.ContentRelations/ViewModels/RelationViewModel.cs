using System;
using System.Runtime.Serialization;
using Umbraco.Cms.Core.Models;

namespace Our.Umbraco.ContentRelations.ViewModels
{
    [DataContract(Name = "relation", Namespace = "")]
    public class RelationViewModel 
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "createDate")]
        public DateTime CreateDate { get; set; }

        [DataMember(Name = "childId")]
        public int ChildId { get; set; }

        [DataMember(Name = "childObjectType")]
        public Guid ChildObjectType { get; set; }

        [DataMember(Name = "comment")]
        public string Comment { get; set; }

        [DataMember(Name = "parentId")]
        public int ParentId { get; set; }

        [DataMember(Name = "parentObjectGuid")]
        public Guid ParentObjectGuid { get; set; }

        [DataMember(Name = "relationType")]
        public IRelationType RelationType { get; set; }

        [DataMember(Name = "relationTypeId")]
        public int RelationTypeId { get; set; }

        [DataMember(Name = "content")]
        public ContentViewModel Content { get; set; }
    }
}
