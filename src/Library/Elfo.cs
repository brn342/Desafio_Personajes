namespace Library;
using System;
public class Elfo
{
    public string Nombre { get; set; }
    public List<Item> ItemsElfo { get; set; }
    public int ValorVida { get; set; } = 100;
    public int ValorAtaque { get; set; } = 15;
    
    
    //public int Curacion { get; set; }

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
    
    public void AtacarDuende(Duende duende)
    {
        int ataque = CalcularAtaqueTotal();
        if (ataque<duende.ValorVida)
        {
            duende.ValorVida = duende.ValorVida - ValorAtaque;
            Console.WriteLine($"{duende.Nombre} recibió un ataque de {ataque}.");
        }
        else
        {
            duende.ValorVida = 0;
            Console.WriteLine($"{duende.Nombre} murió.");
        }
    }
    
    public void CurarDuendes(Duende duende)
    {
        if (duende.ValorVida < 20)
        {
            duende.ValorVida = duende.ValorVida + 20;
            Console.WriteLine($"{duende.Nombre} aumento 20 puntos de salud.");

        }
        else
        {
            duende.ValorVida = 100;
            Console.WriteLine($"{duende.Nombre} aumento su salud al maximo.");
        }
    }
}

    
     /*public void CurarElfo(Elfos elfo)
     {
         if (elfo.VidaTotal() < 100)
         {
             elfo.ValorVida += Curacion;
         }
    
    */
    
    