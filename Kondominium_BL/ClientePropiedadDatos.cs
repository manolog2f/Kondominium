using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_BL
{
  public  class ClientePropiedadDatos
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<ClientePropiedadEntity> GetAll()
        {
            var query = context.clientepropiedad
                        .Select(p => new ClientePropiedadEntity
                        {
                            Cliente = (new ClientesEntity
                            {
                                Apellidos = p.clientes.Apellidos,
                                ClienteId = p.ClienteId,
                                Nombres = p.clientes.Nombres,
                                Documento1 = p.clientes.Documento1,
                                Documento2 = p.clientes.Documento2,
                                Documento3 = p.clientes.Documento3,
                                Email = p.clientes.Email,
                                TelefonoFijo = p.clientes.TelefonoFijo,
                                TelefonoMovil = p.clientes.TelefonoMovil,
                                Eliminado = p.clientes.Eliminado,
                            }
                           ),
                            Propiedad = (new PropiedadesEntity
                            {

                                PropiedadId = p.propiedades.PropiedadId,
                                TipoDePropiedad = p.propiedades.TipoDePropiedad,
                                Descripcion = p.propiedades.Descripcion,
                                Casa = p.propiedades.Casa,
                                PoligonoId = p.propiedades.PoligonoId,
                                ArancelId = p.propiedades.ArancelId,
                                Eliminado = p.propiedades.Eliminado,

                                TipoDePropiedadDesc = ((TipodePropiedades)p.propiedades.TipoDePropiedad).ToString(),

                                ArancelDescripcion = p.propiedades.aranceles.Descripcion,
                                PoligonoDescripcion = p.propiedades.poligonos.PoligonoDescripcion,
                                AvenidaDescripcion = p.propiedades.avenida1.AvenidaDescripcion,
                                CalleDescripcion = p.propiedades.calles.CalleDescripcion,
                                SendaDescripcion = p.propiedades.sendas.SendaDescripcion,
                                Calle = p.propiedades.Calle,
                                Avenida = p.propiedades.Avenida,
                                Senda = p.propiedades.Senda

                            }),
                            ClienteId = p.ClienteId,
                            PropiedadId = p.PropiedadId,
                            Justificacion = p.Justificacion,
                            TipoCliente =  p.TipoCliente,
                            FechaDeCreacion = (DateTime)p.FechaDeCreacion,
                            FechaDeModificacion = p.FechaDeModificacion,
                            CreadoPor = p.CreadoPor,
                            ModificadoPor = p.ModificadoPor

                        });


            return query.ToList();
        }
        public ClientePropiedadEntity GetById(int ClienteId, int propiedadId)
        {
            var query = context.clientepropiedad
                        .Where( p => p.ClienteId == ClienteId && p.PropiedadId == propiedadId)
                        .Select( p =>  new ClientePropiedadEntity
                        {
                            Cliente = (  new ClientesEntity
                                { 
                                    Apellidos = p.clientes.Apellidos,
                                    ClienteId = p.ClienteId, 
                                    Nombres = p.clientes.Nombres,
                                    Documento1 = p.clientes.Documento1,
                                    Documento2 = p.clientes.Documento2,
                                    Documento3 = p.clientes.Documento3,
                                    Email = p.clientes.Email,
                                    TelefonoFijo = p.clientes.TelefonoFijo,
                                    TelefonoMovil = p.clientes.TelefonoMovil,
                                    Eliminado = p.clientes.Eliminado,
                                }
                            ),
                            Propiedad = ( new PropiedadesEntity {

                                PropiedadId = p.propiedades.PropiedadId,
                                TipoDePropiedad = p.propiedades.TipoDePropiedad,
                                Descripcion = p.propiedades.Descripcion,
                                Casa = p.propiedades.Casa,
                                PoligonoId = p.propiedades.PoligonoId,
                                ArancelId = p.propiedades.ArancelId,
                                Eliminado = p.propiedades.Eliminado,

                                TipoDePropiedadDesc = ((TipodePropiedades)p.propiedades.TipoDePropiedad).ToString(),

                                ArancelDescripcion = p.propiedades.aranceles.Descripcion,
                                PoligonoDescripcion = p.propiedades.poligonos.PoligonoDescripcion,
                                AvenidaDescripcion = p.propiedades.avenida1.AvenidaDescripcion,
                                CalleDescripcion = p.propiedades.calles.CalleDescripcion,
                                SendaDescripcion = p.propiedades.sendas.SendaDescripcion,
                                Calle = p.propiedades.Calle,
                                Avenida = p.propiedades.Avenida,
                                Senda = p.propiedades.Senda

                            }),
                            ClienteId = p.ClienteId,
                            PropiedadId = p.PropiedadId,
                            Justificacion = p.Justificacion,
                            TipoCliente = p.TipoCliente,
                            FechaDeCreacion = (DateTime)p.FechaDeCreacion,
                            FechaDeModificacion = p.FechaDeModificacion,
                            CreadoPor = p.CreadoPor,
                            ModificadoPor = p.ModificadoPor
                            
                        });

            return query.FirstOrDefault();
        }

        public (ClientePropiedadEntity, Resultado) Save(ClientePropiedadEntity model)
        {
            try
            {
                using (var cn = new Kondominium_DAL.KEntities())
                {
                    var modlExist = cn.clientepropiedad.Where(x => x.ClienteId == model.ClienteId && x.PropiedadId == model.PropiedadId).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.clientepropiedad();

                    if (modlExist != null)
                    {
                        //if (modlExist.// Elininado == true)
                        //    return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "Regstro ha sido marcado como // Elininado, no se puede actualizar" });

                        modlNew = modlExist;
                    }

                    modlNew.ClienteId = model.ClienteId;
                    modlNew.PropiedadId = model.PropiedadId;
                    modlNew.Justificacion = model.Justificacion;
                    modlNew.TipoCliente = model.TipoCliente;
                  //  modlNew.// Elininado = model.// Elininado;
                    modlNew.FechaDeModificacion = DateTime.Now;
                    modlNew.ModificadoPor = model.ModificadoPor;



                    if (modlExist == null)
                    {
                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;

                        cn.clientepropiedad.Add(modlNew);
                    }
                    cn.SaveChanges();

                    model.ClienteId = modlNew.ClienteId;
                    model.PropiedadId = modlNew.PropiedadId;

                }

                return (GetById(model.ClienteId, model.PropiedadId), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {
                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "El registro no pudo ser guardado. \n" + ex.Message });

            }
        }

        public Resultado Delete(ClientePropiedadEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.clientepropiedad.Where(x => x.ClienteId == model.ClienteId && x.PropiedadId == model.PropiedadId).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.clientepropiedad.Remove(modlExist);
                        ContextP.SaveChanges();
                        return new Resultado { Codigo = 0, Mensaje = "Exito, Registro // Elininado permanentemente" };
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
        //public Resultado SetDelete(string Id, string UserId)
        //{
        //    try
        //    {
        //        using (var ContextP = new Kondominium_DAL.KEntities())
        //        {

        //            var modlExist = ContextP.clientepropiedad.Where(x => x.ClienteId == Id).FirstOrDefault();
        //            // var modlNew = new Kondominium_DAL.clientepropiedad();


        //            if (modlExist == null)
        //                return (new Resultado { Codigo = CodigosMensaje.No_Existe, Mensaje = "Registro no Existe" });

        //         //   modlExist.// Elininado = true;

        //            modlExist.FechaDeModificacion = DateTime.Now;
        //            modlExist.ModificadoPor = UserId;
        //            ContextP.SaveChanges();
        //        }

        //        return (new Resultado { Codigo = 0, Mensaje = "Registro // Elininado con exito" });
        //    }
        //    catch (Exception ex)
        //    {

        //        return (new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logro Eliminar el Registro \n" + ex.Message });
        //    }

        //}
    }
}
