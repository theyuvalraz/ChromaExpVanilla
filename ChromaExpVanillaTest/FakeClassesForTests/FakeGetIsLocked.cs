using Interfacer.Interfaces;

namespace ChromaExpVanillaTest.FakeClassesForTests
{
    public class FakeGetIsLocked : IGetIsLocked
    {
        public bool IsCapsLocked { get; set; }
        public bool IsNumLocked { get; set; }
    }
}