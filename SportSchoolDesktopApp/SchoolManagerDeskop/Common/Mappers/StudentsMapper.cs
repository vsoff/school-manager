using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Common.Mappers
{
    public class StudentsMapper : IModelMapper<Student, StudentModel>
    {
        public Student ToCore(StudentModel obj) => new Student
        {
            Id = obj.Id,
            Phone = obj.Phone,
            Birdth = obj.Birdth,
            LastName = obj.LastName,
            FirstName = obj.FirstName,
            MiddleName = obj.MiddleName,
        };

        public StudentModel ToModel(Student obj) => new StudentModel
        {
            Id = obj.Id,
            Phone = obj.Phone,
            Birdth = obj.Birdth,
            LastName = obj.LastName,
            FirstName = obj.FirstName,
            MiddleName = obj.MiddleName,
        };
    }
}
