using System;
using System.Collections.Generic;
using Library;
using Library.Characters;

namespace Demonstration
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear héroes y enemigos
            List<Hero> heroes = CrearHeroes();
            List<Enemigo> enemigosRonda1 = CrearEnemigos(1);
            List<Enemigo> enemigosRonda2 = CrearEnemigos(2);
            List<Enemigo> enemigosRonda3 = CrearEnemigos(3, bossFinal: true);

            // Seleccionar número aleatorio de héroes
            Random rand = new Random();
            int cantidadHeroes = rand.Next(1, heroes.Count + 1);

            // Mostrar la lista de héroes y permitir al usuario elegir
            List<Hero> heroesSeleccionados = SeleccionarHeroes(heroes, cantidadHeroes);
            
            // Mostrar los héroes seleccionados
            Console.WriteLine($"Has seleccionado {cantidadHeroes} héroes para la batalla.");
            foreach (Hero heroe in heroesSeleccionados)
            {
                Console.WriteLine($"Héroe seleccionado: {heroe.Nombre} - Tipo: {heroe.Tipo} - Vida: {heroe.ValorVida}");
            }

            // Iniciar las rondas de encuentros
            Encuentro encuentro1 = new Encuentro(heroesSeleccionados, enemigosRonda1);
            Console.WriteLine("\nRonda 1: ¡Enemigos débiles!");
            encuentro1.DoEncounter();

            // Continuar con las siguientes rondas si hay héroes sobrevivientes
            if (encuentro1.Heroes.Count > 0)
            {
                Encuentro encuentro2 = new Encuentro(encuentro1.Heroes, enemigosRonda2);
                Console.WriteLine("\nRonda 2: ¡Los enemigos se vuelven más fuertes!");
                encuentro2.DoEncounter();
            }

            if (encuentro1.Heroes.Count > 0)
            {
                Encuentro encuentro3 = new Encuentro(encuentro1.Heroes, enemigosRonda3);
                Console.WriteLine("\nRonda 3: ¡El jefe final ha aparecido!");
                encuentro3.DoEncounter();
            }

            Console.WriteLine("¡El juego ha terminado!");
        }

        // Crear múltiples instancias de héroes de los mismos tipos
        static List<Hero> CrearHeroes()
        {
            Mago mago1 = new Mago("Bruno el Sabio", 120, 40, new SpellBook("Hechizos Antiguos"));
            Mago mago2 = new Mago("Mara la Arcana", 110, 45, new SpellBook("Magia de Sombras"));
            Elfo elfo1 = new Elfo("Seba el Rápido", 100, 35);
            Elfo elfo2 = new Elfo("Lía la Ágil", 90, 40);
            Enano enano1 = new Enano("Natu el Fuerte", 130, 45);
            Enano enano2 = new Enano("Tobías el Rudo", 140, 50);

            return new List<Hero> { mago1, mago2, elfo1, elfo2, enano1, enano2 };
        }

        // Crear enemigos con más variedad
        static List<Enemigo> CrearEnemigos(int ronda, bool bossFinal = false)
        {
            List<Enemigo> enemigos = new List<Enemigo>();
            if (bossFinal)
            {
                enemigos.Add(new Enemigo("Ogro Sucio", 500, 80, 3)); // Boss final
            }
            else
            {
                for (int i = 0; i < ronda * 2; i++) // Más enemigos en rondas posteriores
                {
                    string nombreEnemigo = ronda switch
                    {
                        1 => $"Goblin Travieso {i + 1}",
                        2 => $"Orco Salvaje {i + 1}",
                        3 => $"Gólem de Piedra {i + 1}",
                        _ => $"Enemigo {i + 1}"
                    };

                    enemigos.Add(new Enemigo(nombreEnemigo, 60 + ronda * 20, 20 + ronda * 10, ronda*2));
                }
            }
            return enemigos;
        }

        // Interfaz para que el usuario elija sus héroes
        static List<Hero> SeleccionarHeroes(List<Hero> heroes, int cantidad)
        {
            List<Hero> seleccionados = new List<Hero>();

            Console.WriteLine($"Tienes {cantidad} héroes para seleccionar.");
            for (int i = 0; i < heroes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {heroes[i].Nombre} - Tipo: {heroes[i].Tipo} - Vida: {heroes[i].ValorVida} - Ataque: {heroes[i].ValorAtaque}");
            }

            while (seleccionados.Count < cantidad)
            {
                Console.Write($"Selecciona el héroe {seleccionados.Count + 1} (ingresa el número): ");
                int eleccion = Convert.ToInt32(Console.ReadLine()) - 1;

                if (eleccion >= 0 && eleccion < heroes.Count && !seleccionados.Contains(heroes[eleccion]))
                {
                    seleccionados.Add(heroes[eleccion]);
                }
                else
                {
                    Console.WriteLine("Selección inválida o héroe ya seleccionado. Intenta de nuevo.");
                }
            }

            return seleccionados;
        }
    }
}
