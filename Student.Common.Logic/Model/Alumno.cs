using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Common.Logic.Model
{
    public class Alumno : IVuelingObject
    {
        #region Propiedades
        public Guid guid { get; set; }
        public int Id { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { set; get; }
        public DateTime Nacimiento { get; set; }
        public DateTime Registro { set; get; }
        #endregion



        public Alumno()
        {
            this.guid = Guid.NewGuid();
        }

        public Alumno(Guid guid, int id, string dni, string nombre, string apellidos, int edad, DateTime nacimiento, DateTime registro)
        {
            this.guid = guid;
            Id = id;
            Dni = dni;
            Nombre = nombre;
            Apellidos = apellidos;
            Edad = edad;
            Nacimiento = nacimiento;
            Registro = registro;
        }

        public override bool Equals(object obj)
        {
            var alumno = obj as Alumno;
            return alumno != null &&
                   guid.Equals(alumno.guid) &&
                   Id == alumno.Id &&
                   Dni == alumno.Dni &&
                   Nombre == alumno.Nombre &&
                   Apellidos == alumno.Apellidos &&
                   Edad == alumno.Edad &&
                   Nacimiento == alumno.Nacimiento &&
                   Registro == alumno.Registro;
        }

        public override int GetHashCode()
        {
            var hashCode = 1353083435;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(guid);
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Dni);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Apellidos);
            hashCode = hashCode * -1521134295 + Edad.GetHashCode();
            hashCode = hashCode * -1521134295 + Nacimiento.GetHashCode();
            hashCode = hashCode * -1521134295 + Registro.GetHashCode();
            return hashCode;
        }
    }
}
