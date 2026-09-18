using System;
using System.Text;

internal static class Program
{
    private static int Main(string[] args)
    {
        Console.InputEncoding = new UTF8Encoding(false);
        Console.OutputEncoding = new UTF8Encoding(false);

        if (args.Length == 1 && args[0] == "--help")
        {
            PrintUsage();
            return 0;
        }

        if (args.Length > 1 || (args.Length == 0 && !Console.IsInputRedirected))
        {
            PrintUsage();
            return 1;
        }

        try
        {
            if (args.Length == 1)
            {
                Console.Write(ConvertText(args[0]));
                return 0;
            }

            char[] buffer = new char[4096];
            int count;
            while ((count = Console.In.Read(buffer, 0, buffer.Length)) > 0)
            {
                for (int index = 0; index < count; index++)
                    buffer[index] = ConvertCharacter(buffer[index]);
                Console.Out.Write(buffer, 0, count);
            }
            return 0;
        }
        catch (System.IO.IOException error)
        {
            Console.Error.WriteLine(error.Message);
            return 1;
        }
    }

    private static string ConvertText(string value)
    {
        char[] characters = value.ToCharArray();
        for (int index = 0; index < characters.Length; index++)
            characters[index] = ConvertCharacter(characters[index]);
        return new string(characters);
    }

    private static char ConvertCharacter(char character)
    {
        return character >= 'a' && character <= 'z'
            ? (char)(character - 'a' + 'A')
            : character;
    }

    private static void PrintUsage()
    {
        Console.Error.WriteLine("Usage: uppercase.exe \"text\"");
        Console.Error.WriteLine("       command | uppercase.exe");
        Console.Error.WriteLine("Converts ASCII a-z to A-Z; preserves all other characters.");
        Console.Error.WriteLine("Piped input and output use UTF-8. No newline is added.");
    }
}
