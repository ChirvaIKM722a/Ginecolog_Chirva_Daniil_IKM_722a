using System;

public class Patient
{
    private string name;
    private DateTime dateOfBirth;
    private string insuranceNumber;
    private MedicalRecord medicalRecord;

    public string Name
    {
        get { return name; }
    }

    public DateTime DateOfBirth
    {
        get { return dateOfBirth; }
        set { dateOfBirth = value; }
    }

    public string InsuranceNumber
    {
        get { return insuranceNumber; }
        set { insuranceNumber = value; }
    }

    public Patient(string name, DateTime dateOfBirth, string insuranceNumber)
    {
        this.name = name;
        this.dateOfBirth = dateOfBirth;
        this.insuranceNumber = insuranceNumber;
        this.medicalRecord = new MedicalRecord();
    }

    public virtual void WriteDiagnosis(string diagnosis)
    {
        medicalRecord.AddDiagnosis(diagnosis);
    }

    public void ShowMedicalRecord()
    {
        Console.WriteLine($"Patient Name: {name}");
        Console.WriteLine($"Date of Birth: {dateOfBirth.ToShortDateString()}");
        Console.WriteLine($"Insurance Number: {insuranceNumber}");
        Console.WriteLine("Diagnoses:");
        medicalRecord.ShowDiagnoses();
    }
}

public class Doctor : Patient
{
    private string specialization;

    public Doctor(string name, DateTime dateOfBirth, string insuranceNumber, string specialization)
        : base(name, dateOfBirth, insuranceNumber)
    {
        this.specialization = specialization;
    }

    public void SetDiagnosis(Patient patient, string diagnosis)
    {
        patient.WriteDiagnosis(diagnosis);
    }
}

public class MedicalRecord
{
    private string[] diagnoses;
    private int currentIndex;

    public MedicalRecord()
    {
        diagnoses = new string[10]; // Assuming maximum of 10 diagnoses per patient
        currentIndex = 0;
    }

    public void AddDiagnosis(string diagnosis)
    {
        if (currentIndex < diagnoses.Length)
        {
            diagnoses[currentIndex] = diagnosis;
            currentIndex++;
        }
        else
        {
            Console.WriteLine("Medical record is full. Cannot add more diagnoses.");
        }
    }

    public void ShowDiagnoses()
    {
        if (currentIndex == 0)
        {
            Console.WriteLine("No diagnoses recorded.");
            return;
        }

        for (int i = 0; i < currentIndex; i++)
        {
            Console.WriteLine($"{i + 1}. {diagnoses[i]}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating a patient
        Patient patient = new Patient("Storozhenko Vladimir", new DateTime(1900, 1, 1), "987654321");

        // Creating a doctor
        Doctor doctor = new Doctor("Dr. Rick", new DateTime(1988, 2, 2), "1234567890", "Psychiatrist");

        // Doctor diagnoses the patient
        doctor.SetDiagnosis(patient, "Schizophrenia");

        // Displaying patient's medical record
        patient.ShowMedicalRecord();
    }
}