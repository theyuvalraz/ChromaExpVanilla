using System.Globalization;
using Interfacer.Interfaces;

namespace ChromaExpVanillaTest.FakeClassesForTests
{
    internal class FakeGetKeyboardLayout : IGetKeyboardLayout
    {
        public FakeGetKeyboardLayout(string fakeLayout)
        {
            FakeLayout = fakeLayout;
        }

        public string FakeLayout { get; set; }

        public string GetCurrentKeyboardLayout()
        {
            return new CultureInfo(FakeLayout).ToString();
        }
    }
}