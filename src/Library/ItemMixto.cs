namespace Library
{
    public class ItemMixto : ItemBase, IItemDefensa, IItemAtaque
    {
        public int Ataque { get; set; }
        public int Defensa { get; set; }

        public ItemMixto(string nombreItem, int ataque, int defensa, bool especial)
            : base(nombreItem, especial)
        {
            Ataque = ataque;
            Defensa = defensa;
        }
    }
}