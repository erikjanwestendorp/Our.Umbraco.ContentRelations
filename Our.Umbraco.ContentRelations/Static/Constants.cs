namespace Our.Umbraco.ContentRelations.Static
{
    public static class Constants
    {
        public static class Package
        {
            public const string Name = "Our.Umbraco.ContentRelations";
            public const string Alias = "ourUmbracoContentRelations";
            public const string Icon = "icon-trafic";

            public const string SettingsTreeAlias = "contentRelationsSettings";
            public const string SettingsTreeTitle = "Content Relations Settings";
            public const string SettingsAreaName = "ContentRelations";
            public const string TreeRoutePath = "/contentrelationssettings/settingsdashboard";
            public const string TreeGroup = "thirdParty";
        }

        public static class Apps
        {
            public static class RelationsContentApp
            {
                public const string Alias = "contentRelations";
                public const string Name = "Relations";
                public const string Icon = Package.Icon;
                public const string View = "/App_Plugins/ContentRelations/info.html";
                public const int Weight = 0;

            }
        }

        public static class ApiPaths
        {
            public const string ContentRelationsController = "contentRelations";
            public const string ContentRelationsUserGroupsController = "contentRelationsUserGroups";
            public const string ContentRelationsPackageController = "package";
        }

        public static class RelationTypes
        {
            public static class RelatedContent
            {
                public const string Alias = "contentRelationsRelatedContent";
                public const string Name = "Related Content";
            }
        }

        public static class Text
        {
            public static class Notifications
            {
                public const string Area = "contentRelationsMessages";
                public const string DeleteNotAllowedCategory = "deleteNotAllowedCategory";
                public const string DeleteNotAllowedMessage = "deleteNotAllowedMessage";
            }
        }

    }
}
