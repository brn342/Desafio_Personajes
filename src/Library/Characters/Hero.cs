namespace Library.Characters;

public class Hero: PersonajeBase
{
    public override int PV { get; set; } = 0;
    public int PuntosVictoriaAcumulados { get; private set; } = 0;


    public Hero(string nombre, int valorVida, int valorDefensa)
        : base(nombre, valorVida, valorDefensa)
    {
        PuntosVictoriaAcumulados = 0;
        PV = 0;
    }

    public override void Atacar(IChar enemigo)
    {
        base.Atacar(enemigo);
        if (enemigo.ValorVida == 0)
        {
            PuntosVictoriaAcumulados += enemigo.PV;
            enemigo.PV = 0;
        }
    }
}