namespace Library;

public class Spell
{
    public string Nombre { get; set; }
    public int ValorAtaque { get; set; }

    public Spell(string nombre, int valorAtaque)
    {
        Nombre = nombre;
        ValorAtaque = valorAtaque; 
    }
}