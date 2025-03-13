

using System.Numerics;

internal interface IFileServis
{

    IEnumerable<object[]> ReadFile(string fileName);
    void SaveData(IEnumerable<object[]> data, string fileName);

}