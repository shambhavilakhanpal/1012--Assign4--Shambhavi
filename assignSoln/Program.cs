
using ClientAssign;

Client myClient = new();
List<Client> listofClient = [];

LoadFileValuesToMemory(listofClient);

bool loopAgain = true;
while (loopAgain)
{
    try
    {
        DisplayMainMenu();
        string mainMenuChoice = Prompt("\nEnter a Main Menu Choice: ").ToUpper();
        if (mainMenuChoice == "N")
            myClient = NewClient();
        if (mainMenuChoice == "S")
            ShowClientInfo(myClient);

        // if (mainMenuChoice == "A")
        // 	AddPetToList(myPet, listOfPets);
        // if (mainMenuChoice == "F")
        // 	myPet = FindPetInList(listOfPets);
        // if (mainMenuChoice == "R")
        // 	RemovePetFromList(myPet, listOfPets);
        // if (mainMenuChoice == "D")
        // 	DisplayAllPetsInList(listOfPets);
        if (mainMenuChoice == "Q")
        {
            SaveMemoryValuesToFile(listofClient);
            loopAgain = false;
            throw new Exception("Bye, hope to see you again.");
        }
        if (mainMenuChoice == "E")
        {
            while (true)
            {
                DisplayEditMenu();
                string editMenuChoice = Prompt("\nEnter a Edit Menu Choice: ").ToUpper();
                if (editMenuChoice == "F")
                    GetFirstName(myClient);
                if (editMenuChoice == "L")
                    GetLastName(myClient);
                if (editMenuChoice == "W")
                    GetWeight(myClient);
                if (editMenuChoice == "H")
                    GetHeight(myClient);
                if (editMenuChoice == "R")
                    throw new Exception("Returning to Main Menu");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"{ex.Message}");
    }
}

void DisplayMainMenu()
{
    Console.WriteLine("\nMain Menu");
    Console.WriteLine("N) New Client");
    Console.WriteLine("S) Show Client BMI Info ");
    Console.WriteLine("E) Edit Client Info");
    // Console.WriteLine("A) Add Pet To List PartB");
    // Console.WriteLine("F) Find Pet In List PartB");
    // Console.WriteLine("R) Remove Pet From List PartB");
    // Console.WriteLine("D) Display all Pets in List PartB");
    Console.WriteLine("Q) Quit");
}

void DisplayEditMenu()
{
    Console.WriteLine("Edit Menu");
    Console.WriteLine("F) FirstName");
    Console.WriteLine("L) LastName");
    Console.WriteLine("W) Weight");
    Console.WriteLine("H) Height");
    Console.WriteLine("R) Return to Main Menu");
}

void ShowClientInfo(Client myclient)
{
    if (myclient == null)
        throw new Exception($"No Client In memory");
    Console.WriteLine($"\n{myclient.ToString()}");
    Console.WriteLine($"Bmi Score required :\t{myclient.BmiScore:n4}");
    Console.WriteLine($"bmi Status Required :\t{myclient.BmiStatus:n4}");
}

string Prompt(string prompt)
{
    string myString = "";
    while (true)
    {
        try
        {
            Console.Write(prompt);
            myString = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(myString))
                throw new Exception($"Empty Input: Please enter something.");
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    return myString;
}
double PromptIntBetweenMinMax(String msg, int min, int max)
{
    double num = 0;
    while (true)
    {
        try
        {
            Console.Write($"{msg} between {min} and {max} inclusive: ");
            num = double.Parse(Console.ReadLine());
            if (num < min || num > max)
                throw new Exception($"Must be between {min:n2} and {max:n2}");
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Invalid: {ex.Message}");
        }
    }
    return num;
}

Client NewClient()
{
    Client myclient = new();
    GetFirstName(myclient);
    GetLastName(myclient);
    GetWeight(myclient);
    GetHeight(myclient);
    return myclient;
}

void GetFirstName(Client myClient)
{
    string myString = Prompt($"Enter First Name: ");
    myClient.FirstName = myString;
}

void GetLastName(Client myClient)
{
    string myString = Prompt($"Enter Last Name: ");
    myClient.LastName = myString;
}

void GetWeight(Client myClient)
{
    int myint = (int)PromptIntBetweenMinMax("Enter Weight in pounds: ", 0, 200);
    myClient.Weight = myint;
}

void GetHeight(Client myClient)
{
    int myint = (int)PromptIntBetweenMinMax("Enter Height in inches: ", 1, 200);
    myClient.Height = myint;
}

void LoadFileValuesToMemory(List<Client> listofClient)
{
    while (true)
    {
        try
        {
            //string fileName = Prompt("Enter file name including .csv or .txt: ");
            string fileName = "regin.csv";
            string filePath = $"./data/{fileName}";
            if (!File.Exists(filePath))
                throw new Exception($"The file {fileName} does not exist.");
            string[] csvFileInput = File.ReadAllLines(filePath);
            for (int i = 0; i < csvFileInput.Length; i++)
            {
                //Console.WriteLine($"lineIndex: {i}; line: {csvFileInput[i]}");
                string[] items = csvFileInput[i].Split(',');
                for (int j = 0; j < items.Length; j++)
                {
                    //Console.WriteLine($"itemIndex: {j}; item: {items[j]}");
                }
                Client myclient = new(items[0], items[1], int.Parse(items[2]), int.Parse(items[3]));
                listofClient.Add(myclient);
            }

            Console.WriteLine($"Load complete. {fileName}has {listofClient.Count} data entries");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }
}

void SaveMemoryValuesToFile(List<Client> listofClient)
{
    //string fileName = Prompt("Enter file name including .csv or .txt: ");
    string fileName = "regout.csv";
    string filePath = $"./data/{fileName}";
    string[] csvLines = new string[listofClient.Count];
    for (int i = 0; i < listofClient.Count; i++)
    {
        csvLines[i] = listofClient[i].ToString();
    }
    File.WriteAllLines(filePath, csvLines);
    Console.WriteLine($"Save complete. {fileName} has {listofClient.Count} entries.");
}











