using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Ball
    {
        private string color = "Red";
        private int size = 0;
        public int x = 6;
        public int y = 9;

        private int currentDirectionX = -1;
        private int currentDirectionY = -1;

        // Méthode Move modifiée
        public void Move(List<(int x, int y)> otherBallsPositions)
        {
            Clear();

            // Déplacement
            x += currentDirectionX;
            y += currentDirectionY;

            // Rebonds avec les murs
            if (x <= 1 || x >= Console.WindowWidth - 2)
                BounceX();
            if (y <= 1 || y >= Console.WindowHeight - 5)
                BounceY();

            foreach (var pos in otherBallsPositions)
            {
                if (x == pos.x && y == pos.y)
                {
                    BounceX();
                    BounceY();
                    break;
                }
            }

            // Met à jour la liste avec la nouvelle position
            for (int i = 0; i < otherBallsPositions.Count; i++)
            {
                if (otherBallsPositions[i].x == x && otherBallsPositions[i].y == y)
                {
                    otherBallsPositions[i] = (x, y);
                    break;
                }
            }

            Draw();
        }

        public void ChangeColor(string color)
        {
            this.color = color;
        }

        public string GetInfo()
        {
            return $"color: {color}, size: {size}, x: {x}, y: {y}";
        }

        public void Draw()
        {
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color, true);
            Console.SetCursorPosition(x, y);
            Console.Write("◯");
            Console.SetCursorPosition(Console.WindowWidth, Console.WindowHeight - 4);
        }

        public void Clear()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }

        public void BounceX() => currentDirectionX *= -1;
        public void BounceY() => currentDirectionY *= -1;

        public (int x, int y) GetPosition() => (x, y);
    }
}
