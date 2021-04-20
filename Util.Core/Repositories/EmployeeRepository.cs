using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using Util.Core.Helpers;
using Util.Core.Models;

namespace Util.Core.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        List<EmployeeDTO> _employees;

        public EmployeeRepository()
        {
            this._employees = new List<EmployeeDTO>();
        }

        public List<EmployeeDTO> GetEmployeesFromFile(string path)
        {
            try
            {
                using (var doc = WordprocessingDocument.Open(path, false))
                {
                    string prevFirm = string.Empty;
                    int counter = 1;

                    foreach (var row in GetTableRows(doc))
                    {
                        _employees.Add(GetEmployeeFromRow(row, ref prevFirm, ref counter));
                    }
                    return _employees;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private IEnumerable<TableRow> GetTableRows(WordprocessingDocument doc)
        {
            return doc.MainDocumentPart.Document.Body.Elements().OfType<Table>().First().Elements().OfType<TableRow>();
        }

        private EmployeeDTO GetEmployeeFromRow(TableRow row, ref string prevFirm, ref int counter)
        {
            var cells = row.Elements().OfType<TableCell>().ToArray();
            if (!string.IsNullOrEmpty(cells[0].InnerText))
            {
                prevFirm = cells[0].InnerText;
            }

            EmployeeDTO employee = new EmployeeDTO
            {
                Id = counter,
                Firm = prevFirm,
                NameRus = cells[1].InnerText.GetName(),
                NameKaz = cells[1].InnerText.GetName(),
                Address = cells[3].InnerText.GetAddress(),
                Profession = cells[1].InnerText.GetProfession(),
                Phone = cells[3].InnerText.GetPhone()
            };
            counter++;

            return employee;
        }

        public List<EmployeeDTO> GetEmployees()
        {
            return this._employees;
        }
    }
}
