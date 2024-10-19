using Library.Characters;

namespace Library;

public class Encuentro
{
    private PersonajeBase Hero;
    private PersonajeBase Enemigo;
    private string turnoActual = "turnoVillano";
    public List<Hero> Heroes;
    public List<Enemigo> Enemigos;

    public Encuentro(List<Hero> heroes, List<Enemigo> enemigos)
    {
        Heroes = heroes;
        Enemigos = enemigos;
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

            EstadoBatalla();
        }
    }

    public void MostrarEstado()
    {
        Console.WriteLine($"{Hero.Nombre} tiene esta cantidad de vida ");
        Console.WriteLine($"{Enemigo.Nombre} tiene esta cantidad de vida");
    }

    public void EstadoBatalla()
    {
        if (Heroes.Count == 0)
        {
            Console.WriteLine("Los villanos los han derrotado chaval");
        }
        else if (Enemigos.Count == 0)
        {
            Console.WriteLine("Los heroes han derrotado a los villanos");
        }

        else
        {
            Console.WriteLine("Ninguno de los 2 ha sido derrotado, la batalla sigue!!");
            Console.WriteLine($"{Hero.Nombre} tiene esta cantidad de vida ");
            Console.WriteLine($"{Enemigo.Nombre} tiene esta cantidad de vida");
        }

    }

    private void EnemigosAtacan()
    {
        int indiceEnemigo = 0;
        int indiceHeroe = 0;
        while (indiceEnemigo < Enemigos.Count)
        {
            if (indiceEnemigo <= Heroes.Count)
            {
                Enemigos[indiceEnemigo].Atacar(Heroes[indiceHeroe]);
                Console.WriteLine($"{Enemigos[indiceEnemigo].Nombre} ataca a {Heroes[indiceHeroe].Nombre}");
                if (Enemigos[indiceEnemigo].ValorVida <= 0)
                {
                    Enemigos.Remove(Enemigos[indiceEnemigo]);
                }
            }
            else
            {
                indiceHeroe = 0;
                Enemigos[indiceEnemigo].Atacar(Heroes[indiceHeroe]);
                Console.WriteLine($"{Enemigos[indiceEnemigo].Nombre} ataca a {Heroes[indiceHeroe].Nombre}");
                if (Enemigos[indiceEnemigo].ValorVida <= 0)
                {
                    Enemigos.Remove(Enemigos[indiceEnemigo]);
                }
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
            if (indiceHeroe <= Enemigos.Count)
            {
                Heroes[indiceHeroe].Atacar(Enemigos[indiceEnemigo]);
                Console.WriteLine($"{Heroes[indiceHeroe].Nombre} ataca a {Enemigos[indiceEnemigo].Nombre}");
                if (Heroes[indiceHeroe].ValorVida <= 0)
                {
                    Heroes.Remove(Heroes[indiceHeroe]);
                }
            }
            else
            {
                indiceEnemigo = 0;
                Heroes[indiceHeroe].Atacar(Enemigos[indiceEnemigo]);
                Console.WriteLine($"{Heroes[indiceHeroe].Nombre} ataca a {Enemigos[indiceEnemigo].Nombre}");
                if (Heroes[indiceHeroe].ValorVida <= 0)
                {
                    Heroes.Remove(Heroes[indiceHeroe]);
                }
            }

            indiceEnemigo += 1;
            indiceHeroe += 1;
        }
    }
}

