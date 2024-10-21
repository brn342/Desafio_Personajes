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
        Console.WriteLine($"Los héroes {Heroes.Count} restantes tienen este valor de vida:");
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

    public void EnemigosAtacan()
    {
        int cantidadHeroes = Heroes.Count;
        for (int i = 0; i < Enemigos.Count; i++)
        {
            if (Heroes.Count == 0) break; // No hay más héroes a los cuales atacar

            int indiceHeroe = i % cantidadHeroes; // Distribución cíclica
            var enemigo = Enemigos[i];
            var objetivo = Heroes[indiceHeroe];

            Console.WriteLine($"{enemigo.Nombre} ataca a {objetivo.Nombre}");
            enemigo.Atacar(objetivo);

            if (objetivo.ValorVida <= 0)
            {
                Console.WriteLine($"El héroe {objetivo.Nombre} ha sido derrotado.");
                Heroes.RemoveAt(indiceHeroe);
                cantidadHeroes--; // Actualizar la cantidad de héroes
            }
        }
    }


    public void HeroesAtacan()
    {
        int cantidadEnemigos = Enemigos.Count;
        for (int i = 0; i < Heroes.Count; i++)
        {
            if (Enemigos.Count == 0) break; // No hay más enemigos a los cuales atacar

            foreach (var enemigo in Enemigos.ToList()) // Crear una copia de la lista para iterar
            {
                Console.WriteLine($"{Heroes[i].Nombre} ataca a {enemigo.Nombre}");
                Heroes[i].Atacar(enemigo);

                if (enemigo.ValorVida <= 0)
                {
                    Console.WriteLine($"El enemigo {enemigo.Nombre} ha sido derrotado.");
                    Enemigos.Remove(enemigo); // Remover al enemigo de la lista original
                }
            }
        }
    }
        
}

