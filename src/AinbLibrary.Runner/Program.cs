using AinbLibrary;
using Revrs;
using System.Text;

byte[] data = File.ReadAllBytes(args[0]);
RevrsReader reader = new(data, Endianness.Little);
ImmutableAinb ainb = new(ref reader);

StringBuilder sb = new();
foreach (var node in ainb.) {

}

using FileStream fs = File.Create("D:\\bin\\AINB\\output.yml");
