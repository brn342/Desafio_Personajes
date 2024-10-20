using Library.Characters;

namespace Library;

public class Encuentro
{
    private PersonajeBase Hero;
    private PersonajeBase Enemigo;
    private string turnoActual = "turnoEnemigo";
    public List<Hero> Heroes;
    public List<Enemigo> Enemigos;

    public Encuentro(List<Hero> heroes, List<Enemigo> enemigos)
    {
        Heroes= new List<Hero>(heroes);
        Enemigos = new List<Enemigo>(enemigos);
    }

    public string CambiarTurno()
    {
        return turnoActual == "turnoEnemigo" ? "turnoHeroe" : "turnoEnemigo";
    }

    public void DoEncounter()
    {
        Console.WriteLine("¡La batalla ha comenzado!");

        while (Heroes.Count > 0 && Enemigos.Count > 0)
        {



            if (turnoActual == "turnoEnemigo")
            {
                EnemigosAtacan();
                CambiarTurno();
            }
            else
            {

                HeroesAtacan();
                CambiarTurno();
            }

            MostrarEstado();
        }
        SaberGanador();
    }

    public void MostrarEstado()
    {
        Console.WriteLine($"{Hero.Nombre} tiene {Hero.ValorVida} de vida ");
        Console.WriteLine($"{Enemigo.Nombre} tiene {Enemigo.ValorVida} de vida");
    }

    public void SaberGanador()
    {
        if (Heroes.Count == 0)
        {
            Console.WriteLine("Todos los heroes han sido derrotados, los villanos ganan");
        }
        else if (Enemigos.Count == 0)
        {
            Console.WriteLine("Los heroes han derrotado a los villanos exitosamente");
        }
    }

    private void EnemigosAtacan()
    {
        int indiceEnemigo = 0;
        int indiceHeroe = 0;
        while (indiceEnemigo < Enemigos.Count)
        {
            if (indiceEnemigo > Heroes.Count)
            {
                indiceHeroe = 0;
            }

            Enemigos[indiceEnemigo].Atacar(Heroes[indiceHeroe]);
            Console.WriteLine($"{Enemigos[indiceEnemigo].Nombre} ataca a {Heroes[indiceHeroe].Nombre}");
            if (Heroes[indiceHeroe].ValorVida <= 0)
            {
                Console.WriteLine($"El heroe {Heroes[indiceHeroe].Nombre} ha sido derrotado");
                Heroes.Remove(Heroes[indiceHeroe]);
                
            }

            indiceEnemigo += 1;
            indiceHeroe += 1;
        }
        
    }
    private void HeroesAtacan()
    {
        int indiceEnemigo = 0;
        int indiceHeroe = 0;
        while (indiceHeroe < Heroes.Count)
        {
            if (indiceHeroe > Enemigos.Count)
            {
                indiceEnemigo = 0;
            }
            Heroes[indiceHeroe].Atacar(Enemigos[indiceEnemigo]);
            Console.WriteLine($"{Heroes[indiceHeroe].Nombre} ataca a {Enemigos[indiceEnemigo].Nombre}");
            if (Enemigos[indiceEnemigo].ValorVida <= 0)
            {
                Console.WriteLine($"El enemigo {Enemigos[indiceEnemigo].Nombre} ha sido derrotado");
                Enemigos.Remove(Enemigos[indiceEnemigo]);
            }
            indiceEnemigo += 1;
            indiceHeroe += 1;
        }
    }
}