namespace Library;
using System;
public class Elfos
{
    public string NombreElfos
    {
        get;
        set;
    }

    public List<Item> ItemsElfos { get; set; }
    public int ValorVida { get; set; }
    public int ValorAtaque { get; set; }
    
    public int ValorDefensa { get; set; }
    
    //public int Curacion { get; set; }

    public Elfos(string nombreElfos, List<Item> itemsElfos, int valorAtaque, int valorVida, int valorDefensa, int curacion)
    {
        this.NombreElfos = nombreElfos;
        this.ItemsElfos = itemsElfos;
        this.ValorVida = valorVida;
        this.ValorAtaque = valorAtaque;
        this.ValorDefensa = valorDefensa;
        this.Curacion = curacion;
    }

    public void AgregarItem(Item item)
    {
        ItemsElfos.Add(item);
    }

    public void QuitarItem(Item item)
    {
        ItemsElfos.Remove(item);
    }

    public int VidaTotal() 
    {
        int vidaExtra = 0;
        foreach (Item item in ItemsElfos)
        {
            vidaExtra += item.ValorDefensa;
        }

        return (ValorVida + vidaExtra);
    }

    public int AtaqueTotal()
    {
        int ataqueExtra = 0;
        foreach (Item item in ItemsElfos)
        {
            ataqueExtra += item.ValorAtaque;
        }

        return (ValorAtaque + ataqueExtra);
        
    }

    public void AtacarElfo(Elfos elfo)
    {
        int ataque = AtaqueTotal();
        if (ataque < elfo.VidaTotal())
        {
            elfo.ValorVida -= ataque;
        }
        
    }
    public void AtacarMago(Magos mago)
    {
        int ataque = AtaqueTotal();
        if (ataque < mago.VidaTotal())
        {
            mago.ValorVida -= ataque;
        }
        
    }
    public void AtacarEnano(Enanos enano)
    {
        int ataque = AtaqueTotal();
        if (ataque < enano.VidaTotal())
        {
            enano.ValorVida -= ataque;
        }
        
    }

    
     /*public void CurarElfo(Elfos elfo)
     {
         if (elfo.VidaTotal() < 100)
         {
             elfo.ValorVida += Curacion;
         }
    
    */
    
    
}