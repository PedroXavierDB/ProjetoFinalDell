using System;
using System.Configuration;
using System.Linq;

namespace ProjetoFinal.Config
{
    public class ReadConfigs
    {
        public static string ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key];
                return result;
            }
            catch (ConfigurationErrorsException)
            {
                throw new Exception("Erro ao ler App.config");
            }
        }
    }
}
