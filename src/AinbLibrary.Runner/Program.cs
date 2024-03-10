using AinbLibrary;
using AinbLibrary.Yaml;
using Revrs;

byte[] data = File.ReadAllBytes(args[0]);
RevrsReader reader = new(data, Endianness.Little);
ImmutableAinb ainb = new(ref reader);

using FileStream fs = File.Create("D:\\bin\\AINB\\output.yml");
ainb.ToYaml(fs);
