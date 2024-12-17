using System;
using System.Collections.Generic;
using System.Data;
using marcatel_api.Models;
using marcatel_api.DataContext;
using System.Collections;
using System.Data.SqlClient;
using apiSegurosCelestial.Models;

namespace apiSegurosCelestial.Services
{
    public class PolizasService
    {
        private  string connection;
        public PolizasService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }


        public List<PolizaModel>GetPolizas()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<PolizaModel>();
            try
            {
                DataSet ds = dac.Fill("GetPolizas");
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new PolizaModel
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            DireccionParticular = dr["direccion"].ToString(),
                            Telefono = dr["telefono"].ToString(),
                            Colonia = dr["colonia"].ToString(),
                            Poblacion = dr["poblacion"].ToString(),
                            DomicilioCobro = dr["DomicilioCobro"].ToString(),
                            Empresa = dr["Empresa"].ToString(),
                            TelEmpresa = dr["TelefonoEmpresa"].ToString(),
                            CalleEmpresa = dr["CalleEmpresa"].ToString(),
                            Vendedor = dr["Vendedor"].ToString(),
                            Promotor = dr["Promotor"].ToString(),
                            FechaVencimiento = dr["FechaVencimiento"].ToString(),
                            Fecha = dr["Fecha"].ToString()


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

        public int InsertPoliza(InsertPolizaModel poliza, int usuario)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            int folio = 0;
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Consecutivo", SqlDbType = SqlDbType.VarChar, Value = 1 });
                parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = poliza.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@Direccion", SqlDbType = SqlDbType.VarChar, Value = poliza.DireccionParticular  });
                parametros.Add(new SqlParameter { ParameterName = "@Telefono", SqlDbType = SqlDbType.VarChar, Value = poliza.Telefono  });
                parametros.Add(new SqlParameter { ParameterName = "@Colonia", SqlDbType = SqlDbType.VarChar, Value = poliza.Colonia });
                parametros.Add(new SqlParameter { ParameterName = "@Poblacion", SqlDbType = SqlDbType.VarChar, Value = poliza.Poblacion  });
                parametros.Add(new SqlParameter { ParameterName = "@DomicilioCobro", SqlDbType = SqlDbType.VarChar, Value = poliza.DomicilioCobro });
                parametros.Add(new SqlParameter { ParameterName = "@Empresa", SqlDbType = SqlDbType.VarChar, Value = poliza.Empresa });
                parametros.Add(new SqlParameter { ParameterName = "@TelefonoEmpresa", SqlDbType = SqlDbType.VarChar, Value = poliza.TelEmpresa });
                parametros.Add(new SqlParameter { ParameterName = "@CalleEmpresa", SqlDbType = SqlDbType.VarChar, Value = poliza.CalleEmpresa  });
                parametros.Add(new SqlParameter { ParameterName = "@Vendedor", SqlDbType = SqlDbType.VarChar, Value = poliza.Vendedor });
                parametros.Add(new SqlParameter { ParameterName = "@Promotor", SqlDbType = SqlDbType.VarChar, Value = poliza.Promotor });
                parametros.Add(new SqlParameter { ParameterName = "@Usuario", SqlDbType = SqlDbType.VarChar, Value = usuario });
                DataSet ds = dac.Fill("InsertPoliza", parametros);
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

        public List<ConsecutivoPoliza>Getconsecutivo()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<ConsecutivoPoliza>();
            try
            {
                DataSet ds = dac.Fill("GetConsecutivo");
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new ConsecutivoPoliza
                        {
                            Consecutivo = int.Parse(dr["Consecutivo"].ToString()),



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


        public int InsertBeneficiario(InsertBeneficiarioModel beneficiario, int usuario)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            int folio = 0;
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = beneficiario.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@Edad", SqlDbType = SqlDbType.VarChar, Value = beneficiario.Edad });
                parametros.Add(new SqlParameter { ParameterName = "@Parentesco", SqlDbType = SqlDbType.VarChar, Value = beneficiario.Parantesco  });
                parametros.Add(new SqlParameter { ParameterName = "@UsuarioActualiza", SqlDbType = SqlDbType.VarChar, Value = usuario  });
                parametros.Add(new SqlParameter { ParameterName = "@pConsecutivo", SqlDbType = SqlDbType.VarChar, Value = beneficiario.ConsecutivoPoliza  });

                DataSet ds = dac.Fill("SP_InsertarBeneficiario", parametros);
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

        public List<BeneficiarioModel>GetBeneficiarios(int consecutivo)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<BeneficiarioModel>();
            parametros.Add(new SqlParameter { ParameterName = "@Consecutivo", SqlDbType = SqlDbType.VarChar, Value = consecutivo });
            try
            {
                DataSet ds = dac.Fill("SP_ObtenerBeneficiarios", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new BeneficiarioModel
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            Edad = int.Parse(dr["Edad"].ToString()),
                            Parantesco = dr["Parentesco"].ToString(),



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
    }
}
