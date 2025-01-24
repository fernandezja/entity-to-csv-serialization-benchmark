using FileHelpers;
using System;

namespace Starwars.Core.Entities
{
    [DelimitedRecord(",")] // DelimitedRecord: Nuget FileHelpers
    public class Jedi
    {
        public int JediId { get; set; }
        public string Name { get; set; }
        public string LightsaberColor { get; set; }

        [FieldConverter(ConverterKind.Double, ".")] //FieldConverter: Nuget FileHelpers The decimal separator is .
        public double Power { get; set; }

    }
}

/*
I'll demonstrate using `ReadOnlySpan<T>` to concatenate entity properties and generate a text file in C#.



```csharp
Text File Generation">
using System;
using System.IO;
using System.Text;

public class Entity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class EntityProcessor
{
    public static void GenerateEntityTextFile(Entity[] entities, string filePath)
    {
        using var writer = new StreamWriter(filePath);

        foreach (var entity in entities)
        {
            // Using Span to efficiently concatenate properties
            Span<char> buffer = stackalloc char[100];

            // Attempt to format directly into the span
            bool formatted = TryFormatEntityLine(entity, buffer, out ReadOnlySpan<char> result);

            if (formatted)
            {
                writer.WriteLine(result.ToString());
            }
        }
    }

    private static bool TryFormatEntityLine(Entity entity, Span<char> buffer, out ReadOnlySpan<char> result)
    {
        // Using Span<T> for efficient string formatting
        int charsWritten = 0;
        bool success = entity.Id.TryFormat(buffer.Slice(charsWritten), out int written);
        if (!success)
        {
            result = ReadOnlySpan<char>.Empty;
            return false;
        }
        charsWritten += written;

        buffer[charsWritten++] = ',';

        success = entity.Name.AsSpan().TryCopyTo(buffer.Slice(charsWritten));
        if (!success)
        {
            result = ReadOnlySpan<char>.Empty;
            return false;
        }
        charsWritten += entity.Name.Length;

        buffer[charsWritten++] = ',';

        success = entity.Price.TryFormat(buffer.Slice(charsWritten), out written);
        if (!success)
        {
            result = ReadOnlySpan<char>.Empty;
            return false;
        }
        charsWritten += written;

        result = buffer.Slice(0, charsWritten);
        return true;
    }

    public static void Main()
    {
        Entity[] entities = new[]
        {
            new Entity { Id = 1, Name = "Product A", Price = 19.99m },
            new Entity { Id = 2, Name = "Product B", Price = 29.99m }
        };

        GenerateEntityTextFile(entities, "entities.txt");
    }
}

```

Key benefits of this approach:
-Uses stack allocation with `stackalloc` for efficient memory management
- Leverages `Span<T>` and `ReadOnlySpan<T>` for zero-allocation string formatting
- Demonstrates efficient property concatenation without repeated string allocations
- Provides error handling for formatting operations

The code generates a comma-separated text file with entity details, using `ReadOnlySpan < T >` for performance - optimized string handling.
    */