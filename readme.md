# Employee Salary Calculator

This project is for calculating employee salaries using ASP.NET Core 7 and clean architecture. It consists of the following layers:

- **Domain**: Contains all entities, enums, exceptions, interfaces, types, and logic specific to the domain layer.
- **Application**: Contains all application logic. It depends on the domain layer but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application needs to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.
- **Infrastructure**: Contains classes for accessing external resources such as file systems, web services, smtp, etc. These classes should be based on interfaces defined within the application layer.
- **WebUI**: Contains web APIs without any business logic.

This project also includes a stand-alone library project named **OvertimePolicies**, which contains calculatorA, calculatorB, and calculatorC. You can easily add new calculators by implementing the `OvertimeCalculator` abstract class.

## Table of Contents
- [Installation](#installation)
- [Usage](#usage)
- [Database](#database)
- [Contributors](#contributors)

## Installation
To run this project, use the following command:

```bash
docker-compose up --build
```
Then, navigate to http://localhost:5000/api to access the Swagger.

## Usage
This project accepts two types of data formats: JSON and custom format, which is for batch data entry. For example, you can add batch salary data with this command:
```bash
curl -X 'POST' \
  'http://localhost:5000/SalaryCalculator/custom' \
  -H 'accept: application/json' \
  -H 'Content-Type: application/json' \
  -d '{
  "overTimeCalculator": 1,
  "salaryData": "PersonId/FirstName/LastName/BasicSalary/Allowance/Transportation/Date\n1/Ali/Ahmadi/1200000/400000/350000/14010801\n100/Reza/Rezaee/100000/300000/150000/14010801"
}'
```
For JSON data entry, use:
```bash
curl -X 'POST' \
  'http://localhost:5000/SalaryCalculator/json' \
  -H 'accept: application/json' \
  -H 'Content-Type: application/json' \
  -d '{
  "overTimeCalculator": 1,
  "salaryData": {
    "personId": 0,
    "firstName": "string",
    "lastName": "string",
    "basicSalary": 0,
    "allowance": 0,
    "transportation": 0,
    "date": "14010101"
  }
}'
```
## Database
For simplicity, the database contains only one table named **SalaryData**, and the database is an *InMemoryDatabase*. You can change it in the **appsetting.json** file.


## Contributors
- This project was developed by: **Mohammad Sadegh Azarkaman**. <br/>
- This project based on https://github.com/jasontaylordev/Cl

