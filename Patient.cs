using System;
using System.Collections;
using System.Threading;

namespace SampleFrameworksApp
{
    class Details
    {

        public string DiseaseName { get; set; }
        public string Severity { get; set; }

        public string Symptom { get; set; }


    }

    class Sympthoms : Details
    {
        private ArrayList Disease = new ArrayList();
        public bool AddDisease(Details dis)
        {
            Disease.Add(dis);
            Console.WriteLine("Done with adding");
            return true;
        }
        public Array DisplayDis()
        {

            return Disease.ToArray();

        }
        public bool CheckSymptoms(string Sym)
        {
            for (int i = 0; i < Disease.Count; i++)
            {
                if (Disease[i] is Details)
                {
                    var data = Disease[i] as Details;
                    if (data.Symptom == Sym)
                    {
                        Console.WriteLine("The patient may have {0}", data.DiseaseName);
                        return true;
                    }
                }
            }

            return false;
        }

    }

    class PatientDetails : Sympthoms
    {
        public string PatName { get; set; }
        public string pats { get; set; }

        public ArrayList PatDet { get; set; }

        public void SetDet(PatientDetails pat)
        {
            PatDet.Add(pat);
        }
    }

class Patient
{
    private static object utilities;

    static public void Run()
    {

        Console.WriteLine("Press 1 To Add Disease");
        Console.WriteLine("press 2 to Take Advise");
    P:
        int choice = Utilities.GetNumber("Enter the choice");
        switch (choice)
        {
            case 1:
                Add();
                break;
            default:
                Console.WriteLine("Invalid entry");
                goto P;
        }

    }
    static public void Add()
    {

        Sympthoms Sym = new Sympthoms();
        void SeverityCheck(string SeverityBool)
        {
            if (SeverityBool.ToUpper() == "  high" || SeverityBool.ToUpper() == "low" || SeverityBool.ToUpper() == "medium")
            {
                Console.WriteLine("Valid ");
            }
            else
            {
                throw new Exception("Invalid ");
            }
        }
    P:
        string DisName = Utilities.Prompt("Enter Disease Name");

        string Severity = Utilities.Prompt("Enter Severity level Options  ");
        try
        {
            SeverityCheck(Severity);

        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
            goto P;
        }
        string EnteredSymptoms = Utilities.Prompt("Enter  symptoms");
            Details dis = new Details();
        dis.DiseaseName = DisName;
        dis.Severity = Severity;
        dis.Symptom = EnteredSymptoms;
        Sym.AddDisease(dis);
        string ChoiceAdd = Utilities.Prompt("Add Another disease");
        if (ChoiceAdd.ToUpper() == "YES")
        {
            goto P;
        }
        string PatName = Utilities.Prompt("Patient Name");
        string pats = Utilities.Prompt("Symtoms");
        Console.WriteLine(" Checking");
        Thread.Sleep(100);
        Sym.CheckSymptoms(pats);

    }
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome");
        Run();
    }
}  }
