using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using apiSegurosCelestial.Models;
using iText.Forms;
using iText.Forms.Fields;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Properties;
using marcatel_api.DataContext;
using marcatel_api.Models;

namespace apiSegurosCelestial.Services
{
    public class CertificadosService
    {
        private string connection;

        public CertificadosService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public int InsertCertificado(InsertCertificadoModel certificado)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            int idCertificado = 0;
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pFolio", SqlDbType = SqlDbType.Int, Value = certificado.Folio });
                parametros.Add(new SqlParameter { ParameterName = "@pIdVendedor", SqlDbType = SqlDbType.Int, Value = certificado.IdVendedor });
                parametros.Add(new SqlParameter { ParameterName = "@pNombreCliente", SqlDbType = SqlDbType.VarChar, Value = certificado.NombreCliente });
                parametros.Add(new SqlParameter { ParameterName = "@pValorPaquete", SqlDbType = SqlDbType.Decimal, Value = certificado.ValorPaquete });
                parametros.Add(new SqlParameter { ParameterName = "@pPagoInicial", SqlDbType = SqlDbType.Decimal, Value = certificado.PagoInicial });
                parametros.Add(new SqlParameter { ParameterName = "@pMontoMensualidad", SqlDbType = SqlDbType.Decimal, Value = certificado.MontoMensualidad });
                parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = SqlDbType.Int, Value = certificado.Estatus });
                parametros.Add(new SqlParameter { ParameterName = "@pTipo", SqlDbType = SqlDbType.Int, Value = certificado.TipoCertificado });

                DataSet ds = dac.Fill("Certificados_Insert", parametros);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        idCertificado = int.Parse(dr["id_certificado"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return idCertificado;
        }

        public List<CertificadoModel> GetAllCertificados()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<CertificadoModel>();
            try
            {
                DataSet ds = dac.Fill("Certificados_GetAll");
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new CertificadoModel
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Folio = int.Parse(dr["Folio"].ToString()),
                            IdVendedor = int.Parse(dr["IdVendedor"].ToString()),
                            NombreCliente = dr["NombreCliente"].ToString(),
                            ValorPaquete = decimal.Parse(dr["ValorPaquete"].ToString()),
                            PagoInicial = decimal.Parse(dr["PagoInicial"].ToString()),
                            MontoMensualidad = decimal.Parse(dr["MontoMensualidad"].ToString()),
                            FechaRegistro = dr["FechaRegistro"].ToString(),
                            Estatus = int.Parse(dr["Estatus"].ToString()),
                            FechaActualizacion = dr["FechaActualizacion"].ToString(),
                            DescripcionTipo = dr["TipoCertificado"].ToString(),
                            TotalAbonado = decimal.Parse(dr["TotalAbonado"].ToString()),
                            SaldoPendiente = decimal.Parse(dr["Restante"].ToString())

                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }

        public List<CertificadoModel> GetCertificadoById(int id)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<CertificadoModel>();

            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = id });

            try
            {
                DataSet ds = dac.Fill("Certificados_GetById", parametros);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new CertificadoModel
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Folio = int.Parse(dr["Folio"].ToString()),
                            IdVendedor = int.Parse(dr["IdVendedor"].ToString()),
                            NombreCliente = dr["NombreCliente"].ToString(),
                            ValorPaquete = decimal.Parse(dr["ValorPaquete"].ToString()),
                            PagoInicial = decimal.Parse(dr["PagoInicial"].ToString()),
                            MontoMensualidad = decimal.Parse(dr["MontoMensualidad"].ToString()),
                            FechaRegistro = dr["FechaRegistro"].ToString(),
                            Estatus = int.Parse(dr["Estatus"].ToString()),
                            FechaActualizacion = dr["FechaActualizacion"].ToString(),
                            VendedorNombre = dr["nombre"].ToString(),
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }

        public CertificadoAbonoInsertResponse InsertCertificadoAbono(InsertCertificadoAbonoModel abono)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var response = new CertificadoAbonoInsertResponse();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdCertificado", SqlDbType = SqlDbType.Int, Value = abono.IdCertificado });
                parametros.Add(new SqlParameter { ParameterName = "@pMonto", SqlDbType = SqlDbType.Decimal, Value = abono.Monto });
                parametros.Add(new SqlParameter { ParameterName = "@pFormaPago", SqlDbType = SqlDbType.Int, Value = abono.FormaPago });
                parametros.Add(new SqlParameter
                {
                    ParameterName = "@pReferencia",
                    SqlDbType = SqlDbType.VarChar,
                    Value = string.IsNullOrWhiteSpace(abono.Referencia) ? DBNull.Value : (object)abono.Referencia
                });
                parametros.Add(new SqlParameter
                {
                    ParameterName = "@pObservaciones",
                    SqlDbType = SqlDbType.VarChar,
                    Value = string.IsNullOrWhiteSpace(abono.Observaciones) ? DBNull.Value : (object)abono.Observaciones
                });
                parametros.Add(new SqlParameter
                {
                    ParameterName = "@pIdUsuario",
                    SqlDbType = SqlDbType.Int,
                    Value = abono.IdUsuario.HasValue ? (object)abono.IdUsuario.Value : DBNull.Value
                });

                DataSet ds = dac.Fill("CertificadosAbonos_Insert", parametros);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        response.Mensaje = dr["mensaje"].ToString();
                        response.IdAbono = int.Parse(dr["id_abono"].ToString());
                        response.IdCertificado = int.Parse(dr["id_certificado"].ToString());
                        response.FolioAbono = int.Parse(dr["folio_abono"].ToString());
                        response.SaldoAnterior = decimal.Parse(dr["saldo_anterior"].ToString());
                        response.MontoAbono = decimal.Parse(dr["monto_abono"].ToString());
                        response.SaldoActual = decimal.Parse(dr["saldo_actual"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }

            return response;
        }

        public List<CertificadoAbonoModel> GetCertificadoAbonosByCertificado(int idCertificado)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<CertificadoAbonoModel>();

            parametros.Add(new SqlParameter { ParameterName = "@pIdCertificado", SqlDbType = SqlDbType.Int, Value = idCertificado });

            try
            {
                DataSet ds = dac.Fill("CertificadosAbonos_GetByCertificado", parametros);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new CertificadoAbonoModel
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            IdCertificado = int.Parse(dr["IdCertificado"].ToString()),
                            FolioAbono = int.Parse(dr["FolioAbono"].ToString()),
                            FechaAbono = dr["FechaAbono"].ToString(),
                            Monto = decimal.Parse(dr["Monto"].ToString()),
                            FormaPago = int.Parse(dr["FormaPago"].ToString()),
                            FormaPagoDescripcion = dr["FormaPagoDescripcion"].ToString(),
                            Referencia = dr["Referencia"].ToString(),
                            Observaciones = dr["Observaciones"].ToString(),
                            IdUsuario = string.IsNullOrWhiteSpace(dr["IdUsuario"].ToString()) ? null : (int?)int.Parse(dr["IdUsuario"].ToString()),
                            Estatus = int.Parse(dr["Estatus"].ToString()),
                            FechaRegistro = dr["FechaRegistro"].ToString(),
                            FechaActualizacion = dr["FechaActualizacion"].ToString()
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }

        public List<CertificadoEstadoCuentaModel> GetEstadoCuentaCertificado(int idCertificado)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<CertificadoEstadoCuentaModel>();

            parametros.Add(new SqlParameter { ParameterName = "@pIdCertificado", SqlDbType = SqlDbType.Int, Value = idCertificado });

            try
            {
                DataSet ds = dac.Fill("Certificados_GetEstadoCuenta", parametros);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new CertificadoEstadoCuentaModel
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Folio = int.Parse(dr["Folio"].ToString()),
                            NombreCliente = dr["NombreCliente"].ToString(),
                            IdVendedor = int.Parse(dr["IdVendedor"].ToString()),
                            ValorPaquete = decimal.Parse(dr["ValorPaquete"].ToString()),
                            PagoInicial = decimal.Parse(dr["PagoInicial"].ToString()),
                            TotalAbonado = decimal.Parse(dr["TotalAbonado"].ToString()),
                            SaldoPendiente = decimal.Parse(dr["SaldoPendiente"].ToString()),
                            MontoMensualidad = decimal.Parse(dr["MontoMensualidad"].ToString()),
                            Estatus = int.Parse(dr["Estatus"].ToString()),
                            EstatusDescripcion = dr["EstatusDescripcion"].ToString(),
                            FechaRegistro = dr["FechaRegistro"].ToString(),
                            FechaActualizacion = dr["FechaActualizacion"].ToString()
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }

        public List<CertificadoAbonoReporteModel> GetReporteAbonos(string fechaInicial, string fechaFinal)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<CertificadoAbonoReporteModel>();

            parametros.Add(new SqlParameter { ParameterName = "@pFechaInicial", SqlDbType = SqlDbType.VarChar, Value = fechaInicial });
            parametros.Add(new SqlParameter { ParameterName = "@pFechaFinal", SqlDbType = SqlDbType.VarChar, Value = fechaFinal });

            try
            {
                DataSet ds = dac.Fill("CertificadosAbonos_GetReporte", parametros);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new CertificadoAbonoReporteModel
                        {
                            IdAbono = int.Parse(dr["IdAbono"].ToString()),
                            IdCertificado = int.Parse(dr["IdCertificado"].ToString()),
                            FolioCertificado = int.Parse(dr["FolioCertificado"].ToString()),
                            FolioAbono = int.Parse(dr["FolioAbono"].ToString()),
                            FechaAbono = dr["FechaAbono"].ToString(),
                            NombreCliente = dr["NombreCliente"].ToString(),
                            IdVendedor = int.Parse(dr["IdVendedor"].ToString()),
                            ValorPaquete = decimal.Parse(dr["ValorPaquete"].ToString()),
                            PagoInicial = decimal.Parse(dr["PagoInicial"].ToString()),
                            MontoAbono = decimal.Parse(dr["MontoAbono"].ToString()),
                            FormaPago = int.Parse(dr["FormaPago"].ToString()),
                            FormaPagoDescripcion = dr["FormaPagoDescripcion"].ToString(),
                            Referencia = dr["Referencia"].ToString(),
                            Observaciones = dr["Observaciones"].ToString(),
                            IdUsuario = string.IsNullOrWhiteSpace(dr["IdUsuario"].ToString()) ? null : (int?)int.Parse(dr["IdUsuario"].ToString()),
                            TipoCertificado = int.Parse(dr["TipoCertificado"].ToString()),
                            TipoCertificadoDescripcion = dr["TipoCertificadoDescripcion"].ToString(),
                            EstatusAbono = int.Parse(dr["EstatusAbono"].ToString()),
                            EstatusAbonoDescripcion = dr["EstatusAbonoDescripcion"].ToString(),
                            TotalAbonadoCertificado = decimal.Parse(dr["TotalAbonadoCertificado"].ToString()),
                            RestanteCertificado = decimal.Parse(dr["RestanteCertificado"].ToString())
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }

        public byte[] GenerarCertificadoPdf(int idCertificado)
        {
            var certificados = GetCertificadoById(idCertificado);
            if (certificados.Count == 0)
            {
                throw new Exception("No se encontró el certificado solicitado.");
            }

            var certificado = certificados[0];
            var estadoCuenta = GetEstadoCuentaCertificado(idCertificado);
            var estado = estadoCuenta.Count > 0 ? estadoCuenta[0] : null;

            string rutaPlantilla = Path.Combine(Directory.GetCurrentDirectory(), "Certificado_Capillas_del_Bosque.pdf");
            if (!File.Exists(rutaPlantilla))
            {
                throw new Exception("No se encontró la plantilla del certificado.");
            }

            using var outputStream = new MemoryStream();
            using var reader = new PdfReader(rutaPlantilla);
            using var writer = new PdfWriter(outputStream);
            using var pdfDocument = new PdfDocument(reader, writer);

            bool informacionInsertada = false;
            var acroForm = PdfAcroForm.GetAcroForm(pdfDocument, false);
            if (acroForm != null)
            {
                var fields = acroForm.GetAllFormFields();
                if (fields != null && fields.Count > 0)
                {
                    informacionInsertada = true;

                    SetFirstExistingField(fields, certificado.Folio.ToString(), "folio", "nofolio", "numerofolio");
                    SetFirstExistingField(fields, certificado.NombreCliente, "nombrecliente", "cliente", "nombre");
                    SetFirstExistingField(fields, certificado.IdVendedor.ToString(), "idvendedor", "vendedor");
                    SetFirstExistingField(fields, FormatCurrency(certificado.ValorPaquete), "valorpaquete", "totalpaquete", "paquete");
                    SetFirstExistingField(fields, FormatCurrency(certificado.PagoInicial), "pagoinicial", "enganche");
                    SetFirstExistingField(fields, FormatCurrency(certificado.MontoMensualidad), "montomensualidad", "mensualidad");
                    SetFirstExistingField(fields, estado != null ? FormatCurrency(estado.TotalAbonado) : "0.00", "totalabonado", "abonado");
                    SetFirstExistingField(fields, estado != null ? FormatCurrency(estado.SaldoPendiente) : "0.00", "saldopendiente", "saldo");
                    SetFirstExistingField(fields, estado != null ? estado.EstatusDescripcion : certificado.Estatus.ToString(), "estatus", "estatusdescripcion");
                    SetFirstExistingField(fields, certificado.FechaRegistro, "fecharegistro", "fecha");
                    SetFirstExistingField(fields, certificado.FechaActualizacion, "fechaactualizacion");

                    acroForm.FlattenFields();
                }
            }

            if (!informacionInsertada)
            {
                var page = pdfDocument.GetFirstPage();
                var canvas = new Canvas(new PdfCanvas(page), page.GetPageSize());
                var font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                canvas.SetFont(font).SetFontSize(11);
                canvas.ShowTextAligned(" " + certificado.Folio, 260, 545, TextAlignment.LEFT);
                canvas.ShowTextAligned(" " + certificado.NombreCliente, 130, 430, TextAlignment.LEFT);
                canvas.ShowTextAligned(" " + certificado.VendedorNombre, 130, 380, TextAlignment.LEFT);
                canvas.ShowTextAligned(" " + FormatCurrency(certificado.ValorPaquete), 150, 270, TextAlignment.LEFT);
                canvas.ShowTextAligned(" " + FormatCurrency(certificado.PagoInicial), 310, 270, TextAlignment.LEFT);
                canvas.ShowTextAligned(" " + FormatCurrency(certificado.MontoMensualidad), 480, 270, TextAlignment.LEFT);
                canvas.ShowTextAligned(" " + certificado.FechaRegistro, 110, 155, TextAlignment.LEFT);
                canvas.Close();
            }

            pdfDocument.Close();
            return outputStream.ToArray();
        }

        private static string FormatCurrency(decimal amount)
        {
            return amount.ToString("N2");
        }

        private static void SetFirstExistingField(IDictionary<string, PdfFormField> fields, string value, params string[] aliases)
        {
            foreach (var alias in aliases)
            {
                var targetField = fields.FirstOrDefault(x => NormalizeFieldName(x.Key) == NormalizeFieldName(alias));
                if (!string.IsNullOrWhiteSpace(targetField.Key))
                {
                    targetField.Value.SetValue(value ?? string.Empty);
                    return;
                }
            }
        }

        private static string NormalizeFieldName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return string.Empty;
            }

            return name
                .Trim()
                .Replace("_", string.Empty)
                .Replace("-", string.Empty)
                .Replace(" ", string.Empty)
                .ToLowerInvariant();
        }
    }
}