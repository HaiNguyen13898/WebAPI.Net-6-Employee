using Microsoft.AspNetCore.Mvc;
using WebApplicationPage.Dto;
using WebApplicationPage.Filter;
using WebApplicationPage.Models;

namespace WebApplicationPage.Service
{
    public interface IDepartmentRepository
    {
        //ActionResult getAll(PaginationFilter filter);
        DepartmentDto getDepartById(int id);
        void add(DepartmentDto department);
        void update(DepartmentDto department);
        void deleteById(int id);
    }
}
