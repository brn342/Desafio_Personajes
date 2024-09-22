namespace Library
{
    public class ItemDefensa : IItemDefensa
    {
        public string NombreItem { get; set; }
        public int Ataque { get; set; } = 0;  // Para ítems de defensa, el ataque es 0
        public int Defensa { get; set; }
        public bool Especial { get; set; }

        public ItemDefensa(string nombreItem, int ataque, bool especial)
        {
            NombreItem = nombreItem;
            Ataque = ataque;
            Especial = especial;
        }

        public int ValorDefensa()
        {
            return Defensa; // Devuelve el valor de ataque del ítem
        }
    }
}