using System;
using System.Collections.Generic;
using System.Data;
using marcatel_api.Models;
using marcatel_api.DataContext;
using System.Collections;
using System.Data.SqlClient;



namespace marcatel_api.Services
{
    public class MapeosService
    {
        private  string connection;
        public MapeosService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public List<InvAreaModel>GetAreasInv()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<InvAreaModel>();
            try
            {
                DataSet ds = dac.Fill("sp_get_areas", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new InvAreaModel
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Nombre = dr["Nombre"].ToString(),

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

        public int InsertMapeo(InsertMapeo mapeo)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            int folio = 0;
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdArea", SqlDbType = SqlDbType.VarChar, Value = mapeo.IdArea });
                parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = mapeo.IdSucursal });
                parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = SqlDbType.VarChar, Value = mapeo.IdUsuario });
                parametros.Add(new SqlParameter { ParameterName = "@pMueble", SqlDbType = SqlDbType.VarChar, Value = mapeo.Mueble });
                parametros.Add(new SqlParameter { ParameterName = "@pZona", SqlDbType = SqlDbType.VarChar, Value = mapeo.Zona });
                parametros.Add(new SqlParameter { ParameterName = "@pCara", SqlDbType = SqlDbType.VarChar, Value = mapeo.Cara });
             //   parametros.Add(new SqlParameter { ParameterName = "@pTipo", SqlDbType = SqlDbType.VarChar, Value = mapeo.Tipo });
                DataSet ds = dac.Fill("sp_insert_mapeo", parametros);
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

        public int EliminarMapeo(int id)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            int folio = 0;
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdMapeo", SqlDbType = SqlDbType.VarChar, Value = id });

                 dac.ExecuteNonQuery("MAP_EliminarMapeo", parametros);
                 return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                
            }
            return folio;

        }

        public List<MapeoModel>GetMapeosImpresion(int id_sucursal, int impresion, int id_usuario)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            var lista = new List<MapeoModel>();
            parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = id_sucursal });
            parametros.Add(new SqlParameter { ParameterName = "@pImpreso", SqlDbType = SqlDbType.VarChar, Value = impresion });
            parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = SqlDbType.VarChar, Value = id_usuario });
            try
            {
                DataSet ds = dac.Fill("sp_get_mapeos_impresion", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new MapeoModel
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            IdArea = 1,
                            Zona = dr["Zona"].ToString(),
                            Mueble = dr["Mueble"].ToString(),
                            Cara = dr["Cara"].ToString(),
                            Estado = dr["Estado"].ToString()
                           
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
                throw;
            }
            return lista;
        }

        public List<MapeoModel>GetMapeosFechas(int id_sucursal, string fecha_inicial, string fecha_final)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            var lista = new List<MapeoModel>();
            parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = id_sucursal });
            parametros.Add(new SqlParameter { ParameterName = "@pFechaInicial", SqlDbType = SqlDbType.VarChar, Value = fecha_inicial });
            parametros.Add(new SqlParameter { ParameterName = "@pFechaFinal", SqlDbType = SqlDbType.VarChar, Value = fecha_final });
            try
            {
                DataSet ds = dac.Fill("MAP_GetMapeos", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new MapeoModel
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Zona = dr["Zona"].ToString(),
                            Mueble = dr["Mueble"].ToString(),
                            Cara = dr["Cara"].ToString(),
                            Estado = dr["Estatus"].ToString(),
                            Area = dr["Area"].ToString(),
                            Sucursal = dr["Sucursal"].ToString(),
                            Fecha = dr["Fecha"].ToString()
                           
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
                throw;
            }
            return lista;
        }

        public int InsertDetalleMapeo(RenglonMapeoModel renglon)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            int valor = 0;
            parametros.Add(new SqlParameter { ParameterName = "@pIdMapeo", SqlDbType = SqlDbType.VarChar, Value = renglon.IdMapeo });
            parametros.Add(new SqlParameter { ParameterName = "@pEstante", SqlDbType = SqlDbType.VarChar, Value = renglon.Estante });
            parametros.Add(new SqlParameter { ParameterName = "@pCodigo", SqlDbType = SqlDbType.VarChar, Value = renglon.Codigo });
            parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = SqlDbType.VarChar, Value = renglon.IdUsuario });
            parametros.Add(new SqlParameter { ParameterName = "@pTipo", SqlDbType = SqlDbType.VarChar, Value = renglon.Tipo });
            parametros.Add(new SqlParameter { ParameterName = "@pCantidad", SqlDbType = SqlDbType.VarChar, Value = renglon.CantidadDirecto });

            try
            {
                DataSet ds = dac.Fill("sp_insert_detalle_mapeo", parametros);
                if (ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        valor = int.Parse(dr["Id"].ToString());
                    }

                }
                
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return valor;

        }

        public int DeleteDetalleMapeo(int Id)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            int valor = 0;
            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.VarChar, Value = Id });

            try
            {
                dac.ExecuteNonQuery("MAP_EliminarRenglonMapeo", parametros);
                return 1;
                
            }
            catch (Exception ex)
            {
                
                Console.Write(ex.Message);
                return 0;
            }

        }

        public int CongelarInventario(int sucursal, string fecha, string fecha_inicial, string fecha_final)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            int valor = 0;
            parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = sucursal });
            parametros.Add(new SqlParameter { ParameterName = "@pFecha", SqlDbType = SqlDbType.VarChar, Value = fecha });
            parametros.Add(new SqlParameter { ParameterName = "@pFechaInicial", SqlDbType = SqlDbType.VarChar, Value = fecha_final });
            parametros.Add(new SqlParameter { ParameterName = "@pFechaFinal", SqlDbType = SqlDbType.VarChar, Value = fecha_final });

            try
            {
                DataSet ds = dac.Fill("INV_CongelarInventario", parametros);
                if (ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        valor = int.Parse(dr["Id"].ToString());
                    }

                }
                
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return valor;

        }

        public List<RenglonMapeoModel>GetDetalleMapeo(int id, int tipo)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            
            var lista = new List<RenglonMapeoModel>();
            parametros.Add(new SqlParameter { ParameterName = "@pIdMapeo", SqlDbType = SqlDbType.VarChar, Value = id });
            parametros.Add(new SqlParameter { ParameterName = "@pTipo", SqlDbType = SqlDbType.VarChar, Value = tipo });
            try
            {
                DataSet ds = dac.Fill("sp_get_detalle_mapeo", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new RenglonMapeoModel
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Consecutivo = int.Parse(dr["ConsecutivoMueble"].ToString()),
                            Estante = int.Parse(dr["Estante"].ToString()),
                            DescripcionArticulo = dr["ARTC_DESCRIPCION"].ToString(),
                            Codigo = dr["CodigoProducto"].ToString(),
                            IdMapeo = int.Parse(dr["IdMapeo"].ToString()),
                            CantidadCaptura = float.Parse(dr["Captura"].ToString())
                            
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }
            return lista;
        }

        public List<MapeoModel>GetMapeosCapturar(int id_sucursal, int id_usuario)
        {

            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var list = new List<MapeoModel>();

            parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = id_sucursal });
            parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = SqlDbType.VarChar, Value = id_usuario });
            parametros.Add(new SqlParameter { ParameterName = "@pImpreso", SqlDbType = SqlDbType.VarChar, Value = 0 });
            try
            {
                DataSet ds = dac.Fill("sp_get_mapeos_captura", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new MapeoModel
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Zona = dr["Zona"].ToString(),
                            Mueble = dr["Mueble"].ToString(),
                            Cara = dr["Cara"].ToString(),
                            NombreUsuario = dr["nombre_usuario"].ToString(),
                            Sucursal = dr["Sucursal"].ToString(),
                            Fecha = dr["Fecha"].ToString(),
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
                
            }
            return list;
        }

        public List<MapeoModel>GetMapeosCapturados(int id_sucursal, int id_usuario)
        {

            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var list = new List<MapeoModel>();

            parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = id_sucursal });
            parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = SqlDbType.VarChar, Value = id_usuario });
            parametros.Add(new SqlParameter { ParameterName = "@pImpreso", SqlDbType = SqlDbType.VarChar, Value = 0 });
            try
            {
                DataSet ds = dac.Fill("MAP_GetMapeosCapturados", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new MapeoModel
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Zona = dr["Zona"].ToString(),
                            Mueble = dr["Mueble"].ToString(),
                            Cara = dr["Cara"].ToString(),
                            NombreUsuario = dr["nombre_usuario"].ToString(),
                            Sucursal = dr["Sucursal"].ToString(),
                            Fecha = dr["Fecha"].ToString(),
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
                
            }
            return list;
        }

        public List<CantidadesCapturadasModel>GetCantidadesCapturadas(int id_sucursal, string fecha)
        {

            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var list = new List<CantidadesCapturadasModel>();

            parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = id_sucursal });
            parametros.Add(new SqlParameter { ParameterName = "@pFecha", SqlDbType = SqlDbType.VarChar, Value = fecha });
            try
            {
                DataSet ds = dac.Fill("INV_GetCapturaFecha", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new CantidadesCapturadasModel
                        {
                            Codigo = dr["CodigoProducto"].ToString(),
                            Cantidad = decimal.Parse(dr["Cantidad"].ToString()),
                            Descripcion = dr["ARTC_DESCRIPCION"].ToString(),
                            IdDetalleMapeo = int.Parse(dr["IdDetalleMapeo"].ToString()),
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }
            return list;
        }

        public List<GetDiferenciasInventarios>GetDiferenciasInventarios(int id_sucursal, string fecha, int idDepto, string fecha_captura, string fecha_final, int incluye_cero, int pageSize, int skip)
        {

            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var list = new List<GetDiferenciasInventarios>();

            parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = id_sucursal });
            parametros.Add(new SqlParameter { ParameterName = "@pFecha", SqlDbType = SqlDbType.VarChar, Value = fecha });
            parametros.Add(new SqlParameter { ParameterName = "@pIdDepartamento", SqlDbType = SqlDbType.VarChar, Value = idDepto });
            parametros.Add(new SqlParameter { ParameterName = "@pFechaCaptura", SqlDbType = SqlDbType.VarChar, Value = fecha_captura });
            parametros.Add(new SqlParameter { ParameterName = "@pFechaFinal", SqlDbType = SqlDbType.VarChar, Value = fecha_final });
            parametros.Add(new SqlParameter { ParameterName = "@pIncluyeCeros", SqlDbType = SqlDbType.VarChar, Value = incluye_cero });
            parametros.Add(new SqlParameter { ParameterName = "@pSkip", SqlDbType = SqlDbType.VarChar, Value = skip });
            parametros.Add(new SqlParameter { ParameterName = "@pPageSize", SqlDbType = SqlDbType.VarChar, Value = pageSize });
            parametros.Add(new SqlParameter { ParameterName = "@pSearch", SqlDbType = SqlDbType.VarChar, Value = "" });
            try
            {
                DataSet ds = dac.Fill("INV_GetDiferenciasInventarios", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new GetDiferenciasInventarios
                        {
                            Codigo = dr["Codigo"].ToString(),
                            Capturado = decimal.Parse(dr["Capturado"].ToString()),
                            Congelado = decimal.Parse(dr["Cantidad"].ToString()),
                            Descripcion =  dr["ARTC_DESCRIPCION"].ToString(),
                            Diferencia = decimal.Parse(dr["TeoricoCalculado"].ToString()) - decimal.Parse(dr["Capturado"].ToString()),
                            SalidaVenta = decimal.Parse(dr["salidaVenta"].ToString()),
                            SalidaPConsumo = decimal.Parse(dr["salidaConsumo"].ToString()) ,
                            SalidaConversion = decimal.Parse(dr["salidaConversion"].ToString()),
                            SalidaPmerma = decimal.Parse(dr["salidaMerma"].ToString()) ,
                            SalidaTransferencia  = decimal.Parse(dr["salidaTransfer"].ToString()),
                            EntradaPTraspaso  = decimal.Parse(dr["entradaTraspaso"].ToString()),
                            EntradaPConversion = decimal.Parse(dr["entradaConversion"].ToString()),
                            EntradaSOrden = decimal.Parse(dr["EntradaSOrden"].ToString()),
                            EntradaDevolucion  = decimal.Parse(dr["EntradaDevolucion"].ToString()),
                            Teorico  =  decimal.Parse(dr["TeoricoCalculado"].ToString()),
                            Costo = decimal.Parse(dr["costo"].ToString()),
                            PrecioPublico = decimal.Parse(dr["ARTN_PRECIOVENTA"].ToString()),
                            AjustePositivo = decimal.Parse(dr["ajustePositivo"].ToString()),
                            AjusteNegativo = decimal.Parse(dr["ajusteNegativo"].ToString()),
                            EntradaEspecial = decimal.Parse(dr["entradaEspecial"].ToString()),
                            SalidaEspecial = decimal.Parse(dr["salidaEspecial"].ToString()),
                            SalidaDevolucion = decimal.Parse(dr["salidaDevolucion"].ToString()),
                            TotalRegistros = int.Parse(dr["cantidadRegistros"].ToString())

                        });
                    }
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }
            return list;
        }

        public List<GetDiferenciasInventarios>GetDiferenciasInventariosExport(int id_sucursal, string fecha, int idDepto, string fecha_captura, string fecha_final, int incluye_cero)
        {

            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var list = new List<GetDiferenciasInventarios>();

            parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = id_sucursal });
            parametros.Add(new SqlParameter { ParameterName = "@pFecha", SqlDbType = SqlDbType.VarChar, Value = fecha });
            parametros.Add(new SqlParameter { ParameterName = "@pIdDepartamento", SqlDbType = SqlDbType.VarChar, Value = idDepto });
            parametros.Add(new SqlParameter { ParameterName = "@pFechaCaptura", SqlDbType = SqlDbType.VarChar, Value = fecha_captura });
            parametros.Add(new SqlParameter { ParameterName = "@pFechaFinal", SqlDbType = SqlDbType.VarChar, Value = fecha_final });
            parametros.Add(new SqlParameter { ParameterName = "@pIncluyeCeros", SqlDbType = SqlDbType.VarChar, Value = incluye_cero });
            try
            {
                DataSet ds = dac.Fill("INV_GetDiferenciasInventariosExport", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new GetDiferenciasInventarios
                        {
                            Codigo = dr["Codigo"].ToString(),
                            Capturado = decimal.Parse(dr["Capturado"].ToString()),
                            Congelado = decimal.Parse(dr["Cantidad"].ToString()),
                            Descripcion =  dr["ARTC_DESCRIPCION"].ToString(),
                            Diferencia = decimal.Parse(dr["TeoricoCalculado"].ToString()) - decimal.Parse(dr["Capturado"].ToString()),
                            SalidaVenta = decimal.Parse(dr["salidaVenta"].ToString()),
                            SalidaPConsumo = decimal.Parse(dr["salidaConsumo"].ToString()) ,
                            SalidaConversion = decimal.Parse(dr["salidaConversion"].ToString()),
                            SalidaPmerma = decimal.Parse(dr["salidaMerma"].ToString()) ,
                            SalidaTransferencia  = decimal.Parse(dr["salidaTransfer"].ToString()),
                            EntradaPTraspaso  = decimal.Parse(dr["entradaTraspaso"].ToString()),
                            EntradaPConversion = decimal.Parse(dr["entradaConversion"].ToString()),
                            EntradaSOrden = decimal.Parse(dr["EntradaSOrden"].ToString()),
                            EntradaDevolucion  = decimal.Parse(dr["EntradaDevolucion"].ToString()),
                            Teorico  =  decimal.Parse(dr["TeoricoCalculado"].ToString()),
                            Costo = decimal.Parse(dr["costo"].ToString()),
                            PrecioPublico = decimal.Parse(dr["ARTN_PRECIOVENTA"].ToString()),
                            AjustePositivo = decimal.Parse(dr["ajustePositivo"].ToString()),
                            AjusteNegativo = decimal.Parse(dr["ajusteNegativo"].ToString()),
                            EntradaEspecial = decimal.Parse(dr["entradaEspecial"].ToString()),
                            SalidaEspecial = decimal.Parse(dr["salidaEspecial"].ToString()),
                            SalidaDevolucion = decimal.Parse(dr["salidaDevolucion"].ToString()),

                        });
                    }
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }
            return list;
        }

        public List<ReporteValorInventario>ReporteValorInventario(int id_sucursal, string fecha_inicial, string fecha_final)
        {

            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var list = new List<ReporteValorInventario>();

            parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = id_sucursal });
            parametros.Add(new SqlParameter { ParameterName = "@pFechaInicial", SqlDbType = SqlDbType.VarChar, Value = fecha_inicial });
            parametros.Add(new SqlParameter { ParameterName = "@pFechaFinal", SqlDbType = SqlDbType.VarChar, Value = fecha_final });
            try
            {
                DataSet ds = dac.Fill("INV_RptValorInventario", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new ReporteValorInventario
                        {
                            Departamento = dr["Depto"].ToString(),
                            Familia = dr["Familia"].ToString(),
                            SalidaVenta = decimal.Parse(dr["salidaVenta"].ToString()),
                            SalidaPConsumo = decimal.Parse(dr["salidaConsumo"].ToString()) ,
                            SalidaConversion = decimal.Parse(dr["salidaConversion"].ToString()),
                            SalidaPmerma = decimal.Parse(dr["salidaMerma"].ToString()) ,
                            SalidaTransferencia  = decimal.Parse(dr["salidaTransfer"].ToString()),
                            EntradaPTraspaso  = decimal.Parse(dr["entradaTraspaso"].ToString()),
                            EntradaPConversion = decimal.Parse(dr["entradaConversion"].ToString()),
                            EntradaSOrden = decimal.Parse(dr["EntradaSOrden"].ToString()),
                            EntradaDevolucion  = decimal.Parse(dr["EntradaDevolucion"].ToString()),
                            Teorico  =  decimal.Parse(dr["Teorico"].ToString()),
                            AjustePositivo = decimal.Parse(dr["ajustePositivo"].ToString()),
                            AjusteNegativo = decimal.Parse(dr["ajusteNegativo"].ToString()),
                            SalidaEspecial = decimal.Parse(dr["SalidaEspecial"].ToString()),
                            EntradaEspecial = decimal.Parse(dr["EntradaEspecial"].ToString()),
                            Valor = decimal.Parse(dr["Valor"].ToString())

                        });
                    }
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }
            return list;
        }


        public void FinalizarMapeo(int id)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.VarChar, Value = id });
            try
            {
                dac.ExecuteNonQuery("sp_finalizar_mapeo", parametros);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                
            }
        }

        public void AjustarDiferencias(int id_sucursal, int usuario, int id_depto, string fecha_captura)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = id_sucursal });
            parametros.Add(new SqlParameter { ParameterName = "@pFechaCaptura", SqlDbType = SqlDbType.VarChar, Value = fecha_captura });
            parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = SqlDbType.VarChar, Value = usuario });
            parametros.Add(new SqlParameter { ParameterName = "@pIdDepartamento", SqlDbType = SqlDbType.VarChar, Value = id_depto });

            try
            {
                dac.ExecuteNonQuery("INV_AjustarDiferencias", parametros);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                
            }
        }

        public int InsertarCodigosDiferencias(DataTable dt, int id_depto, int usuario, int sucursal, string fecha)
        {
             //var datos  = ToDataTable<DetalleModel>(data);
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
           // List<DetalleModel> lista = new List<DetalleModel>();
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@TVP", SqlDbType = SqlDbType.Structured, Value = dt });
                parametros.Add(new SqlParameter { ParameterName = "@pIdDepartamento", SqlDbType = SqlDbType.Int, Value = id_depto });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = SqlDbType.Int, Value = usuario });
                parametros.Add(new SqlParameter { ParameterName = "@pSucursal", SqlDbType = SqlDbType.Int, Value = sucursal });
                parametros.Add(new SqlParameter { ParameterName = "@pFecha", SqlDbType = SqlDbType.VarChar, Value = fecha });
                dac.ExecuteNonQuery("INV_CargarCodigosAjuste", parametros);
                return 1;

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0 ;
            }
        }

        public int ActualizarDatosMapeo(MapeoModel mapeo)
        {
             //var datos  = ToDataTable<DetalleModel>(data);
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
           // List<DetalleModel> lista = new List<DetalleModel>();
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pArea", SqlDbType = SqlDbType.Int, Value = mapeo.IdArea });
                parametros.Add(new SqlParameter { ParameterName = "@pZona", SqlDbType = SqlDbType.VarChar, Value = mapeo.Zona });
                parametros.Add(new SqlParameter { ParameterName = "@pMueble", SqlDbType = SqlDbType.VarChar, Value = mapeo.Mueble });
                parametros.Add(new SqlParameter { ParameterName = "@pCara", SqlDbType = SqlDbType.VarChar, Value = mapeo.Cara });
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.VarChar, Value = mapeo.Id });
                dac.ExecuteNonQuery("MAP_UpdateDatosMapeo", parametros);
                return 1;

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0 ;
            }
        }

        public MapeoModel GetDatosMapeo(int id)
        {
            var mapeo = new MapeoModel();
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.VarChar, Value = id });
                DataSet ds = dac.Fill("sp_get_datos_mapeo", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        mapeo.Zona = dr["Zona"].ToString();
                        mapeo.Mueble = dr["Mueble"].ToString();
                        mapeo.Cara = dr["Cara"].ToString();
                        mapeo.Id = int.Parse(dr["Id"].ToString());
                        mapeo.Fecha = dr["Fecha"].ToString();
                        mapeo.Area = dr["Area"].ToString();
                        mapeo.IdArea = int.Parse(dr["IdArea"].ToString());
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return mapeo;
        }

        public List<MapeoModel>GetMapeos(int id_sucursal)
        {
            var mapeo = new MapeoModel();
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            var lista = new List<MapeoModel>();
            parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = id_sucursal });
            parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = SqlDbType.VarChar, Value = 1 });
            try
            {
                
                DataSet ds = dac.Fill("sp_get_mapeos", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new MapeoModel
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            IdArea = int.Parse(dr["IdArea"].ToString()),
                            Area = dr["Area"].ToString(),
                            Zona = dr["Zona"].ToString(),
                            Mueble = dr["Mueble"].ToString(),
                            Cara = dr["Cara"].ToString(),
                            NombreUsuario = dr["nombre_usuario"].ToString(),
                            Sucursal = dr["Sucursal"].ToString(),
                            Fecha = dr["Fecha"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }
            return lista;
        }

        public int InsertCaptura(CapturaModel captura)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdDetalle", SqlDbType = SqlDbType.VarChar, Value = captura.IdRenglon });
                parametros.Add(new SqlParameter { ParameterName = "@pCodigo", SqlDbType = SqlDbType.VarChar, Value = captura.Codigo });
                parametros.Add(new SqlParameter { ParameterName = "@pCantidad", SqlDbType = SqlDbType.VarChar, Value = captura.Cantidad });
                parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = SqlDbType.VarChar, Value = captura.IdUsuario });
                parametros.Add(new SqlParameter { ParameterName = "@pFecha", SqlDbType = SqlDbType.VarChar, Value = captura.Fecha });
                dac.ExecuteNonQuery("sp_insert_captura", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
                
            }
        }

        public int FinalizarCaptura(int id, int usuario)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            int numero = 0;
            parametros.Add(new SqlParameter { ParameterName = "@pIdMapeo", SqlDbType = SqlDbType.VarChar, Value = id });
            parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = SqlDbType.VarChar, Value = usuario });
            try
            {
                dac.ExecuteNonQuery("sp_finalizar_captura", parametros);
                numero = 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return numero;
        }

        public List<KardexArticuloModel>GetKardexArticulos(string fecha_inicial, string fecha_final, int sucursal, int id_depto)
        {
            var mapeo = new MapeoModel();
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            var lista = new List<KardexArticuloModel>();
            parametros.Add(new SqlParameter { ParameterName = "@pFechaInicial", SqlDbType = SqlDbType.VarChar, Value = fecha_inicial });
            parametros.Add(new SqlParameter { ParameterName = "@pFechaFinal", SqlDbType = SqlDbType.VarChar, Value = fecha_final });
            parametros.Add(new SqlParameter { ParameterName = "@pSucursal", SqlDbType = SqlDbType.VarChar, Value = sucursal });
            try
            {
                
                DataSet ds = dac.Fill("INV_GetKardexArticulos", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new KardexArticuloModel
                        {
                            Codigo = dr["Codigo"].ToString(),
                            Cantidad =  Math.Round(decimal.Parse( dr["cantidad"].ToString()), 2),
                            SalidaVentas = Math.Round( decimal.Parse( dr["salidaVenta"].ToString()), 2),
                            SalidaConsumo = Math.Round( decimal.Parse( dr["SalidaPConsumo"].ToString()), 2),
                            SalidaMerma = Math.Round( decimal.Parse( dr["SalidaPmerma"].ToString()), 2),
                            SalidaTransferencia = Math.Round( decimal.Parse( dr["salidaPTransfer"].ToString()), 2),
                            SalidaEspecial =  Math.Round(  decimal.Parse(dr["SalidaEspecial"].ToString()), 2),
                            SalidaDevolucion = Math.Round( decimal.Parse(dr["SalidaDevolucion"].ToString()), 2),
                            SalidaConversion = Math.Round( decimal.Parse( dr["SalidaPConversion"].ToString()), 2),
                            EntradaTraspaso = Math.Round( decimal.Parse( dr["EntradaPTraspaso"].ToString()), 2),
                            EntradasConversion = Math.Round( decimal.Parse( dr["EntradaPConversion"].ToString()), 2),
                            EntradasDevolucion = Math.Round( decimal.Parse( dr["EntradaDevolucion"].ToString()), 2),
                            EntradasSinOrden = Math.Round( decimal.Parse( dr["EntradaSOrden"].ToString()), 2),
                            AjusteNegativo = Math.Round( decimal.Parse( dr["AjusteNegativo"].ToString()), 2),
                            AjustePositivo = Math.Round( decimal.Parse( dr["AjustePositivo"].ToString()), 2),
                            EntradaEspecial = Math.Round( decimal.Parse(dr["EntradaEspecial"].ToString()), 2),
                            TotalEntradas = Math.Round( decimal.Parse(dr["TotalEntradas"].ToString()), 2),
                            TotalSalidas = Math.Round( decimal.Parse(dr["TotalSalidas"].ToString()), 2),
                            Teorico = Math.Round( decimal.Parse(dr["Teorico"].ToString()), 2)
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }
            return lista;
        }

        public List<MapeosCodigoModel>GetMapeosCodigo(string codigo, string fecha, int id_sucursal)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            
            var lista = new List<MapeosCodigoModel>();
            parametros.Add(new SqlParameter { ParameterName = "@pArticulo", SqlDbType = SqlDbType.VarChar, Value = codigo });
            parametros.Add(new SqlParameter { ParameterName = "@pFechaConteo", SqlDbType = SqlDbType.VarChar, Value = fecha });
            parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = id_sucursal });
            try
            {
                DataSet ds = dac.Fill("INV_GetMapeosArticulo", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new MapeosCodigoModel
                        {
                            IdDetalleMapeo = int.Parse(dr["IdDetalleMapeo"].ToString()),
                            Descripcion = dr["ARTC_DESCRIPCION"].ToString(),
                            Codigo = dr["CodigoProducto"].ToString(),
                            IdMapeo = int.Parse(dr["IdMapeo"].ToString()),
                            Cantidad = decimal.Parse(dr["Cantidad"].ToString()),
                            Zona = dr["Zona"].ToString(),
                            Mueble = dr["Mueble"].ToString(),
                            Cara = dr["Cara"].ToString()
                            
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }
            return lista;
        }

        public int GuardarTeoricoFecha(string fecha_inicial, string fecha_final, string fecha_existencia, int sucursal, int IdDepartamento)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            
            var lista = new List<MapeosCodigoModel>();
            parametros.Add(new SqlParameter { ParameterName = "@pFechaInicial", SqlDbType = SqlDbType.VarChar, Value = fecha_inicial });
            parametros.Add(new SqlParameter { ParameterName = "@pFechaFinal", SqlDbType = SqlDbType.VarChar, Value = fecha_final });
            parametros.Add(new SqlParameter { ParameterName = "@pFechaExistencia", SqlDbType = SqlDbType.VarChar, Value = fecha_existencia });
            parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = sucursal });
            parametros.Add(new SqlParameter { ParameterName = "@pIdDepartamento", SqlDbType = SqlDbType.VarChar, Value = IdDepartamento });
            try
            {
                dac.ExecuteNonQuery("INV_GuardarTeoricoFecha", parametros);

            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }
            return 1;
        }

        public List<KardexArticuloModel>GetKardexDepartamento(string fecha_inicial, string fecha_final, int sucursal, int id_depto)
        {
            var mapeo = new MapeoModel();
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            var lista = new List<KardexArticuloModel>();
            parametros.Add(new SqlParameter { ParameterName = "@pFechaInicial", SqlDbType = SqlDbType.VarChar, Value = fecha_inicial });
            parametros.Add(new SqlParameter { ParameterName = "@pFechaFinal", SqlDbType = SqlDbType.VarChar, Value = fecha_final });
            parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = sucursal });
            parametros.Add(new SqlParameter { ParameterName = "@pIdDepartamento", SqlDbType = SqlDbType.VarChar, Value = id_depto });
            try
            {
                
                DataSet ds = dac.Fill("INV_GetKardexDepartamento", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new KardexArticuloModel
                        {
                            Codigo = dr["Codigo"].ToString(),
                            Descripcion = dr["ARTC_DESCRIPCION"].ToString(),
                            Cantidad =  Math.Round(decimal.Parse( dr["cantidad"].ToString()), 2),
                            SalidaVentas = Math.Round( decimal.Parse( dr["salidaVenta"].ToString()), 2),
                            SalidaConsumo = Math.Round( decimal.Parse( dr["salidaConsumo"].ToString()), 2),
                            SalidaMerma = Math.Round( decimal.Parse( dr["salidaMerma"].ToString()), 2),
                            SalidaTransferencia = Math.Round( decimal.Parse( dr["salidaTransfer"].ToString()), 2),
                            SalidaEspecial =  Math.Round(  decimal.Parse(dr["SalidaEspecial"].ToString()), 2),
                            SalidaDevolucion = Math.Round( decimal.Parse(dr["SalidaDevolucion"].ToString()), 2),
                            SalidaConversion = Math.Round( decimal.Parse( dr["salidaConversion"].ToString()), 2),
                            EntradaTraspaso = Math.Round( decimal.Parse( dr["entradaTraspaso"].ToString()), 2),
                            EntradasConversion = Math.Round( decimal.Parse( dr["entradaConversion"].ToString()), 2),
                            EntradasDevolucion = Math.Round( decimal.Parse( dr["entradaDevolucion"].ToString()), 2),
                            EntradasSinOrden = Math.Round( decimal.Parse( dr["entradaSorden"].ToString()), 2),
                            AjusteNegativo = Math.Round( decimal.Parse( dr["AjusteNegativo"].ToString()), 2),
                            AjustePositivo = Math.Round( decimal.Parse( dr["AjustePositivo"].ToString()), 2),
                            EntradaEspecial = Math.Round( decimal.Parse(dr["EntradaEspecial"].ToString()), 2),
                            TotalEntradas = Math.Round( decimal.Parse(dr["TotalEntradas"].ToString()), 2),
                            TotalSalidas = Math.Round( decimal.Parse(dr["TotalSalidas"].ToString()), 2),
                            Teorico = Math.Round( decimal.Parse(dr["Teorico"].ToString()), 2)
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }
            return lista;
        }

        public List<KardexArticuloModel>GetKardexFamilia(string fecha_inicial, string fecha_final, int sucursal, int id_familia)
        {
            var mapeo = new MapeoModel();
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            var lista = new List<KardexArticuloModel>();
            parametros.Add(new SqlParameter { ParameterName = "@pFechaInicial", SqlDbType = SqlDbType.VarChar, Value = fecha_inicial });
            parametros.Add(new SqlParameter { ParameterName = "@pFechaFinal", SqlDbType = SqlDbType.VarChar, Value = fecha_final });
            parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = sucursal });
            parametros.Add(new SqlParameter { ParameterName = "@pIdFamilia", SqlDbType = SqlDbType.VarChar, Value = id_familia });
            try
            {
                
                DataSet ds = dac.Fill("INV_GetKardexFamilia", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new KardexArticuloModel
                        {
                            Codigo = dr["Codigo"].ToString(),
                            Descripcion = dr["ARTC_DESCRIPCION"].ToString(),
                            Cantidad =  Math.Round(decimal.Parse( dr["cantidad"].ToString()), 2),
                            SalidaVentas = Math.Round( decimal.Parse( dr["salidaVenta"].ToString()), 2),
                            SalidaConsumo = Math.Round( decimal.Parse( dr["salidaConsumo"].ToString()), 2),
                            SalidaMerma = Math.Round( decimal.Parse( dr["salidaMerma"].ToString()), 2),
                            SalidaTransferencia = Math.Round( decimal.Parse( dr["salidaTransfer"].ToString()), 2),
                            SalidaEspecial =  Math.Round(  decimal.Parse(dr["SalidaEspecial"].ToString()), 2),
                            SalidaDevolucion = Math.Round( decimal.Parse(dr["SalidaDevolucion"].ToString()), 2),
                            SalidaConversion = Math.Round( decimal.Parse( dr["salidaConversion"].ToString()), 2),
                            EntradaTraspaso = Math.Round( decimal.Parse( dr["entradaTraspaso"].ToString()), 2),
                            EntradasConversion = Math.Round( decimal.Parse( dr["entradaConversion"].ToString()), 2),
                            EntradasDevolucion = Math.Round( decimal.Parse( dr["entradaDevolucion"].ToString()), 2),
                            EntradasSinOrden = Math.Round( decimal.Parse( dr["entradaSorden"].ToString()), 2),
                            AjusteNegativo = Math.Round( decimal.Parse( dr["AjusteNegativo"].ToString()), 2),
                            AjustePositivo = Math.Round( decimal.Parse( dr["AjustePositivo"].ToString()), 2),
                            EntradaEspecial = Math.Round( decimal.Parse(dr["EntradaEspecial"].ToString()), 2),
                            TotalEntradas = Math.Round( decimal.Parse(dr["TotalEntradas"].ToString()), 2),
                            TotalSalidas = Math.Round( decimal.Parse(dr["TotalSalidas"].ToString()), 2),
                            Teorico = Math.Round( decimal.Parse(dr["Teorico"].ToString()), 2)
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }
            return lista;
        }

        public int InsertarConteoDirecto(int usuario, decimal cantidad, string codigo, int id_mapeo)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            
            var lista = new List<MapeosCodigoModel>();
            parametros.Add(new SqlParameter { ParameterName = "@pIdMapeo", SqlDbType = SqlDbType.VarChar, Value = id_mapeo });
            parametros.Add(new SqlParameter { ParameterName = "@pCodigo", SqlDbType = SqlDbType.VarChar, Value = codigo });
            parametros.Add(new SqlParameter { ParameterName = "@pCantidad", SqlDbType = SqlDbType.VarChar, Value = cantidad });
            parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = SqlDbType.VarChar, Value = usuario });
            try
            {
                dac.ExecuteNonQuery("MAP_InsertarConteoDirecto", parametros);

            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }
            return 1;
        }

        public List<CantidadesCapturadasModel>GetCantidadesCapturadasMapeo(int id_mapeo)
        {

            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var list = new List<CantidadesCapturadasModel>();

            parametros.Add(new SqlParameter { ParameterName = "@pIdMapeo", SqlDbType = SqlDbType.VarChar, Value = id_mapeo });
            try
            {
                DataSet ds = dac.Fill("INV_GetCapturaMapeo", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new CantidadesCapturadasModel
                        {
                            Codigo = dr["CodigoProducto"].ToString(),
                            Cantidad = decimal.Parse(dr["Cantidad"].ToString()),
                            Descripcion = dr["ARTC_DESCRIPCION"].ToString(),
                            IdDetalleMapeo = int.Parse(dr["IdDetalleMapeo"].ToString()),
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }
            return list;
        }
    }

    
}