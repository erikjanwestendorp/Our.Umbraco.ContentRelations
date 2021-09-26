using System.Reflection;

namespace Our.Umbraco.ContentRelations.Extensions
{
    internal static class AssemblyExtensions
    {

        internal static string GetPackageVersion(this Assembly assembly)
        {
            var attribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();

            if (attribute != null && !string.IsNullOrWhiteSpace(attribute.InformationalVersion))
                return attribute.InformationalVersion;

            return string.Empty;
        }

        internal static string GetPackageName(this Assembly assembly)
        {
            var attribute = assembly.GetCustomAttribute<AssemblyTitleAttribute>();

            if (attribute != null && !string.IsNullOrWhiteSpace(attribute.Title))
                return attribute.Title;

            return string.Empty;
        }
    }
}
