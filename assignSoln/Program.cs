
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

        if (mainMenuChoice == "A")
            AddClientToList(myClient, listofClient);
        if (mainMenuChoice == "F")
            myClient = FindClientInList(listofClient);
        if (mainMenuChoice == "R")
            RemoveClientFromList(myClient, listofClient);
        if (mainMenuChoice == "D")
            DisplayAllClientInList(listofClient);
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
    Console.WriteLine("D) Display List Of All Clients");
    Console.WriteLine("F) Find Cleint");
    Console.WriteLine("N) New Client");
    Console.WriteLine("E) Edit Client Info");
    Console.WriteLine("R) Remove Client");
    Console.WriteLine("A) Add Client ");
    Console.WriteLine("S) Show Client BMI Info ");
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

void ShowClientInfo(Client client)
{
    if (client == null)
        throw new Exception($"No Client In memory");
    Console.WriteLine($"\n{client.ToString()}");
    Console.WriteLine($"Bmi Score required :\t{client.BmiScore:n4}");
    Console.WriteLine($"bmi Status Required :\t{client.BmiStatus:n4}");
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

void GetFirstName(Client client)
{
    string myString = Prompt($"Enter First Name: ");
    client.FirstName = myString;
}

void GetLastName(Client client)
{
    string myString = Prompt($"Enter Last Name: ");
    client.LastName = myString;
}

void GetWeight(Client client)
{
    int myint = (int)PromptIntBetweenMinMax("Enter Weight in pounds: ", 0, 200);
    client.Weight = myint;
}

void GetHeight(Client client)
{
    int myint = (int)PromptIntBetweenMinMax("Enter Height in inches: ", 1, 200);
    client.Height = myint;
}

void LoadFileValuesToMemory(List<Client> listOfPets)
{
    while (true)
    {
        try
        {
            string fileName = Prompt("Enter file name including .csv or .txt: ");
            string filePath = $"./data/{fileName}";
            if (!File.Exists(filePath))
                throw new Exception($"The file {fileName} does not exist.");
            string[] csvFileInput = File.ReadAllLines(filePath);
            for (int i = 0; i < csvFileInput.Length; i++)
            {
                Console.WriteLine($"lineIndex: {i}; line: {csvFileInput[i]}");
                string[] items = csvFileInput[i].Split(',');
                for (int j = 0; j < items.Length; j++)
                {
                    Console.WriteLine($"itemIndex: {j}; item: {items[j]}");
                }
                Client myClient = new(items[0], items[1], int.Parse(items[2]), int.Parse(items[3]));
                listOfPets.Add(myClient);
            }
            Console.WriteLine($"Load complete. {fileName} has {listofClient.Count} data entries");
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }
}


void DisplayAllClientInList(List<Client> listofClient)
{
    foreach (Client client in listofClient)
        ShowClientInfo(client);

}


void RemoveClientFromList(Client myClient, List<Client> listofClient)
{
    if (myClient == null)
    {
        Console.WriteLine("No client selected for removal");
        return;
    }

    listofClient.Remove(myClient);
    Console.WriteLine("Client removed from the list");

}

Client FindClientInList(List<Client> listofClient)
{
    string searchTerm = Prompt("Enter the clients's last name to search");

    foreach (Client client in listofClient)
    {
        if (client.LastName == searchTerm)
        {
            return client;
        }
    }
    return null;
}

void AddClientToList(Client myClient, List<Client> listofClient)
{
    listofClient.Add(myClient);
    Console.WriteLine("Client Added to the list.");
}





void SaveMemoryValuesToFile(List<Client> listofClient)
{
    string fileName = Prompt("Enter file name including .csv or .txt: ");
    string filePath = $"./data/{fileName}";

    try
    {
        List<string> lines = new List<string>();
        foreach (Client client in listofClient)
        {
            lines.Add(client.ToString());
        }
        File.WriteAllLines(filePath, lines);

        Console.WriteLine($"Save complete. {fileName} has {listofClient.Count} entries.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error while saving to file: {ex.Message}");
    }
}




