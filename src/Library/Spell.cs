namespace Library;

public class Spell
{
    public string Nombre { get; set; }
    public int ValorAtaque { get; set; }
    public int ValorDefensa { get; set; }


    public Spell(string nombre, int valorAtaque, int valorDefensa)
    {
        Nombre = nombre;
        ValorAtaque = valorAtaque;
        ValorDefensa = valorDefensa;
    }
}