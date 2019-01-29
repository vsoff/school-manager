using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSchoolDesktopApp.Classes
{
    public enum DataReporterType
    {
        Trainer, Student
    }
    public class DataReporter
    {
        public DataReporter()
        {
        }

        public bool SaveReport(string saveText, string caption)
        {
            try
            {
                DateTime dt = DateTime.Now;
                string fileName = dt.ToShortDateString()
                    + "_" + dt.ToShortTimeString().Replace(':', '.')
                    + "_" + caption
                    + "_" + Guid.NewGuid().ToString().Substring(0, 8)
                    + ".txt";
                TextWriter txt = new StreamWriter(SportProgramSettings.ReportDirectory + fileName, false);
                txt.Write(saveText);
                txt.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public string GetTrainerReport(int trainerId, DateTime from, DateTime to, bool isDetailed)
        {
            StringBuilder sb = new StringBuilder();

            using (var db = new SportEntities(SportProgramSettings.ConnectionString))
            {
                // Находим тренера
                Trainers trainer = db.Trainers.Find(trainerId);
                // Заполняем шапку отчёта
                sb.AppendLine($"Отчёт сформирован {DateTime.Now}");
                sb.AppendLine($"Тренер: {trainer.LastName} {trainer.FirstName} {trainer.MiddleName} (TrainerId {trainer.TrainerId})");
                sb.AppendLine($"Границы отчёта: С `{from.ToShortDateString()}` ПО `{to.ToShortDateString()}`");
                sb.AppendLine();
                // Получаем список групп, подконтрольных тренеру
                int[] trainerGroupIds = db.Groups.Where(x => x.TrainerId == trainerId).Select(x => x.GroupId).ToArray();
                if (trainerGroupIds.Length == 0)
                {
                    sb.AppendLine("Этот тренер не тренирует никаких групп.");
                    return sb.ToString();
                }
                // Получаем список сессий, проведенных тренером за указанный период
                var sessions = db.Sessions.Where(x => trainerGroupIds.Contains(x.GroupId) && from <= x.Date && x.Date <= to).OrderBy(x => x.Date).ThenBy(x => x.Time);
                if (sessions.Count() == 0)
                {
                    sb.AppendLine("У тренера не было занятий в этом периоде.");
                    return sb.ToString();
                }
                foreach (Sessions s in sessions)
                {
                    int studentsCount = s.StudentsInSessions.Count();
                    sb.AppendLine($"{s.Date.ToShortDateString()} {s.Time} [ {studentsCount} ] {s.Groups.Name} (GroupId {s.GroupId})");
                    if (isDetailed)
                    {
                        StringBuilder sbStudents = new StringBuilder();
                        var students = s.StudentsInSessions.ToList();
                        sbStudents.AppendLine("Ученики:");
                        if (studentsCount == 0)
                            sbStudents.AppendLine("\t <<никого не было>>");
                        for (int i = 0; i < students.Count; i++)
                            sbStudents.AppendLine($"\t{i + 1}. {students[i].Students.LastName} {students[i].Students.FirstName} {students[i].Students.MiddleName} (StudentId {students[i].Students.StudentId})");
                        sbStudents.AppendLine();
                        sb.Append(sbStudents.ToString());
                    }
                }
            }

            return sb.ToString();
        }

        public string GetStudentReport(int studentId, DateTime from, DateTime to)
        {
            StringBuilder sb = new StringBuilder();

            using (var db = new SportEntities(SportProgramSettings.ConnectionString))
            {
                // Находим тренера
                Students student = db.Students.Find(studentId);
                // Заполняем шапку отчёта
                sb.AppendLine($"Отчёт сформирован {DateTime.Now}");
                sb.AppendLine($"Ученик: {student.LastName} {student.FirstName} {student.MiddleName} (StudentId {student.StudentId})");
                sb.AppendLine($"Границы отчёта: С `{from.ToShortDateString()}` ПО `{to.ToShortDateString()}`");
                sb.AppendLine();
                // Получаем список сессий, в которых был этот ученик
                var sessions = db.StudentsInSessions
                    .Where(x => x.StudentId == studentId && from <= x.Sessions.Date && x.Sessions.Date <= to)
                    .Select(x => x.Sessions)
                    .OrderBy(x => x.Date).ThenBy(x => x.Time).ToList();
                foreach (Sessions s in sessions)
                {
                    int studentsCount = s.StudentsInSessions.Count();
                    sb.AppendLine($"{s.Date.ToShortDateString()} {s.Time} :: {s.Groups.Name} (GroupId {s.GroupId})");
                }
            }

            return sb.ToString();
        }
    }
}
