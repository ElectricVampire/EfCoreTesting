using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

public class Program
{
    public static void Main(string[] args)
    {
        using (var context = new SqlDbContext())
        {
            // Query to get employees from the database
            var query = context.Projects;
            var projects = query.ToList();

            // Output the result
            foreach (var project in projects)
            {
                Console.WriteLine($"ID: {project.Id}, Name: {project.Name}");
            }
        }

        using (var context = new AppDbContext())
        {

            var query = context.Employees.Where(e => e.Employee_Id ==1);

            var employees = query.ToList();

            foreach (var employee in employees)
            {
                Console.WriteLine($"ID: {employee.Employee_Id}, Name: {employee.FirstName}, Email: {employee.Email}");
            }
        }

        using (var dbContext = new AppDbContext())
        {

            // Accessing the database connection from the DbContext
            var connection = dbContext.Database.GetDbConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "EXPLAIN PLAN FOR Select * from employees";
            command.ExecuteNonQuery();

            // Querying the execution plan using DBMS_XPLAN
            command.CommandText = "SELECT * FROM TABLE(DBMS_XPLAN.DISPLAY())";
            using var reader = command.ExecuteReader();

            // Fetching the plan output
            var plan = string.Join(Environment.NewLine, reader.Cast<IDataRecord>().Select(r => r.GetString(0)));

        }

        using (var context = new SqlDbContext())
        {
            // Query to get employees from the database
            var query = context.Projects.Where(x=> x.Id ==1);
                var projects  = query.ToList();

            // Output the result
            foreach (var project in projects)
            {
                Console.WriteLine($"ID: {project.Id}, Name: {project.Name}");
            }
        }

       

       
    }
}
