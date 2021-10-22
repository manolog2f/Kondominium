using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Entidad referente al Arancel
/// </summary>

public class ArancelesEntity
{

    /// <summary>
    /// Id de Arancel
    /// </summary>
    [DisplayName("Id de Arancel")]
    public int ArancelId { get; set; }
    /// <summary>
    /// Descripcion
    /// </summary>
    [DisplayName("Descripcion")]
    public string Descripcion { get; set; }
    /// <summary>
    /// Id del Arancel
    /// </summary>
    [DisplayName("Id de Arancel")]
    public decimal Monto { get; set; }
    /// <summary>
    /// Activo
    /// </summary>
    [DisplayName("Activo")]
    public Nullable<bool> Activo { get; set; }
    /// <summary>
    /// Fecha de Creacion
    /// </summary>
    [DisplayName("Fecha de Creación")]
    public System.DateTime FechaDeCreacion { get; set; }
    /// <summary>
    /// Fecha de Modificaion
    /// </summary>
    [DisplayName("Fecha de Modificación")]
    public System.DateTime FechaDeModificacion { get; set; }
    /// <summary>
    /// Creado por
    /// </summary>
    [DisplayName("Creado por")]
    public string CreadoPor { get; set; }
    /// <summary>
    /// Modificado por
    /// </summary>
    [DisplayName("Modificado por")]
    public string ModificadoPor { get; set; }
    /// <summary>
    /// Eliminado
    /// </summary>
    [DisplayName("Eliminado")]
    public bool Eliminado
    {
        get; set;
    }