namespace Library;

public class ItemMagico: ItemBase, IItemMagico
{
    public int Ataque { get; set; }
    public int Defensa { get; set; }

    public ItemMagico(string nombreItem, int ataque, int defensa, bool especial)
        : base(nombreItem, especial)
    {
        Ataque = ataque;
        Defensa = defensa;
    }
}