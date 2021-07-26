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

        public static readonly string[] PersonTypes = new[]
        {
            "IN", "EM", "SP", "SC", "VC", "GC"
        };

        public static readonly string[] PersonTitles = new[]
        {
            "Sr.", "Mrs.", null, "Sra.", "Ms.", "Mr."
        };

        public static readonly string[] PersonSuffix = new[]
        {
            "Sr.", "PhD", null, "IV", "II", "Jr.", "III"
        };

        public static readonly string[] Addresses = new[]
        {
            "589 Halifax Rd.", "994 Gainsway St.", "9082 W. Halifax Court", "205 SW. Blackburn Drive", "779 Brandywine Dr.", "731 Del Monte Street", "8527 North Linden Drive",
            "106 West Princeton Lane", "8181 Thomas Drive", "303 Sage St.", "46 Rock Maple Ave.", "8028 Buttonwood Court", "398 Arrowhead Street", "588 Glen Creek Lane",
            "16 Virginia St.", "7970 York St.", "9862 Armstrong St.", "748 Strawberry Street", "71 Hilltop Ave.", "59 Henry Smith Court", "138 Clark Drive", "115 Oakland Ave.",
            "65 East Court Street", "80 Old Pacific Drive", "46 Warren Lane", "80 Theatre Street", "9518 Chapel Lane", "567 Roberts Drive", "9448 Cedar Swamp Drive", 
            "102 Edgefield Ave.", "7785 Amerige Street", "838 Wagon Ave.", "9180 Wood St.", "8427 College St.", "704 6th Street", "70 Elmwood Street", "2 Shub Farm Court",
            "75 Linda Ave.", "806 Windfall Lane", "42 Glenwood Road", "676 Main Dr.", "837 Beach Dr.", "134 Virginia Dr.", "47 East Fordham Rd.", "40 Front Street",
            "47 Fremont Street", "4 W. Pendergast Dr.", "7 Beaver Ridge St.", "672 Trout St.", "9418 Birchwood St.", "7 Rockland Drive", "608 North Ketch Harbour Ave.",
            "73 Pin Oak Drive", "476 Ohio Ave.", "51 E. Theatre St.", "799 Mulberry Lane", "902 Lakewood St.", "578 Church St.", "267 Poplar Court", "8100 Vine Street",
            "356 Ohio Drive", "64 Jones Drive", "9746 Ramblewood Avenue", "505 W. Saxton Street", "9510 Thatcher St.", "8609 Andover Street", "489 Greenrose Rd.",
            "65 Bay Meadows Lane", "7417 Hartford Lane", "1 Bridgeton St.", "884 York Dr.", "76 Fawn Lane", "36 St Paul Drive", "885 Branch Street", "22 Ocean Ave.",
            "9526 Lancaster Ave.", "752 E. Newport Street", "17 Pawnee Lane", "9 Trusel Lane", "798 Beechwood Ave.", "920 Halifax St.", "31 East Green Lake Drive",
            "8601 Garfield Street", "200 Circle Dr.", "39 Prairie Drive", "7261 Laurel Drive", "8781 Carriage Road", "61 Longfellow St.", "8 6th Drive",
            "5 Delaware St.", "7672 Pawnee St.", "949 Wayne Drive", "69 Lilac Dr.", "465 Wellington Drive", "7565 Virginia Dr.", "742 Primrose St.", "375 East Argyle St.",
            "426 Homewood Ave.", "64 Indian Spring St.", "7791 N. Richardson Ave."
        };

        public static readonly string[] Cities = new[]
        {
            "Cheltenham", "Kingsport", "Suresnes", "Baltimore", "Reading", "Fontana", "Braunschweig", "Sooke", "Newark", "Oxnard", "Cheyenne", "Modesto",
            "Charlotte", "Phoenix", "Richmond Hill", "Kansas City", "Redwood City", "Monrovia", "Frankfurt", "Plano", "Eilenburg", "Saginaw", "Courbevoie",
            "Royal Oak", "Elk Grove", "Sillery", "Runcorn", "North Randall", "Kassel", "Miami", "Oxon", "Round Rock", "Newton", "Chalk Riber", "Norwood",
            "Kittery", "Kannapolis", "Rhodes", "Longview", "Logansport", "North Sydney", "Sacramento", "Saint Germain en Laye", "Gold Bar", "N. Vancouver",
            "Newcastle upon Tyne", "Ogden", "Gilroy", "Longmont", "Englewood", "Mansfield", "Santa Ana", "Redford", "Grossmont", "Mentor", "Ville De'anjou",
            "Fullerton", "Irving", "Denby", "Raleigh", "Merritt Island", "Los Angeles", "Gulfport", "Gilbert", "Waterloo", "Sand City", "La Marque", "Corpus Christi",
            "Index", "Santa Cruz", "Cerritos", "Kingston", "Nashua", "Portland", "Sandy", "South Bend", "Renton", "Winston-Salem", "Seattle", "Austin",
            "Etobicoke", "Clackamas", "Crossville", "Oregon City", "Newport Hills", "Carol Stream", "Parker", "Escondido", "Paris", "Liverpool", "Montreal",
            "Westminster", "Brisbane", "Tucson", "Pontiac", "Oak Bay", "Bluffton", "Klamath Falls", "Quebec", "Lancaster", "Lavender Bay", "Boulogne-Billancourt",
            "Salem", "Albany", "Basingstoke Hants", "Minneapolis", "Marietta", "Kiel", "Bury", "Brampton", "Atlanta", "Las Cruces", "Saint John", "Greeley",
            "Vista", "Eureka", "Saarbrücken", "Southgate", "Lakeland", "Woonsocket", "Stockton", "Baytown", "Yakima", "Burien", "Waterbury", "Gateshead",
            "Lake Oswego", "Cedar Park", "Caloundra", "Sunrise", "London", "Olympia", "Lake Elsinore", "Kennewick", "Saugus", "Ballard", "Riverton",
            "San Jose", "Altamonte Springs", "Stamford", "El Segundo", "Michigan City", "Woodland Hills", "Virginia Beach", "Pantin", "Orly", "Camarillo",
            "Maryville", "Palo Alto", "Biloxi", "Tooele", "Southfield", "Sherman Oaks", "Les Ulis", "Burbank", "Issaquah", "Spokane", "Sequim", "Sparks",
            "Marysville", "Berks", "Weston", "Casper", "Melville", "Altadena", "Sandpoint", "Tilton", "North Miami Beach", "Moline", "De Witt", "Morangis",
            "San Diego", "New York", "Edina", "Greensboro", "Chula Vista", "Bothell", "Kelso", "Villeneuve-d'Ascq", "Daly City", "Norwalk", "Great Falls",
            "Drancy", "Ellensburg", "Auburn", "Gloucestershire", "Denver", "St. Louis", "Rock Springs", "Kanata", "Endicott", "Kent", "Visalia", "Monroe",
            "Walnut Creek", "Philadelphia", "Rocky Mount", "Wrentham", "Sedro Woolley", "Lincoln Acres", "College Station", "Arlington", "Lane Cove", 
            "Markham", "Shelton", "Ontario", "Abingdon", "Townsville", "Milwaukie", "East Brisbane", "Hayward", "Pigeon Forge", "Hanford", "Warrington",
            "Bell Gardens", "San Antonio", "Washougal", "Vero Beach", "Tigard", "München", "Plaistow", "Lebanon", "Oberlin", "Leesburg", "Everett", "Houston",
            "Chandler", "Hooksett", "La Grange", "Springfield", "Lille", "Van Nuys", "Reno", "Mühlheim", "Geelong", "Rockhampton", "Aujan Mournede", "Medford",
            "Duluth", "Barrie", "Duesseldorf", "Simi Valley", "Randolph", "Branch", "Muehlheim", "Malabar", "Maidenhead", "Roissy en Brie", "Sydney",
            "Woodbury", "Port Huron", "Lieusaint", "Calgary", "New Castle", "Sèvres", "Mcdonough", "Münster", "El Cajon", "North York", "Snohomish", "Branson",
            "Lake George", "Aurora", "Saint-Denis", "Hannover", "Alhambra", "Bendigo", "Springdale", "Dorval", "Warwick", "Clay", "Newport Beach", "Downey",
            "Boulogne-sur-Mer", "Westland", "Colma", "Surprise", "Milford", "Lacey", "Whittier", "Sammamish", "Torrance", "Toronto", "Offenbach", "Shawnee",
            "Novi", "Braintree", "Saarlouis", "Langford", "Mesa", "City Of Commerce", "Boston", "La Vergne", "Grevenbroich", "Mill Valley", "San Bruno",
            "Hillsboro", "Metz", "Dallas", "Huntsville", "Canoga Park", "Bracknell", "Sunbury", "Glendale", "Newport News", "Metchosin", "West Sussex",
            "Florence", "Mosinee", "Paris La Defense", "Langley", "Darlinghurst", "Hobart", "Birmingham", "Woolston", "Missoula", "Richmond", "Melton",
            "Burlingame", "Edmonton", "Chantilly", "Stoke-on-Trent", "Cliffside", "Bobigny", "Essen", "West Kingston", "Madison Heights", "Central Valley",
            "Bellingham", "San Carlos", "Garland", "Poing", "Saint Ouen", "Billericay", "Anacortes", "Bountiful", "Irvine", "Dunkerque", "Federal Way", 
            "W. York", "Campbellsville", "Daleville", "East Haven", "Ottawa", "Cambridge", "Ferguson", "Smithfield", "Burnaby", "Seaford", "Rio Rancho", 
            "Bad Soden", "New Hartford", "Newport", "High Wycombe", "Watford", "Tupelo", "Myrtle Beach", "Kendall", "Decatur", "Croix", "Gaffney", "San Gabriel",
            "Milsons Point", "Nepean", "Verrieres Le Buisson", "Bellflower", "Idaho Falls", "Jefferson City", "Somerset", "W. Linn", "Goulburn", "Peoria",
            "Scarborough", "Austell", "Fort Worth", "Carrollton", "Winnipeg", "San Mateo", "Cincinnati", "Joliet", "Surrey", "Killeen", "Bordeaux", "North Bend",
            "Midland", "Santa Monica", "Saint Louis", "Milwaukee", "Esher-Molesey", "Hamburg", "Outremont", "Roncq", "Coffs Harbour", "Clarkston", "Johnson Creek",
            "Springwood", "Findon", "Euclid", "Sugar Land", "Ascheim", "Union Gap", "Port Macquarie", "National City", "Troutdale", "Colomiers", "Clearwater",
            "Ingolstadt", "Cergy", "Corvallis", "Laredo", "Silverwater", "Vancouver", "Cranbourne", "Zeeland", "Dresden", "Vacaville", "Concord", "St. Leonards",
            "Barstow", "Erlangen", "Salzgitter", "Tremblay-en-France", "Bradenton", "Holland", "Alpine", "Montgomery", "Stafford", "Redmond", "La Mesa",
            "Roubaix", "Hawthorne", "Long Beach", "Nashville", "Sulzbach Taunus", "Park City", "Berkshire", "Chicago", "Elgin", "North Ryde", "Orlando",
            "Salt Lake City", "Spring Valley", "Woodinville", "Paderborn", "Solingen", "Versailles", "Orleans", "Hollywood", "Kenmore", "Fort Wayne",
            "San Ramon", "Bellevue", "Indianapolis",  "Hull", "Edmonds", "Duvall", "Baldwin Park", "Saint Matthews", "Frankfurt am Main", "Lewiston", "Wollongong",
            "Wood Dale", "Union City", "Byron", "Werne", "Memphis", "Cheektowaga", "Las Vegas", "Neunkirchen", "Kirkland", "Walla Walla", "Alexandria", "Saint Ann",
            "Humble", "Leipzig", "Chehalis", "Brossard", "Scottsdale", "Tampa", "Milton Keynes", "Cedar City", "Destin", "York", "Cloverdale", "Colombes",
            "Berkeley", "Imperial Beach", "Odessa", "Sainte-Foy", "Tuscola", "Howell", "Lakewood", "Hof", "Milpitas", "Bremerton", "North Las Vegas", "Falls Church",
            "West Covina", "Berlin", "Heath", "Peterborough", "Detroit", "San Francisco", "Racine", "Mesquite", "Newcastle", "Millington", "La Jolla", "Matraville",
            "Port Hammond", "Perth", "Mobile", "Beverly Hills", "North Sioux City", "Westport", "Boise", "Augusta", "San Ysidro", "Kirkby", "Wenatchee",
            "Bottrop", "Bonn", "Hixson", "Stuttgart", "Lemon Grove", "Fremont", "Columbus", "Ithaca", "Wokingham", "Farmington", "Pleasanton", "Hamden",
            "Culver City", "Augsburg", "Warrnambool", "Woodburn", "Nevada", "Lynnwood", "New Haven", "Redlands", "Victoria", "Mississauga", "Billings", "Puyallup",
            "Oakland", "Coronado", "Valley Stream", "Loveland", "Carson", "Suwanee", "Darmstadt", "Hervey Bay", "Oxford", "West Chicago", "Haney", "Beaverton",
            "Gold Coast", "Fernley", "Upland", "Tacoma", "Carnation", "Leeds", "Novato", "Citrus Heights", "Santa Fe", "Chatou", "Port Orchard", "Pnot-Rouge",
            "Melbourne", "Savannah", "Orange", "Norridge", "South Melbourne", "Trabuco Canyon", "Sarasota"
        };
    }
}
