using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Core.Helpers;
using Util.Core.Models;

namespace Util.Core.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        List<Employee> employees;

        public EmployeeRepository()
        {
            employees = new List<Employee>();
        }

        public List<Employee> GetEmployeesFromFile(string path)
        {
            try
            {
                using (var doc = WordprocessingDocument.Open(path, false))
                {
                    var tablesRows = doc.MainDocumentPart.Document.Body.Elements().OfType<Table>().First().Elements().OfType<TableRow>();
                    string prevFirm = string.Empty;
                    int counter = 1;

                    foreach (var row in tablesRows)
                    {
                        var cells = row.Elements().OfType<TableCell>().ToArray();
                        if (!string.IsNullOrEmpty(cells[0].InnerText))
                        {
                            prevFirm = cells[0].InnerText;
                        }


                        Employee employee = new Employee
                        {
                            Id = counter,
                            Firm = prevFirm,
                            NameRus = cells[1].InnerText.GetName(),
                            NameKaz = cells[1].InnerText.GetName(),
                            Address = cells[3].InnerText.GetAddress(),
                            Profession = cells[1].InnerText.GetProfession(),
                            Phone = cells[3].InnerText.GetPhone()
                        };

                        employees.Add(employee);

                        counter++;
                    }
                    return employees;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
