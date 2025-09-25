using ConsoleApp1;
Random rnd = new Random();

Wall wall = new Wall();
wall.Draw();

List<Ball> balls = new List<Ball>();
List<(int, int)> positions = new List<(int, int)>();

for (int i = 0; i < 25; i++)
{
    Ball b = new Ball();
    balls.Add(b);
    b.x = rnd.Next(2, Console.WindowWidth - 2);
    b.y = rnd.Next(2, Console.WindowHeight - 5);
    positions.Add(b.GetPosition());
    b.Draw();
}

while (true)
{
    for (int i = 0; i < balls.Count; i++)
    {
        var otherPositions = new List<(int, int)>(positions);
        otherPositions.RemoveAt(i);

        balls[i].Move(otherPositions);

        positions[i] = balls[i].GetPosition();
    }
    await Task.Delay(30);
}
