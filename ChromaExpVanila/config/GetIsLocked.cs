using System.Windows.Forms;
using Interfacer.Interfaces;

namespace ChromaExpVanilla.config
{
    public class GetIsLocked : IGetIsLocked
    {
        public bool IsCapsLocked
        {
            get { return Control.IsKeyLocked(Keys.CapsLock); }
            set { }
        }

        public bool IsNumLocked
        {
            get { return Control.IsKeyLocked(Keys.NumLock); }
            set { }
        }
    }
}