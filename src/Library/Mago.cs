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
        int ataqueExtra = 0;|
        foreach (Item item in ItemsMago)
        {
            ataqueExtra += item.ValorAtaque;
        }

        return (ataqueExtra + ValorAtaque);
    }

    public void AtacarMago(Mago mago)
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
    
    public void CurarMago(Mago mago)
    {
        if (mago.ValorVida < 20)
        {
            mago.ValorVida = mago.ValorVida + 20;
            Console.WriteLine($"{mago.Nombre} aumento 20 puntos de salud.");
        }
        else
        {
            mago.ValorVida = 100;
            Console.WriteLine($"{mago.Nombre} aumento su salud al maximo.");
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
        if (elfo.ValorVida < 20)
        {
            elfo.ValorVida = elfo.ValorVida + 20;
            Console.WriteLine($"{elfo.Nombre} aumento 20 puntos de salud.");
        }
        else
        {
            elfo.ValorVida = 100;
            Console.WriteLine($"{elfo.Nombre} aumento su salud al maximo.");
        }
    }
    
    public void AtacarEnano(Enano enano   )
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
            Console.WriteLine($"{Enano.Nombre} murió.");
        }
    }
    
    public void CurarEnano(Enano enano)
    {
        if (enano.ValorVida < 20)
        {
            enano.ValorVida = enano.ValorVida + 20;
            Console.WriteLine($"{enano.Nombre} aumento 20 puntos de salud.");

        }
        else
        {
            enano.ValorVida = 100;
            Console.WriteLine($"{enano.Nombre} aumento su salud al maximo.");
        }
    }
}