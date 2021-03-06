﻿using Corale.Colore.Core;
using Corale.Colore.Razer.Keyboard;
using Interfacer.Interfaces;

namespace ChromaExpVanilla.config
{
    public class ColoredKey : IColoredKey
    {
        public ColoredKey()
        {
        }

        public ColoredKey(Key key, Color color = default(Color), int group = 0)
        {
            Key = key;
            Color = color;
            Group = group;
        }

        public Key Key { get; set; }
        public Color Color { get; set; }
        public int Group { get; set; }
    }
}