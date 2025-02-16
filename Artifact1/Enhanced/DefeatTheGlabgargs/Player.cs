namespace DefeatTheGlabgargs
{
    /// <summary>
    /// This is the class that manages the player. This includes trackign the various game states that are changed
    /// by the player while they play the game.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// This gets or sets the value. This is used to indicate whether the player has examined the console
        /// that is located on the Bridge. When this is set to true, it indicates that the player intereacted with
        /// the console and has triggered the event associated with that object.
        /// </summary>
        public bool ExaminedConsole { get; set; }

        /// <summary>
        ///This gets or sets the value that indicates whether the player has downloaded the map from the Bridge's
        ///console event. When this is set to true, it indicates that the player has successfully retrieved the map
        ///and can access it to navigate the floors or for other purposes.
        /// </summary>
        public bool MapDownloaded { get; set; }

        /// <summary>
        /// This gets or sets the value that indicates whether the player possesses the map. When this is set to true,
        /// it signifies that the player has acquired the map. This map is used for additional navigational or
        /// informational functionality.
        /// </summary>
        public bool HasMap { get; set; }

        /// <summary>
        /// This gets or sets the value that indicates whether or not hte player possesses the Mirror. When the
        /// player has this mirror, it enables specific game actions that relate to interactions or the unlocking of
        /// certain events that occur within the game.
        /// </summary>
        public bool HasMirror { get; set; }

        /// <summary>
        /// This gets or sets the value that indicates whether the Key Codes. When this is set to true, it enables
        /// unlocks additional movement functionality and game progression.
        /// </summary>
        public bool HasKeyCodes { get; set; }

        /// <summary>
        /// This gets or sets the value that indicates the players possession of the Bag of Marbles item. This property
        /// is used to determine if the player is able to interact with specific events or actions that require the
        /// marbles to succeed.
        /// </summary>
        public bool HasMarbles { get; set; }

        /// <summary>
        /// This gets or sets the value that indicates whether the player has possession of the Flash Charge object.
        /// If this is true, the player has acquired the Flash Charge and is able to trigger specific events that allow
        /// for completing the game.
        /// </summary>
        public bool HasFlashCharge { get; set; }

        /// <summary>
        /// This gets or sets the value that indicates whether or not the player has used the marbles during the game.
        /// This property reflects that the player has triggered the action that involves the marbles. These actions
        /// include: throwing them or using them in specific scenarios.
        /// </summary>
        public bool MarblesUsed { get; set; }

        /// <summary>
        /// This gets or sets the value that indicates whether the player has interacted with the computer from the
        /// Engine Room. If this is true, it signifies that the computer has been used and that the player has received
        /// userful information and advanced the game.
        /// </summary>
        public bool UsedComputer { get; set; }

        /// <summary>
        /// This gets or sets the value that indicates whether the player has read the Sticky Note. Wen this is set to
        /// true, it shows that the player has interacted with the Sticky Note and has gained important information
        /// that benefits the player in reaching the win scenario.
        /// </summary>
        public bool ReadStickNote { get; set; }

        /// <summary>
        /// This gets or sets the favlue that indicates whether or not hte player is in possession of the Ray Gun item.
        /// When this is set to true, it shows that the player has acquired the Ray Gun and enabled specific in game
        /// actions.
        /// </summary>
        public bool HasRayGun { get; set; }

        /// <summary>
        /// This gets or sets the value that indicates whether the player has used the Ray Gun. This property reflects
        /// whether or not the Ray Gun action has been triggered. The use of the Ray Gun can affect certain game events
        /// and player interactions when used at the wrong time.
        /// </summary>
        public bool RayGunUsed { get; set; }

        /// <summary>
        /// This gets or sets the value that indicates whether the player has used the Flash Charge item. When this is
        /// set to true, it indicates that the user has used the Flash Charge. This is typically a part of an action
        /// or event in the game.
        /// </summary>
        public bool FlashChargeUsed { get; set; }

        /// <summary>
        /// This gets or sets the value that indicates whether the Glabgarg is in Corridor 3 is unconscious or not.
        /// This property becomes true when the player successfully incapacitates the Glabgarg by using an item or
        /// action that renders the corridor safe to travel through.
        /// </summary>
        public bool CorridorThreeGlagargUnconscious { get; set; }

        /// <summary>
        /// This gets or sets the value that indicates whether the Glabgarg in the Crew Commons has been stunned. This
        /// property is updated when the player takes specific actions, such as using the marbles or the Flash Charge
        /// to render the Glabgarg incapacited and allows further game progress.
        /// </summary>
        public bool CrewCommonGlagargStunned { get; set; }

        /// <summary>
        /// This represents the current player score. The score increases as the player successfully completes
        /// specific tasks and also when interacting with certain objects during gameplay. This provides a measure of
        /// a player's progress and achievements found within the game.
        /// </summary>
        public int Score;

        /// <summary>
        /// This tracks the number of turns that the player has taken during the game. This value is incremented
        /// whenever the player performs an action or progresses within the game. This allows the game to monitor
        /// the gameplay duration and provides feedback at the conclusion of the session.
        /// </summary>
        public int Turns;

        /// <summary>
        /// This gets or sets the current room that the player is located. This property represents the room that
        /// the player is actively interacting with and is updated as the player moves between the rooms during
        /// gameplay.
        /// </summary>
        public Room current = Program.bridge;

        /// <summary>
        /// This represents the current flow that the player is located on within the game. The floor determines the
        /// available rooms and the interactions that are specific to that location.
        /// </summary>
        public int floor = 1;

        /// <summary>
        /// This displays the map of the current floor. This highlights the accessible rooms based on the floor.
        /// </summary>
        /// <remarks>
        /// This method determines the current player floor and prints the name of the available rooms on that floor.
        /// It always begins by showing the Lift, followed by the rooms on the respective floor. IE: Floor 1--Lift,
        /// Bridge, Captain's Office.
        /// </remarks>
        public void ReadMap()
        {
            Console.WriteLine("Map:");
            Console.WriteLine("    Lift");
            switch (floor)
            {
                case 1:
                    Console.WriteLine("    Bridge");
                    Console.WriteLine("    Captain's Office");
                    break;
                case 2:
                    Console.WriteLine("    Corridor");
                    Console.WriteLine("    Sleeping Quarters");
                    Console.WriteLine("    Engine room");
                    Console.WriteLine("    Armory");
                    break;
                case 3:
                    Console.WriteLine("    Hallway");
                    Console.WriteLine("    Crew Commons");
                    break;
            }
        }

        /// <summary>
        /// This retrieves the player's menu selection from the available options within the specified range.
        /// </summary>
        /// <remarks>
        /// This method presents various gameplay options based on the player's current state and available resources.
        /// This also depends on whether or not a saved game exists, which can cause additional options to be displayed.
        /// This ensures that the player has a selection of valid menu options within the provided range.
        /// </remarks>
        /// <param name="first">The first valid menu option as an integer.</param>
        /// <param name="last">The last valid menu option as an integer.</param>
        /// <returns>A <see cref="GameSelections"/> The value indicating the player's menu choice.</returns>
        public static GameSelections GetSelection(int first, int last)
        {
            if (Program.player.HasMap)
            {
                Console.WriteLine($"R) Read map.");
            }

            Console.WriteLine($"Q) Quit game.");

            while ( true )
            {
                while (!Console.KeyAvailable)
                {
                    Thread.Sleep(100);
                }
                char ch = Console.ReadKey(true).KeyChar;
                switch (ch)
                {
                    case 'R':
                    case 'r':
                        Console.WriteLine(ch.ToString());
                        return GameSelections.ReadMap;
                    case 'q':
                    case 'Q':
                        Console.WriteLine(ch.ToString());
                        return GameSelections.QuitGame;
                    case '1':
                        Console.WriteLine(ch.ToString());
                        return GameSelections.MenuItem1;
                    case '2':
                        Console.WriteLine(ch.ToString());
                        return GameSelections.MenuItem2;
                    case '3':
                        Console.WriteLine(ch.ToString());
                        return GameSelections.MenuItem3;
                    case '4':
                        Console.WriteLine(ch.ToString());
                        return GameSelections.MenuItem4;
                    case '5':
                        Console.WriteLine(ch.ToString());
                        return GameSelections.MenuItem5;
                }
            }
        }

        /// <summary>
        /// This simulates the player's encounter with a Glabgarg in the corridor, which can result in the player's
        /// death.
        /// </summary>
        /// <remarks>
        /// This method describes the events that occur when the player enters the corridor and encounters a Glabgarg.
        /// It provides a narrative that outputs a sequence of messages that detail the encounter and indicates the
        /// termination of the game.
        /// </remarks>
        /// <returns>
        /// Always returns <see cref="GameSelections.QuitGame"/> to signify the end of the game following the player's death.
        /// </returns>
        private static GameSelections DieInCorridor()
        {
            Console.WriteLine("You enter the corridor from the Lift.");
            Console.WriteLine("\r\n");
            Console.WriteLine("A Glabgarg you didn't expect turns and sees you.\r\n");
            Thread.Sleep(100);
            Console.WriteLine("After staring at you for a single moment, he raises his blaster at you.");
            Console.WriteLine("\r\n");
            Thread.Sleep(100);
            Console.WriteLine("You stare at him for the single section it takes him to pull the trigger and shoot you " +
                "in the chest. The blaster shot hits you and you die instantly. Sorry about that, maybe you should be " +
                "more careful next time.\r\n");
            return GameSelections.QuitGame;
        }

        /// <summary>
        /// This allows the player to enter a corridor from the Lift. It allows for interaction with the elements and
        /// the handling o any potential dangers that exist.
        /// </summary>
        /// <remarks>
        /// This method is used to manage the plahyer's actions when they enter a corridor. If the corridor has not
        /// been visited, it updates the state of the corridor. This method also checks if the player is in possession
        /// of the Mirror item. Possession of this item allows for observing to see that there is a Glabgarg in the
        /// corridor and wait for it to fall asleep. This depends on the current floor that the player is in. It will
        /// update the information based on whether or not the player is on the second or third floor corridor. This
        /// method then returns a corresponding menu selection based on that information.
        /// </remarks>
        /// <returns>
        /// This returns a menu selection that indicates the next action available to the player.
        /// </returns>
        public GameSelections EnterCorridor()
        {
            if (!Program.player.current.Visited)
            {
                
            }

            if (!HasMirror)
            {
                return DieInCorridor();
            }

            Console.WriteLine("You're about to enter the corridor, but realize that it might be a good idea to use" +
                "the mirror before doing so. You  can never be too careful.\r\n");
            Console.Write("When you stick the mirror just enough around the corner of the door, you see that there is a " +
                "Glabgarg in the corridor. With the enemy in the corridor, you decide that it is a better idea to wait " +
                "and see what is going to happen before making any decisions.\r\n");
            for (int ii = 1; ii <= 3; ++ii)
            {
                Thread.Sleep(100);
                switch (ii)
                {
                    case 1:
                        Console.WriteLine("\r\n");
                        Console.WriteLine("As you watch and wait, the Glabgarg walks to end of the corridor.\r\n");
                        break;
                    case 2:
                        Console.WriteLine("It stands for a few moments before turning and sitting down on the floor. " +
                            "It then leans back against the wall.\r\n");
                        break;
                    case 3:
                        Console.WriteLine("After a few moments, the three eyes close and the Glabgarg decides to " +
                            "fall asleep and take a nap. It should be safe to sneak around now.\r\n");
                        break;
                }
            }

            if (Program.player.floor == 2)
            {
                Program.player.current = Program.floorTwoCorridor;
            }
            else
            {
                Program.player.current = Program.floorThreeCorridor;
            }
            return GameSelections.MenuItem1;

        }

        /// <summary>
        /// This adds the option for the player to throw the marbles during the current interaction if
        /// the conditions are met.
        /// </summary>
        /// <remarks>
        /// This method checks on whether the player  has marbles and if they haven't been used.
        /// If both conditions are true, there is an additional option to throw the marbles and the selection count
        /// is incremented.
        /// </remarks>
        /// <param name="maxSelect">This is a reference to the variable that tracks the maximum selectable options in
        /// the current interaction. This value is incremented if the option to throw marbles is added.</param>
        /// <returns>Returns true if the marble option is successfully added; otherwise, it is false.</returns>
        public bool AddMarblesOption(ref int maxSelect)
        {
            if (!Program.player.HasMarbles || Program.player.MarblesUsed)
            {
                return false;
            }
            ++maxSelect;
            Console.WriteLine($"{maxSelect}) Throw the Marbles at the Glabgarg.");
            return true;

        }

        /// <summary>
        /// This adds the option to use the Ray Gun against the Glagarg, but only if certain conditions are met.
        /// </summary>
        /// <remarks>
        /// This method evaluates whether or not the player is in possession of the Ray Gun and has not used it. If
        /// both of these conditions are true, it increments the menu option count and displays the menu options that
        /// allow for using the Ray Gun.
        /// </remarks>
        /// <param name="maxSelect">This is a reference to the current maximum selectable menu option number, which
        /// will be incremented if an option is added.</param>
        /// <returns>Returns true if the ray gun option is successfully added; otherwise, returns is is false.</returns>
        public bool AddRayGunOption(ref int maxSelect)
        {
            if (!Program.player.HasRayGun || Program.player.RayGunUsed)
            {
                return false;
            }
            ++maxSelect;
            Console.WriteLine($"{maxSelect}) Shoot the Ray Gun at the Glabgarg.");
            return true;
        }

        /// <summary>
        /// This adds the option to use the Flash Charge to the player's available choices. If the player has a
        /// Flash Charge and has not been used, then both conditions are met.
        /// </summary>
        /// <param name="maxSelect">This is a reference to the current maximum selection index for the player's
        /// options, which will be incremented if the option is added.</param>
        /// <returns>Returns true if the flash charge option is successfully added; otherwise, false.</returns>
        public bool AddFlashChargeOption(ref int maxSelect)
        {
            if (!Program.player.HasFlashCharge || Program.player.FlashChargeUsed)
            {
                return false;
            }
            ++maxSelect;
            Console.WriteLine($"{maxSelect}) Use the Flash Charge against the Glabgarg.");
            return true;
        }
    }
}