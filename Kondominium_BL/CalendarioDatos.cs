using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_BL
{
   public class CalendarioDatos
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<CalendarioEntity> GetAll()
        {
            var query = context.calendario.Select(cal => new CalendarioEntity
            {
                CalendarioId = cal.CalendarioId,
                Fecha = cal.Fecha,
                HoraInicio = cal.HoraInicio,
                HoraFin = cal.HoraFin,
                LugarId = cal.LugarId,
                ClienteId = cal.ClienteId,
                PropiedadId = cal.PropiedadId,
                TituloEvento = cal.TituloEvento,
                DescripcionEvento = cal.DescripcionEvento,
                FechaDeCreacion = (DateTime)cal.FechaDeCreacion,
                FechaDeModificacion = cal.FechaDeModificacion,
                CreadoPor = cal.CreadoPor,
                ModificadoPor = cal.ModificadoPor,
                ClienteNombre = string.Concat(cal.clientes.Nombres, " ", cal.clientes.Apellidos),
                VPropiedad = string.Concat(cal.propiedades.PoligonoId, "-", cal.propiedades.Casa.ToString(), cal.propiedades.CasaLetra),
                VLugar = cal.lugares.Nombre
            });

            return query.ToList();
        }
        public CalendarioEntity GetById(int Id)
        {
            var query = context.calendario.Where( x => x.CalendarioId == Id ).Select(cal => new CalendarioEntity
            {
                CalendarioId = cal.CalendarioId,
                Fecha = cal.Fecha,
                HoraInicio = cal.HoraInicio,
                HoraFin = cal.HoraFin,
                LugarId = cal.LugarId,
                ClienteId = cal.ClienteId,
                PropiedadId = cal.PropiedadId,
                TituloEvento = cal.TituloEvento,
                DescripcionEvento = cal.DescripcionEvento,
                FechaDeCreacion = (DateTime)cal.FechaDeCreacion,
                FechaDeModificacion = cal.FechaDeModificacion,
                CreadoPor = cal.CreadoPor,
                ModificadoPor = cal.ModificadoPor,
                ClienteNombre = string.Concat(cal.clientes.Nombres, " ", cal.clientes.Apellidos),
                VPropiedad = string.Concat(cal.propiedades.PoligonoId, "-", cal.propiedades.Casa.ToString(), cal.propiedades.CasaLetra),
                VLugar = cal.lugares.Nombre
            });
                        
            return query.FirstOrDefault();
        }

        public (CalendarioEntity, Resultado) Save(CalendarioEntity model)
        {
            try
            {
                using (var cn = new Kondominium_DAL.KEntities())
                {
                    var modlExist = cn.calendario.Where(x => x.CalendarioId == model.CalendarioId).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.calendario();

                    if (modlExist != null)
                    {
                        //TODO: Esta parte del eliminado Agregarlo a los demas metodos de Datos
                        modlNew = modlExist;
                    }


                    modlNew.Fecha = model.Fecha;
                    modlNew.HoraInicio = model.HoraInicio;
                    modlNew.HoraFin = model.HoraFin;
                    modlNew.LugarId = model.LugarId;
                    modlNew.ClienteId = model.ClienteId;
                    modlNew.PropiedadId = model.PropiedadId;
                    modlNew.TituloEvento = model.TituloEvento;
                    modlNew.DescripcionEvento = model.DescripcionEvento;
                    modlNew.FechaDeModificacion = DateTime.Now;                   
                    modlNew.ModificadoPor = model.ModificadoPor;



                    if (modlExist == null)
                    {
                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;

                        cn.calendario.Add(modlNew);
                    }
                    cn.SaveChanges();

                    model.CalendarioId = modlNew.CalendarioId;

                }

                return (GetById(model.CalendarioId), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {
                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "El registro no pudo ser guardado. \n" + ex.Message });

            }
        }

        public Resultado Delete(CalendarioEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.calendario.Where(x => x.CalendarioId == model.CalendarioId).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.calendario.Remove(modlExist);
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

                    var modlExist = ContextP.calendario.Where(x => x.CalendarioId == Id).FirstOrDefault();
                    // var modlNew = new Kondominium_DAL.Calles();


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

        public List<CalendarioEntity> GetByStarEndDate(DateTime Inicio, DateTime Fin)
        {
            var query = context.calendario.Where( cal => cal.Fecha >= Inicio && cal.Fecha <= Fin).OrderBy(x => x.Fecha  ).Select( cal => new CalendarioEntity
                        {
                            CalendarioId = cal.CalendarioId,
                            Fecha = cal.Fecha,
                            HoraInicio = cal.HoraInicio,
                            HoraFin = cal.HoraFin,
                            LugarId = cal.LugarId,
                            ClienteId = cal.ClienteId,
                            PropiedadId = cal.PropiedadId,
                            TituloEvento = cal.TituloEvento,
                            DescripcionEvento = cal.DescripcionEvento,
                            FechaDeCreacion = (DateTime)cal.FechaDeCreacion,
                            FechaDeModificacion = cal.FechaDeModificacion,
                            CreadoPor = cal.CreadoPor,
                            ModificadoPor = cal.ModificadoPor,
                            ClienteNombre =  cal.clientes.Nombres + " " + cal.clientes.Apellidos,
                            VPropiedad = string.Concat( cal.propiedades.PoligonoId , "-",   cal.propiedades.Casa.ToString() ,  cal.propiedades.CasaLetra),
                            VLugar = cal.lugares.Nombre
            });

            return query.ToList();
        }

    }
}
