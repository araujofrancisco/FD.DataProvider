namespace FD.SampleData.Data
{
    public static class Generics
    {
        // TODO: use https://github.com/smashew/NameDatabases to generate a bigger set of names and surnames
        public static readonly string[] FirstNames = new[]
        {
            "Anna", "Edward", "John", "Paul", "Dawn", "Kyle", "Sheldon", "Douglas", "Martin", "Luke", "Phil", "Jane", "Joseph", "Peter", "Franklin"
        };

        public static readonly string[] LastNames = new[]
        {
            "Doe", "Perry", "Raussman", "Ford", "Thompson", "Smith", "Simpson", "Dunphy", "Brown", "Blake", "Cooper", "Jackson"
        };

        public static readonly string[] EmailProvider = new[]
        {
            "gmail.com", "outlook.com", "yahoo.com", "aol.com", "hotmail.com", "protonmail.com", "zohomail.com", "icloudmail.com", "123.com"
        };

        public static readonly string[] Roles = new[]
        {
            "Administrator", "PowerUser", "Reports", "Import", "Export", "User"
        };

        public static readonly string[] WeatherTypes = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching", "Sunny", "Overcast", "Foggy", 
            "Cloudy", "Rainy"
        };

    }
}
