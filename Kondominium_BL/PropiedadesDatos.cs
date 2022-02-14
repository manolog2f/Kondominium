using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Kondominium_BL
{
    public class PropiedadesDatos
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<PropiedadesEntity> GetAll(bool VerEliminado = false)
        {
            var query = context.propiedades.Where(x => (VerEliminado ? x.Eliminado == x.Eliminado : x.Eliminado == false)).Select(x => new PropiedadesEntity
            {
                PropiedadId = x.PropiedadId,
                TipoDePropiedad = x.TipoDePropiedad,
                Descripcion = x.Descripcion,
                Casa = x.Casa,
                PoligonoId = x.PoligonoId,
                ArancelId = x.ArancelId,
                FechaDeCreacion = x.FechaDeCreacion,
                FechaDeModificacion = x.FechaDeModificacion,
                CreadoPor = x.CreadoPor,
                ModificadoPor = x.ModificadoPor,
                Eliminado = x.Eliminado,

                TipoDePropiedadDesc = ((TipodePropiedades)x.TipoDePropiedad).ToString(),

                ArancelDescripcion = x.aranceles.Descripcion,
                PoligonoDescripcion = x.poligonos.PoligonoDescripcion,
                AvenidaDescripcion = x.avenida1.AvenidaDescripcion,
                CalleDescripcion = x.calles.CalleDescripcion,
                SendaDescripcion = x.sendas.SendaDescripcion,
                Calle = x.Calle,
                Avenida = x.Avenida,
                Senda = x.Senda,
                CasaLetra = x.CasaLetra,

                Alameda = x.Alameda,
                AlamedaDescripcion = x.alameda1.AlamedaDescripcion




            });


            return query.ToList();
        }

        public List<PropiedadesEntity> GetAllByClienteId(int ClienteId, bool VerEliminado = false)
        {
            var query = from p in context.propiedades
                        join cp in context.clientepropiedad on p.PropiedadId equals cp.PropiedadId
                        where p.Eliminado == (VerEliminado ? p.Eliminado : false) && cp.ClienteId == ClienteId
                        select new PropiedadesEntity
                        {
                            PropiedadId = p.PropiedadId,
                            TipoDePropiedad = p.TipoDePropiedad,
                            Descripcion = p.Descripcion,
                            Casa = p.Casa,
                            PoligonoId = p.PoligonoId,
                            ArancelId = p.ArancelId,
                            FechaDeCreacion = p.FechaDeCreacion,
                            FechaDeModificacion = p.FechaDeModificacion,
                            CreadoPor = p.CreadoPor,
                            ModificadoPor = p.ModificadoPor,
                            Eliminado = p.Eliminado,
                            TipoDePropiedadDesc = ((TipodePropiedades)p.TipoDePropiedad).ToString(),
                            ArancelDescripcion = p.aranceles.Descripcion,
                            PoligonoDescripcion = p.poligonos.PoligonoDescripcion,
                            AvenidaDescripcion = p.avenida1.AvenidaDescripcion,
                            CalleDescripcion = p.calles.CalleDescripcion,
                            SendaDescripcion = p.sendas.SendaDescripcion,
                            Calle = p.Calle,
                            Avenida = p.Avenida,
                            Senda = p.Senda,
                            CasaLetra = p.CasaLetra,

                            Alameda = p.Alameda,
                            AlamedaDescripcion = p.alameda1.AlamedaDescripcion
                        };


            return query.ToList();
        }

        public PropiedadesEntity GetById(int Id)
        {
            var query = context.propiedades.Where(x => x.PropiedadId == Id).
                        Select(x => new PropiedadesEntity
                        {
                            PropiedadId = x.PropiedadId,
                            TipoDePropiedad = x.TipoDePropiedad,
                            Descripcion = x.Descripcion,
                            Casa = x.Casa,
                            PoligonoId = x.PoligonoId,
                            ArancelId = x.ArancelId,
                            FechaDeCreacion = x.FechaDeCreacion,
                            FechaDeModificacion = x.FechaDeModificacion,
                            CreadoPor = x.CreadoPor,
                            ModificadoPor = x.ModificadoPor,
                            Eliminado = x.Eliminado,

                            TipoDePropiedadDesc = ((TipodePropiedades)x.TipoDePropiedad).ToString(),

                            ArancelDescripcion = x.aranceles.Descripcion,
                            PoligonoDescripcion = x.poligonos.PoligonoDescripcion,
                            AvenidaDescripcion = x.avenida1.AvenidaDescripcion,
                            CalleDescripcion = x.calles.CalleDescripcion,
                            SendaDescripcion = x.sendas.SendaDescripcion,
                            Calle = x.Calle,
                            Avenida = x.Avenida,
                            Senda = x.Senda,
                            CasaLetra = x.CasaLetra
                            ,

                            Alameda = x.Alameda,
                            AlamedaDescripcion = x.alameda1.AlamedaDescripcion

                        });

            return query.FirstOrDefault();
        }

        public DataTable DataTable(int Id)
        {

            var dTabla = new DataTable();

            using (var _context = new Kondominium_DAL.KEntities())
            {
                dTabla = ZoomTechUtils.ZMTDriveDataTable.ToDataTable(_context.propiedades.Where( x=> x.PropiedadId == Id).ToList());
            }

            return dTabla;
        }
        public (PropiedadesEntity, Resultado) Save(PropiedadesEntity model)
        {
            try
            {
                using (var cn = new Kondominium_DAL.KEntities())
                {
                    var modlExist = cn.propiedades.Where(x => x.PropiedadId == model.PropiedadId).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.propiedades();

                    if (modlExist != null)
                    {
                        if (modlExist.Eliminado == true)
                            return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "Regstro ha sido marcado como eliminado, no se puede actualizar" });

                        modlNew = modlExist;
                    }
                    // modlNew.PropiedadId = model.PropiedadId;
                    modlNew.TipoDePropiedad = model.TipoDePropiedad;
                    modlNew.Descripcion = model.Descripcion;
                    modlNew.Casa = model.Casa;
                    modlNew.CasaLetra = model.CasaLetra;

                    modlNew.PoligonoId = model.PoligonoId;
                    modlNew.ArancelId = model.ArancelId;
                    modlNew.Calle = model.Calle;
                    modlNew.Avenida = model.Avenida;
                    modlNew.Senda = model.Senda;

                    modlNew.FechaDeModificacion = DateTime.Now;

                    modlNew.ModificadoPor = model.ModificadoPor;
                    modlNew.Eliminado = model.Eliminado;

                    modlNew.Alameda = model.Alameda;


                    if (modlExist == null)
                    {
                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;

                        cn.propiedades.Add(modlNew);
                    }
                    cn.SaveChanges();

                    model.PropiedadId = modlNew.PropiedadId;
                }

                return (GetById(model.PropiedadId), new Resultado { Codigo = 0, Mensaje = "Exito" });

            }
            catch (Exception ex)
            {

                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logro almacenar el Registro \n" + ex.Message });
            }
        }

        public Resultado Delete(PropiedadesEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.propiedades.Where(x => x.PropiedadId == model.PropiedadId).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.propiedades.Remove(modlExist);
                        ContextP.SaveChanges();
                        return new Resultado { Codigo = 0, Mensaje = "Exito, Registro eliminado permanentemente" };
                    }
                    else
                        return new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "Registro no encontrado" };
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

                    var modlExist = ContextP.propiedades.Where(x => x.PropiedadId == Id).FirstOrDefault();
                    // var modlNew = new Kondominium_DAL.propiedades();


                    if (modlExist == null)
                        return (new Resultado { Codigo = CodigosMensaje.No_Existe, Mensaje = "Registro no Existe" });

                    modlExist.Eliminado = true;

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

        public List<string> Letras()
        {

            var rlist = new List<string>();

            rlist.Add(" ");
            rlist.Add("A");
            rlist.Add("B");
            rlist.Add("C");
            rlist.Add("D");
            rlist.Add("E");
            rlist.Add("F");
            rlist.Add("G");
            rlist.Add("H");
            rlist.Add("I");
            rlist.Add("J");
            rlist.Add("K");
            rlist.Add("L");
            rlist.Add("M");
            rlist.Add("N");
            rlist.Add("O");
            rlist.Add("P");
            rlist.Add("Q");
            rlist.Add("R");
            rlist.Add("S");
            rlist.Add("T");
            rlist.Add("U");
            rlist.Add("V");
            rlist.Add("W");
            rlist.Add("X");
            rlist.Add("Y");
            rlist.Add("Z");

            return rlist;
        }

        public List<string> Parentesco()
        {

            var rlist = new List<string>();

            rlist.Add("Padre");
            rlist.Add("Madre");
            rlist.Add("Hijo");
            rlist.Add("Hija");
            rlist.Add("Suegra");
            rlist.Add("Suegro");
            rlist.Add("Yerno");
            rlist.Add("Nuera");
            rlist.Add("Abuelo");
            rlist.Add("Abuela");
            rlist.Add("Nieto");
            rlist.Add("Nieta");
            rlist.Add("Hermano");
            rlist.Add("Hermana");
            rlist.Add("Cuñado");
            rlist.Add("Cuñada");
            rlist.Add("Tio");
            rlist.Add("Tia");
            rlist.Add("Sobrino");
            rlist.Add("Sobrina");
            rlist.Add("Esposo");
            rlist.Add("Esposa");
            rlist.Add("Amigo");
            rlist.Add("Otro");

            return rlist;
        }
    }
}
