using System.Runtime.CompilerServices;

namespace Library;

public class Magos
{
    public string NombreMago { get; set; }

   public SpellBook LibroHechizos { get; set; }

    public List<Item> ItemsMago { get; set; }
    public int ValorVida { get; set; }
    public int ValorAtaque { get; set; }

    public void AgregarItem(Item item)
    {
        ItemsMago.Add(item);
       
    }
    
    public void QuitarItem(Item item)
    {
        ItemsMago.Remove(item);
      
    }
    
    public int calcularVidaTotal()
    {
        int VidaExtra = 0;
        foreach (Item item in ItemsMago)
        {
            VidaExtra += item.ValorDefensa;
        }
        
        return (VidaExtra + ValorVida);

    }

    public void AtacarMago(Magos mago)
    {
        int ataque = ValorAtaqueExtra();
        if (ataque<mago.ValorVida)
        {
            mago.ValorVida = mago.ValorVida - ValorAtaque;
        }
        else
        {
            Console.WriteLine("Se murio el personaje que has atacado");
        }
    }
    public void AtacarElfo(Elfos elfos)
    {
        int ataque = ValorAtaqueExtra();
        if (ataque<elfos.ValorVida)
        {
            elfos.ValorVida = elfos.ValorVida - ValorAtaque;
        }
        else
        {
            Console.WriteLine("Se murio el personaje que has atacado");
        }
    }
    
    public void AtacarElfo(Duendes duendes)
    {
        int ataque = ValorAtaqueExtra();
        if (ataque<duendes.ValorVida)
        {
            duendes.ValorVida = duendes.ValorVida - ValorAtaque;
        }
        else
        {
            Console.WriteLine("Se murio el personaje que has atacado");
        }
    }
    
    public void CurarElfo(Elfos elfos)
    {
            elfos.ValorVida = elfos.ValorVida + 20;
    }
       
    public void CurarMago(Magos mago)
    {
        mago.ValorVida = mago.ValorVida + 20;
    }

    public void CurarDuendes(Duendes duendes)
    {
        duendes.ValorVida = duendes.ValorVida + 20;
    }


  
    public int ValorAtaqueExtra()
    {
        int AtaqueExtra = 0;
        foreach (Item item in ItemsMago)
        {
            AtaqueExtra += item.ValorAtaque;
        }

        return (AtaqueExtra + ValorAtaque);

    }
    public Magos(string nombreMago, int vida, SpellBook hechizos, int valorAtaque)
    {
        this.NombreMago = nombreMago;
        this.ValorVida = vida;
        this.LibroHechizos = hechizos;
        this.ValorAtaque = valorAtaque;
        this.ItemsMago = new List<Item>();
    }
}