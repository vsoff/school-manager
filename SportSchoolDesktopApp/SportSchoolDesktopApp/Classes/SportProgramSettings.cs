using SimpleJSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportSchoolDesktopApp.Classes
{
    public class SportProgramSettings
    {
        //private const string ConnectionStringPattern = "metadata=res://*/DatabaseModel.csdl|res://*/DatabaseModel.ssdl|res://*/DatabaseModel.msl;provider=System.Data.SqlClient;provider connection string=\";data source={0};initial catalog={1};integrated security={2};User ID={3};Password={4};Connection Timeout={5};MultipleActiveResultSets=True;App=EntityFramework\";";
        //private const string ConnectionStringPattern = "metadata=res://*/DatabaseModel.csdl|res://*/DatabaseModel.ssdl|res://*/DatabaseModel.msl;provider=System.Data.SqlClient;provider connection string=\";data source={0};initial catalog={1};Trusted_Connection={2};User ID={3};Password={4};Connection Timeout={5};MultipleActiveResultSets=True;App=EntityFramework\";";
        private const string ConnectionStringPattern = "data source={0};initial catalog={1};integrated security={2};User ID={3};Password={4};MultipleActiveResultSets=True;App=EntityFramework";
        public static string ReportDirectory { get; private set; }
        public static string ConnectionString { get; private set; }
        public static int SessionDurationMin { get; private set; }
        public static int StudentCanLateMin { get; private set; }
        public static int[] Subscribe_MaxHoursList { get; private set; }
        public static int[] Subscribe_DurationList { get; private set; }

        public static bool Initialization()
        {
            // Загружаем настройки из файла, либо создаём свой файл с настройками
            try
            {
                var fileName = "config.json";
                if (!File.Exists(fileName))
                {
                    File.WriteAllText(fileName, DefaultConfigText);
                    MessageBox.Show($"Файл конфигурации `{fileName}` не найден. Поэтому был создан новый, пожалуйста заполните его актуальными данными.",
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                string jsonFile = File.ReadAllText(fileName);
                JSONNode jsonObj = JSON.Parse(jsonFile);
                // Заглушка (типа загрузили)=
                string DataSource = jsonObj["DataSource"];
                string DatabaseName = jsonObj["DatabaseName"];
                bool IsIntegratedSecurity = jsonObj["IsIntegratedSecurity"].AsBool;
                string UserId = jsonObj["UserId"];
                string Password = jsonObj["Password"];
                int ConnectionTimeout = jsonObj["ConnectionTimeout"].AsInt;

                List<int> maxhours = new List<int>();
                foreach (JSONNode i in jsonObj["Subscribe_MaxHoursList"].AsArray)
                    maxhours.Add(i.AsInt);
                List<int> durations = new List<int>();
                foreach (JSONNode i in jsonObj["Subscribe_DurationList"].AsArray)
                    durations.Add(i.AsInt);
                SportProgramSettings.Subscribe_MaxHoursList = maxhours.ToArray();
                SportProgramSettings.Subscribe_DurationList = durations.ToArray();
                SportProgramSettings.ConnectionString = string.Format(ConnectionStringPattern, DataSource, DatabaseName, IsIntegratedSecurity, UserId, Password, ConnectionTimeout);
                SportProgramSettings.SessionDurationMin = jsonObj["SessionDurationMin"].AsInt;
                SportProgramSettings.StudentCanLateMin = jsonObj["StudentCanLateMin"].AsInt;
                SportProgramSettings.ReportDirectory = jsonObj["ReportDirectory"];
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Файл конфигурации повреждён, дальнейший запуск невозможен!\nПодробности: " + ex,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private static string DefaultConfigText = "{\"ReportDirectory\": \"\",\"StudentCanLateMin\": 15,\"SessionDurationMin\": 60,\"Subscribe_MaxHoursList\": [ 1, 2, 4, 6, 8, 12, 24, 999 ],\"Subscribe_DurationList\": [ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 ],\"DataSource\": \"\",\"DatabaseName\": \"\",\"ConnectionTimeout\": 5,\"IsIntegratedSecurity\": true,\"UserId\": \"\",\"Password\": \"\"}";
    }
}
