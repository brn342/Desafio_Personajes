namespace Library.Characters;

public interface IChar
{
    string Nombre { get; set; }
    int ValorVida { get; set; }
    int ValorAtaque { get; set; }
    List<IItem> Items { get; set; }
    int ValorVidaInicial { get; }
    
    void AgregarItem(IItem item);
    void QuitarItem(IItem item);
    int CalcularVidaTotal();
    int CalcularAtaqueTotal();
    void Atacar(IChar enemigo);
    void Curar(IChar aliado);
}
