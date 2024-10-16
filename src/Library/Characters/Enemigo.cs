namespace Library.Characters;

public class Enemigo: PersonajeBase
{
    public override int PV { get; set; }

    public Enemigo(string nombre, int valorVida, int valorAtaque, int pv)
        : base(nombre, valorVida, valorAtaque)
    {
        PV = pv;
    }
}