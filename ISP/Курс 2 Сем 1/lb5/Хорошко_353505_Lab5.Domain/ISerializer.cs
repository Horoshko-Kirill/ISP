

namespace Хорошко_353505_Lab5.Domain
{
    public interface ISerializer
    {
        public IEnumerable<Patient> DeSerializeByLINQ(string fileName);
        public IEnumerable<Patient> DeSerializeXML(string fileName);
        public IEnumerable<Patient> DeSerializeJSON(string fileName);
        public void SerializeByLINQ(IEnumerable<Patient> xxx, string fileName);
        public void SerializeXML(IEnumerable<Patient> xxx, string fileName);
        public void SerializeJSON(IEnumerable<Patient> xxx, string fileName);
    }
}
