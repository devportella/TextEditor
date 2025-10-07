Menu();

static void Menu()
{
    Console.Clear();
    Console.WriteLine("What do you wish to do?\n");
    Console.WriteLine("1 - Open file");
    Console.WriteLine("2 - Create new file");
    Console.WriteLine("0 - Exit\n");
    Console.Write("Your input: ");
    short option = short.Parse(Console.ReadLine());

    switch (option)
    {
        case 0: System.Environment.Exit(0); break;
        case 1: Open(); break;
        case 2: Edit(); break;
        default: Menu(); break;
    }
}

static void Open()
{
    
}

static void Edit()
{

}