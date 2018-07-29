using Student.Common.Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Dao.Interfaces
{
    public interface IRepository
    {
        Alumno Create(Alumno alumno);
        List<Alumno> GetAlumnos();
        Alumno GetAlumnoById(int id);
        bool DeleteAlumnoById(int id);
        Alumno UpDateAlumno(Alumno alumno, int id);
    }
}
