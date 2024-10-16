namespace Library.Characters;

public class Mago : Hero, IMagic
{
    public SpellBook SpellBook { get; set; }

    public Mago(string nombre, int valorVida, int valorAtaque, SpellBook spellBook)
        : base(nombre, valorVida, valorAtaque)
    {
        SpellBook = spellBook;
    }

    public override void AgregarItem(ItemBase item)
    {
        // El mago puede agregar tanto ítems normales como especiales
        Items.Add(item);
        Console.WriteLine($"{Nombre} agregó el ítem {item.NombreItem} correctamente.");
    }

    public void AtacarConHechizos(IChar enemigo)
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

    public void CurarConHechizos(IChar aliado)
    {
        int curacion = SpellBook.CalcularDefensaTotal();
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
