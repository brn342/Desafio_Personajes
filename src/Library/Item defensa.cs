namespace Library;

public class ItemDefensa:IItemDefensa
{
    public string nombreItem { get; set; }
    public int valorDefensa { get; set; }

    public ItemDefensa(string nombreItem, int valorDefensa)
    {
        this.nombreItem = nombreItem;
        this.valorDefensa = valorDefensa;
    }

    public string NombreItem()
    {
        return nombreItem;
    }

    public int ValorDefensa()
    {
        return valorDefensa;
    }
}