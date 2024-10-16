namespace Library
{
    public class ItemAtaque :ItemBase, IItemAtaque
    {
        public int Ataque { get; set; }

        public ItemAtaque(string nombreItem, int ataque, bool especial)
            : base(nombreItem, especial)
        {
            Ataque = ataque;
        }
    }
}