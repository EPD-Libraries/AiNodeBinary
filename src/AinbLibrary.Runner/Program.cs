// JsonSerializerOptions options = new() {
//     WriteIndented = true
// };

// byte[] data = File.ReadAllBytes(args[1]);
// RevrsReader reader = new(data, Endianness.Little);
// AinbView ainbView = new(ref reader);
// Ainb ainb = Ainb.FromAinbView(ref ainbView);

// using FileStream fs = File.Create("D:\\bin\\AINB\\output.yml");
// ainbView.ToYaml(fs);

// using FileStream fsJson = File.Create("D:\\bin\\AINB\\output.json");
// JsonSerializer.Serialize(fsJson, ainb, options);

using AinbLibrary;
using AinbLibrary.IO;
using Revrs;

byte[] data = File.ReadAllBytes(args[2]);
RevrsReader reader = new(data, Endianness.Little);
AinbReader ainbReader = new(ref reader);