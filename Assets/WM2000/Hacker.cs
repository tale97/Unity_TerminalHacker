using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    string[] level1Password = { "book", "shelf", "read", "learn", "study", "author" };
    string[] level2Password = { "prison", "guilty", "death", "justice", "police", "criminal", "jailbreak" };
    string[] level3Password = { "spaceship", "rocket", "universe", "planetarium", "hyperdrive", "stars", "astronaut", "astrology", "planetary", "telescope", "extraterrestial"};

    // Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("Hello Tuan,");
    }

    void ShowMainMenu(string greeting)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("What would you like to hack into?\n");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for the Pentagon\n");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        // go back to menu at anytime
        if (input == "menu" || input == "back" || input == "again" || input == "play again")
        {
            ShowMainMenu("Welcome back, Tuan");
        } // quit application
        else if (input == "quit" || input == "exit" || input == "close")
        {
            Terminal.WriteLine("If on the web. Close the tab");
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    private void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber) {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Please choose level 1, 2, 3, or menu");
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Please enter decryption code.");
        Terminal.WriteLine("Hint: " + password.Anagram());
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Password[Random.Range(0, level1Password.Length)];
                break;
            case 2:
                password = level2Password[Random.Range(0, level2Password.Length)];
                break;
            case 3:
                password = level3Password[Random.Range(0, level3Password.Length)];
                break;
            default:
                Debug.LogError("Invalid Level Number");
                break;
        }
    }

    private void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("ACCESS DENIED");
            AskForPassword();
        }
    }

    private void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine("ACCESS GRANTED. Type menu to go back.");
    }

    private void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Got a book!");
                Terminal.WriteLine(@"
    ________     _______________
   /       //   / ---- //~-~-- //
  /       //   / ---~ //------//
 /______ //   /_____ //______//
(_______(/    )_____\/______(/
");
                break;
            case 2:
                Terminal.WriteLine("Got an out of jail card!");
                Terminal.WriteLine(@"
 ___
/O  \__________    
\___/   |_| |_|     
");
                break;
            case 3:
                Terminal.WriteLine("Got a spaceship!");
                Terminal.WriteLine(@"

       
    /\
   /__\                     ________
   |  |                     |**    |
   |__|                     |______|
   |  |        __|__        |
   |__|     __/_____\__     |
   |  |    /___________\    |
  [][][]     /       \      |
");
                break;
            default:
                Debug.LogError("Something went horribly wrong...");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
