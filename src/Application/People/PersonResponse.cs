namespace Application.People
{
    public class PersonResponse
    {
        public string Id    { get; init; }
        public string Name  { get; init; }
        public string Genre { get; init; }
        public int    Age   { get; init; }

        public PersonResponse(string id, string name, int age, string genre)
        {
            Id    = id;
            Name  = name;
            Age   = age;
            Genre = genre;
        }
    }
}
