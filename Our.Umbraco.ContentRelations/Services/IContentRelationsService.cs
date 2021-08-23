using System.Collections.Generic;
using Our.Umbraco.ContentRelations.ViewModels;

namespace Our.Umbraco.ContentRelations.Services
{
    public interface IContentRelationsService
    {
        IEnumerable<RelationViewModel> GetRelationsByContentId(int id);
    }
}
