using System.Text.Json;
// ReSharper disable All
namespace DefeatTheGlabgargs;
/// <summary>
/// This program class serves as the central point for initializing and managing the primary game locations
/// and player states within the game. It provides access to various rooms, the player,
/// and the mechanisms needed to run the game.
/// </summary>
internal static class Program
{
    private static List<Room> rooms = new List<Room>();

    public static Bridge bridge = new Bridge();
    public static CaptainsOffice captainsOffice = new CaptainsOffice();
    public static Lift lift = new Lift();
    public static Player player = new Player();
    public static FloorTwoCorridor floorTwoCorridor = new FloorTwoCorridor();
    public static FloorThreeCorridor floorThreeCorridor = new FloorThreeCorridor();
    public static Showers showers = new Showers();
    public static CrewQuarters crewQuarters = new CrewQuarters();
    public static Engine engine = new Engine();
    public static Armory armory = new Armory();
    public static CrewCommons crewCommons = new CrewCommons();

    /// <summary>
    /// This initializes the game's rooms and flags by setting them to their default state. This is used on program
    /// start up and when the game is loaded to ensure that the program starts from a known to be good state.
    /// </summary>
    public static void Initialize()
    {
        bridge = new Bridge();
        captainsOffice = new CaptainsOffice();
        player = new Player();
        lift = new Lift();
        floorTwoCorridor = new FloorTwoCorridor();
        floorThreeCorridor = new FloorThreeCorridor();
        showers = new Showers();
        crewQuarters = new CrewQuarters();
        engine = new Engine();
        armory = new Armory();
        crewCommons = new CrewCommons();
    }
    
    /// <summary>
    /// This is the program's entry point.
    /// </summary>
    /// <param name="args">Unused at present, required by OS.</param>
    private static void Main(string[] args)
    {
        Initialize();

        GameSelections selection = 0;
        while (selection != GameSelections.QuitGame)
        {
            int maxSelect = player.current.Display();
            Thread.Sleep(50);
            selection = player.current.ProcessInput(maxSelect);
            switch (selection)
            {
                case GameSelections.QuitGame:
                    break;
                case GameSelections.ReadMap:
                    player.ReadMap();
                    break;
                default:
                    break;
            }
        }
        Console.WriteLine($"Thank you for playing! You played for {player.Turns} turns, and your final score " +
            $"was {player.Score} out of a possible 200 points.\r\n");
        Console.WriteLine("Goodbye!\r\n");
    }
}