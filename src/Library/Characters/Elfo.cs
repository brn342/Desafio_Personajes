namespace Library.Characters;

public class Elfo : IChar {
    public string Nombre { get; set; }
    public int ValorVida { get; set; }
    public int ValorAtaque { get; set; }
    public List<IItem> Items { get; set; }
    
    private int valorVidaInicial; // Vida máxima del personaje

    
    public Elfo(string nombre, int valorVida, int valorAtaque)
    {
        Nombre = nombre;
        ValorVida = valorVida;
        ValorAtaque = valorAtaque;
        Items = new List<IItem>();
        valorVidaInicial = valorVida;
    }

    public void AgregarItem(IItem item)
    {
        Items.Add(item);
        Console.WriteLine("Sea agrego el item correctamente.");
    }
    
    public void QuitarItem(IItem item)
    {
        Items.Remove(item);
        Console.WriteLine("Sea quito el item correctamente.");

    }
    
    public int CalcularVidaTotal()
    {
        int vidaExtra = 0;
        foreach (IItem item in Items)
        {
            vidaExtra += item.Defensa;
        }
        
        return (vidaExtra + ValorVida);
    }
    
    public int CalcularAtaqueTotal()
    {
        int ataqueExtra = 0;
        foreach (IItem item in Items)
        {
            ataqueExtra += item.Ataque;
        }

        return (ataqueExtra + ValorAtaque);
    }

    public void Atacar(IChar enemigo)
    {
        int ataque = CalcularAtaqueTotal();
        if (ataque < enemigo.ValorVida)
        {
            enemigo.ValorVida = enemigo.ValorVida - ValorAtaque;
            Console.WriteLine($"{enemigo.Nombre} recibió un ataque de {ataque}.");
        }
        else
        {
            enemigo.ValorVida = 0;
            Console.WriteLine($"{enemigo.Nombre} murió.");
        }
    }

    public void Curar(IChar aliado)
    {
        int curacion = 20;
        int vidaFaltante = valorVidaInicial - aliado.ValorVida;

        if (vidaFaltante >= curacion)
        {
            aliado.ValorVida += curacion;
            Console.WriteLine(
                $"{Nombre} curó a {aliado.Nombre} con {curacion} puntos de vida. Ahora tiene {aliado.ValorVida} de vida.");
        }
        else
        {
            aliado.ValorVida = valorVidaInicial;
            Console.WriteLine($"{Nombre} curó a {aliado.Nombre}, ahora tiene el valor maximo de vida.");
        }
    }
}