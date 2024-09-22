namespace Library;

public interface IItem
{
    string NombreItem { get; set; }
    int Ataque { get; set; }
    int Defensa { get; set; }
    bool Especial { get; set; }
}