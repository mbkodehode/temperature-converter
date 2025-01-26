using system;
namespace oppgave3;
public class Player
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string array Position { get; set; }
    public int Rank { get; set; }

    public Player(string name, int age, string position, int rank)
    {
        Name = name;
        Age = age;
        Position = position;
        Rank = rank;
    }

    array<string> Position 
    { 
        string[] positions = {"Goalkeeper", "Defender", "Midfielder", "Striker"};
        return positions;
    }
}