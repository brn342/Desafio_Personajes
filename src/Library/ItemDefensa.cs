namespace Library
{
    public class ItemDefensa : IItemDefensa
    {
        public string NombreItem { get; set; }
        public int Defensa { get; set; }
        public bool Especial { get; set; }

        public ItemDefensa(string nombreItem, int defensa, bool especial)
        {
            NombreItem = nombreItem;
            Defensa = defensa;
            Especial = especial;
        }
    }
}