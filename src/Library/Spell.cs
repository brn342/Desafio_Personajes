namespace Library;

public class Spell: IItemMagico
{
    public string NombreItem { get; set; }
    public int Ataque { get; set; }
    public int Defensa { get; set; }
    public bool Especial { get; set; } = true;



    public Spell(string nombreItem, int ataque, int defensa)
    {
        NombreItem = nombreItem;
        Ataque = ataque;
        Defensa = defensa;
    }
}