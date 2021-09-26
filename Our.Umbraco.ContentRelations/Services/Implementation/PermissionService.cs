using System;
using J2N.Collections.Generic;
using Newtonsoft.Json;
using Our.Umbraco.ContentRelations.ViewModels;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Services;

namespace Our.Umbraco.ContentRelations.Services.Implementation
{
    public class PermissionService : IPermissionService
    {
        private readonly IKeyValueService _keyValueService;
        
        private Guid _key = Guid.Parse("CFC88F56-CDAB-430B-8CB2-ED879C4ACA8C");

        public PermissionService(IKeyValueService keyValueService)
        {
            _keyValueService = keyValueService;
        }

        public PermissionsViewModel GetPermissions()
        {
            var settings = _keyValueService.GetValue("contentRelationsSettings" + _key);

            if (!string.IsNullOrWhiteSpace(settings))
            {
                return JsonConvert.DeserializeObject<PermissionsViewModel>(settings);
            }

            return CreateSettings();
        }

        public PermissionsViewModel SavePermissionViewModel(PermissionsViewModel permissionViewModel)
        {
            throw new NotImplementedException();
        }

        private static PermissionsViewModel CreateSettings()
        {
            return new PermissionsViewModel
            {
                Delete = new PermissionViewModel("deletePermission")
                {
                    Allowed = true,
                    UseGroups = new List<string>
                    {
                        Constants.Security.AdminGroupAlias
                    }
                }
            };
        }
    }
}
