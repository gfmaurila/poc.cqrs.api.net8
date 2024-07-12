namespace poc.api.sqlserver.Model.HR;

public class Department
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public int? ManagerId { get; set; }
    public int LocationId { get; set; }

    // Navigation properties
    public virtual Location Location { get; set; }
    public virtual ICollection<Employee> Employees { get; set; }
    public virtual ICollection<JobHistory> JobHistories { get; set; }
}

public class Location
{
    public int LocationId { get; set; }
    public string StreetAddress { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string StateProvince { get; set; }
    public string CountryId { get; set; }

    // Navigation properties
    public virtual Country Country { get; set; }
    public virtual ICollection<Department> Departments { get; set; }
}

public class Country
{
    public string CountryId { get; set; }
    public string CountryName { get; set; }
    public int RegionId { get; set; }

    // Navigation property
    public virtual Region Region { get; set; }
    public virtual ICollection<Location> Locations { get; set; }
}

public class Region
{
    public int RegionId { get; set; }
    public string RegionName { get; set; }

    // Navigation property
    public virtual ICollection<Country> Countries { get; set; }
}

public class Employee
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime HireDate { get; set; }
    public int JobId { get; set; }
    public decimal Salary { get; set; }
    public decimal? CommissionPct { get; set; }
    public int? ManagerId { get; set; }
    public int DepartmentId { get; set; }

    // Navigation properties
    public virtual Job Job { get; set; }
    public virtual Department Department { get; set; }
    public virtual ICollection<JobHistory> JobHistories { get; set; }
}

public class Job
{
    public int JobId { get; set; }
    public string JobTitle { get; set; }
    public decimal MinSalary { get; set; }
    public decimal MaxSalary { get; set; }

    // Navigation property
    public virtual ICollection<Employee> Employees { get; set; }
    public virtual ICollection<JobHistory> JobHistories { get; set; }
}

public class JobHistory
{
    public int EmployeeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int JobId { get; set; }
    public int DepartmentId { get; set; }

    // Navigation properties
    public virtual Employee Employee { get; set; }
    public virtual Job Job { get; set; }
    public virtual Department Department { get; set; }
}

