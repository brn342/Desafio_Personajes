namespace Library;
using System;
public class Elfo
{
    public string Nombre { get; set; }
    public List<Item> ItemsElfo { get; set; }
    public int ValorVida { get; set; } = 100;
    public int ValorAtaque { get; set; } = 15;
    

    public Elfo(string nombre, int valorAtaque, int valorVida, int valorDefensa)
    {
        Nombre = nombre;
        ItemsElfo = new List<Item>();
        ValorVida = valorVida;
        ValorAtaque = valorAtaque;
        ValorVida = valorDefensa;
    }

     public void AgregarItem(Item item)
    {
        ItemsElfo.Add(item);
        Console.WriteLine("Sea agrego el item correctamente.");
    }
    
    public void QuitarItem(Item item)
    {
        ItemsElfo.Remove(item);
        Console.WriteLine("Sea quito el item correctamente.");

    }
    
    public int CalcularVidaTotal()
    {
        int vidaExtra = 0;
        foreach (Item item in ItemsElfo)
        {
            vidaExtra += item.ValorDefensa;
        }
        
        return (vidaExtra + ValorVida);
    }
    
    public int CalcularAtaqueTotal()
    {
        int ataqueExtra = 0;
        foreach (Item item in ItemsElfo)
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
        if (mago.ValorVida < 80)
        {
            mago.ValorVida = mago.ValorVida + 20;
            Console.WriteLine($"{mago.Nombre} aumento  su vida {mago.CalcularVidaTotal()}."); 
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
        if (elfo.ValorVida < 80)
        {
            elfo.ValorVida = elfo.ValorVida + 20;
            Console.WriteLine($"{elfo.Nombre} aumento se vida a {elfo.CalcularVidaTotal()}.");
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
    
    public void CurarEnano(Enano enano)
    {
        if (enano.ValorVida < 80)
        {
            enano.ValorVida = enano.ValorVida + 20;
            Console.WriteLine($"{enano.Nombre} aumento su vida a {enano.CalcularVidaTotal()}.");
        }
        else
        {
            enano.ValorVida = 100;
            Console.WriteLine($"{enano.Nombre} aumento su salud al maximo.");
        }
    }
}

    
  