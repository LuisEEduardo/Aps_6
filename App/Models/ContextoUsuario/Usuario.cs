using App.Models.ContextoUsuario.Enum;

namespace App.Models.ContextoUsuario;

public class Usuario
{
    public int Id { get; set; }
    public string Name { get; set; }
    public TipoPermissao TipoPermissao { get; set; }
}
