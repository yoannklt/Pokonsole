using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokonsole.Source.Core.GameState
{
    internal class Menu
    {

        public List<Button> buttons;
        public Menu()
        {

        }

        public void init()
        {
            buttons = new List<Button>();

            Button NewGame = new Button();
            buttons.Add(NewGame);
            NewGame.Init_Button("NewGame");

            Button LoadSave = new Button();
            buttons.Add(LoadSave);
            LoadSave.Init_Button("LoadSave");

            Button Parameters = new Button();
            buttons.Add(Parameters);
            Parameters.Init_Button("Parameters");
        }

        public void Draw(int select)
        {
            Console.Clear();
            Console.WriteLine("Main Menu");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");

            

            for (int i = 0; i < buttons.Count; i++)
            {
                if (select == i)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Red;
                    
                    Console.WriteLine(buttons[i].mText);

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine(buttons[i].mText);

                }
            }
        }
    }
}
