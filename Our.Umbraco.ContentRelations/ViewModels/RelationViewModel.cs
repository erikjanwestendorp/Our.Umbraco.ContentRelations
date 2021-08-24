using System;
using Umbraco.Cms.Core.Models;

namespace Our.Umbraco.ContentRelations.ViewModels
{
    public class RelationViewModel 
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int ChildId { get; set; }
        public Guid ChildObjectType { get; set; }
        public string Comment { get; set; }
        public int ParentId { get; set; }
        public Guid ParentObjectGuid { get; set; }
        public IRelationType RelationType { get; set; } 
        public int RelationTypeId { get; set; }
        public ContentViewModel Content { get; set; }
    }
}
