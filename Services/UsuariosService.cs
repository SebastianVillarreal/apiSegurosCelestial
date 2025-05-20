using System;
using System.Collections.Generic;
using System.Data;
using marcatel_api.Models;
using marcatel_api.DataContext;
using System.Collections;
using System.Data.SqlClient;
using apiSegurosCelestial.Models;
using marcatel_api.Utilities;

namespace apiSegurosCelestial.Services
{
    public class UsuariosService
    {
        private  string connection;
        public UsuariosService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public List<UsuarioModel> GetUsuarios()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<UsuarioModel>();
            try
            {
                DataSet ds = dac.Fill("GetUsuarios");
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new UsuarioModel
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Password = dr["Password"].ToString(),
                            FechaCreacion = dr["Fecha"].ToString(),
                            Activo = int.Parse(dr["Activo"].ToString()),
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public int InsertUsuario(UsuarioRequest usuario)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            Encrypt enc = new Encrypt();
            string cryptedPass = enc.GetSHA256(usuario.Password);
            usuario.Password = cryptedPass;
            int folio = 0;
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = usuario.Id });
                parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = usuario.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@Correo", SqlDbType = SqlDbType.VarChar, Value = usuario.Correo });
                parametros.Add(new SqlParameter { ParameterName = "@Password", SqlDbType = SqlDbType.VarChar, Value = usuario.Password });
                DataSet ds = dac.Fill("InsertUsuario", parametros);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        folio = int.Parse(dr["Id"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return folio;
        }

        public int DeleteUsuario(int usuarioId)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = usuarioId });
            int folio = 0;
            try
            {
                DataSet ds = dac.Fill("DeleteUsuario", parametros);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        folio = int.Parse(dr["Id"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return folio;
        }
    }
}
