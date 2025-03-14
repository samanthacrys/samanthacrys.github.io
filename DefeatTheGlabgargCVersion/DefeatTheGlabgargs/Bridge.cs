namespace DefeatTheGlabgargs
{
    public class Bridge : Room
    {
        private enum BridgeMenuOptions
        {
            NoOption = 0,
            GoWest = 1,
            ExamineConsole = 2,
            PressDownloadButton = 3,
            EnterLift = 4
        };

        private readonly List<BridgeMenuOptions> options;

        /// <summary>
        /// This is the constructor for the Bridge. This sets up the initial values and sets the visited flag. This
        /// is used to determine whether the long or short description is displayed.
        /// </summary>
        public Bridge()
        {
            Name = "Bridge";
            options = new List<BridgeMenuOptions>();
        }

        /// <summary>
        /// This displays the room's description and the available menu options that the player can choose from.
        /// </summary>
        /// <returns>The number of menu options available.</returns>
        public override int Display()
        {
            base.Display();
            if (!Visited)
            {
                Console.WriteLine(
                    "You groan as you sit up and open your eyes. The sudden stop of your vessel, the IGC Jessie, " +
                    "did a number on you. What a way to end the night shift by trying to avoid a head-on collision " +
                    "with another spaceship. Looking around, you see that the bridge is a mess, Elliot’s cup of tea " +
                    "is on the floor, luckily it was empty. The navigation console sits in front of you, a blinking " +
                    "light that you should maybe look at, what with all the crew gone. Maybe you can use it to check " +
                    "the rest of the ship?\r\n");
                Visited = true;
            }

            int maxSelect = 1;
            options.Clear();

            options.Add(BridgeMenuOptions.NoOption);

            Console.WriteLine("1) Go west to the Captain's Office.");
            options.Add(BridgeMenuOptions.GoWest);
            
            if (!Program.player.ExaminedConsole)
            {
                ++maxSelect;
                Console.WriteLine($"{maxSelect}) Examine the Navigation Console.");
                options.Add(BridgeMenuOptions.ExamineConsole);
            }
            else
            {
                if (!Program.player.MapDownloaded)
                {
                    ++maxSelect;
                    Console.WriteLine($"{maxSelect}) Press the flashing Download button.");
                    options.Add(BridgeMenuOptions.PressDownloadButton);
                    Program.player.Score += 5;
                }
            }

            if (!Program.player.HasKeyCodes)
            {
                return maxSelect;
            }
            
            ++maxSelect;
            Console.WriteLine($"{maxSelect}) Enter the Lift.");
            options.Add(BridgeMenuOptions.EnterLift);

            return maxSelect;
        }

        /// <summary>
        /// This gets and processes the menu items that the player selects.
        /// </summary>
        /// <param name="maxSelect">
        /// This shows the max menu items and it is returned from the display method.</param>
        /// <returns>The game selection chosen by the player.</returns>
        public override GameSelections ProcessInput(int maxSelect)
        {
            GameSelections selection = Player.GetSelection(1, maxSelect);
            if (selection < GameSelections.MenuItem1 || selection > GameSelections.MenuItem5)
            {
                return selection;
            }
            switch (options[(int)selection])
            {
                case BridgeMenuOptions.GoWest:
                    Program.player.current = Program.captainsOffice;
                    break;
                case BridgeMenuOptions.ExamineConsole:
                    Console.WriteLine("Going over to the console, you type in a command. The system tells you that " +
                        "none of the crew are wandering the ship. It takes you a moment to move from that screen to the " +
                        "camera recordings. That's when your heart stutters. You see that there are Glabgarg on the " +
                        "ship and that they are shoving the crew about. You keep watching the recordings to see that it " +
                        "appears as if they're being taken to floor three. The only problem is that you lose them " +
                        "because there aren't that many cameras on that floor and so you have no idea where they went" +
                        " in the end.\r\n");
                    Program.player.ExaminedConsole = true;
                    break;
                case BridgeMenuOptions.PressDownloadButton:
                    Program.player.HasMap = true;
                    Console.WriteLine("The map is now available on your wrist computer.\r\n");
                    Program.player.MapDownloaded = true;
                    break;
                case BridgeMenuOptions.EnterLift:
                    Program.player.current = Program.lift;
                    Console.WriteLine("You enter the Key Codes, the Lift opens and you walk into the Lift.\r\n");
                    break;
            }
            return selection;
        }
    }
}