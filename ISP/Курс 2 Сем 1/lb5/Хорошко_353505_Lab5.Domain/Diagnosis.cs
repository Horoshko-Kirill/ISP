namespace Хорошко_353505_Lab5.Domain
{
    public class Diagnosis
    {
        public int DiagnosisId { get; set; }
        public string Name { get; set; }

        public Diagnosis(int diagnosisId, string name)
        {
            DiagnosisId = diagnosisId;
            Name = name;
        }

        public Diagnosis() { }
    }

}
