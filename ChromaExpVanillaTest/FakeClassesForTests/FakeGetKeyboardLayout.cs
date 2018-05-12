using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return new CultureInfo( FakeLayout );
        }
    }
}
