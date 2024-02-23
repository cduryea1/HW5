//MIS 3033
//patient DB manipulation
//Camille Duryea
//113529005
using a;
Console.WriteLine("DB");

string menuStr = @"
********************************************************
1. Add a new patient
2. Show all patients
3. Search for one patient based on a given ID
4. Delete one patient based on a given ID
5. Show the average age of all patients
6. Show the patient information with the lowest age
Press other keys to exit
********************************************************
";

PatientDB db;
db = new PatientDB();//load the database from file to RAM

while(true)
{
    Console.WriteLine(menuStr);

    Console.Write("Enter an option: ");
    string optStr = Console.ReadLine();

    if(optStr == "1")
    {//1. Add a new patient
        Console.WriteLine("Add new patient");
        Console.Write("ID: ");
        string idStr = Console.ReadLine();

        Console.Write("Age: ");
        string ageStr = Console.ReadLine();
        int ageInt = Convert.ToInt32(ageStr);

        //create patient
        Patient patient;
        patient = new Patient();

        patient.PID = idStr;
        patient.Age = ageInt;

        patient.GetAgeLevel();

        //add patient to db
        db.patients.Add(patient);

        //persist
        db.SaveChanges();
        Console.WriteLine("Patient added successfully!");
        Console.WriteLine(patient);

    }
    else if(optStr == "2")
    {//2. Show all patients
        Console.WriteLine("Show all patients");
        List<Patient> pList = db.patients.ToList();

        for(int i=0; i<pList.Count; i++)
        {
            Console.WriteLine(pList[i]);
        }


    }
    else if(optStr == "3")
    {//3. Search for one patient based on a given ID
        Console.WriteLine("Search for one patient based on a given ID");

        Console.Write("ID: ");
        string idStr = Console.ReadLine();

        //null
        Patient p = db.patients.Where(x => x.PID == idStr).FirstOrDefault();

        if(p!=null)
        {
            Console.WriteLine(p);
        }
        else//p is null
        {
            Console.WriteLine($"PID {idStr} does not exist in the DB!");
        }

    }
    else if(optStr == "4")
    {//4. Delete one patient based on a given ID
        Console.WriteLine("Delete one patient based on a given ID");
        Console.Write("ID: ");
        string idStr = Console.ReadLine();

        //query
        Patient p = db.patients.Where(x=>x.PID == idStr).FirstOrDefault();

        //remove from table in ram
        if(p != null)
        {
            db.patients.Remove(p);
            Console.WriteLine("Patient removed successfully!");
            Console.WriteLine(p);

        }
        else
        {
            Console.WriteLine($"PID {idStr} does not exist in the DB!");
        }
        //persist
        db.SaveChanges();

    }
    else if( optStr == "5")
    {//5. Show the average age of all patients
        Console.WriteLine("Show the average age of all patients");

        double aveAge = db.patients.Average(x => x.Age);
        Console.WriteLine($"{aveAge:F2}");

    }
    else if(optStr == "6")
    {//6. Show the patient information with the lowest age
        Console.WriteLine("Show the patient info with the lowest age");

        Patient p = db.patients.ToList().MinBy(xx => xx.Age);

        Console.WriteLine(p);

    }
    else
    {
        Console.WriteLine("Thank you and goodbye!");
        break;
    }

}    