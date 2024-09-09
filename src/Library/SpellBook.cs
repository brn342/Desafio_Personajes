namespace Library;

public class SpellBook
{
    public string Nombre { get; set; }
    public List<Spell> Hechizos;

    public SpellBook(string nombre)
    {
        Nombre = nombre;
        Hechizos = new List<Spell>();
    }

    public void AgregarHechizo(Spell hechizo)
    {
        Hechizos.Add(hechizo);
    }

    public int CalcularAtaqueTotal()
    {
        int poderTotal = 0;
        foreach (Spell hechizo in Hechizos)
        {
            poderTotal += hechizo.ValorAtaque;
        }

        return poderTotal;
    }

    public void ListarHechizos()
    {
        foreach (Spell hechizo in Hechizos)
        {
            Console.WriteLine($"- {hechizo.Nombre} tiene un poder de: {hechizo.ValorAtaque}");
        }
    }
}