using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kondominium_BL
{
    public class ContratoDatos
    {

        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<ContratosEntity> GetAll(bool VerEliminado = false)
        {
            var query = context.contratos.Select(x => new ContratosEntity
            {
                Activo = x.Activo,
                Categoria = x.Categoria,
                ClienteId = x.ClienteId,
                ContratoId = x.ContratoId,
                CreadoPor = x.CreadoPor,
                DiaMesaFacturar = x.DiaMesaFacturar,
                FechaDeCreacion = x.FechaDeCreacion,
                FechaDeModificacion = x.FechaDeModificacion,
                FechaFin = x.FechaFin,
                FechaInicio = x.FechaInicio,
                Frecuencia = x.Frecuencia,
                ModificadoPor = x.ModificadoPor,
                PropiedadId = x.PropiedadId,
                TipoCliente = x.TipoCliente,

            });

            return query.ToList();
        }
        public ContratosEntity GetById(int Id)
        {
            var query = context.contratos.Where(x => x.ContratoId == Id).Select(x => new ContratosEntity
            {
                Activo = x.Activo,
                Categoria = x.Categoria,
                ClienteId = x.ClienteId,
                ContratoId = x.ContratoId,
                CreadoPor = x.CreadoPor,
                DiaMesaFacturar = x.DiaMesaFacturar,
                FechaDeCreacion = x.FechaDeCreacion,
                FechaDeModificacion = x.FechaDeModificacion,
                FechaFin = x.FechaFin,
                FechaInicio = x.FechaInicio,
                Frecuencia = x.Frecuencia,
                ModificadoPor = x.ModificadoPor,
                PropiedadId = x.PropiedadId,
                TipoCliente = x.TipoCliente,

            });

            return query.FirstOrDefault();
        }

        public (ContratosEntity, Resultado) Save(ContratosEntity model)
        {
            try
            {
                using (var cn = new Kondominium_DAL.KEntities())
                {
                    var modlExist = cn.contratos.Where(x => x.ContratoId == model.ContratoId).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.contratos();

                    if (modlExist != null)
                    {

                        modlNew = modlExist;
                    }

                    // modlNew.ContratoId = model.ContratoId;


                    modlNew.Activo = model.Activo;
                    modlNew.Categoria = model.Categoria;
                    modlNew.ClienteId = model.ClienteId;

                    modlNew.DiaMesaFacturar = model.DiaMesaFacturar;


                    modlNew.FechaFin = model.FechaFin;
                    modlNew.FechaInicio = model.FechaInicio;
                    modlNew.Frecuencia = model.Frecuencia;

                    modlNew.PropiedadId = model.PropiedadId;
                    modlNew.TipoCliente = model.TipoCliente;


                    modlNew.FechaDeModificacion = DateTime.Now;
                    modlNew.ModificadoPor = model.ModificadoPor;


                    if (modlExist == null)
                    {
                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;
                        cn.contratos.Add(modlNew);
                    }
                    cn.SaveChanges();

                    model.ContratoId = modlNew.ContratoId;

                }

                return (GetById(model.ContratoId), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {
                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "El registro no pudo ser guardado. \n" + ex.Message });

            }
        }

        public Resultado Delete(ContratosEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.contratos.Where(x => x.ContratoId == model.ContratoId).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.contratos.Remove(modlExist);
                        ContextP.SaveChanges();
                        return new Resultado { Codigo = 0, Mensaje = "Exito, Registro eliminado permanentemente" };
                    }
                    else
                        return new Resultado { Codigo = 0, Mensaje = "Registro no encontrado" };
                }
            }
            catch (Exception ex)
            {
                return new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logró eliminar el Registro \n" + ex.Message };

            }
        }
        public Resultado SetDelete(int Id, string UserId)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {

                    var modlExist = ContextP.contratos.Where(x => x.ContratoId == Id).FirstOrDefault();
                    // var modlNew = new Kondominium_DAL.Contratos();


                    if (modlExist == null)
                        return (new Resultado { Codigo = CodigosMensaje.No_Existe, Mensaje = "Registro no Existe" });

                    //modlExist.Eliminado = true;

                    modlExist.FechaDeModificacion = DateTime.Now;
                    modlExist.ModificadoPor = UserId;
                    ContextP.SaveChanges();
                }

                return (new Resultado { Codigo = 0, Mensaje = "Registro eliminado con exito" });
            }
            catch (Exception ex)
            {

                return (new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logro Eliminar el Registro \n" + ex.Message });
            }

        }
    }
}
