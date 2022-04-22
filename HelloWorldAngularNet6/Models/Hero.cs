namespace HelloWorldAngularNet6.Models
{
    public class Hero
    {
        /// <summary>
        /// Hero's ID in the DB
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Hero's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The id of the universe
        /// </summary>
        public int UniverseId { get; set; }

        /// <summary>
        /// The universe the hero originated from
        /// </summary>
        public Universe Universe { get; set; }
    }
}
