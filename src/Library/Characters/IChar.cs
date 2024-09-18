namespace Library.Characters;

public interface IChar
{
    string Nombre { get; set; }
    int ValorVida { get; set; }
    int ValorAtaque { get; set; }
    List<Item> Items { get; set; }

    void AgregarItem(Item item);
    void QuitarItem(Item item);
    int CalcularVidaTotal();
    int CalcularAtaqueTotal();
    void Atacar(IChar enemigo);
    void Curar(IChar aliado);
}
