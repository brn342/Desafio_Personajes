namespace Library
{
    public class ItemAtaque : IItemAtaque
    {
        public string NombreItem { get; set; }
        public int Ataque { get; set; }
        public int Defensa { get; set; } = 0;  // Para ítems de ataque, la defensa es 0
        public bool Especial { get; set; }

        public ItemAtaque(string nombreItem, int ataque, bool especial)
        {
            NombreItem = nombreItem;
            Ataque = ataque;
            Especial = especial;
        }

        public int ValorAtaque()
        {
            return Ataque; // Devuelve el valor de ataque del ítem
        }
    }
}