using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace WindowsFormsAppTesting.Utilities
{
    internal static class ConfigHelper
    {
        public static string GetConnectionString(string name)
        {
            try
            {
                var cfgPath = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
                if (string.IsNullOrWhiteSpace(cfgPath) || !File.Exists(cfgPath))
                    return string.Empty;

                var doc = XDocument.Load(cfgPath);
                var cs = doc.Root?
                    .Element("connectionStrings")?
                    .Elements("add")
                    .FirstOrDefault(e => (string)e.Attribute("name") == name)
                    ?.Attribute("connectionString")
                    ?.Value;

                return cs ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
