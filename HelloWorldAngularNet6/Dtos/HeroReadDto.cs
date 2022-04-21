namespace HelloWorldAngularNet6.Dtos
{
    /// <summary>
    /// The ready-to-be-consumed format of a Hero
    /// </summary>
    public class HeroReadDto
    {
        /// <summary>
        /// Hero's id in the db
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Hero's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of the universe the hero belongs to
        /// </summary>
        public string Universe { get; set; }
    }
}
