using System.Runtime.CompilerServices;

namespace Library;

public class Mago
{
    public string Nombre { get; set; }
    public SpellBook SpellBook { get; set; }
    public List<Item> ItemsMago { get; set; }
    public int ValorVida { get; set; } = 100;
    public int ValorAtaque { get; set; } = 25;
    
    public Mago(string nombre, int vida, SpellBook spellBook, int valorAtaque)
    {
        Nombre = nombre;
        ValorVida = vida;
        SpellBook = spellBook;
        ValorAtaque = valorAtaque;
        ItemsMago = new List<Item>();
    }

    public void AgregarItem(Item item)
    {
        ItemsMago.Add(item);
        Console.WriteLine("Sea agrego el item correctamente.");
    }
    
    public void QuitarItem(Item item)
    {
        ItemsMago.Remove(item);
        Console.WriteLine("Sea quito el item correctamente.");

    }
    
    public int CalcularVidaTotal()
    {
        int vidaExtra = 0;
        foreach (Item item in ItemsMago)
        {
            vidaExtra += item.ValorDefensa;
        }
        
        return (vidaExtra + ValorVida);
    }
    
    public int CalcularAtaqueTotal()
    {
        int ataqueExtra = 0;
        foreach (Item item in ItemsMago)
        {
            ataqueExtra += item.ValorAtaque;
        }

        return (ataqueExtra + ValorAtaque);
    }

    public void AtacarMago(Mago mago)
    {
        if (this == mago)
        {
            Console.WriteLine("El personaje no puede atacrse a si mismo");
        }
        else
        {
            int ataque = CalcularAtaqueTotal();
            if (ataque < mago.ValorVida)
            {
                mago.ValorVida = mago.ValorVida - ValorAtaque;
                Console.WriteLine($"{mago.Nombre} recibió un ataque de {ataque}.");

            }
            else
            {
                mago.ValorVida = 0;
                Console.WriteLine($"{mago.Nombre} murió.");
            }
        }
    }
    
    public void CurarMago(Mago mago)
    {
        if (this == mago)
        {
            Console.WriteLine("El perosnaje no puede curarse a si mismo");
        }
        else
        {
            if (mago.ValorVida < 80)
            {
                mago.ValorVida = mago.ValorVida + 20;
                Console.WriteLine($"{mago.Nombre} aumento su vida a {mago.CalcularVidaTotal()}.");
            }
            else
            {
                mago.ValorVida = 100;
                Console.WriteLine($"{mago.Nombre} aumento su salud al maximo.");
            }
        }
    }
    
    public void AtacarElfo(Elfo elfo)
    {
        int ataque = CalcularAtaqueTotal();
        if (ataque < elfo.ValorVida)
        {
            elfo.ValorVida = elfo.ValorVida - ValorAtaque;
            Console.WriteLine($"{elfo.Nombre} recibió un ataque de {ataque}.");
        }
        else
        {
            elfo.ValorVida = 0;
            Console.WriteLine($"{elfo.Nombre} murió.");
        }
    }
    
    public void CurarElfo(Elfo elfo)
    {
        if (elfo.ValorVida < 80)
        {
            elfo.ValorVida = elfo.ValorVida + 20;
            Console.WriteLine($"{elfo.Nombre} aumento su vida a {elfo.CalcularVidaTotal()}.");
        }
        else
        {
            elfo.ValorVida = 100;
            Console.WriteLine($"{elfo.Nombre} aumento su salud al maximo.");
        }
    }
    
    public void AtacarDuende(Enano enano)
    {
        int ataque = CalcularAtaqueTotal();
        if (ataque<enano.ValorVida)
        {
            enano.ValorVida = enano.ValorVida - ValorAtaque;
            Console.WriteLine($"{enano.Nombre} recibió un ataque de {ataque}.");
        }
        else
        {
            enano.ValorVida = 0;
            Console.WriteLine($"{enano.Nombre} murió.");
        }
    }
    
    public void CurarDuendes(Enano duende)
    {
        if (duende.ValorVida < 80)
        {
            duende.ValorVida = duende.ValorVida + 20;
            Console.WriteLine($"{duende.Nombre} aumento su vida a {duende.CalcularVidaTotal}.");

        }
        else
        {
            duende.ValorVida = 100;
            Console.WriteLine($"{duende.Nombre} aumento su salud al maximo.");
        }
    }
}