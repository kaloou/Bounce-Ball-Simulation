using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Wall
    {
        private int height = Console.WindowHeight - 4; // -4 to leave space for the top info
        private int width = Console.WindowWidth / 2; // each wall character takes 2 spaces
        //private string color = "green";
        public string ColorName = "Green";
        public void Draw()
        {
            Console.Clear();
            int cursorx = 0;
            int cursory = 0;

            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), ColorName, true);
            //TOPWALL
            Console.SetCursorPosition(cursorx, cursory);
            for (int i = 0; i < width; i++)
            {
                Console.Write("■ ");
            }
            //LEFTWALL
            for (int i = 0; i < height; i++)
            {
                cursory++;
                Console.SetCursorPosition(cursorx, cursory);
                Console.Write("■");
            }


            //RIGHTWALL
            cursory = 0;
            cursorx = width * 2;
            for (int i = 0; i < height - 1; i++)
            {
                cursory++;
                Console.SetCursorPosition(cursorx, cursory);
                Console.Write("■");
            }

            //BOTTOMWALL
            cursory++;
            Console.SetCursorPosition(0, cursory);
            for (int i = 0; i < width; i++)
            {
                Console.Write("■ ");
            }
        }
        
    }
}