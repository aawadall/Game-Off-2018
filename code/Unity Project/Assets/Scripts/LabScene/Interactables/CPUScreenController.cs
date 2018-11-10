using UnityEngine;

// Controller for the output of the screen of the CPU. 
public class CPUScreenController : MonoBehaviour {

    private TMPro.TextMeshProUGUI screenText;
    private string userInput;
    private string bootUpText = ">>Welcome to your computer. \r\n" +
                                ">>Would you like to access your email,\r\n" +
                                ">>or do some shopping?\r\n" +
                                ">>Please enter 'email' or 'shop'. \r\n>>";
    private string textNotInput; // All the on-screen text that isn't part of the current user input line

    private int maxLinesOnScreen = 10; // Number of lines to display on screen 

    public void BootUp()
    {
        screenText = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        userInput = "";
        screenText.text = bootUpText;
        textNotInput = bootUpText;
    }

    // Use this for initialization
    public void Start () {

        BootUp();
	}

    // Get user input and update to the screen 
    private void Update()
    {
        // Get the user input from Input.inputString 
        foreach( char c in Input.inputString )
        {
            // backspace
            if ( ( c == '\b' ) && userInput.Length > 0 )
            {
                userInput = userInput.Substring(0, userInput.Length - 1);
            }
            // Enter 
            else if ( (c == '\n') || (c == '\r') )
                EnterCommand();

            // Regular character
            else
            {
                userInput += c;
            }
        }

        // Add user input to the screen 
        screenText.text = textNotInput + userInput;
        ControlOverflow();
    }

    // Manage overflow of text in the textbox on-screen 
    private void ControlOverflow()
    {
        // Count the number of occurrences of '>>' in the string to get current line count 
        int currentLineCount = 0;
        bool succeedsArrow = false; // tells us if a given character succeeds '>'

        foreach( char c in screenText.text )
        {
            if (c == '>')
            {
                if (succeedsArrow)
                    currentLineCount++;
                else
                    succeedsArrow = true; // Setting it here means that it'll get used for the character after c.
            }
            else
                succeedsArrow = false;
        }

        // truncate text to fit it on screen 
        if (currentLineCount > maxLinesOnScreen)
        {
            // Go through text backwards until we've passed 10 '>>'
            int linesPassed = 0;
            bool precedesArrow = false;
            int truncatedTextStartIndex = 0;
            for( int i = screenText.text.Length - 1; i >= 0; i-- )
            {
                char c = screenText.text[i];

                if ( c == '>')
                {
                    if (precedesArrow)
                        linesPassed++;
                    else
                        precedesArrow = true; // Setting it here means that it'll get used for the character before c.
                }
                else
                    precedesArrow = false;

                // Test if we've found 10 lines 
                if (linesPassed >= maxLinesOnScreen)
                {
                    truncatedTextStartIndex = i;
                    break;
                }
            }

            // Now we can make the truncation we need 
            screenText.text = screenText.text.Substring( truncatedTextStartIndex );
        }
    }

    // Implement CPU functions here
    private void EnterCommand()
    {
        // shopping 
        if (userInput == "shop")
            Shop();
        // Check emails 
        else if (userInput == "email")
            Email();

        // Invalid input given
        else
        {
            screenText.text += "\r\n>>Please enter 'email' or 'shop'. \r\n>>";
            textNotInput = screenText.text;
            userInput = "";
            ControlOverflow();
        }
    }

    // Shopping 
    private void Shop()
    {
        textNotInput = ">>Welcome to the shop. \r\n" +
                       ">>The shop is currently empty. \r\n>>";
        userInput = "";
        return;
    }
    // Check emails
    private void Email()
    {
        textNotInput = ">>Welcome to your email account. \r\n" +
                       ">>You have no new emails. \r\n>>";
        userInput = "";
        return;
    }
}
