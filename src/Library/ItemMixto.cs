namespace Library
{
    public class ItemMixto : IItemDefensa, IItemAtaque
    {
        public string NombreItem { get; set; }
        public int Ataque { get; set; }
        public int Defensa { get; set; }
        public bool Especial { get; set; }

        public ItemMixto(string nombreItem, int ataque, int defensa, bool especial)
        {
            NombreItem = nombreItem;
            Ataque = ataque;
            Defensa = defensa;
            Especial = especial;
        }
        
        public int ValorAtaque()
        {
            return Ataque; 
        }

        public int ValorDefensa()
        {
            return Defensa;
        }
    }
}