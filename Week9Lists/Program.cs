// Tekstifaili loomine arvutis:

string folderPath = @"C:\data\";
string fileName = "shoppingList.txt";
string filePath = Path.Combine(folderPath, fileName);

List<string> MyShoppingList = new List<string>();

// Kontroll faili eksisteerimiseks
if (File.Exists(filePath)) // Tagastab true, kui see fail selles alukohas eksisteerib, false kui ei eksisteeri
{
    MyShoppingList = GetItemsFromUser();
    File.WriteAllLines(filePath, MyShoppingList);
}
else
{
    File.Create(filePath).Close(); // Kui ei eksisteeri, siis loob faili ja sulgeb selle
    Console.WriteLine($"File {fileName} has been created.");
    MyShoppingList = GetItemsFromUser();
    File.WriteAllLines(filePath, MyShoppingList);
}

ShowItemsFromList(MyShoppingList);

static List<string> GetItemsFromUser()
{
List<string> userList = new List<string>();

    while (true)
    {
        Console.WriteLine("Add an item (add)/ Exit (exit):");
        string userChoice = Console.ReadLine();

        if (userChoice == "add")
        {
            Console.WriteLine("Enter an item:");
            string userItem = Console.ReadLine();
            userList.Add(userItem);
        }
        else
        {
            Console.WriteLine("Bye!");
            break;
        }
    }
    return userList;
}

static void ShowItemsFromList(List<string> someList)
{
    Console.Clear();

    int listLength = someList.Count; // Kuvab mitu elementi on listis
    Console.WriteLine($"You have added {listLength} items to your shopping list.");


    // Nimekirja nummerdus

    int i = 1; // väljaspool funktsiooni, sest i on eraldiseisev number
    foreach (string item in someList)
    {
        Console.WriteLine($"{i}. {item}");
        i++;
    }
}
