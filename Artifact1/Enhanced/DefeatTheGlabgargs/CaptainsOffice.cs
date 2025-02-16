namespace DefeatTheGlabgargs
{
    public class CaptainsOffice : Room
    {
        /// <summary>
        /// This is the constructor for the room labelled Captain's office. This sets the initial values, the visited
        /// flag, which is used to show either the long description or the short description. The visited is set to
        /// false when visiting for the first time so that you are guaranteed to get the long description.
        /// </summary>
        public CaptainsOffice()
        {
            Name = "Captain's Office";
            Visited = false;
        }

        /// <summary>
        /// This displays the room's descriptions and the available menu options for the player.
        /// </summary>
        /// <returns>The number of menu options available.</returns>
        public override int Display()
        {
            base.Display();
            int maxSelect = 1;
            if (!Visited)
            {
                Console.WriteLine(
                    "You enter the captain’s Office. The captains office is filled with knick-knacks, such as his " +
                    "stuffed bugbear that nobody knows why he has it. The desk, as usual, is a mess of folders " +
                    "that are open. A picture of his husband sits on one corner of his desk. There’s also a " +
                    "picture of his cat and parakeet together. Not that those matter, what matters is the piece " +
                    "of paper he keeps taped to his husband’s picture. You’ve seen it before and it always has his " +
                    "key codes. The man can never remember them otherwise.\r\n");
                Visited = true;
            }

            Console.WriteLine("1) Go east to the Bridge.");
            if (Program.player.HasKeyCodes)
            {
                return maxSelect;
            }

            Console.WriteLine("2) Take the Key Codes.");
            Program.player.Score += 15;
            maxSelect = 2;

            return maxSelect;
        }
        
        /// <summary>
        /// This gets and processes the menu items that the player selects.
        /// </summary>
        /// <param name="maxSelect">
        /// The max menu items shown. This is returned from the Display method.</param>
        /// <returns>The game selection chosen by the player.</returns>
        public override GameSelections ProcessInput(int maxSelect)
        {
            GameSelections selection = Player.GetSelection(1, maxSelect);
            switch (selection)
            {
                case GameSelections.MenuItem1:
                    Program.player.current = Program.bridge;
                    break;
                case GameSelections.MenuItem2:
                    Program.player.HasKeyCodes = true;
                    break;
            }

            return selection;
        }
    }
}