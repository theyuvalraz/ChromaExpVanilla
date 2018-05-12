using System.Globalization;
using Interfacer.Interfaces;

namespace ChromaExpVanillaTest.FakeClassesForTests
{
    class FakeGetKeyboardLayout : IGetKeyboardLayout
    {
        public string FakeLayout { get; set; }

        public FakeGetKeyboardLayout(string fakeLayout)
        {
            FakeLayout = fakeLayout;
        }

        public CultureInfo GetCurrentKeyboardLayout()
        {
            return new CultureInfo(FakeLayout);
        }
    }
}