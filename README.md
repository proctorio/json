# Proctorio.JSON

[![NuGet](https://img.shields.io/nuget/v/Proctorio.JSON.svg)](https://www.nuget.org/packages/Proctorio.JSON/)
[![Build Status](https://img.shields.io/badge/build-passing-brightgreen.svg)]()
[![Code Coverage](https://img.shields.io/badge/coverage-98.31%25-brightgreen.svg)]()
[![License: Apache 2.0](https://img.shields.io/badge/License-Apache%202.0-blue.svg)](LICENSE)
[![Dependencies](https://img.shields.io/badge/dependencies-zero-brightgreen.svg)]()

A lightweight, high-performance JSON array encoder/decoder library for .NET. Provides simple, fast JSON array encoding and decoding without complex object mapping.

## ✨ Features

- 🚀 **Fast & Lightweight** - **Zero runtime dependencies**, optimized for performance
- 📦 **Multi-Platform Support** - Targets .NET Framework 4.5, .NET Standard 2.0, .NET 6.0, .NET 8.0, and .NET 9.0
- 🎯 **Simple API** - Easy-to-use static methods for encoding and decoding
- 🔧 **Array-Focused** - Specialized for JSON array operations
- ✅ **Well-Tested** - 98.31% code coverage with comprehensive unit tests using MSTest
- 📝 **Pretty Printing** - Built-in JSON formatting with proper indentation
- 🔒 **No External Dependencies** - Pure .NET implementation with no third-party packages
- 📏 **Tiny Package** - Only 37KB package size

## 🚀 Installation

Install via NuGet Package Manager:

```bash
dotnet add package Proctorio.JSON
```

Or via Package Manager Console:

```powershell
Install-Package Proctorio.JSON
```

## 🎯 Quick Start

### Decoding JSON Arrays

#### Simple String Array

```csharp
using Proctorio.JSON;

string input = "[\"philcollins\",\"Ih8PeterG\"]";
string[] result = JSONDecoders.DecodeJsStringArray(input);

// result[0]: "philcollins"
// result[1]: "Ih8PeterG"
```

#### Complex Nested Array

```csharp
string input = "[14,4,[14,\"data\"],[[5,\"10.186.122.15\"],[6,\"10.186.122.16\"]]]";
string[] result = JSONDecoders.DecodeJSONArray(input);

// result[0]: "14"
// result[1]: "4"
// result[2]: "[14,\"data\"]"
// result[3]: "[[5,\"10.186.122.15\"],[6,\"10.186.122.16\"]]"

// Decode nested arrays
string[] nested = JSONDecoders.DecodeJSONArray(result[3]);
// nested[0]: "[5,\"10.186.122.15\"]"
// nested[1]: "[6,\"10.186.122.16\"]"
```

### Encoding JSON Arrays

#### String Array Encoding

```csharp
string[] items = new[] { "hello", "world", "test" };
string result = JSONEncoders.EncodeJsStringArray(items);
// Result: ["hello","world","test"]
```

#### Object Array Encoding

```csharp
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public override string ToString()
    {
        return $"[{Age},{JSONEncoders.EncodeJsString(Name)}]";
    }
}

var people = new[]
{
    new Person { Name = "Alice", Age = 30 },
    new Person { Name = "Bob", Age = 25 }
};

string result = JSONEncoders.EncodeJsObjectArray(people);
// Result: [[30,"Alice"],[25,"Bob"]]
```

### Pretty Printing

```csharp
using Proctorio.JSON.Pretty;

string input = "[14,4,[14,\"data\"],[[5,\"10.186.122.15\"],[6,\"10.186.122.16\"]]]";
string pretty = input.PrettyPrintJson();
```

Output:
```json
[
   14,
   4,
   [
      14,
      "data"
   ],
   [
      [
         5,
         "10.186.122.15"
      ],
      [
         6,
         "10.186.122.16"
      ]
   ]
]
```

## 📚 API Reference

### JSONDecoders

| Method | Description |
|--------|-------------|
| `DecodeJSONArray(string s)` | Decodes a complex JSON array with nested structures |
| `DecodeJsStringArray(string s)` | Decodes a simple JSON string array |
| `DecodeJsString(string s)` | Decodes a JSON-encoded string with escape sequences |

### JSONEncoders

| Method | Description |
|--------|-------------|
| `EncodeJsStringArray(string[] s)` | Encodes a string array with proper escaping |
| `EncodeJsObjectArray(object[] s)` | Encodes an object array (uses `ToString()`) |
| `EncodeJsObjectList<T>(List<T> s)` | Encodes a generic list (uses `ToString()`) |
| `EncodeJsString(string s)` | Encodes a single string with JSON escaping |

### Extensions

| Method | Description |
|--------|-------------|
| `string.PrettyPrintJson()` | Formats JSON with proper indentation |
| `string.Slice(int start, int end)` | Python-like string slicing (supports negative indices) |

## 🔧 Why Proctorio.JSON?

### Comparison with Other Libraries

| Feature | Proctorio.JSON | Json.NET | System.Text.Json |
|---------|----------------|----------|------------------|
| **Runtime Dependencies** | **Zero** | Multiple | None (built-in) |
| Package Size | Minimal (~35KB) | Large (~700KB) | Built-in |
| Array Focus | ✅ | ❌ | ❌ |
| Simple API | ✅ | ❌ | ⚠️ |
| .NET Framework 4.5 | ✅ | ✅ | ❌ |
| Performance | Fast | Medium | Fast |
| Memory Footprint | Minimal | Large | Medium |

**When to use Proctorio.JSON:**
- You need simple JSON array encoding/decoding
- You want **zero runtime dependencies**
- You're working with legacy .NET Framework projects
- You need a tiny package size
- You don't need complex object serialization
- You want minimal memory overhead

**When to use alternatives:**
- You need full JSON object serialization
- You need LINQ-to-JSON capabilities
- You need streaming JSON parsing

## 🛠️ Development

### Building from Source

```bash
git clone https://github.com/proctorio/json.git
cd json
dotnet build
```

### Running Tests

```bash
dotnet test
```

### Running Tests with Coverage

```bash
dotnet test --collect:"XPlat Code Coverage"
```

## 📊 Code Coverage

Current code coverage: **98.31%**

- Line coverage: 98.31% (175/178)
- Branch coverage: 97.71% (169/173)
- Method coverage: 100% (12/12)

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the Apache License 2.0 - see the [LICENSE](LICENSE) file for details.

## 🙏 Credits

- Originally developed by Echovoice
- String slicing extension credit: [DotNetPerls](http://www.dotnetperls.com/string-slice)
- Original encode inspiration: [Rick Strahl's Blog](http://www.west-wind.com/weblog/posts/2007/Jul/14/Embedding-JavaScript-Strings-from-an-ASPNET-Page)

## 📮 Support

- 📧 Issues: [GitHub Issues](https://github.com/proctorio/json/issues)
- 📦 NuGet: [Proctorio.JSON](https://www.nuget.org/packages/Proctorio.JSON/)

---

Made with ❤️ by Proctorio
