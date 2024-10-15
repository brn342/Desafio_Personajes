namespace Library;

public class ItemBase: IItem
{
    public string NombreItem { get; set; }
    public bool Especial { get; set; }

    public ItemBase(string nombreItem, bool especial)
    {
        NombreItem = nombreItem;
        Especial = especial;
    }
}