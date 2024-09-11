using System.Runtime.CompilerServices;

namespace Library;

public class Magos
{
    public string NombreMago
    {
        get { return nombremagoFinal;}
        set
        {
            string simbolos="!#$%&/())=?'¿´´¨+[]_:;";
            bool posible = false;
            foreach (var letra in value)
            {
                foreach (var simbolo in simbolos)
                {
                    if (letra==simbolo)
                    {
                        posible = true;
                        break;
                    }
                }
            }

            if (posible)
            {
                throw new ArgumentException("El nombre es incorrecto. No puede contener símbolos.");
            }
            else
            {
                nombremagoFinal=value;
            } 
        }
    }

    private string nombremagoFinal;

    public List<Item> ItemsMago { get; set; }
    public double Vida { get; set; }
    public List<Spell> Hechizos { get; set; }
    public int DañoHecho { get; set; }
    public int DañoAtaque { get; set; }
    public int ValorDefensa { get; set; }
    public void curar()
    {
        double vidaCurable = (DañoHecho-(DañoHecho*(ValorDefensa/100)));
        double VidaCurada = Vida + vidaCurable;
        if (vidaCurable>Vida)
        {
            Vida = Vida;
        }
        else
        {
            Vida = VidaCurada;
        }
    }

    public Magos(string nombreMago, List<Item> itemsMago, double vida, List<Spell> hechizos, int dañoHecho,
        int dañoAtaque,
        int valorDefensa)
    {
        this.NombreMago = nombreMago;
        this.ItemsMago = itemsMago;
        this.Vida = vida;
        this.Hechizos = hechizos;
        this.DañoHecho = dañoHecho;
        this.DañoAtaque = dañoAtaque;
        this.ValorDefensa = valorDefensa;
    }
}