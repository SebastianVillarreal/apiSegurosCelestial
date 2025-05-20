﻿using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;

namespace marcatel_api.Services
{
    public class LoginService
    {
        private  string connection;
        public LoginService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }

        public UsuarioModel Login(string user, string pass)
        {
            UsuarioModel usuario = new UsuarioModel();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList();
                parametros.Add(new SqlParameter { ParameterName = "@pCorreo", SqlDbType = SqlDbType.VarChar, Value = user });
                parametros.Add(new SqlParameter { ParameterName = "@pPass", SqlDbType = SqlDbType.VarChar, Value = pass });
                DataSet ds = dac.Fill("sp_login", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        usuario.Id = int.Parse(row["Id"].ToString());
                        usuario.Nombre = row["Nombre"].ToString();
                        usuario.Correo = row["Correo"].ToString();
                        usuario.IdPerfil = int.Parse(row["IdPerfil"].ToString());
                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
