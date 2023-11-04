using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Newtonsoft.Json;

using TeisterMask.Data;
using TeisterMask.Data.Models;
using TeisterMask.Data.Models.Enums;
using TeisterMask.DataProcessor.ImportDto;

namespace TeisterMask.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(List<ImportProjectDto>), new XmlRootAttribute("Projects"));

            List<ImportProjectDto> importProjectDtos =
                (List<ImportProjectDto>)xmlSerializer.Deserialize(new StringReader(xmlString));

            List<Project> projects = new List<Project>();
            List<Task> tasks = new List<Task>();

            foreach (ImportProjectDto importProjectDto in importProjectDtos)
            {
                if (!IsValid(importProjectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isProjectOpenDateValid = DateTime.TryParseExact(importProjectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime projectOpenDate);

                if (!isProjectOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Project project = new Project()
                {
                    Name = importProjectDto.Name,
                    OpenDate = projectOpenDate,
                };

                bool isProjectDueDate = DateTime.TryParseExact(importProjectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime projectDueDate);

                if (isProjectDueDate)
                {
                    project.DueDate = projectDueDate;
                }

                projects.Add(project);

                foreach (ImportTaskDto importTaskDto in importProjectDto.Tasks)
                {
                    if (!IsValid(importTaskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate = DateTime.ParseExact(importTaskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    DateTime taskDueDate = DateTime.ParseExact(importTaskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    if (taskOpenDate < projectOpenDate || (taskDueDate > projectDueDate && isProjectDueDate))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task task = new Task()
                    {
                        Name = importTaskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)importTaskDto.ExecutionType,
                        LabelType = (LabelType)importTaskDto.LabelType,
                    };

                    project.Tasks.Add(task);
                    tasks.Add(task);
                }

                sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            context.Projects.AddRange(projects);
            context.Tasks.AddRange(tasks);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            List<ImportEmployeeDto> importEmployeeDtos = JsonConvert
                .DeserializeObject<List<ImportEmployeeDto>>(jsonString)
                .ToList();

            List<Employee> employees = new List<Employee>();
            List<EmployeeTask> employeeTasks = new List<EmployeeTask>();

            foreach (ImportEmployeeDto importEmployeeDto in importEmployeeDtos)
            {
                if (!IsValid(importEmployeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee employee = new Employee()
                {
                    Username = importEmployeeDto.Username,
                    Phone = importEmployeeDto.Phone,
                    Email = importEmployeeDto.Email,
                };

                employees.Add(employee);

                foreach (int taskId in importEmployeeDto.Tasks.Distinct())
                {
                    Task task = context.Tasks.Find(taskId);

                    if (task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    EmployeeTask employeeTask = new EmployeeTask()
                    {
                        TaskId = taskId,
                        EmployeeId = employee.Id,
                    };

                    employee.EmployeesTasks.Add(employeeTask);
                    employeeTasks.Add(employeeTask);
                }

                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count()));
            }

            context.Employees.AddRange(employees);
            context.EmployeesTasks.AddRange(employeeTasks);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}