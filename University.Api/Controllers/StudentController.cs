using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using University.Application.Interfaces;

namespace University.Api.Controllers
{
    public class StudentController : ApiControllerBase
    {
        private readonly IStudentAppService _studentAppService;

        public StudentController(IStudentAppService studentAppService)
        {
            _studentAppService = studentAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<Application.ViewModels.StudentViewModel>> Get()
        {
            return await _studentAppService.GetAll();
        }

        [HttpGet("{id:int}")]
        public async Task<Application.ViewModels.StudentViewModel> Get(int id)
        {
            return await _studentAppService.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Application.ViewModels.StudentViewModel vmStudent)
        {
            return CustomResponse(await _studentAppService.Create(vmStudent));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Application.ViewModels.StudentViewModel vmStudent)
        {
            return CustomResponse(await _studentAppService.Update(vmStudent));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return CustomResponse(await _studentAppService.Delete(id));
        }
    }
}