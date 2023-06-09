﻿using Entekhab.Salary.Application.Common.Mappings;
using Entekhab.Salary.Domain.Entities;
using OvertimePolicies;

namespace Entekhab.Salary.Application.SalaryCalculator.Models;

public class SalaryDataDto:IMapFrom<SalaryData>
{
    public int PersonId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int BasicSalary { get; set; }
    public int Allowance { get; set; }
    public int Transportation { get; set; }
    public string Date { get; set; }
}