using System.Collections.Generic;

namespace Хорошко_353505_Lab5.Domain
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public List<Diagnosis> Diagnoses { get; set; } = new List<Diagnosis>();

        public void AddDiagnosis(Diagnosis diagnosis)
        {
            Diagnoses.Add(diagnosis);
        }

        public bool RemoveDiagnosis(int diagnosisId)
        {
            var diagnosis = Diagnoses.Find(d => d.DiagnosisId == diagnosisId);
            if (diagnosis != null)
            {
                Diagnoses.Remove(diagnosis);
                return true;
            }
            return false;
        }
    }

}
