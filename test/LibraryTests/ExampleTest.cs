using NUnit.Framework;
using Library.Characters;
using Library;
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

            // Asegura que no pueda atacarse a sí mismo y su vida no cambia
            Assert.That(enano.ValorVida, Is.EqualTo(100));
        }

        [Test]
        public void NoDebeCurarseASiMismo()
        {
            var enano = new Enano("Natu", 50, 20);
            enano.Curar(enano);

            // Asegura que no pueda curarse a sí mismo y su vida no cambia
            Assert.That(enano.ValorVida, Is.EqualTo(50));
        }

        [Test]
        public void CurarPersonaje_NoExcedeVidaMaxima()
        {
            var enano = new Enano("Natu", 80, 25);
            var aliado = new Enano("Seba", 90, 25);

            aliado.Atacar(enano); // Causar daño al enano
            aliado.Curar(enano);  // Curarlo una vez
            aliado.Curar(enano);  // Intentar curarlo otra vez, no debe exceder vida máxima

            // Verifica que la vida no exceda el máximo (80)
            Assert.That(enano.ValorVida, Is.EqualTo(80));
        }

        [Test]
        public void PersonajeDebeMorirCuandoVidaEsCero()
        {
            var mago = new Mago("Seba", 30, 40, new SpellBook("Spellbook Seba"));
            var enano = new Enano("Natu", 50, 20);

            mago.Atacar(enano); // Atacar una vez (resta 40 vida, enano queda con 10)
            mago.Atacar(enano); // Otro ataque debería matarlo

            // Verifica que la vida del enano sea 0
            Assert.That(enano.ValorVida, Is.EqualTo(0));
        }

        [Test]
        public void AgregarItemAumentaAtaque()
        {
            var enano = new Enano("Natu", 100, 20);
            var espada = new ItemAtaque("Espada de Acero", 15, false); // Crear un ítem de ataque
            enano.AgregarItem(espada); // Añadir el ítem al enano
            int ataqueTotal = enano.CalcularAtaqueTotal(); // Calcular el ataque total

            // Verifica que el ataque total ahora sea 20 + 15 = 35
            Assert.That(ataqueTotal, Is.EqualTo(35));
        }

        [Test]
        public void QuitarItemDisminuyeDefensa()
        {
            var enano = new Enano("Natu", 100, 20);
            var escudo = new ItemDefensa("Escudo", 10, false); // Crear un ítem de defensa
            enano.AgregarItem(escudo); // Agregar ítem de defensa
            enano.QuitarItem(escudo);  // Quitar el ítem
            int defensaTotal = enano.CalcularVidaTotal(); // Calcular la defensa total

            // Verifica que la defensa vuelva a ser la base, es decir, 100
            Assert.That(defensaTotal, Is.EqualTo(100));
        }
        
        [Test]
        public void SoloMagoPuedeAgregarItemsMagicos()
        {
            var mago = new Mago("Seba", 100, 50, new SpellBook("Spellbook Seba"));
            var elfo = new Elfo("Bruno", 90, 40);
            var itemMagico = new ItemMagico("Varita Mágica", 30, 10, true); // Ítem mágico

            // Elfo intenta agregar un ítem mágico (esto no debería ser permitido)
            elfo.AgregarItem(itemMagico);
            Assert.That(elfo.Items, Does.Not.Contain(itemMagico)); // Verifica que no lo tiene

            // Mago agrega un ítem mágico (esto sí debería ser permitido)
            mago.AgregarItem(itemMagico);
            Assert.That(mago.Items, Contains.Item(itemMagico)); // Verifica que lo tiene
        }
        
        [Test]
        public void EnemigoSeCreaCorrectamenteConVP()
        {
            var orc = new Enemigo("Orco", 80, 30, 15); // El enemigo tiene 15 puntos de victoria (VP)

            // Verifica que el enemigo se crea con los valores correctos
            Assert.That(orc.Nombre, Is.EqualTo("Orco"));
            Assert.That(orc.ValorVida, Is.EqualTo(80));
            Assert.That(orc.ValorAtaque, Is.EqualTo(30));
            Assert.That(orc.PV, Is.EqualTo(15)); // Verifica que tenga los VP correctos
        }

        [Test]
        public void HeroeGanaVPAlMatarEnemigo()
        {
            var hero = new Mago("Bruno", 120, 50, new SpellBook("Spellbook Gandalf"));
            var orc = new Enemigo("Orco", 50, 30, 10); // El enemigo otorga 10 puntos de victoria (VP)

            // El héroe ataca dos veces, el enemigo debería morir en el segundo ataque
            hero.Atacar(orc); // Reduce la vida del orco a 0
            hero.Atacar(orc); // El orco muere

            // Verifica que el enemigo esté muerto
            Assert.That(orc.ValorVida, Is.EqualTo(0));

            // Verifica que el héroe haya ganado los 10 puntos de victoria
            Assert.That(hero.PuntosVictoriaAcumulados, Is.EqualTo(10));
        }
        
        [Test]
        public void HeroeAcumulaPuntosCorrectamente()
        {
            var hero = new Enano("Bruno", 130, 40);
            var orc1 = new Enemigo("Orco", 50, 30, 5); // Primer enemigo otorga 5 VP
            var orc2 = new Enemigo("Orco", 50, 30, 10); // Segundo enemigo otorga 10 VP

            // El héroe mata al primer enemigo
            hero.Atacar(orc1);
            hero.Atacar(orc1);

            // El héroe mata al segundo enemigo
            hero.Atacar(orc2);
            hero.Atacar(orc2);

            // Verifica que los puntos de victoria acumulados sean correctos
            Assert.That(hero.PuntosVictoriaAcumulados, Is.EqualTo(15)); // 5 + 10 = 15
            Assert.That(hero.PV, Is.EqualTo(0));
        }
        
        [Test]
        public void EnemigoPierdeVidaAlSerAtacado()
        {
            var hero = new Elfo("Natu", 100, 35);
            var orc = new Enemigo("Orco", 80, 30, 10); // El enemigo tiene 80 de vida

            // El héroe ataca una vez
            hero.Atacar(orc);

            // Verifica que la vida del enemigo se haya reducido
            Assert.That(orc.ValorVida, Is.LessThan(80));
            Assert.That(orc.ValorVida, Is.EqualTo(45)); // 80 - 35 (ataque del elfo) = 45
        }
        
        [Test]
        public void EnemigosAtacanCorrectamente()
        {
            // Configuración del encuentro
            var heroe1 = new Elfo("Elfo 1", 100, 20);
            var heroe2 = new Enano("Enano 1", 100, 25);
            var enemigo1 = new Enemigo("Orco 1", 50, 15, 1);
            var enemigo2 = new Enemigo("Orco 2", 50, 15, 1);

            List<Hero> heroes = new List<Hero> { heroe1, heroe2 };
            List<Enemigo> enemigos = new List<Enemigo> { enemigo1, enemigo2 };

            var encuentro = new Encuentro(heroes, enemigos);
            
            // Ejecución de un turno de ataque de los enemigos
            encuentro.EnemigosAtacan();

            // Verificación: Cada enemigo debe haber atacado al héroe correspondiente
            Assert.That(heroe1.ValorVida, Is.LessThan(100));
            Assert.That(heroe2.ValorVida, Is.LessThan(100));
        }

        [Test]
        public void HeroesAtacanCorrectamente()
        {
            // Configuración del encuentro
            var heroe1 = new Mago("Mago 1", 100, 30, new SpellBook("Hechizos"));
            var enemigo1 = new Enemigo("Orco 1", 60, 15, 5);
            var enemigo2 = new Enemigo("Orco 2", 60, 15, 5);

            List<Hero> heroes = new List<Hero> { heroe1 };
            List<Enemigo> enemigos = new List<Enemigo> { enemigo1, enemigo2 };

            var encuentro = new Encuentro(heroes, enemigos);
            
            // Ejecución de un turno de ataque de los héroes
            encuentro.HeroesAtacan();

            // Verificación: Los enemigos deben haber recibido daño
            Assert.That(enemigo1.ValorVida, Is.LessThan(60));
            Assert.That(enemigo2.ValorVida, Is.LessThan(60));
        }

        [Test]
        public void HeroeSeCuraCuandoAcumulaCincoVP()
        {
            // Configuración del encuentro
            var heroe1 = new Enano("Enano 1", 100, 40);
            var enemigo1 = new Enemigo("Orco 1", 10, 5, 3); // Otorga 3 VP
            var enemigo2 = new Enemigo("Orco 2", 10, 5, 3); // Otorga 3 VP

            List<Hero> heroes = new List<Hero> { heroe1 };
            List<Enemigo> enemigos = new List<Enemigo> { enemigo1, enemigo2 };

            var encuentro = new Encuentro(heroes, enemigos);

            // Hacer que el héroe reciba daño primero para probar curación
            enemigo1.Atacar(heroe1);
            Assert.That(heroe1.ValorVida, Is.LessThan(100)); // Verificar que recibió daño

            // Ejecutar la primera ronda de ataques de héroes
            encuentro.HeroesAtacan();

            // Verificar que el héroe se haya curado
            Assert.That(heroe1.ValorVida, Is.EqualTo(100)); // Verifica la curación
        }

        [Test]
        public void EnemigosRotanAtaquesEntreHeroes()
        {
            // Configuración del encuentro
            var heroe1 = new Elfo("Elfo 1", 100, 20);
            var heroe2 = new Enano("Enano 1", 100, 25);
            var heroe3 = new Mago("Mago 1", 100, 30, new SpellBook("Hechizos"));
            var enemigo1 = new Enemigo("Orco 1", 50, 15, 1);
            var enemigo2 = new Enemigo("Orco 2", 50, 15, 1);
            var enemigo3 = new Enemigo("Orco 3", 50, 15, 1);
            var enemigo4 = new Enemigo("Orco 4", 50, 15, 1);

            List<Hero> heroes = new List<Hero> { heroe1, heroe2, heroe3 };
            List<Enemigo> enemigos = new List<Enemigo> { enemigo1, enemigo2, enemigo3, enemigo4 };

            var encuentro = new Encuentro(heroes, enemigos);
            
            // Ejecución de un turno de ataque de los enemigos
            encuentro.EnemigosAtacan();

            // Verificación: Cada héroe debe haber recibido al menos un ataque (se rotan los ataques)
            Assert.That(heroe1.ValorVida, Is.LessThan(100));
            Assert.That(heroe2.ValorVida, Is.LessThan(100));
            Assert.That(heroe3.ValorVida, Is.LessThan(100));
        }
    }
}

