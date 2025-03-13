using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;  
using System.Xml.Linq; 
using System.Xml.Serialization;
using Хорошко_353505_Lab5.Domain;



namespace SerializerLib
{
    public class Serialze : ISerializer
    {

        public void SerializeByLINQ(IEnumerable<Patient> patients, string fileName)
        {
            var xml = new XElement("Patients",
                patients.Select(patient => new XElement("Patient",
                    new XElement("PatientId", patient.PatientId),
                    new XElement("Name", patient.Name),
                    new XElement("SecondName", patient.SecondName),
                    new XElement("LastName", patient.LastName),
                    new XElement("Age", patient.Age),
                    new XElement("Diagnoses", 
                    patient.Diagnoses.Select(diagnosis => new XElement("Diagnosis",
                    new XElement("DiagnosisId", diagnosis.DiagnosisId),
                    new XElement("Name", diagnosis.Name))))
                ))
            );

            xml.Save(fileName);
        }

        public IEnumerable<Patient> DeSerializeByLINQ(string fileName)
        {
            var xml = XElement.Load(fileName);

            var patients = xml.Elements("Patient").Select(patientElement => new Patient
            {
                PatientId = (int)patientElement.Element("PatientId"),
                Name = (string)patientElement.Element("Name"),
                SecondName = (string)patientElement.Element("SecondName"),
                LastName = (string)patientElement.Element("LastName"),
                Age = (int)patientElement.Element("Age"),
                Diagnoses = patientElement.Element("Diagnoses")?.Elements("Diagnosis").Select(diagnosisElement => new Diagnosis
                {
                    DiagnosisId = (int)diagnosisElement.Element("DiagnosisId"),
                    Name = (string)diagnosisElement.Element("Name")
                }).ToList() ?? new List<Diagnosis>()
            });

            return patients;
        }
        public void SerializeXML(IEnumerable<Patient> patients, string fileName)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<Patient>));
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    serializer.Serialize(fs, patients.ToList());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during XML serialization: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<Patient> DeSerializeXML(string fileName)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<Patient>));
                using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return (List<Patient>)serializer.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during XML deserialization: {ex.Message}");
                throw;
            }
        }

        public void SerializeJSON(IEnumerable<Patient> patients, string fileName)
        {
            try
            {
                var json = JsonSerializer.Serialize(patients);
                File.WriteAllText(fileName, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during JSON serialization: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<Patient> DeSerializeJSON(string fileName)
        {
            try
            {
                var json = File.ReadAllText(fileName);
                return JsonSerializer.Deserialize<List<Patient>>(json) ?? new List<Patient>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during JSON deserialization: {ex.Message}");
                throw;
            }
        }

    }
}
