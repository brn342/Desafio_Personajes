namespace Library;

public class Enanos
{
    public string NombreEnano { get; set; }
    public List<Item> ItemsEnano { get; set; }
    public int Vida { get; set; }
    public int AtaqueEnano { get; set; }

    public Enanos(string nombre, int vida, int ataque)
    {
        NombreEnano = nombre;
        ItemsEnano = new List<Item>();
        Vida = vida;
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
        return VidaExtra + Vida;
    }

    public int AtaqueTotal()
    {
        int AtaqueExtra = 0;
        foreach (Item item in ItemsEnano)
        {
            AtaqueExtra += item.ValorAtaque;
        }
        return Vida + AtaqueExtra;
    }

    public void AtacarMago(Magos mago)
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

    public void CurarMago(Magos mago)
    {
        mago.Vida += 20;
        Console.WriteLine($"el mago {mago.NombreMago} ha recuperado 20 de vida");
    }
    
    public void AtacarElfo(Elfo elfo)
    {
        int ValorAtaque = AtaqueTotal();
        if (ValorAtaque < elfo.Vida)
        {
            elfo.Vida -= ValorAtaque;
        }
        else
        {
            Console.WriteLine($"El elfo {elfo.NombreElfo} ha sido derrotado");
        }
    }

    public void CurarElfo(Elfo elfo)
    {
        elfo.Vida += 20;
        Console.WriteLine($"El elfo {elfo.NombreElfo} ha recuperado 20 de vida");
    }

    public void AtacarEnano(Enanos enano)
    {
        int ValorAtaque = AtaqueTotal();
        if (ValorAtaque < enano.Vida)
        {
            enano.Vida -= ValorAtaque;
        }
        else
        {
            Console.WriteLine($"El enano {enano.NombreEnano} ha sido derrotado");
        }
    }

    public void CurarEnano(Enanos enano)
    {
        enano.Vida += 20;
        Console.WriteLine($"El enano {enano.NombreEnano} ha recuperado 20 de vida");
    }
}