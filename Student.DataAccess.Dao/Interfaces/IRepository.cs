using Student.Common.Logic.Model;
using System;
using System.Collections.Generic;

namespace Student.DataAccess.Dao.Interfaces
{
    public interface IRepository
    {
        int AddAlumno(Alumno alumno);
        List<Alumno> GetAll();
        Alumno GetById(Guid guid);
        int Remove(Guid guid);
        Alumno Update(Guid guid, Alumno alumno);
    }
}
