namespace Kondominium_Entities
{
    public class Resultado
    {
        public string Mensaje { get; set; }
        public CodigosMensaje Codigo { get; set; }

        public Resultado()
        {
            Mensaje = null;
            Codigo = CodigosMensaje.Null;
        }
    }

    public enum CodigosMensaje
    {
        Null = -1,
        Exito = 0,
        Error = 9999,
        Warning = 5000,
        Log = 9000,
        Eliminado = 9898,
        No_Se_Puede_Eliminar = 97,
        No_Existe = 96
    }
}