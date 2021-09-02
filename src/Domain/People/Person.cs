namespace Domain.People
{
    public class Person
    {
        public Person(string id, string name, int age, Genre genre)
        {
            Id    = id;
            Name  = name;
            Age   = age;
            Genre = genre;
        }

        public string Id         { get; init; }
        public string Name       { get; init; }
        public Genre  Genre      { get; init; }
        public int    Age        { get; init; }
        public double HeartBeats => ((int)Genre - Age) / 10.0;

        public void Deconstruct(out string id, out string name, out int age,
            out Genre genre,
            out double heartBeats)
        {
            id         = Id;
            name       = Name;
            age        = Age;
            genre      = Genre;
            heartBeats = HeartBeats;
        }

        public override string ToString()
        {
            return $"{Id}, {Name}, {Age}, {Genre}, {HeartBeats}";
        }
    }
}
