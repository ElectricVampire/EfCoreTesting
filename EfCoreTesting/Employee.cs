using System.ComponentModel.DataAnnotations.Schema;

public class Employee
{
    [Column("EMPLOYEE_ID")]
    public int Employee_Id { get; set; }
    [Column("FIRST_NAME")]
    public string FirstName { get; set; }
    [Column("LAST_NAME")]
    public string LastName { get; set; }
    [Column("EMAIL")]
    public string Email { get; set; }
    [Column("PHONE")]
    public string Phone { get; set; }
    [Column("HIRE_DATE")]
    public DateTime Hire_Date { get; set; }
    [Column("MANAGER_ID")]
    public int? Manager_Id { get; set; }
    [Column("JOB_TITLE")]
    public string Job_Title { get; set; }
}
