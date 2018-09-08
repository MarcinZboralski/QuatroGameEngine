using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;

namespace QuatroGameEngine.Input
{
    [System.Serializable]
    public class Button
    {
        public string buttonName;

        public Key firstKey;
        public Key secondKey;

        public Button(string buttonName, Key firstKey, Key secondKey)
        {
            this.buttonName = buttonName;
            this.firstKey = firstKey;
            this.secondKey = secondKey;
        }
    }
}
