using System.ComponentModel;

namespace Kondominium_Entities
{
    public class MREnums
    {
    }

    public enum EstatusTarea
    {
        Programada = 1,
        Finalizada = 2,
        Cancelada = 3
        //0 = Activa\n1 = Trabajando\n2 = Finalizada\n
        // 1 Programada, 2 Finalizada, 3 Cancelada
    }

    public enum PrioridadTarea
    {
        Alta = 1,
        Media = 2,
        Normal = 3
        //0 = Activa\n1 = Trabajando\n2 = Finalizada\n
        // 1 Programada, 2 Finalizada, 3 Cancelada
    }

    public enum TipoClientes
    {
        Propietario = 0,
        Inquilino = 1,
        Otro = 2
    }

    public enum TipoDocumento
    {
        DUI = 0,
        NIT = 1,
        Pasaporte = 2,
        Contrato = 3,
        Recibo = 4,
        Otro = 5
    }

    public enum Parentescos
    {
        Padre = 1,
        Madre = 2,
        Hijo = 3,
        Hija = 4,
        Suegra = 5,
        Suegro = 6,
        Yerno = 7,
        Nuera = 8,
        Abuelo = 9,
        Abuela = 10,
        Nieto = 11,
        Nieta = 12,
        Hermano = 13,
        Hermana = 14,
        Cuñado = 15,
        Cuñada = 16,
        Tio = 17,
        Tia = 18,
        Sobrino = 19,
        Sobrina = 20,
        Esposo = 21,
        Esposa = 22,
        Amigo = 23,
        Otro = 24
    }

    public enum TipodePropiedades
    {
        Lote = 0,
        Casa = 1,
        Edificio = 2,
        Otros = 3
        //0 = Lote\n1 = Casa\n2 = Edificio\n3 = Otros
    }

    public enum LetrasCasa
    {
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
        Z
    }

    public enum MetodoPago
    {
        TarjetaCredito = 1,
        TarjetaDebito = 2,
        Transferencia = 3,
        Cheque = 4,
        Efectivo = 5,
        NPE = 6,

        [DescriptionAttribute("Codigo de Barras")]
        BAR = 7,
    }

    public enum Pais
    {
        SV = 503,
        USA = 1,
        GT = 502,
        MX = 52,
        CA = 1,
        Otro = 0
    }
}