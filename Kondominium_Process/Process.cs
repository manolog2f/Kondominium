using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kondominium_BL;
using Kondominium_Entities;

namespace Kondominium_Process
{
    public class Process
    {
        private CuentasPorCobrarDatos obj_CuentasPorCobrarDatos = new CuentasPorCobrarDatos();
        private CuentasPorCobrarPagoDatos obj_CuentasPorCobrarPagoDatos = new CuentasPorCobrarPagoDatos();

        public (DataTable, bool) LeerArchivo(string ruta)
        {
            string codigo_banco = tools.GetUntilOrEmpty(ruta);
            DataTable dtRDB = new DataTable();
            bool fileName = false;

            //if (codigo_banco == "BCU")
            //{
            //    //dtRDB = LeerArchivo_BCU(ruta);
            //    fileName = true;
            //}
            //else if (codigo_banco == "BAG")
            //{
            //    dtRDB = LeerArchivo_BAG(ruta);
            //    fileName = true;
            //}
            //else
            //{
            //    fileName = false;
            //}

            dtRDB = LeerArchivo_BAG(ruta);
            fileName = true;

            //LeerArchivo_BAG2(ruta);

            return (dtRDB, fileName);
        }

        public DataTable LeerArchivo_BAG(string ruta)
        {
            DateTime? fecha_archivo = null;
            decimal monto_archivo = 0;
            DateTime fecha;

            int id_codificacion = 0;
            string codificacion = "";
            decimal monto = 0;

            string gln = "";
            string referencia;

            int id_banco = 0;
            string banco = ""; // Nombre del banco

            string linea = "";
            string referencia1 = "";
            string referencia2 = "";

            /// cuenta los registros no validos
            //int reg = 0;
            string[] lines = File.ReadAllLines(@ruta);

            string entidad = "";
            string campo = "";
            string valor = "";
            int larg = 0;

            (entidad, campo, valor, larg) = LeerDefEntidad("GLN", "");
            gln = valor;

            DataTable dtRDB = new DataTable();

            dtRDB.Columns.Add("VaucherNumber", typeof(string));
            dtRDB.Columns.Add("ClienteId", typeof(int));
            dtRDB.Columns.Add("MetodoPago", typeof(string));
            dtRDB.Columns.Add("ReferenciaPago", typeof(string));
            dtRDB.Columns.Add("Observacion", typeof(string));
            dtRDB.Columns.Add("Monto", typeof(decimal));
            dtRDB.Columns.Add("PropiedadId", typeof(int));
            dtRDB.Columns.Add("FechadePago", typeof(DateTime));
            dtRDB.Columns.Add("CreadoPor", typeof(string));
            dtRDB.Columns.Add("ModificadoPor", typeof(string));

            /////////////   BANCO    //////////////
            string codigo_banco = tools.GetUntilOrEmpty(ruta);
            Array items_banco = Enum.GetValues(typeof(enumerados.banco));
            foreach (enumerados.banco item in items_banco)
            {
                if (item.ToString() == codigo_banco)
                {
                    id_banco = (int)item;
                    banco = item.GetDescription();
                }
            }

            try
            {
                /////////////////// Encabezado  - H //////////////////////
                for (int i = 0; i < lines.Length; i++)
                {
                    char tipo = Convert.ToChar(lines[i].ToString().Substring(0, 1));
                    if (tipo == Convert.ToChar("H"))
                    {
                        fecha_archivo = DateTime.ParseExact(lines[i].Substring(3, 8) + ' ' + lines[i].Substring(11, 8), "yyyyMMdd HH:mm:ss", null);
                    }
                }

                /////////////////// Total - T //////////////////////
                for (int i = 0; i < lines.Length; i++)
                {
                    char tipo = Convert.ToChar(lines[i].ToString().Substring(0, 1));
                    if (tipo == Convert.ToChar("T"))
                    {
                        // Linea de Encabezado //
                        monto_archivo = tools.toDecimal(lines[i].Substring(7, 12) + "." + lines[i].Substring(19, 2));
                    }
                }

                /////////////////// Detalle  //////////////////////
                ///

                var CuentasPorCobrar = new CuentasPorCobrarEntity();

                for (int i = 0; i < lines.Length; i++)
                {
                    char tipo = Convert.ToChar(lines[i].ToString().Substring(0, 1));
                    if (tipo == Convert.ToChar("D"))
                    {
                        linea = lines[i];
                        //monto = tools.toDecimal(lines[i].Substring(44, 10));
                        monto = tools.toDecimal(lines[i].Substring(40, 12) + "." + lines[i].Substring(52, 2));
                        var a = lines[i].Substring(15, 8);
                        var b = lines[i].Substring(7, 8);
                        fecha = DateTime.ParseExact(lines[i].Substring(15, 8) + ' ' + lines[i].Substring(7, 8), "yyyyMMdd HH:mm:ss", null);

                        if (lines[i].Substring(57, 3) == "415" && lines[i].Substring(60, 13) == gln.ToString() && (lines[i].Substring(73, 4) == "3902" || lines[i].Substring(73, 4) == "96") || lines[i].Substring(73, 4) == "8020")
                        {
                            /************** BARRAS ********************/
                            id_codificacion = 1;
                            // referencia1 = linea.Substring(0, linea.Length - 44);
                            referencia1 = linea.Substring(57, linea.Length - 57 - 44); /* 57 del inicio y 44 del final */
                            referencia = LeerConfig("BAR4") != 0 ? referencia1.Substring(referencia1.Length - LeerConfig("BAR4"), LeerConfig("BAR4")) : "";
                        }
                        else
                        {
                            /************** NPE ********************/
                            id_codificacion = 2;
                            //referencia2 = linea.Substring(0, linea.Length - 69);
                            referencia2 = linea.Substring(54, linea.Length - 54 - 69); /* 55 del inicio y 69 del final */
                            referencia = LeerConfig("NPE4") != 0 ? referencia2.Substring(referencia2.Length - LeerConfig("NPE4") - 1, LeerConfig("NPE4")) : "";
                        }

                        //////////////  CODIFICACION  //////////////
                        Array items_codificacion = Enum.GetValues(typeof(enumerados.codificacion));
                        foreach (enumerados.codificacion item in items_codificacion)
                        {
                            if ((int)item == id_codificacion)
                            {
                                codificacion = item.GetDescription();
                            }
                        }

                        if (id_codificacion == 1)
                        {
                            //DataTable dtcxc = new DataTable();
                            CuentasPorCobrar = obj_CuentasPorCobrarDatos.GetByBRCode(referencia1);
                        }
                        else if (id_codificacion == 2)
                        {
                            string ref2 = "";
                            for (int x = 0; x < referencia2.Length / 4; x++)
                            {
                                ref2 = ref2 + referencia2.Substring(x * 4, 4) + " ";
                            }
                            referencia2 = ref2.Substring(0, ref2.Length - 1);
                            CuentasPorCobrar = obj_CuentasPorCobrarDatos.GetByNPE(referencia2);
                        }

                        CuentasPorCobrarPagoEntity CuentasPorCobrarPago = new CuentasPorCobrarPagoEntity();

                        CuentasPorCobrarPago.VaucherNumber = CuentasPorCobrar.VaucherNumber;
                        CuentasPorCobrarPago.ClienteId = CuentasPorCobrar.ClienteId;
                        CuentasPorCobrarPago.MetodoPago = codificacion;
                        CuentasPorCobrarPago.ReferenciaPago = referencia;
                        CuentasPorCobrarPago.Observacion = CuentasPorCobrar.PeriodoFacturado;
                        CuentasPorCobrarPago.Monto = monto;
                        CuentasPorCobrarPago.PropiedadId = CuentasPorCobrar.PropiedadId;
                        CuentasPorCobrarPago.FechadePago = fecha;
                        CuentasPorCobrarPago.CreadoPor = "Process";
                        CuentasPorCobrarPago.ModificadoPor = "Process";

                        obj_CuentasPorCobrarPagoDatos.SavePagoProcess(CuentasPorCobrarPago);

                        DataRow row = dtRDB.NewRow();

                        row["VaucherNumber"] = CuentasPorCobrar.VaucherNumber;
                        row["ClienteId"] = CuentasPorCobrar.ClienteId;
                        row["MetodoPago"] = codificacion;
                        row["ReferenciaPago"] = referencia;
                        row["Observacion"] = CuentasPorCobrar.PeriodoFacturado; ;
                        row["Monto"] = monto;
                        row["PropiedadId"] = CuentasPorCobrar.PropiedadId;
                        row["FechadePago"] = fecha;
                        row["CreadoPor"] = "Process";
                        row["ModificadoPor"] = "Process";

                        dtRDB.Rows.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
                Console.WriteLine(ex.Message);
                //MessageBox.Show("Error: " + ex.Message);
            }
            return dtRDB;
        }
        public void LeerArchivo_BAG2(string ruta)
        {
            DateTime? fecha_archivo = null;
            decimal monto_archivo = 0;
            DateTime fecha;

            int id_codificacion = 0;
            string codificacion = "";
            decimal monto = 0;

            string gln = "";
            string referencia;

            int id_banco = 0;
            string banco = ""; // Nombre del banco

            string linea = "";
            string referencia1 = "";
            string referencia2 = "";

            /// cuenta los registros no validos
            //int reg = 0;
            string[] lines = File.ReadAllLines(@ruta);

            string entidad = "";
            string campo = "";
            string valor = "";
            int larg = 0;

            (entidad, campo, valor, larg) = LeerDefEntidad("GLN", "");
            gln = valor;

            
            /////////////   BANCO    //////////////
            string codigo_banco = tools.GetUntilOrEmpty(ruta);
            Array items_banco = Enum.GetValues(typeof(enumerados.banco));
            foreach (enumerados.banco item in items_banco)
            {
                if (item.ToString() == codigo_banco)
                {
                    id_banco = (int)item;
                    banco = item.GetDescription();
                }
            }

            try
            {
                /////////////////// Encabezado  - H //////////////////////
                for (int i = 0; i < lines.Length; i++)
                {
                    char tipo = Convert.ToChar(lines[i].ToString().Substring(0, 1));
                    if (tipo == Convert.ToChar("H"))
                    {
                        fecha_archivo = DateTime.ParseExact(lines[i].Substring(3, 8) + ' ' + lines[i].Substring(11, 8), "yyyyMMdd HH:mm:ss", null);
                    }
                }

                /////////////////// Total - T //////////////////////
                for (int i = 0; i < lines.Length; i++)
                {
                    char tipo = Convert.ToChar(lines[i].ToString().Substring(0, 1));
                    if (tipo == Convert.ToChar("T"))
                    {
                        // Linea de Encabezado //
                        monto_archivo = tools.toDecimal(lines[i].Substring(7, 12) + "." + lines[i].Substring(19, 2));
                    }
                }

                /////////////////// Detalle  //////////////////////
                ///

                var CuentasPorCobrar = new CuentasPorCobrarEntity();

                for (int i = 0; i < lines.Length; i++)
                {
                    char tipo = Convert.ToChar(lines[i].ToString().Substring(0, 1));
                    if (tipo == Convert.ToChar("D"))
                    {
                        linea = lines[i];
                        //monto = tools.toDecimal(lines[i].Substring(44, 10));
                        monto = tools.toDecimal(lines[i].Substring(40, 12) + "." + lines[i].Substring(52, 2));
                        var a = lines[i].Substring(15, 8);
                        var b = lines[i].Substring(7, 8);
                        fecha = DateTime.ParseExact(lines[i].Substring(15, 8) + ' ' + lines[i].Substring(7, 8), "yyyyMMdd HH:mm:ss", null);

                        if (lines[i].Substring(57, 3) == "415" && lines[i].Substring(60, 13) == gln.ToString() && (lines[i].Substring(73, 4) == "3902" || lines[i].Substring(73, 4) == "96") || lines[i].Substring(73, 4) == "8020")
                        {
                            /************** BARRAS ********************/
                            id_codificacion = 1;
                            // referencia1 = linea.Substring(0, linea.Length - 44);
                            referencia1 = linea.Substring(57, linea.Length - 57 - 44); /* 57 del inicio y 44 del final */
                            referencia = LeerConfig("BAR4") != 0 ? referencia1.Substring(referencia1.Length - LeerConfig("BAR4"), LeerConfig("BAR4")) : "";
                        }
                        else
                        {
                            /************** NPE ********************/
                            id_codificacion = 2;
                            //referencia2 = linea.Substring(0, linea.Length - 69);
                            referencia2 = linea.Substring(54, linea.Length - 54 - 69); /* 55 del inicio y 69 del final */
                            referencia = LeerConfig("NPE4") != 0 ? referencia2.Substring(referencia2.Length - LeerConfig("NPE4") - 1, LeerConfig("NPE4")) : "";
                        }

                        //////////////  CODIFICACION  //////////////
                        Array items_codificacion = Enum.GetValues(typeof(enumerados.codificacion));
                        foreach (enumerados.codificacion item in items_codificacion)
                        {
                            if ((int)item == id_codificacion)
                            {
                                codificacion = item.GetDescription();
                            }
                        }

                        if (id_codificacion == 1)
                        {
                            //DataTable dtcxc = new DataTable();
                            CuentasPorCobrar = obj_CuentasPorCobrarDatos.GetByBRCode(referencia1);
                        }
                        else if (id_codificacion == 2)
                        {
                            string ref2 = "";
                            for (int x = 0; x < referencia2.Length / 4; x++)
                            {
                                ref2 = ref2 + referencia2.Substring(x * 4, 4) + " ";
                            }
                            referencia2 = ref2.Substring(0, ref2.Length - 1);
                            CuentasPorCobrar = obj_CuentasPorCobrarDatos.GetByNPE(referencia2);
                        }

                        CuentasPorCobrarPagoEntity CuentasPorCobrarPago = new CuentasPorCobrarPagoEntity();

                        CuentasPorCobrarPago.VaucherNumber = CuentasPorCobrar.VaucherNumber;
                        CuentasPorCobrarPago.ClienteId = CuentasPorCobrar.ClienteId;
                        CuentasPorCobrarPago.MetodoPago = codificacion;
                        CuentasPorCobrarPago.ReferenciaPago = referencia;
                        CuentasPorCobrarPago.Observacion = CuentasPorCobrar.PeriodoFacturado;
                        CuentasPorCobrarPago.Monto = monto;
                        CuentasPorCobrarPago.PropiedadId = CuentasPorCobrar.PropiedadId;
                        CuentasPorCobrarPago.FechadePago = fecha;
                        CuentasPorCobrarPago.CreadoPor = "Process";
                        CuentasPorCobrarPago.ModificadoPor = "Process";

                        obj_CuentasPorCobrarPagoDatos.SavePagoProcess(CuentasPorCobrarPago);


                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
                Console.WriteLine(ex.Message);
                //MessageBox.Show("Error: " + ex.Message);
            }
        }

        public int LeerConfig(string llave)
        {
            int largo = 0;
            bool esnum = false;
            int num = 0;

            NameValueCollection Keys;
            Keys = ConfigurationManager.AppSettings;

            List<configCodigos> ListConfig = new List<configCodigos>();

            foreach (string s in Keys.AllKeys)
            {
                configCodigos c = new configCodigos();
                c.llave = s.ToString();
                c.valor = Keys.Get(s).ToString();
                ListConfig.Add(c);
            }

            foreach (var obj in ListConfig)
            {
                if (obj.llave.ToString().StartsWith(llave))
                {
                    string[] separadores = obj.valor.ToString().Split('|');

                    foreach (var separador in separadores)
                    {
                        esnum = Int32.TryParse(separador, out num);
                        if (esnum)
                        {
                            largo += Convert.ToInt32(separador);
                        }
                    }
                }
            }

            if (llave.Equals("NPE"))
            {
                largo += 2; // 1 Impar  + 1 Verificador
            }
            return largo;
        }

        public (int, string[]) LeerConfig(string llave, string separador)
        {
            int largo = 0;
            string[] separadores = { "", "", "" };
            bool esnum = false;
            int num = 0;

            NameValueCollection Keys;
            Keys = ConfigurationManager.AppSettings;

            List<configCodigos> ListConfig = new List<configCodigos>();

            foreach (string s in Keys.AllKeys)
            {
                if (s.StartsWith(llave))
                {
                    configCodigos c = new configCodigos();
                    c.llave = s.ToString();
                    c.valor = Keys.Get(s).ToString();
                    ListConfig.Add(c);
                }
            }

            foreach (var obj in ListConfig)
            {
                separadores = obj.valor.ToString().Split('|');

                foreach (var sep in separadores)
                {
                    esnum = Int32.TryParse(sep, out num);
                    if (esnum)
                    {
                        largo = Convert.ToInt32(sep);
                    }
                }
            }
            return (largo, separadores);
        }

        public (string, string, string, int) LeerDefEntidad(string llave, string separador)
        {
            string[] defEnty;
            string entidad = "";
            string campo = "";
            string valor = "";
            int largo = 0;

            (largo, defEnty) = LeerConfig(llave, separador);
            foreach (var item in defEnty)
            {
                int index = defEnty.ToList().IndexOf(item);
                entidad = index == 0 && item.Length > 0 ? item.Substring(1, item.Length - 1) : entidad;
                campo = index == 1 && item.Length > 0 ? item.Substring(1, item.Length - 1) : campo;
                valor = index == 2 && item.Length > 0 ? item.Substring(1, item.Length - 1) : valor;
                largo = index == 3 ? Convert.ToInt32(item) : largo;

                // MessageBox.Show(String.Format("Definicion: {0},{1}", index, item));
            }
            return (entidad, campo, valor, largo);
        }
    }

    public static class Helper
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attr = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attr.Length == 0 ? value.ToString() : (attr[0] as DescriptionAttribute).Description;
        }
    }
}