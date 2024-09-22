using NUnit.Framework;
using Library.Characters;
using System.Collections.Generic;

namespace Library.Tests
{
    [TestFixture]
    public class PersonajeTests
    {
        [Test]
        public void NoDebeAtacarseASiMismo()
        {
            var enano = new Enano("Natu", 100, 20);
            enano.Atacar(enano);
            
            Assert.That(enano.ValorVida, Is.EqualTo(100));
        }

        [Test]
        public void NoDebeCurarseASiMismo()
        {
            var enano = new Enano("Natu", 50, 20);
            enano.Curar(enano);
            
            Assert.That(enano.ValorVida, Is.EqualTo(50));
        }

        [Test]
        public void CurarPersonaje_NoExcedeVidaMaxima()
        {
            var enano = new Enano("Natu", 80, 25); 
            var aliado = new Enano("Seba", 90, 25);

            aliado.Atacar(enano);
            aliado.Curar(enano);
            aliado.Curar(enano);

            Assert.That(enano.ValorVida, Is.EqualTo(80));
        }

        [Test]
        public void PersonajeDebeMorirCuandoVidaEsCero()
        {
            var mago = new Mago("Seba", 30, 40, new SpellBook("Libro de Hechizos"));
            var enano = new Enano("Natu", 50, 20);
            mago.Atacar(enano); // 40 de ataque reduce la vida del enano
            mago.Atacar(enano); // Otro ataque debería matarlo

            Assert.That(enano.ValorVida, Is.EqualTo(0));
        }

        [Test]
        public void AgregarItemAumentaAtaque()
        {
            var enano = new Enano("Ntu", 100, 20);
            var espada = new ItemAtaque("Espada de Acero", 15, false);
            enano.AgregarItem(espada);
            int ataqueTotal = enano.CalcularAtaqueTotal();

            Assert.That(ataqueTotal, Is.EqualTo(35));
        }

        [Test]
        public void QuitarItemDisminuyeDefensa()
        {
            // Arrange
            var enano = new Enano("Natu", 100, 20);
            var escudo = new ItemDefensa("Escudo", 10, false);
            enano.AgregarItem(escudo);
            enano.QuitarItem(escudo);
            int defensaTotal = enano.CalcularVidaTotal();

            Assert.That(defensaTotal, Is.EqualTo(100));
        }
    }
}