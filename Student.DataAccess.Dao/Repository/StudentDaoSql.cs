using Student.Common.Logic.Log4net;
using Student.Common.Logic.Model;
using Student.DataAccess.Dao.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Student.DataAccess.Dao.Repository
{
    public class StudentDaoSql : IRepository
    {
        private readonly ILogger log;
        private readonly string connectionString;

        public StudentDaoSql() { }

        public StudentDaoSql(ILogger log)
        {
            this.log = log;
            connectionString = "Data Source=.;Initial Catalog=VuelingApi;Integrated Security=true;";
        }

        public int AddAlumno(Alumno alumno)
        {
            try
            {
                var sql = "INSERT INTO dbo.Alumnos (Guid, Nombre, Apellidos, Dni, Registro, Nacimiento, Edad) VALUES " +
                    "(@Guid, @Nombre, @Apellidos, @Dni, @Registro, @Nacimiento, @Edad)";

                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                    {
                        // Importante abrir la conexion antes de lanzar ningun comando
                        _conn.Open();

                        _cmd.Parameters.AddWithValue("@Guid", alumno.guid.ToString());
                        _cmd.Parameters.AddWithValue("@Nombre", alumno.Nombre.ToString());
                        _cmd.Parameters.AddWithValue("@Apellidos", alumno.Apellidos.ToString());
                        _cmd.Parameters.AddWithValue("@Dni", alumno.Dni.ToString());
                        _cmd.Parameters.AddWithValue("@Registro", alumno.Registro.ToString());
                        _cmd.Parameters.AddWithValue("@Nacimiento", alumno.Nacimiento.ToString());
                        _cmd.Parameters.AddWithValue("@Edad", alumno.Edad.ToString());

                        _cmd.ExecuteNonQuery();
                        _cmd.Parameters.Clear();

                        _cmd.CommandText = "SELECT @@IDENTITY";

                        // Obtener el ultimo identificador insertado.
                        return Convert.ToInt32(_cmd.ExecuteScalar());

                        // var id = Convert.ToInt32(_cmd.ExecuteScalar());
                        // return SelectById(id);
                    }
                }
            }
            catch (SqlException ex)
            {
                log.Error(ex);
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                log.Error(ex);
                throw ex;
            }
        }

        public List<Alumno> GetAll()
        {
            List<Alumno> listaAlumnos = new List<Alumno>();
            //csharp-station.com
            try
            {
                //var sql = "SELECT * FROM dbo.Alumnos";

                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    _conn.Open();

                    using (SqlCommand _cmd = new SqlCommand("DataSelect", _conn))
                    {
                        using (SqlDataReader reader = _cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Alumno alumno = new Alumno(Guid.Parse(reader["Guid"].ToString()), Convert.ToInt32
                                    (reader["Id"]), reader["Nombre"].ToString(), reader["Apellidos"].ToString(),
                                    reader["Dni"].ToString(), Convert.ToInt32(reader["Edad"]), DateTime.Parse
                                    (reader["Nacimiento"].ToString()), DateTime.Parse(reader["Registro"].ToString()));
                                listaAlumnos.Add(alumno);
                            }
                        }
                    }
                }

                return listaAlumnos;
            }
            catch (SqlException ex)
            {
                log.Error(ex);
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                log.Error(ex);
                throw ex;
            }
        }

        public Alumno GetById(Guid guid)
        {
            Alumno alumno = null;

            try
            {

                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand("DataSelectById", _conn))
                    {
                        _cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter FindGuid = _cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                        FindGuid.SqlValue = guid;

                        _conn.Open();

                        using (SqlDataReader reader = _cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                alumno = new Alumno(Guid.Parse(reader["Guid"].ToString()), Convert.ToInt32(reader["Id"])
                                    , reader["Nombre"].ToString(), reader["apellidos"].ToString(), reader["Dni"].
                                    ToString(), Convert.ToInt32(reader["Edad"]), DateTime.Parse(reader["Nacimiento"].
                                    ToString()), DateTime.Parse(reader["Registro"].ToString()));
                            }
                        }
                    }
                }

                return alumno;
            }
            catch (SqlException ex)
            {
                log.Error(ex);
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                log.Error(ex);
                throw ex;
            }
        }

        public int Remove(Guid guid)
        {
            try
            {
                //var sql = "DELETE FROM dbo.Alumnos WHERE Guid=@GUID";

                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand("DataDeteleById", _conn))
                    {
                        _cmd.Parameters.AddWithValue("@GUID", guid);

                        _cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter FindGuid = _cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                        FindGuid.SqlValue = guid;
                        _conn.Open();


                        _cmd.ExecuteNonQuery();

                        return 1;
                    }
                }
            }
            catch (SqlException ex)
            {
                log.Error(ex);
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                log.Error(ex);
                throw ex;
            }
        }

        public Alumno Update(Guid guid, Alumno alumno)
        {
            try
            {
                var sql = "UPDATE dbo.Alumnos SET Guid=@Guid, Nombre=@Nombre, Apellidos=@Apellidos, Dni=@Dni, " +
                    "Registro=@Registro, Nacimiento=@Nacimiento, Edad=@Edad WHERE Guid=@Guid";

                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                    {
                        _conn.Open();

                        _cmd.Parameters.AddWithValue("@Guid", guid);
                        _cmd.Parameters.AddWithValue("@Nombre", alumno.Nombre.ToString());
                        _cmd.Parameters.AddWithValue("@Apellidos", alumno.Apellidos.ToString());
                        _cmd.Parameters.AddWithValue("@Dni", alumno.Dni.ToString());
                        _cmd.Parameters.AddWithValue("@Registro", alumno.Registro.ToString());
                        _cmd.Parameters.AddWithValue("@Nacimiento", alumno.Nacimiento.ToString());
                        _cmd.Parameters.AddWithValue("@Edad", alumno.Edad.ToString());

                        _cmd.ExecuteNonQuery();
                        _cmd.Parameters.Clear();

                        return GetById(guid);
                    }
                }
            }
            catch (SqlException ex)
            {
                log.Error(ex);
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                log.Error(ex);
                throw ex;
            }
        }

    }
}