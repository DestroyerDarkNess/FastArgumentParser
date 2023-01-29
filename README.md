# FastArgumentParser
Snippets to parse arguments quickly and easily

I was looking on github for something simple and functional to parse arguments. but I didn't find something that I really liked. so i wrote one.

# How to use ?

1 - Add the FastArgumentParser Class to your VB or C# project
2 - Copy&Paste the example and adapt it to your use.

# Visual Basic

```VB
   'Commandline Arguments
        ' This contains the following:
        ' -file "d3d9.h" -silent 0x146 H&146
        Dim CommandLineArgs As String() = Environment.GetCommandLineArgs

        Dim FastArgumentParser As Core.FastArgumentParser = New Core.FastArgumentParser()

        ' Optional Config
        ' FastArgumentParser.ArgumentDelimiter = "-"

        ' Set your Arguments
        Dim FileA As IArgument = FastArgumentParser.Add("file").SetDescription("file name")
        Dim SilentA As IArgument = FastArgumentParser.Add("silent").SetDescription("start silent")

        ' Parse Arguments
        FastArgumentParser.Parse(CommandLineArgs)
        ' Or
        ' FastArgumentParser.Parse(CommandLineArgs, " ") ' To config Parameters Delimiter


        ' Get Arguments Values
        Console.WriteLine("Argument " & FileA.Name & " Value is: " & FileA.Value)
        Console.WriteLine("Argument " & SilentA.Name & " Value is: " & SilentA.Value)
```

# Csharp

```C#
   // Commandline Arguments
    // This contains the following:
    // -file "d3d9.h" -silent 0x146 H&146
    string[] CommandLineArgs = Environment.GetCommandLineArgs();

    Core.FastArgumentParser FastArgumentParser = new Core.FastArgumentParser();

    // Optional Config
    // FastArgumentParser.ArgumentDelimiter = "-"

    // Set your Arguments
    IArgument FileA = FastArgumentParser.Add("file").SetDescription("file name");
    IArgument SilentA = FastArgumentParser.Add("silent").SetDescription("start silent");

    // Parse Arguments
    FastArgumentParser.Parse(CommandLineArgs);
    // Or
    // FastArgumentParser.Parse(CommandLineArgs, " ") ' To config Parameters Delimiter


    // Get Arguments Values
    Console.WriteLine("Argument " + FileA.Name + " Value is: " + FileA.Value);
    Console.WriteLine("Argument " + SilentA.Name + " Value is: " + SilentA.Value);
```

# Finally

In the example above, the following was used as an argument: ```-file "d3d9.h" -silent 0x146 H&146```

and the output was:

```
Argument -file Value is: d3d9.h
Argument -silent Value is: 0x146 H&146
```
