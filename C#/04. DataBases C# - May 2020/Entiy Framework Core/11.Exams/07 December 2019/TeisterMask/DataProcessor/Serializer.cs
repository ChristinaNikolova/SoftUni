using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using Formatting = Newtonsoft.Json.Formatting;
using Newtonsoft.Json;

using TeisterMask.Data;
using TeisterMask.DataProcessor.ExportDto;

namespace TeisterMask.DataProcessor
{
    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context
                .Projects
                .Where(p => p.Tasks.Any())
                .Select(p => new ExportProjectWithTheirTasksDto
                {
                    TasksCount = p.Tasks.Count(),
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate.HasValue ? "Yes" : "No",
                    Tasks = p.Tasks
                    .Select(t => new ExportTaskDto
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString(),
                    })
                    .OrderBy(t => t.Name)
                    .ToArray()
                })
                .OrderByDescending(p => p.TasksCount)
                .ThenBy(p => p.ProjectName)
                .ToList();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(List<ExportProjectWithTheirTasksDto>), new XmlRootAttribute("Projects"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty,
            });

            using (StringWriter writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, projects, namespaces);

                return sb.ToString().TrimEnd();
            }
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context
                .Employees
                .Where(e => e.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                .OrderByDescending(e => e.EmployeesTasks.Where(et => et.Task.OpenDate >= date).Count())
                .ThenBy(e => e.Username)
                .Take(10)
                .Select(e => new
                {
                    e.Username,
                    Tasks = e.EmployeesTasks
                    .Where(et => et.Task.OpenDate >= date)
                    .OrderByDescending(et => et.Task.DueDate)
                    .ThenBy(et => et.Task.Name)
                    .Select(et => new
                    {
                        TaskName = et.Task.Name,
                        OpenDate = et.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = et.Task.LabelType.ToString(),
                        ExecutionType = et.Task.ExecutionType.ToString(),
                    })
                    .ToList()
                })
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(employees, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
            });

            return jsonResult.TrimEnd();
        }
    }
}