﻿using Entekhab.Salary.Application.SalaryCalculator.Models;
using Entekhab.Salary.Domain.Entities;
using MediatR;

namespace Entekhab.Salary.Application.SalaryCalculator.Commands.CreateSalaryByJson;

public class CreateSalaryByJsonCommand: IRequest<int>
{
    public SalaryDataDto SalaryData { get; }
    public CalculatorType CalculatorType { get; }

    public CreateSalaryByJsonCommand(SalaryDataDto salaryData,CalculatorType calculatorType)
    {
        SalaryData = salaryData;
        CalculatorType = calculatorType;
    }
}