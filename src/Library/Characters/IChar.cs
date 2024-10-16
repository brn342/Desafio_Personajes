namespace Library.Characters;

public interface IChar
{
    string Nombre { get; set; }
    int ValorVida { get; set; }
    int ValorAtaque { get; set; }
    List<ItemBase> Items { get; set; }
    int ValorVidaInicial { get; }
    
    void AgregarItem(ItemBase item);
    void QuitarItem(ItemBase item);
    int CalcularVidaTotal();
    int CalcularAtaqueTotal();
    void Atacar(IChar enemigo);
    void Curar(IChar aliado);
}
