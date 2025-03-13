using Хорошко_353505_Lab5.Domain;
using SerializerLib;

class Program
{
    static void Main()
    {
        var patients = new List<Patient>
        {
            new Patient
            {
                PatientId = 1,
                Name = "Иван",
                SecondName = "Иванович",
                LastName = "Иванов",
                Age = 30,
                Diagnoses = new List<Diagnosis>
                {
                    new Diagnosis { DiagnosisId = 101, Name = "Грипп" }
                }
            },
            new Patient
            {
                PatientId = 2,
                Name = "Петр",
                SecondName = "Петрович",
                LastName = "Петров",
                Age = 25,
                Diagnoses = new List<Diagnosis>
                {
                    new Diagnosis { DiagnosisId = 102, Name = "ОРВИ" }
                }
            },
            new Patient
            {
                PatientId = 3,
                Name = "Анна",
                SecondName = "Алексеевна",
                LastName = "Смирнова",
                Age = 40,
                Diagnoses = new List<Diagnosis>
                {
                    new Diagnosis { DiagnosisId = 103, Name = "Гастрит" }
                }
            },
            new Patient
            {
                PatientId = 4,
                Name = "Екатерина",
                SecondName = "Владимировна",
                LastName = "Кузнецова",
                Age = 35,
                Diagnoses = new List<Diagnosis>
                {
                    new Diagnosis { DiagnosisId = 104, Name = "Диабет" }
                }
            },
            new Patient
            {
                PatientId = 5,
                Name = "Сергей",
                SecondName = "Сергеевич",
                LastName = "Сергеев",
                Age = 50,
                Diagnoses = new List<Diagnosis>
                {
                    new Diagnosis { DiagnosisId = 105, Name = "Гипертония" }
                }
            },
            new Patient
            {
                PatientId = 6,
                Name = "Мария",
                SecondName = "Павловна",
                LastName = "Васильева",
                Age = 45,
                Diagnoses = new List<Diagnosis>
                {
                    new Diagnosis { DiagnosisId = 106, Name = "Анемия" }
                }
            }
        };

        string fileName = ConfigHelper.GetFileName();

        string fileName1 = fileName + ".xml";
        string fileName2 = fileName + "1.xml";
        string fileName3 = fileName + ".txt";

        var serializer = new Serialze();

        serializer.SerializeByLINQ(patients, fileName1);
        serializer.SerializeXML(patients, fileName2);
        serializer.SerializeJSON(patients, fileName3);

        var patientsFromLinq = serializer.DeSerializeByLINQ(fileName1);
        var patientsFromXml = serializer.DeSerializeXML(fileName2);
        var patientsFromJson = serializer.DeSerializeJSON(fileName3);

        Console.WriteLine("Проверка LINQ:");
        CheckEquality(patients, patientsFromLinq);

        Console.WriteLine("Проверка XML:");
        CheckEquality(patients, patientsFromXml);

        Console.WriteLine("Проверка JSON:");
        CheckEquality(patients, patientsFromJson);
    }
    private static void CheckEquality(IEnumerable<Patient> originalPatients, IEnumerable<Patient> deserializedPatients)
    {
        bool areEqual = originalPatients.SequenceEqual(deserializedPatients, new PatientComparer());
        Console.WriteLine(areEqual ? "Данные совпадают!" : "Данные не совпадают.");
    }

    public class PatientComparer : IEqualityComparer<Patient>
    {
        public bool Equals(Patient x, Patient y)
        {
            return x.PatientId == y.PatientId
                && x.Name == y.Name
                && x.SecondName == y.SecondName
                && x.LastName == y.LastName
                && x.Age == y.Age
                && x.Diagnoses.SequenceEqual(y.Diagnoses, new DiagnosisComparer());
        }

        public int GetHashCode(Patient obj)
        {
            return obj.PatientId.GetHashCode();
        }
    }

    public class DiagnosisComparer : IEqualityComparer<Diagnosis>
    {
        public bool Equals(Diagnosis x, Diagnosis y)
        {
            return x.DiagnosisId == y.DiagnosisId && x.Name == y.Name;
        }

        public int GetHashCode(Diagnosis obj)
        {
            return obj.DiagnosisId.GetHashCode();
        }
    }
}