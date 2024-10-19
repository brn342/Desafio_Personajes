using Library.Characters;

namespace Library;

public class Encuentros
{
    private PersonajeBase Hero;
    private PersonajeBase Enemigo;
    private string turnoActual="turnoVillano";
    public List<Hero> Heroes;
    public List<Enemigo> Enemigos;
    
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
        }
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
                 Console.WriteLine("Los villanos han sido derrotado ");
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
