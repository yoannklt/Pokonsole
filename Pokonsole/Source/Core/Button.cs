using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokonsole
{
    internal class Button
    {
        public string mText { get; set; }

        public Button() { }
        
        public void Init_Button(string text) 
        { 
        this.mText = text;
        }

    }
}
