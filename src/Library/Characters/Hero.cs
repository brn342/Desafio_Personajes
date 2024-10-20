namespace Library.Characters;

public class Hero: PersonajeBase
{
    public override int PV { get; set; } = 0;
    public int PuntosVictoriaAcumulados { get;  set; } = 0;//hola brunito, te sacamos el private set porque nos impedia en la clase Encuetros linea +- entre [120-130]


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