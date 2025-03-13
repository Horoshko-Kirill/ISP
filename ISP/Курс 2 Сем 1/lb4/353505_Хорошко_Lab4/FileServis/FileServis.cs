internal class FileServis : IFileServis
{
    public IEnumerable<object[]> ReadFile(string fileName)
    {

        using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
        using (var br = new BinaryReader(fs))
        {
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                object[] buffer = new object[3];

                buffer[0] = br.ReadString();
                buffer[1] = br.ReadInt32();
                buffer[2] = br.ReadBoolean();

                yield return buffer;
            }
        }

    }

    public void SaveData(IEnumerable<object[]> data, string fileName)
    {

        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }

        using (var fs = new FileStream(fileName, FileMode.Create))
        using (var bw = new BinaryWriter(fs))
        {
            foreach (object[] buffer in data)
            {
                foreach (var item in buffer)
                {
                    if (item is string)
                    {
                        bw.Write((string)item);
                    }
                    else if (item is int)
                    {
                        bw.Write((int)item);
                    }
                    else if (item is bool)
                    {
                        bw.Write((bool)item);
                    }
                }
            }
        }
    }

}