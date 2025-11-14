using ECOMMERCE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECOMMERCE.Clases
{
    public class ComboHelper : IDisposable
    {
        private static ECommerceContext db = new ECommerceContext();
        public static List<Department> GetDepartments() //Devuelve lo que tenemos en el citiesController para departamentos
        {
            var departments = db.Departments.ToList();
            departments.Add(new Department
            {
                DepartmentId = 0,
                Name = "[Select a department...]",
            });
            return departments.OrderBy(d => d.Name).ToList();
        }


        public static List<City> GetCities() //Devuelve lo que hay en cities
        {
            var cities = db.Cities.ToList();
            cities.Add(new City
            {
                CityId = 0,
                Name = "[Select a city...]",
            });
            return cities.OrderBy(d => d.Name).ToList();
        }

        public static List<Company> GetCompanies() //Devuelve una lista de compañias
        {
            var companies = db.Companies.ToList();
            companies.Add(new Company
            {
                CompanyId = 0,
                Name = "[Select a company...]",
            });
            return companies.OrderBy(d => d.Name).ToList();
        }
        public void Dispose()
        {
            db.Dispose(); 
        }
    }
}