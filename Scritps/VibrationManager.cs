using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{
    private static Dictionary<char, string> morseCodePatterns; // Morse code patterns for each letter
    public string morseCode, inputString;

    private void Awake()
    {
        InitializeMorseCodePatterns();
    }
    public void MorseCode(string inputString)
    {
        if (morseCode.Length != inputString.Length)
        {
            morseCode = ConvertToMorseCode(inputString);

        }

        MorseVibrationTest.VibrateMorseCode(morseCode);


    }

    public void Update()
    {
        

      //  print(morseCode);
    }
    private static void InitializeMorseCodePatterns()
    {
        morseCodePatterns = new Dictionary<char, string>();

        // Add Morse code patterns for each letter
        morseCodePatterns.Add('A', ".-");
        morseCodePatterns.Add('B', "-...");
        morseCodePatterns.Add('C', "-.-.");
        morseCodePatterns.Add('D', "-..");
        morseCodePatterns.Add('E', ".");
        morseCodePatterns.Add('F', "..-.");
        morseCodePatterns.Add('G', "--.");
        morseCodePatterns.Add('H', "....");
        morseCodePatterns.Add('I', "..");
        morseCodePatterns.Add('J', ".---");
        morseCodePatterns.Add('K', "-.-");
        morseCodePatterns.Add('L', ".-..");
        morseCodePatterns.Add('M', "--");
        morseCodePatterns.Add('N', "-.");
        morseCodePatterns.Add('O', "---");
        morseCodePatterns.Add('P', ".--.");
        morseCodePatterns.Add('Q', "--.-");
        morseCodePatterns.Add('R', ".-.");
        morseCodePatterns.Add('S', "...");
        morseCodePatterns.Add('T', "-");
        morseCodePatterns.Add('U', "..-");
        morseCodePatterns.Add('V', "...-");
        morseCodePatterns.Add('W', ".--");
        morseCodePatterns.Add('X', "-..-");
        morseCodePatterns.Add('Y', "-.--");
        morseCodePatterns.Add('Z', "--..");
    }
    public static string ConvertToMorseCode(string message)
    {
        // Convert the message to uppercase
        message = message.ToUpper();

        // Convert each character to its Morse code representation
        string morseCodeMessage = "";
        foreach (char c in message)
        {
            if (morseCodePatterns.ContainsKey(c))
            {
                morseCodeMessage += morseCodePatterns[c] + " ";
            }
            else
            {
                // If the character is not in the dictionary, treat it as a space
                morseCodeMessage += " ";
            }
        }

        return morseCodeMessage;
    }
}
