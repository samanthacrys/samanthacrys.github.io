namespace DefeatTheGlabgargs
{
    /// <summary>
    /// This is an enum that contains the values used to represent the game selections that the player can make.
    /// </summary>
    public enum GameSelections
    {
        /// <summary>
        /// This is used when the player has requested the map.
        /// </summary>
        ReadMap = -4,

        /// <summary>
        /// This is when the player has selected to quit the game.
        /// </summary>
        QuitGame = -2,

        /// <summary>
        /// This represents a state where no selection has been made. It is used by the game to force the system to
        /// redisplay when an option is presented that does not require the need to change rooms.
        /// </summary>
        NoSelection = 0,

        /// <summary>
        /// This represents the first item in the menu selection that the player can see.
        /// </summary>
        MenuItem1 = 1,

        /// <summary>
        ///  This represents the second item in the menu selection that the player can see.
        /// </summary>
        MenuItem2 = 2,

        /// <summary>
        /// This represents the third item in the menu selection that the player can see.
        /// </summary>
        MenuItem3 = 3,

        /// <summary>
        /// Represents the fourth menu item selection shown to the player.
        /// </summary>
        MenuItem4 = 4,

        /// <summary>
        /// This represents the fifth item in the menu selection that the player can see.
        /// </summary>
        MenuItem5 = 5
    }
}