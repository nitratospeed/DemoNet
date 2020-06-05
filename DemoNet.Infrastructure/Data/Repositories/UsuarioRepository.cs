using DemoNet.Core.Entities;
using DemoNet.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DemoNet.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        protected readonly AppDbContext _dbContext;

        public UsuarioRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<UsuarioEntity>> List()
        {
            using (var connection = _dbContext.Connection())
            {
                using (SqlCommand command = new SqlCommand("sp_get_usuarios", connection))
                {
                    var response = new List<UsuarioEntity>();
                    command.CommandType = CommandType.StoredProcedure;               
                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var usuario = new UsuarioEntity();
                            usuario.Id = (int)reader["Id"];
                            usuario.Nombres = (string)reader["Nombres"];
                            usuario.Edad = (int)reader["Edad"];
                            usuario.Ocupacion = (string)reader["Ocupacion"];
                            usuario.Celular = (string)reader["Celular"];
                            usuario.Direccion = (string)reader["Direccion"];
                            usuario.Activo = (bool)reader["Activo"];
                            usuario.FechaCreacion = (DateTime)reader["FechaCreacion"];
                            response.Add(usuario);
                        }
                    }

                    return response;
                }
            }
        }

        public async Task Insert(UsuarioEntity usuarioEntity)
        {
            using (var connection = _dbContext.Connection())
            {
                using (SqlCommand command = new SqlCommand("sp_add_usuarios", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Nombres", usuarioEntity.Nombres));
                    command.Parameters.Add(new SqlParameter("@Edad", usuarioEntity.Edad));
                    command.Parameters.Add(new SqlParameter("@Ocupacion", usuarioEntity.Ocupacion));
                    command.Parameters.Add(new SqlParameter("@Celular", usuarioEntity.Celular));
                    command.Parameters.Add(new SqlParameter("@Direccion", usuarioEntity.Direccion));
                    command.Parameters.Add(new SqlParameter("@Activo", usuarioEntity.Activo));
                    command.Parameters.Add(new SqlParameter("@FechaCreacion", DateTime.Now));
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
