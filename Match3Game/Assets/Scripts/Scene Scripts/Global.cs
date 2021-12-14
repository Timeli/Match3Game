
using UnityEngine;

public class Global : MonoBehaviour
{
    private static string moveTwo = "";
    private static string grounded = "";
    private static string destroyer = "";
    private static string addBlocks = "";
    private static string arrangmentBlocks = "";
    private static string pausePlay = "";


    // Pause
    public static string PausePlay { get => pausePlay; set => pausePlay = value; }

    // Arrangment Block
    public static string ArrangmentBlocks { get => arrangmentBlocks; set => arrangmentBlocks = value; }

    // Add Blocks
    public static string AddBlocks { get => addBlocks; set => addBlocks = value; }

    // Destroy Blocks
    public static string Destroyer { get => destroyer; set => destroyer = value; }

    // Ground
    public static string Grounded { get => grounded; set => grounded = value; }

    // Move Two
    public static string MoveTwo{ get => moveTwo; set => moveTwo = value; }
}
