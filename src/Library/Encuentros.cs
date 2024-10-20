using Library.Characters;

namespace Library;

public class Encuentros
{
    private PersonajeBase Hero;
    private PersonajeBase Enemigo;
<<<<<<< HEAD
    private string turnoActual="turnoVillano";
=======
    private string turnoActual = "turnoEnemigo";
>>>>>>> trabajoNatu
    public List<Hero> Heroes;
    public List<Enemigo> Enemigos;


    public Encuentros(List<Hero> heroes, List<Enemigo> enemigos)
    {
        Heroes= new List<Hero>(heroes);
        Enemigos = new List<Enemigo>(enemigos);
    }
    
    public string CambiarTurno()
    {
        return turnoActual == "turnoEnemigo" ? "turnoHeroe":"turnoEnemigo";
    }
    
    public void DoEncounter()
    {
        Console.WriteLine("¡La batalla ha comenzado!");

        while (Heroes.Count != 0 && Enemigos.Count != 0)
        {
            int indiceEnemigo = 0;
            int indiceHeroe = 0;

            if (turnoActual == "turnoEnemigo")
            {
                while (indiceEnemigo < Enemigos.Count)
                {
                    if (indiceEnemigo <= Heroes.Count)
                    {
                        Enemigos[indiceEnemigo].Atacar(Heroes[indiceHeroe]);
                    }
                    else
                    {
                        indiceHeroe = 0;
                        Enemigos[indiceEnemigo].Atacar(Heroes[indiceHeroe]);
                    }

                    indiceEnemigo += 1;
                    indiceHeroe += 1;
                }

                CambiarTurno();
            }
            else
            {
                while (indiceHeroe < Heroes.Count)
                {
                    if (indiceHeroe <= Enemigos.Count)
                    {
                        Heroes[indiceHeroe].Atacar(Enemigos[indiceEnemigo]);
                    }
                    else
                    {
                        indiceEnemigo = 0;
                        Heroes[indiceHeroe].Atacar(Enemigos[indiceEnemigo]);
                    }

                    indiceEnemigo += 1;
                    indiceHeroe += 1;
                }

                CambiarTurno();
            }

            EstadoBatalla();

            MostrarEstado();

        }
        SaberGanador();
    }

    public void MostrarEstado()
         {   
             Console.WriteLine($"{Hero.Nombre} tiene esta cantidad de vida ");
             Console.WriteLine($"{Enemigo.Nombre} tiene esta cantidad de vida");
         }

         public void EstadoBatalla()
         {
             if (Heroes.Count==0)
             {
                 Console.WriteLine("Los villanos los han derrotado chaval");
             }
             else if (Enemigos.Count==0)
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

}

   /* {
        Console.WriteLine($"{Hero.Nombre} tiene {Hero.ValorVida} de vida ");
        Console.WriteLine($"{Enemigo.Nombre} tiene {Enemigo.ValorVida} de vida");
    }*/

    public PersonajeBase SaberGanador()
    {
        if (Heroes.Count == 0)
        {
            Console.WriteLine("Todos los heroes han sido derrotados, los villanos ganan");
            return Enemigos;
        }
        else if (Enemigos.Count == 0)
        {
            Console.WriteLine("Los heroes han derrotado a los villanos exitosamente");
            return Heroes;
        }

        return null;
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
>>>>>>> trabajoNatu
