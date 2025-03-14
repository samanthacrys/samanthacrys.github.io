namespace DefeatTheGlabgargs
{
    /// <summary>
    /// This classes is used for handling the display of the Lift and for processing its logic.
    /// </summary>
    public class Lift : Room
    {
        /// <summary>
        /// This is the constructor for the Lift.
        /// </summary>
        public Lift()
        {
            Name = "lift";
            Visited = false;
        }

        /// <summary>
        /// This displays the room's description and the available menu options that the player can use.
        /// </summary>
        /// <returns>The number of menu options available.</returns>
        public override int Display()
        {
            base.Display();
            if (!Visited)
            {
                Console.WriteLine("With the key codes in hand, you can use them to unlock the lift. This is a bit of " +
                    "a risk. Other Glabgargs might make use of it, but it appears they’ve already figured out how to " +
                    "traverse the ship with the lift locked down. You’re just lucky it’s a silent lift, but what " +
                    "else can you do.\r\n");            
                Console.WriteLine("The lift is a white box with a panel on one wall. The panel contains 3 buttons " +
                    "one for each floor of the ship.\r\n");
                Visited = true;
            }
            else
            {
                Console.WriteLine($"The {Program.player.floor} button is lit.");
            }
            
            switch (Program.player.floor)
            {
                case 1:
                    Console.WriteLine("1) Exit the Lift.");
                    Console.WriteLine("2) Press the Number 2 button.");
                    Console.WriteLine("3) Press the Number 3 button.");
                    break;
                case 2:
                    Console.WriteLine("1) Press the Number 1 button.");
                    Console.WriteLine("2) Exit the Lift.");
                    Console.WriteLine("3) Press the Number 3 button.");
                    break;
                case 3:
                    Console.WriteLine("1) Press the Number 1 button.");
                    Console.WriteLine("2) Press the Number 2 button.");
                    Console.WriteLine("3) Exit the Lift.");
                    break;
            }

            return 3;
        }

        /// <summary>
        /// This gets and processes the menu items that are selected by the player.
        /// </summary>
        /// <param name="maxSelect">
        /// The Max menu items shown, this is returned from the Display method.</param>
        /// <returns>The game selection chosen by the player.</returns>
        public override GameSelections ProcessInput(int maxSelect)
        {
            GameSelections selection = Player.GetSelection(1, maxSelect);
            switch (Program.player.floor)
            {
                case 1:
                    switch (selection)
                    {
                        default:
                            return selection;
                        case GameSelections.MenuItem1:
                            Program.player.current = Program.bridge;
                            break;
                        case GameSelections.MenuItem2:
                            Program.player.floor = 2;
                            Console.WriteLine("You choose the 2 button and the Lift goes to the second " +
                                "floor.\r\n");
                            break;
                        case GameSelections.MenuItem3:
                            Program.player.floor = 3;
                            Console.WriteLine("You choose the 3 button and the Lift goes to the third " +
                                "floor.\r\n");
                            break;
                    }
                    break;
                case 2:
                    switch (selection)
                    {
                        default:
                            return selection;
                        case GameSelections.MenuItem1:
                            Program.player.floor = 1;
                            Console.WriteLine("You choose the 1 button and the Lift goes to the first " +
                                "floor.\r\n");
                            break;
                        case GameSelections.MenuItem2:
                            Program.player.floor = 2;
                            Program.player.current = Program.floorTwoCorridor;
                            break;
                        case GameSelections.MenuItem3:
                            Program.player.floor = 3;
                            Console.WriteLine("You choose the 3 button and the Lift goes to the third " +
                                "floor.\r\n");
                            break;
                    }
                    break;
                case 3:
                    switch (selection)
                    {
                        default:
                            return selection;
                        case GameSelections.MenuItem1:
                            Program.player.floor = 1;
                            Console.WriteLine("You choose the 1 button and the Lift goes to the first " +
                                "floor.\r\n");
                            break;
                        case GameSelections.MenuItem2:
                            Program.player.floor = 2;
                            Console.WriteLine("You choose the 2 button and the Lift goes to the second " +
                                "floor.\r\n");
                            break;
                        case GameSelections.MenuItem3:
                            Program.player.floor = 3;
                            Program.player.current = Program.floorThreeCorridor;
                            break;
                    }
                    break;
            }

            return selection;
        }
    }
}