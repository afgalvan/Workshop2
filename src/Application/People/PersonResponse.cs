namespace Application.People
{
    public class PersonResponse
    {
        public string Id         { get; init; }
        public string Name       { get; init; }
        public string Genre      { get; init; }
        public int    Age        { get; init; }
        public double HeartBeats { get; init; }

        public PersonResponse(string id, string name, int age, string genre,
            double heartBeats)
        {
            Id         = id;
            Name       = name;
            Age        = age;
            Genre      = genre;
            HeartBeats = heartBeats;
        }

        public override string ToString()
        {
            return $"{Id}, {Name}, {Age}, {Genre}, {HeartBeats}";
        }
    }
}
