using System.Reflection;
using Microsoft.Extensions.Logging;
using Our.Umbraco.ContentRelations.Common;
using Our.Umbraco.ContentRelations.Extensions;
using Our.Umbraco.ContentRelations.ViewModels;
using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Web.Common.Attributes;

namespace Our.Umbraco.ContentRelations.Controllers.Backoffice
{
    [PluginController("ContentRelations")]
    public class PackageController : UmbracoAuthorizedApiController
    {
        private readonly ILogger<PackageController> _logger;
        private readonly Assembly _assembly;
        public PackageController(ILogger<PackageController> logger)
        {
            _logger = logger;
            _assembly = typeof(PackageController).Assembly;
        }
        public ApiAttempt<PackageInformationViewModel> GetInformation()
        {
            var result = new PackageInformationViewModel
            {
                Version = GetVersion(),
                Name = GetName()
            };

            return ApiAttempt<PackageInformationViewModel>.Success(result);
        }

        private string GetVersion()
        {
            var version = _assembly.GetPackageVersion();

            if (string.IsNullOrWhiteSpace(version))
            {
                _logger.LogWarning("Package version is undefined in {assembly}", _assembly.GetName());

            }

            return version;
        }

        private string GetName()
        {
            var name = _assembly.GetPackageName();

            if (string.IsNullOrWhiteSpace(name))
            {
                _logger.LogWarning("Package name is undefined in {assembly}", _assembly.GetName());

            }

            return name;
        }

       
    }
}
