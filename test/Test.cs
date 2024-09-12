using NUnit.Framework;
using Library; // Suponiendo que las clases estén en el namespace Library
using System.Collections.Generic;

namespace Tests
{
    public class CharacterTests
    {
        private Elfo elfo1;
        private Elfo elfo2;
        private Mago mago1;
        private Duende duende1;
        private Item itemDefensa;
        private Item itemAtaque;

        [SetUp]
        public void Setup()
        {
            elfo1 = new Elfo("Elrond", 15, 100, 10);
            elfo2 = new Elfo("Legolas", 15, 100, 10);
            mago1 = new Mago("Gandalf", 100, new SpellBook("Libro de Hechizos"), 25);
            duende1 = new Duende("Dobby", 100, 10);

            itemDefensa = new Item("Escudo", "Defensa", false, 0, 20);
            itemAtaque = new Item("Espada", "Ataque", false, 10, 0);
        }

        [Test]
        public void Elfo1AtacaMago1()
        {
            elfo1.AtacarMago(mago1);

            Assert.Less(mago1.ValorVida, 100);
        }

        [Test]
        public void Elfo1CuraMago1()
        {
            mago1.ValorVida = 10;

            elfo1.CurarMago(mago1);

            Assert.AreEqual(30, mago1.ValorVida);
        }

        [Test]
        public void Elfo1NoPuedeCurarseASiMismo()
        {
            // Arrange
            elfo1.ValorVida = 10;

            elfo1.CurarElfo(elfo1);

            Assert.AreEqual(10, elfo1.ValorVida);
        }

        [Test]
        public void Elfo1NoPuedeAtacarseASiMismo()
        {
            elfo1.AtacarElfo(elfo1);

            Assert.AreEqual(100, elfo1.ValorVida);
        }

        [Test]
        public void MuereDuende()
        {
            duende1.ValorVida = 10;

            mago1.AtacarDuende(duende1);

            Assert.AreEqual(0, duende1.ValorVida);
        }

        [Test]
        public void SaludNoExcedeMaximo()
        {
            mago1.ValorVida = 95;

            elfo1.CurarMago(mago1);

            Assert.AreEqual(100, mago1.ValorVida);
        }
    }
}