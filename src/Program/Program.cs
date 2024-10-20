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
            // Crear héroes (magos, elfos, enanos) y enemigos
            Mago mago = new Mago("Bruno", 120, 40, new SpellBook("Spellbook Bruno"));
            Elfo elfo = new Elfo("Seba", 100, 35);
            Enano enano = new Enano("Natu", 130, 45);
         
            Enemigo enemigo = new Enemigo("Orco", 80, 30, 1); // El enemigo otorga 15 VP

            // Agregar ítems
            ItemAtaque espada = new ItemAtaque("Espada", 20, false);
            ItemDefensa escudo = new ItemDefensa("Escudo", 10, false);

            mago.AgregarItem(espada);
            enemigo.AgregarItem(escudo);

            // Mostrar estado inicial
            Console.WriteLine("Estado inicial de los personajes:");
            MostrarEstadoPersonaje(mago);
            MostrarEstadoPersonaje(enemigo);

            // Héroe ataca al enemigo
            Console.WriteLine("\nGandalf ataca al orco...");
            mago.Atacar(enemigo);

            // Mostrar estado del enemigo después del ataque
            MostrarEstadoPersonaje(enemigo);

            // Segundo ataque, el orco debería morir y Gandalf gana puntos de victoria
            mago.Atacar(enemigo);

            // Mostrar estado final y puntos de victoria
            MostrarEstadoPersonaje(enemigo);
            Console.WriteLine($"{mago.Nombre} tiene {mago.PV} puntos de victoria.");
        }

        static void MostrarEstadoPersonaje(IChar personaje)
        {
            Console.WriteLine($"{personaje.Nombre} tiene {personaje.ValorVida}/{personaje.ValorVidaInicial} puntos de vida.");
            Console.WriteLine($"Ataque total: {personaje.CalcularAtaqueTotal()}");
            Console.WriteLine($"Puntos de victoria (VP): {personaje.PV}");
            Console.WriteLine($"Ítems: {string.Join(", ", personaje.Items.ConvertAll(item => item.NombreItem))}");
        }
    }
}