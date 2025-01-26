namespace oppgave3;
public class Player
{
    internal int count;

    public string Name { get; set; }
    public int Age { get; set; }
    public string  Position { get; set; }
    public int Rank { get; set; }

    

    public Player(string name, int age, string position, int rank)
    {
        Name = name;
        Age = age;
        Position = position;
        Rank = rank;
    }


}