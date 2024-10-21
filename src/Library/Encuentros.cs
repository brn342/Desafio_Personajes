using Library.Characters;

namespace Library;

public class Encuentro
{
    private string turnoActual = "turnoEnemigo";
    public List<Hero> Heroes;
    public List<Enemigo> Enemigos;

    public Encuentro(List<Hero> heroes, List<Enemigo> enemigos)
    {
        Heroes= new List<Hero>(heroes);
        Enemigos = new List<Enemigo>(enemigos);
    }

    public void AgregarHeroes(Hero heroe)
    {
        if (!Heroes.Contains(heroe))
        {
            Heroes.Add(heroe);
        }
        else
        {
            Console.WriteLine("Ese heroe ya ha sido agregado");
        }
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
                Console.WriteLine("Los enemigos han finalizado su ataque, pulse cualquier tecla para continuar");
                Console.ReadLine();
            }
            else
            {
                HeroesAtacan();
                Console.WriteLine("Los Heroes han finalizado su ataque, pulse cualquier tecla para continuar");
                Console.ReadLine();
            }
           turnoActual=CambiarTurno();

            MostrarEstado();
            Console.WriteLine("Presiona cualquier tecla para continuar con la siguiente ronda");
            Console.ReadLine();
        }
       
        SaberGanador();
    }

    public void MostrarEstado() 
    {
        Console.WriteLine($"Los heroes {Heroes.Count} restantes tienen este valor de vida:");
        foreach (var heroe in Heroes)
        {
            Console.WriteLine($" {heroe.Nombre} : {heroe.ValorVida}");
        }
        
        Console.WriteLine($"Los enemigos {Enemigos.Count} restantes tienen este valor de vida:");
        foreach (var enemigo in Enemigos)
        {
            Console.WriteLine($" {enemigo.Nombre} : {enemigo.ValorVida}");
        }
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
        while (indiceEnemigo < Enemigos.Count && Heroes.Count > 0)
        {
            if (indiceHeroe >= Heroes.Count)
            {
                indiceHeroe = 0; // Reiniciar el índice de héroes si se supera la cantidad disponible
            }

            Enemigos[indiceEnemigo].Atacar(Heroes[indiceHeroe]);
            Console.WriteLine($"{Enemigos[indiceEnemigo].Nombre} ataca a {Heroes[indiceHeroe].Nombre}");

            if (Heroes[indiceHeroe].ValorVida <= 0)
            {
                Console.WriteLine($"El héroe {Heroes[indiceHeroe].Nombre} ha sido derrotado");
                Heroes.RemoveAt(indiceHeroe); // Remover al héroe de la lista
            }
            else
            {
                indiceHeroe++; // Solo incrementar si el héroe no ha sido eliminado
            }

            indiceEnemigo++; // El enemigo siempre avanza al siguiente turno
        }
    }

    
    private void HeroesAtacan()
    {
        int indiceHeroe = 0; // Índice para recorrer la lista de héroes
        int indiceEnemigo = 0; // Índice para recorrer la lista de enemigos

        while (indiceHeroe < Heroes.Count && Enemigos.Count > 0)
        {
            if (indiceEnemigo >= Enemigos.Count)
            {
                indiceEnemigo = 0; // Reiniciar el índice de enemigos si se supera la cantidad disponible
            }

            // El héroe ataca al enemigo
            Heroes[indiceHeroe].Atacar(Enemigos[indiceEnemigo]);
            Console.WriteLine($"{Heroes[indiceHeroe].Nombre} ataca a {Enemigos[indiceEnemigo].Nombre}");

            // Verificar si el enemigo ha sido derrotado
            if (Enemigos[indiceEnemigo].ValorVida <= 0)
            {
                Console.WriteLine($"El enemigo {Enemigos[indiceEnemigo].Nombre} ha sido derrotado");
                Enemigos.RemoveAt(indiceEnemigo); // Remover al enemigo de la lista
            }
            else
            {
                indiceEnemigo++; // Solo incrementar si el enemigo no ha sido eliminado
            }

            indiceHeroe++; // El héroe siempre avanza al siguiente turno
        }
    }


}

