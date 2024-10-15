namespace Library
{
    public class ItemAtaque : IItemAtaque
    {
        public string NombreItem { get; set; }
        public int Ataque { get; set; }
        public bool Especial { get; set; }

        public ItemAtaque(string nombreItem, int ataque, bool especial)
        {
            NombreItem = nombreItem;
            Ataque = ataque;
            Especial = especial;
        }
    }
}