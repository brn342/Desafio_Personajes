namespace Library;

public class Item
{
    public string NombreItem { get; set; }
    public string TipoItem { get; set; }

    public bool Especial { get; set; }
    public int ValorAtaque { get; set; }
    public int ValorDefensa { get; set; }

    public Item(string nombreItem, string tipoItem, bool especial, int valorAtaque, int valorDefensa)
    {
        NombreItem = nombreItem;
        TipoItem = tipoItem;
        Especial = especial;
        ValorAtaque = valorAtaque;
        ValorDefensa = valorDefensa;
    }

    public void CambiarItem(Item nuevoItem)
    {
        NombreItem = nuevoItem.NombreItem;
        TipoItem = nuevoItem.TipoItem;
        Especial = nuevoItem.Especial;
        ValorAtaque = nuevoItem.ValorAtaque;
        ValorDefensa = nuevoItem.ValorDefensa;
    }
    
    public void EliminarItem()
    {
        NombreItem = null;
        TipoItem = null;
        Especial = false;
        ValorAtaque = 0;
        ValorDefensa = 0;
    }
    
}
public class ItemsAtacarMago : IItemsAtaqueMagico
{
    public string nombre { get; set; }
    public int ValorAtaque { get; set; }

    public ItemsAtacarMago()
    {
        nombre = "Baculo de fuego";
        ValorAtaque = 10;
    }

    // Implementación del método Nombre
    public string Nombre()
    {
        return nombre; // Retornar el nombre del item
    }

    // Implementación del método ValorAtaque de la interfaz
    int IItemsAtaqueMagico.ValorAtaque()
    {
        return ValorAtaque; // Retornar el valor de ataque del item
    }
}

public class ItemsDefensaMago :IItemsDefensaMagico
{
    public string nombre { get; set; }
    public int ValorDefensa{ get; set; }

    public ItemsDefensaMago()
    {
        nombre = "Escudo";
        ValorDefensa = 10;
    }

    // Implementación del método Nombre
    public string Nombre()
    {
        return nombre; // Retornar el nombre del item
    }

    // Implementación del método ValorAtaque de la interfaz
    int IItemsDefensaMagico.ValorDefensa()
    {
        return ValorDefensa; // Retornar el valor de ataque del item
    }
}
