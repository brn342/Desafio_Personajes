namespace Library;

public class Enanos
{
    public string NombreEnano { get; set; }
    public List<Item> ItemsEnano { get; set; }
    public int VidaEnano { get; set; }
    public int AtaqueEnano { get; set; }

    public Enanos(string nombre, int vida, int ataque)
    {
        NombreEnano = nombre;
        ItemsEnano = new List<Item>();
        VidaEnano = vida;
        AtaqueEnano = ataque;
    }

    public void AgregarItems(Item item)
    {
        ItemsEnano.Add(item);
    }

    public void QuitarItems(Item item)
    {
        ItemsEnano.Remove(item);
    }

    public int VidaTotal()
    {
        int VidaExtra = 0;
        foreach (Item item in ItemsEnano)
        {
            VidaExtra += item.ValorDefensa;
        }
        return VidaExtra + VidaEnano;
    }

    public int AtaqueTotal()
    {
        int AtaqueExtra = 0;
        foreach (Item item in ItemsEnano)
        {
            AtaqueExtra += item.ValorAtaque;
        }
        return VidaEnano + AtaqueExtra;
    }

    public int AtacarMago(Magos mago)
    {
        int ValorAtaque = AtaqueTotal();
        if (ValorAtaque < mago.Vida)
        {
            mago.Vida -= ValorAtaque;
        }
        else
        {
            Console.WriteLine($"El mago {mago.NombreMago} ha sido derrotado");
        }
    }
     
    public int AtacarElfo()
    
}