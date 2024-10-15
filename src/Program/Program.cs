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
            // Crear un SpellBook con hechizos para el Mago
            SpellBook libroHechizos = new SpellBook("Libro de Hechizos Avanzados");
            Spell hechizoFuego = new Spell("Bola de Fuego", 30, 5);
            Spell hechizoCuracion = new Spell("Curación", 0, 20);
            libroHechizos.AgregarHechizo(hechizoFuego);
            libroHechizos.AgregarHechizo(hechizoCuracion);

            // Crear un Mago
            Mago bruno = new Mago("Bruno", 100, 20, libroHechizos);

            // Crear un Enano
            Enano natu = new Enano("Natu", 120, 25);

            // Crear un Elfo
            Elfo seba = new Elfo("Seba", 90, 30);

            // Crear ítems de ataque y defensa
            ItemAtaque espada = new ItemAtaque("Espada", 15, false);
            ItemDefensa escudo = new ItemDefensa("Escudo Mágico", 30, true);
            ItemMixto arcoConFlechas = new ItemMixto("Arco con Flechas", 20, 5, false);

            // Añadir ítems a los personajes
            natu.AgregarItem(espada);
            seba.AgregarItem(arcoConFlechas);
            bruno.AgregarItem(escudo);

            // Mostrar información inicial
            Console.WriteLine("Estado inicial de los personajes:");
            MostrarEstadoPersonaje(natu);
            MostrarEstadoPersonaje(seba);
            MostrarEstadoPersonaje(bruno);

            // Acciones
            Console.WriteLine("\nBruno ataca a Natu con un hechizo...");
            bruno.AtacarConHechizos(natu);
            MostrarEstadoPersonaje(natu);

            Console.WriteLine("\nSeba ataca a Natu con su arco...");
            seba.Atacar(natu);
            MostrarEstadoPersonaje(natu);

            Console.WriteLine("\nBruno cura a Natu con un hechizo...");
            bruno.CurarConHechizos(natu);
            MostrarEstadoPersonaje(natu);

            Console.WriteLine("\nNatu contraataca a Seba...");
            natu.Atacar(seba);
            MostrarEstadoPersonaje(seba);
        }

        static void MostrarEstadoPersonaje(IChar personaje)
        {
            Console.WriteLine($"{personaje.Nombre} tiene {personaje.ValorVida}/{personaje.ValorVidaInicial} puntos de vida.");
            Console.WriteLine($"Ataque total: {personaje.CalcularAtaqueTotal()}");
            Console.WriteLine($"Ítems: {string.Join(", ", personaje.Items.ConvertAll(item => item.NombreItem))}");
        }
    }
}
