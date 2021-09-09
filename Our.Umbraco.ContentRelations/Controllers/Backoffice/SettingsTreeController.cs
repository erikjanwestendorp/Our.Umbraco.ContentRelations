using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Trees;
using Umbraco.Cms.Web.BackOffice.Trees;
using Umbraco.Cms.Web.Common.Attributes;

namespace Our.Umbraco.ContentRelations.Controllers.Backoffice
{
    [Tree(
        sectionAlias: Constants.Applications.Settings,
        treeAlias: Static.Constants.Package.SettingsTreeAlias,
        TreeTitle = Static.Constants.Package.SettingsTreeTitle,
        TreeGroup = Static.Constants.Package.TreeGroup
        )]
    [PluginController(areaName: Static.Constants.Package.SettingsAreaName)]
    public class SettingsTreeController : TreeController
    {
        public SettingsTreeController(ILocalizedTextService localizedTextService, UmbracoApiControllerTypeCollection umbracoApiControllerTypeCollection, IEventAggregator eventAggregator) 
            : base(localizedTextService, umbracoApiControllerTypeCollection, eventAggregator)
        {

        }

        protected override ActionResult<TreeNode> CreateRootNode(FormCollection queryStrings)
        {
            var root = base.CreateRootNode(queryStrings);

            root.Value.RoutePath = $"{Constants.Applications.Settings}{Static.Constants.Package.TreeRoutePath}";
            root.Value.Icon = Static.Constants.Package.Icon;
            root.Value.HasChildren = false;
            root.Value.MenuUrl = null;

            return root;
        }


        protected override ActionResult<TreeNodeCollection> GetTreeNodes(string id, FormCollection queryStrings)
        {
            return new TreeNodeCollection();
        }

        protected override ActionResult<MenuItemCollection> GetMenuForNode(string id, FormCollection queryStrings)
        {
            return null;
        }
    }
}
