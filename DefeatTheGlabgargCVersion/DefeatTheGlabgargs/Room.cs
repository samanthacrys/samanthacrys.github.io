namespace DefeatTheGlabgargs
{
    /// <summary>
    /// This is the Room class that handles all of the default operations that are common across all of the rooms.
    /// Every room in the game inherits from this class.
    /// </summary>
    public class Room
    {
        public string Name { get; set; }
        public bool Visited { get; set; }
        
        /// <summary>
        /// This is the room class' constructor. It sets the name and visited fields to their default values. Each
        /// room that inherits from this class overrides these values with their specific values that are needed for
        /// that room.
        /// </summary>
        protected Room()
        {
            Name = string.Empty;
            Visited = false;
        }
        
        /// <summary>
        /// Displays the base information about the players state.
        /// </summary>
        /// <returns>
        /// The total options added. Since this method doesn't add any options ot the max options, it is a return of
        /// 0. The room that inherits from this base class is responsible for calling and overriding this method.
        /// </returns>
        public virtual int Display()
        {
            Program.player.Turns++;
            Console.WriteLine($"Turn:\t{Program.player.Turns}.\r\n");
            Console.WriteLine($"Score:\t{Program.player.Score} points.\r\n");
            Console.WriteLine($"Room:\t{Name} room.\r\n");
            Console.WriteLine($"--------------------------------------------------------------------");
            
            return 0;
        }

        public virtual GameSelections ProcessInput(int maxSelect)
        {
            return 0;
        }
    }
}