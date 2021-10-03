using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Our.Umbraco.ContentRelations.ViewModels;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Services;

namespace Our.Umbraco.ContentRelations.Services.Implementation
{
    public class PermissionService : IPermissionService
    {
        private readonly IKeyValueService _keyValueService;
        private readonly ILogger<PermissionService> _logger;

        public PermissionService(
            IKeyValueService keyValueService,
            ILogger<PermissionService> logger)
        {
            _keyValueService = keyValueService;
            _logger = logger;
        }

        public PermissionsViewModel GetPermissions()
        {
            var settingsString = _keyValueService.GetValue(Static.Constants.KeyValues.SettingsKey);

            if (!string.IsNullOrWhiteSpace(settingsString))
            {
                var settings = JsonConvert.DeserializeObject<PermissionsViewModel>(settingsString);

                if (settings == null)
                    return CreateSettings();

                if (!settings.Delete.UserGroups.Contains(Constants.Security.AdminGroupAlias))
                    settings.Delete.UserGroups.Add(Constants.Security.AdminGroupAlias);

                return settings;
            }

            return CreateSettings();
        }

        public Attempt<PermissionsViewModel> SavePermissionViewModel(PermissionsViewModel permissionViewModel)
        {
            try
            {

                permissionViewModel.Delete.UserGroups = permissionViewModel.Delete.UserGroups.Distinct().ToList();

                var serializedSettings = JsonConvert.SerializeObject(permissionViewModel);

                _keyValueService.SetValue(Static.Constants.KeyValues.SettingsKey, serializedSettings);

                return Attempt<PermissionsViewModel>.Succeed(permissionViewModel);
            }
            catch (Exception e)
            {
                _logger.LogError(e, nameof(e));

                return Attempt<PermissionsViewModel>.Fail(permissionViewModel);
            }

        }

        private static PermissionsViewModel CreateSettings()
        {
            return new PermissionsViewModel
            {
                Delete = new PermissionViewModel(Static.Constants.Permissions.DeletePermission)
                {
                    Allowed = true,
                    UserGroups = new List<string>
                    {
                        Constants.Security.AdminGroupAlias
                    }
                }
            };
        }
    }
}
