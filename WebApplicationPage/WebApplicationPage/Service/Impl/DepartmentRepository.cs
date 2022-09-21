
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplicationPage.Data;
using WebApplicationPage.Dto;
using WebApplicationPage.Filter;
using WebApplicationPage.Models;
using WebApplicationPage.Wrappers;


namespace WebApplicationPage.Service.Impl
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private DataContext dataContext;
        public DepartmentRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void add(DepartmentDto department)
        {
            throw new NotImplementedException();
        }

        public void deleteById(int id)
        {
            throw new NotImplementedException();
        }

        public DepartmentDto getDepartById(int id)
        {
            throw new NotImplementedException();
        }

        public void update(DepartmentDto department)
        {
            throw new NotImplementedException();
        }


        //public ActionResult getAll([FromQuery] PaginationFilter filter)
        //{
        //    var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
        //    var pagedData = dataContext.Department
        //      .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
        //      .Take(validFilter.PageSize).ToList();
        //    var result = new PagedResponse<List<Department>>(pagedData, validFilter.PageNumber, validFilter.PageSize);
        //    return result;
        //}
    }
}
