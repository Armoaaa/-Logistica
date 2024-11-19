using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Dominio;

public class TipoDNI
{
[Key]
public int IdTipoDni { get; set; }
public bool DNIextranjero { get; set; }
public string Pais { get; set; }
}