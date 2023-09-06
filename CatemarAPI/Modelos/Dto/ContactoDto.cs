using System.Net.NetworkInformation;

namespace CatemarAPI.Modelos.Dto
{
    public class ContactoDto
    {
        public List<Result> results { get; set; } = null!;
        
        public class Result
        {
                public string id { get; set; } = null!;
                public Properties properties { get; set; } = null!;
                public DateTime createdAt { get; set; }
                public DateTime updatedAt { get; set; }
                public bool archived { get; set; }
        }

        public class Properties
        {
            public DateTime createdate { get; set; }
            public string email { get; set; } = null!;
            public string firstname { get; set; } = null!;
            public string hs_object_id { get; set; } = null!;
            public DateTime lastmodifieddate { get; set; }
            public string lastname { get; set; } = null!;
        }
    }
}
