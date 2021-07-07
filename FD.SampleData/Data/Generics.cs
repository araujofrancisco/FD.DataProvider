namespace FD.SampleData.Data
{
    public static class Generics
    {
        // TODO: use https://github.com/smashew/NameDatabases to generate a bigger set of names and surnames
        public static readonly string[] FirstNames = new[]
        {
            "Anna", "Edward", "John", "Paul", "Dawn", "Kyle", "Sheldon", "Douglas", "Martin", "Luke", "Phil", "Jane", "Joseph", "Peter", "Franklin",
            "Aaron", "Abby", "Abdul", "Abraham", "Ambrose", "Amy", "Arnold", "Arthur", "Brandy", "Brian", "Brigid", "Cathy", "Celine", "Chad",
            "Colin", "Corey", "Constance", "Debiie", "Dillon", "Diana", "Dixie", "Dolly", "Donald", "Dominique", "Erika", "Ellen", "Elliot",
            "Farrah", "Evita", "Fanny", "Fay", "Gabriela", "Fred", "Ivonne", "Jackeline", "Jenny", "Johanna", "Jodie", "Kaitlyn", "Kara", "Kelly"
        };

        public static readonly string[] LastNames = new[]
        {
            "Doe", "Perry", "Raussman", "Ford", "Thompson", "Smith", "Simpson", "Dunphy", "Brown", "Blake", "Cooper", "Jackson", "Acre", "Adam",
            "Acosta", "Adler", "Aguilar", "Albany", "Allen", "Badder", "Bafford", "Beiswanger", "Bierley", "Boehler", "Borowicz", "Brabson", "Brader",
            "Cartier", "Caterino", "Cialella", "Delashmit", "Dermo", "Ertzbischoff", "Eytcheson", "Fiotodimitrak", "Garrington", "Harvilchuck", "Harwick"
        };

        public static readonly string[] EmailProvider = new[]
        {
            "gmail.com", "outlook.com", "yahoo.com", "aol.com", "hotmail.com", "protonmail.com", "zohomail.com", "icloudmail.com", "123.com"
        };

        public static readonly string[] Roles = new[]
        {
            "Administrator", "PowerUser", "Reports", "Import", "Export", "User", "Guest"
        };

        public static readonly string[] WeatherTypes = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching", "Sunny", "Overcast", "Foggy", 
            "Cloudy", "Rainy"
        };

        public static readonly string[] ReportTypes = new[]
        {
            "Express", "Daily", "Weekly", "None", "Monthly"
        };
    }
}
