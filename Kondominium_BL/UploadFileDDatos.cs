using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_BL
{
    public class UploadFileDDatos
    {
        private Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();

        public Resultado Delete(UploadFileDEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.uploadfiled.Where(x => x.UploadFileDId == model.UploadFileDId).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.uploadfiled.Remove(modlExist);
                        ContextP.SaveChanges();
                        return new Resultado { Codigo = 0, Mensaje = "Exito Resgistro Eliminado Permanetemente" };
                    }
                    else
                        return new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "Registro no encontrado" };
                }
            }
            catch (Exception ex)
            {
                return new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logro eliminar el Registro \n" + ex.Message };
            }
        }

        public List<UploadFileDEntity> GetAll(bool VerEliminado = false)
        {
            var query = from a in context.uploadfiled
                        select new UploadFileDEntity
                        {
                            Banco = a.Banco,
                            VaucherNumber = a.VaucherNumber,
                            UploadFileDId = a.UploadFileDId,
                            BarraNPE = a.BarraNPE,
                            CodigoInterno = a.CodigoInterno,
                            Estatus = a.Estatus,
                            Fecha = a.Fecha,
                            FilaTexto = a.FilaTexto,
                            Hora = a.Hora,
                            Linea = a.Linea,
                            Mensaje = a.Mensaje,
                            Monto = a.Monto,
                            Tipo = a.Tipo,
                            UploadFileHId = a.UploadFileHId
                        };

            return query.ToList();
        }

        public UploadFileDEntity GetById(int UploadDetailId)
        {
            var query = from a in context.uploadfiled
                        where a.UploadFileDId == UploadDetailId
                        select new UploadFileDEntity
                        {
                            Banco = a.Banco,
                            VaucherNumber = a.VaucherNumber,
                            UploadFileDId = a.UploadFileDId,
                            BarraNPE = a.BarraNPE,
                            CodigoInterno = a.CodigoInterno,
                            Estatus = a.Estatus,
                            Fecha = a.Fecha,
                            FilaTexto = a.FilaTexto,
                            Hora = a.Hora,
                            Linea = a.Linea,
                            Mensaje = a.Mensaje,
                            Monto = a.Monto,
                            Tipo = a.Tipo,
                            UploadFileHId = a.UploadFileHId
                        };

            return query.FirstOrDefault();
        }

        public List<UploadFileDEntity> GetListById(int UploadHeaderId)
        {
            var query = from a in context.uploadfiled
                        where a.UploadFileHId == UploadHeaderId
                        select new UploadFileDEntity
                        {
                            Banco = a.Banco,
                            VaucherNumber = a.VaucherNumber,
                            UploadFileDId = a.UploadFileDId,
                            BarraNPE = a.BarraNPE,
                            CodigoInterno = a.CodigoInterno,
                            Estatus = a.Estatus,
                            Fecha = a.Fecha,
                            FilaTexto = a.FilaTexto,
                            Hora = a.Hora,
                            Linea = a.Linea,
                            Mensaje = a.Mensaje,
                            Monto = a.Monto,
                            Tipo = a.Tipo,
                            UploadFileHId = a.UploadFileHId
                        };

            return query.ToList();
        }

        public (UploadFileDEntity, Resultado) Save(UploadFileDEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.uploadfiled.Where(x => x.UploadFileDId == model.UploadFileDId).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.uploadfiled();

                    if (modlExist != null)
                    {
                        modlNew = modlExist;
                    }

                    modlNew.Banco = model.Banco;
                    modlNew.VaucherNumber = model.VaucherNumber;
                    modlNew.BarraNPE = model.BarraNPE;
                    modlNew.CodigoInterno = model.CodigoInterno;
                    modlNew.Estatus = model.Estatus;
                    modlNew.Fecha = model.Fecha;
                    modlNew.FilaTexto = model.FilaTexto;
                    modlNew.Hora = model.Hora;
                    modlNew.Linea = model.Linea;
                    modlNew.Mensaje = model.Mensaje;
                    modlNew.Monto = model.Monto;
                    modlNew.Tipo = model.Tipo;
                    modlNew.UploadFileHId = model.UploadFileHId;
                    modlNew.FechaProceso = DateTime.Now;

                    if (modlNew.UploadFileDId == 0)
                    {
                        ContextP.uploadfiled.Add(modlNew);
                    }
                    ContextP.SaveChanges();

                    model.UploadFileDId = modlNew.UploadFileDId;
                }

                return (GetById(model.UploadFileDId), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {
                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logro almacenar el Registro \n" + ex.Message });
            }
        }
    }
}