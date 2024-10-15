namespace Library;

public class ItemMagico: IItemMagico
{
    public string NombreItem { get; set; }
    public int Ataque { get; set; }
    public int Defensa { get; set; }
    public bool Especial { get; set; }

    public ItemMagico(string nombreItem, int ataque, int defensa, bool especial)
    {
        NombreItem = nombreItem;
        Ataque = ataque;
        Defensa = defensa;
        Especial = especial;
    }
}