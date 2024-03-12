using AinbLibrary;
using AinbLibrary.Yaml;
using Revrs;
using System.Text.Json;

JsonSerializerOptions options = new() {
    WriteIndented = true
};

byte[] data = File.ReadAllBytes(args[1]);
RevrsReader reader = new(data, Endianness.Little);
AinbView ainbView = new(ref reader);
Ainb ainb = Ainb.FromAinbView(ref ainbView);

using FileStream fs = File.Create("D:\\bin\\AINB\\output.yml");
ainbView.ToYaml(fs);

using FileStream fsJson = File.Create("D:\\bin\\AINB\\output.json");
JsonSerializer.Serialize(fsJson, ainb, options);
