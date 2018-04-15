using Corale.Colore.Core;
using Corale.Colore.Razer.Keyboard;

namespace ChromaExpVanilla.config
{
    public class ColoredKey
    {
        public Key Key { get; set; }
        public Color Color { get; set; }
        public int Group { get; set; }

        public ColoredKey()
        {
        }

        public ColoredKey(Key key, Color color = default(Color), int group = 0)
        {
            Key = key;
            Color = color;
            Group = group;
        }
    }
}