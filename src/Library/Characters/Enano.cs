namespace Library.Characters;

public class Enano : IChar {
    public string Nombre { get; set; }
    public int ValorVida { get; set; }
    public int ValorAtaque { get; set; }
    public List<IItem> Items { get; set; }
    
    public int ValorVidaInicial { get; } 
    
    public Enano(string nombre, int valorVida, int valorAtaque)
    {
        Nombre = nombre;
        ValorVida = valorVida;
        ValorAtaque = valorAtaque;
        Items = new List<IItem>();
        ValorVidaInicial = valorVida;
    }
    
    public void AgregarItem(IItem item)
    {
        if (item.Especial)
        {
            Console.WriteLine("El ítem especial no puede ser agregado al enano");
        }
        else
        {
            Items.Add(item);
            Console.WriteLine("Sea agrego el item correctamente.");
        }
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
            if (item is IItemDefensa itemDefensa)
            {
                vidaExtra += itemDefensa.Defensa;
            }
        }
        return (vidaExtra + ValorVida);
    }

    public int CalcularAtaqueTotal()
    {
        int ataqueExtra = 0;
        foreach (IItem item in Items)
        {
            if (item is IItemAtaque itemAtaque)
            {
                ataqueExtra += itemAtaque.Ataque;
            }
        }
        return (ataqueExtra + ValorAtaque);
    }

    public void Atacar(IChar enemigo)
    {
        if (enemigo == this)
        {
            Console.WriteLine($"{Nombre} no puede atacarse a sí mismo.");
        }
        else
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
    }

    public void Curar(IChar aliado)
    {
        if (aliado == this)
        {
            Console.WriteLine($"{Nombre} no puede curarse a sí mismo.");
        }
        else
        {
            int curacion = 20;
            int vidaFaltante = aliado.ValorVidaInicial - aliado.ValorVida;

            // Verificar si la curación hace que la vida supere el valor máximo
            if (aliado.ValorVida + curacion > aliado.ValorVidaInicial)
            {
                aliado.ValorVida = aliado.ValorVidaInicial; // La vida no puede exceder el valor máximo
                Console.WriteLine($"{Nombre} curó a {aliado.Nombre}, ahora tiene el valor máximo de vida.");
            }
            else
            {
                aliado.ValorVida += curacion;
                Console.WriteLine(
                    $"{Nombre} curó a {aliado.Nombre} con {curacion} puntos de vida. Ahora tiene {aliado.ValorVida} de vida.");
            }
        }
    }
}