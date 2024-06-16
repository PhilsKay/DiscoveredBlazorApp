using Newtonsoft.Json;

namespace Discovered.Models
{
    public class BibleData
    {
        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("verses")]
        public List<Scripture> Verses { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
    public class Scripture
    {
        [JsonProperty("book_id")]
        public string BookId { get; set; }

        [JsonProperty("book_name")]
        public string BookName { get; set; }

        [JsonProperty("chapter")]
        public int Chapter { get; set; }

        [JsonProperty("verse")]
        public int Verse { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
