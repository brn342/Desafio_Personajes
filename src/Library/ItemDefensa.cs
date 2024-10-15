namespace Library
{
    public class ItemDefensa :ItemBase, IItemDefensa
    {
        public int Defensa { get; set; }

        public ItemDefensa(string nombreItem, int defensa, bool especial)
            : base(nombreItem, especial)
        {
            Defensa = defensa;
        }
    }
}