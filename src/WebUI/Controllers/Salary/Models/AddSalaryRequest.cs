﻿using Entekhab.Salary.Application.SalaryCalculator.Models;
using Entekhab.Salary.Domain.Entities;

namespace WebUI.Controllers.Salary.Models;

public class AddSalaryRequest   
{
    public CalculatorType OverTimeCalculator { get; set; }
    public SalaryDataDto SalaryData { get; set; }
}