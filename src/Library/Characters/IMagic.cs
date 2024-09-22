namespace Library.Characters;

public interface IMagic: IChar
{
    SpellBook SpellBook { get; set; }
    void AtacarConHechizos(IChar enemigo);
    void CurarConHechizos(IChar aliado);
}