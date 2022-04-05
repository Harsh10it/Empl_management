using System;

namespace Empl_Management
{
    interface IPrintable
    {
        void DisplayEmployeeDetails();
    }
    class Employee : IPrintable
    {
        protected string fName, lName, designation;
        protected float Salary, grossSalary;


       protected Employee(string fName, string lName, string designation, float salary)
        {
            this.fName = fName;
            this.lName = lName;
            this.designation = designation;
            this.Salary = salary;
        }

        public virtual void CalculateSalary()
        {
            this.grossSalary = this.Salary; //to override
        }

        public void DisplayEmployeeDetails()
        {
            Console.WriteLine("EMPLOYEE DETAILS:\n");
            Console.WriteLine("Name: {0} {1}", this.fName, this.lName);
            Console.WriteLine("Designation: {0}", this.designation);
            Console.WriteLine("Salary: {0}", this.Salary);
            Console.WriteLine("Gross Salary: {0}\n", this.grossSalary);
        }
    }

    class Manager : Employee
    {
        private float petrolAllowance, foodAllowance, otherAllowance;

        public Manager(string fName, string lName, string designation, float salary) : base(fName, lName, designation, salary)
        {
            this.petrolAllowance = 0.08F;
            this.foodAllowance = 0.13F;
            this.otherAllowance = 0.03F;
        }

        public override void CalculateSalary()
        {
            grossSalary = (1 + petrolAllowance + foodAllowance + otherAllowance) * Salary; ;

        }
    }

    class MarketingExecutive : Employee
    {
        private float kilometerTravel, tourAllowance;
        private int telephoneAllowance;

        public MarketingExecutive(string fName, string lName, string designation, float salary, float kilometers) : base(fName, lName, designation, salary)
        {
            this.kilometerTravel = kilometers;
            tourAllowance = 5 * this.kilometerTravel;
            telephoneAllowance = 1000;
        }

        public override void CalculateSalary()
        {
            grossSalary = tourAllowance + telephoneAllowance + Salary;
        }
    }

    class Empl_Main
    {
        static void Main()
        {
            
            Employee A = new Manager("Rahul", "Mohata", "Manager", 20000);
            A.CalculateSalary();
            A.DisplayEmployeeDetails();

            Employee B = new MarketingExecutive("Anish", "Maitra", "Marketing Executive", 50000, 10);
            B.CalculateSalary();
            B.DisplayEmployeeDetails();
        }
    }
}