#Samantha Durr
#February 14, 2023

#This is a text adventure game containing all the code to change from rooms, the opening story, the instructions,
#collecting the items, and whether the user loses or wins the game.

#This dictionary contains the keys for each room with the directions available to them and any item that exists
#within that room. Note: Captain's office should have an apostrophe, but it cannot be used in the dictionary, meaning
#it will always be displayed without in the game. Additional note is the glabgarg item in the Airlock are actually the
#villain of the game.
rooms = {
    'Bridge': {'South': 'Lounge', 'West': 'Captains Office', 'East': 'Sleeping Quarters', 'North': 'Armory'},
    'Captains Office': {'East': 'Bridge', 'item': 'key codes'},
    'Armory': {'South': 'Bridge', 'East': 'Supply Closet', 'item': 'ray gun'},
    'Supply Closet': {'West': 'Armory', 'item': 'oxygen tank'},
    'Sleeping Quarters': {'North': 'Showers', 'West': 'Bridge', 'item': 'face mask'},
    'Showers': {'South': 'Sleeping Quarters', 'item': 'mirror'},
    'Lounge': {'North': 'Bridge', 'East': 'Airlock', 'item': 'remote'},
    'Airlock': {'West': 'Lounge', 'item': 'glabgarg'}
}

#This is a dictionary of valid commands that lets the game know what happens when a user enters go, exit, and get
#for the different elements and what they are doing, either moving, exiting the game, or taking an item.
validCommands = {
    'go north': {'move': 'North'},
    'go east': {'move': 'East'},
    'go south': {'move': 'South'},
    'go west': {'move': 'West'},
    'exit': {'exit': 'Exit'},
    'get key codes': {'take': 'key codes'},
    'get ray gun': {'take': 'ray gun'},
    'get oxygen tank': {'take': 'oxygen tank'},
    'get face mask': {'take': 'face mask'},
    'get mirror': {'take': 'mirror'},
    'get remote': {'take': 'remote'}
}

#This function contains the instructions for how to play the game.
def ShowInstructions():
    print('Welcome to Defeat the Glabgargs. This is a text adventure where you are the '
          'sole crewman to not be locked in the Airlock of the ICS Jessie to have escaped the Glagbarg invasion. '
          'To win the game, you need to collect six items from around the ship.\n')
    print('To collect your six items, enter get (item name) from the room it is located in.\n')
    print('To move around the UCS Jessie, enter go followed by either North, South, East, and West.\n')
    print('Your villain is in the Airlock. To win, you will need the 6 items stored around the ship, otherwise you '
          'will be shot by the Glabgarg.\n')
    print('Good luck. Time to wake up and save your crew!\n')

#This function shows the opening scene to get the player into the story.
def showOpeningScene():
    print('You groan as you sit up and open your eyes. The sudden stop of the vessel, the IGC Jessie, really did a '
          'number on you. What a way to end your night shift by having to avoid a head-on collision with another '
          'spaceship. At least the rest of the crew did not see you. They were in their beds, sleeping. Why is there '
          'only one crew member on the night shifts? Really makes no sense, but there you go. Looking around, you see '
          'that the bridge is a mess, Elliot’s cup of tea is on the floor for one thing. Luckily, it was empty. The '
          'problem was that Elliot isn’t there, he’s on the day shift. They should have come and taken you to sick '
          'bay. The shiny white of the room with its computer controls that run the ship and the captain’s chair in '
          'the center of the room, is a bit much. This is especially true with the room being empty of life, except '
          'for you. You look out of the view window, which is a large window and not some computer screen thank you, '
          'to see the ship that you avoided. Gasping, you recognize it. You get to your feet, though you do sway a '
          'bit thanks to the hit you took. The ship is a Glabgarg ship. Oh no… You’ve been boarded. That’s the only '
          'thing it means when you see their ships. There is only one other thing the Glabgarg do and that’s to '
          'eject all of the still living crew into space. That means everyone is in the Airlock. Maybe you can get '
          'rid of the Glabgarg. They likely think the rough stop killed you. But, before you go after them, you need '
          'to gather a few supplies. \n')

#Calls the instructions before the game begins.
ShowInstructions()

#Calls the opening scene to set the story for the player.
showOpeningScene()

#Stores the items that the player picks up.
playerInventory = []

#This is the player's current location. It currently defaults into the Bridge, as that is the starting room of the game.
playerRoom = 'Bridge'

#This loop contains all the code that runs the game. It evaluates the player's actions, what to display, win or lose,
#how all the commands word within the game.
while playerRoom != 'exit':
    #Outputs the player's location.
    print('You are in the', playerRoom + '.')
    #Displays the player's Inventory. Note: This will be empty at the start of the game.
    print('Inventory:', playerInventory)
    #Checks if the item listed in the rooms dictionary for the room's key is in the room that the player is in.
    if 'item' in rooms[playerRoom]:
        #Displays the item that is connected with the room in the rooms' dictionary.
        print('This room has the', rooms[playerRoom]['item'] + '.')
    #Displays a simple break between the user's text and their own commands.
    print('----------------------')
    #Check if we are in the Airlock.
    if playerRoom == 'Airlock':
        #Checks if the playerInventory is equal to 6 before proceeding.
        if len(playerInventory) == 6:
            #Outputs the game's ending dialogue.
            print('You manage to strike before the invading Glabgargs notice you. The shots from your Ray Master 6000'
                  ' ring through the Airlock and hit the creepy pink skinned, snotty haired, aliens. All three'
                  ' Glabgargs fall to the ground and the light from their 3 yellow eyes goes out.'
                  ' With the creepy pink skinned aliens lying on the ground, unmoving, the rest of the crew lifts you'
                  ' onto their shoulders. You saved the day!')
        else:
            #Outputs the losing scenario.
            print('You jump out to shoot the invaders, but they are too fast for you. All three Glabgargs point their '
                  ' ray guns at you and shoot. You fall over and everything goes dim as you realize that, maybe, you '
                  'should have checked the UCS Jessie for other useful items. Sorry, but you have lost the '
                  'battle.')
        #Exits the game as the player has finished it.
        playerRoom = 'exit'
        continue
    #Prompts the user to input a valid command and converts it into lower case so that it may be read by the system
    #that is already storing lower case.
    playerInput = input('Enter a valid command:').lower()
    #Checks if the input gotten from playerInput is not in the ValidCommands dictionary.
    if playerInput not in validCommands:
        print('This is not a valid command, please input go and either north, south, east, or west.')
        continue
    #Checks that the command is connected to 'move' in the ValidCommands dictionary.
    if 'move' in validCommands[playerInput]:
        #Stores the command in the direction variable.
        direction = validCommands[playerInput]['move']
        #Checks if the direction stored in the move is valid against the rooms' dictionary.
        if direction not in rooms[playerRoom]:
            #Outputs the following error if there is nothing shown in that direction for the playerRoom.
            print('I am unable to go that way.')
            continue
        #Moves the player to the new room as long as the direction it shows has been determined as possible.
        playerRoom = rooms[playerRoom][direction]
    #Checks that exit was input and is in the validCommands dictionary.
    elif 'exit' in validCommands[playerInput]:
        #Moves playerRoom to the exit room and ends the game.
        playerRoom = 'exit'
    #checks that what the user input is part of the 'take command.
    elif 'take' in validCommands[playerInput]:
        #Sets the variable, item, to the 'take' command and stores this information.
        item = validCommands[playerInput]['take']
        #Checks if the item is listed in the key for the playerRoom from the rooms' dictionary is not in the room.
        if item not in rooms[playerRoom]['item']:
            #Outputs an error.
            print('there is no', item, 'in the room.')
            continue
        #If the item is shown as being in that room, it removes it from the playerRoom rooms' key.
        del rooms[playerRoom]['item']
        #Outputs the item to the player to see they took it.
        print('You picked up the', item + '.')
        #Adds the item to the playerInventory list.
        playerInventory.append(item)