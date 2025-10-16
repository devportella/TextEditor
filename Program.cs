Menu();

static void Menu()
{
    Console.Clear();
    Console.WriteLine("What do you wish to do?\n");
    Console.WriteLine("1 - Open file");
    Console.WriteLine("2 - Create new file");
    Console.WriteLine("0 - Exit\n");
    Console.Write("Your input: ");

    var raw = Console.ReadLine();
    
    short option;

    if (!short.TryParse(raw, out option))
        option = -1;

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
    Console.Clear();
    Console.Write("Enter the file's path: ");
    var path = Console.ReadLine() ?? string.Empty;

    using (var file = new StreamReader(path))
    {
        string text = file.ReadToEnd();
        Console.WriteLine($"\n--- {path} ---\n");
        Console.WriteLine(text);
    }

    Console.Write("\nPress any key to return to menu...");
    Console.ReadKey(intercept: true);
    Menu();
}

static void Edit()
{
    Console.Clear();
    Console.WriteLine("--- Write your text below (press ESC to save) ---\n");

    var sb = new System.Text.StringBuilder();

    while (true)
    {
        var key = Console.ReadKey(intercept: true);

        if (key.Key == ConsoleKey.Escape) break;

        if (key.Key == ConsoleKey.Enter)
        {
            sb.Append(Environment.NewLine);
            Console.WriteLine();
        }
        else
        {
            sb.Append(key.KeyChar);
            Console.Write(key.KeyChar);
        }
    }

    Save(sb.ToString());
}

static void Save(string text)
{
    Console.Clear();
    Console.Write("Enter path to save the file: ");
    var path = Console.ReadLine() ?? string.Empty;

    if (string.IsNullOrWhiteSpace(path))
    {
        Console.WriteLine("Invalid path. Press Enter to return...");
        Console.ReadLine();
        Menu();
        return;
    }

    using (var file = new StreamWriter(path))
    {
        file.Write(text);
    }

    Console.WriteLine($"\nFile \"{path}\" saved successfuly");
    Thread.Sleep(2000);
    Menu();
}