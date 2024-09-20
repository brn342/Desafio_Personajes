namespace Library.Characters;

public class Mago : IMagic
{
    public string Nombre { get; set; }
    public int ValorVida { get; set; }
    public int ValorAtaque { get; set; }
    public List<Item> Items { get; set; }
    public SpellBook SpellBook { get; set; }

    private int valorVidaInicial; // Vida máxima del personaje
    
    public Mago(string nombre, int valorVida, int valorAtaque, SpellBook spellBook)
    {
        Nombre = nombre;
        ValorVida = valorVida;
        ValorAtaque = valorAtaque;
        SpellBook = spellBook;
        Items = new List<Item>();
        valorVidaInicial = valorVida;
    }

    public void AgregarItem(Item item)
    {
        Items.Add(item);
        Console.WriteLine("Sea agrego el item correctamente.");
    }

    public void QuitarItem(Item item)
    {
        Items.Remove(item);
        Console.WriteLine("Sea quito el item correctamente.");

    }

    public int CalcularVidaTotal()
    {
        int vidaExtra = 0;
        foreach (Item item in Items)
        {
            vidaExtra += item.ValorDefensa;
        }

        return (vidaExtra + ValorVida);
    }

    public int CalcularAtaqueTotal()
    {
        int ataqueExtra = 0;
        foreach (Item item in Items)
        {
            ataqueExtra += item.ValorAtaque;
        }

        return (ataqueExtra + ValorAtaque);
    }

    public void Atacar(IChar enemigo)
    {
        int ataque = CalcularAtaqueTotal();
        if (ataque < enemigo.ValorVida)
        {
            enemigo.ValorVida -= ValorAtaque;
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
            aliado.ValorVida = 100;
            Console.WriteLine($"{Nombre} curó a {aliado.Nombre}, ahora tiene el valor maximo de vida.");
        }
    }

    public void AtacarConHechizos(IChar enemigo)
    {
        int ataque = SpellBook.CalcularAtaqueTotal();
        if (ataque < enemigo.ValorVida)
        {
            enemigo.ValorVida -= ValorAtaque;
            Console.WriteLine($"{enemigo.Nombre} recibió un ataque de {ataque}.");
        }
        else
        {
            enemigo.ValorVida = 0;
            Console.WriteLine($"{enemigo.Nombre} murió.");
        }
    }

    public void CurarConHechizos(IChar aliado)
    {
        int curacion = SpellBook.GetHashCode();
        int vidaFaltante = valorVidaInicial - aliado.ValorVida;

        if (vidaFaltante >= curacion)
        {
            aliado.ValorVida += curacion;
            Console.WriteLine(
                $"{Nombre} curó a {aliado.Nombre} con {curacion} puntos de vida. Ahora tiene {aliado.ValorVida} de vida.");
        }
        else
        {
            aliado.ValorVida = 100;
            Console.WriteLine($"{Nombre} curó a {aliado.Nombre}, ahora tiene el valor maximo de vida.");
        }
    }
}