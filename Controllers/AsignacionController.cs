using handleFileCertificados.Interfaces;
using handleFileCertificados.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace handleFileCertificados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionController : ControllerBase
    {
        private readonly IAsignacionRepository _asignacionRepository;
        public AsignacionController(IAsignacionRepository asignacionRepository)
        {
            _asignacionRepository = asignacionRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _asignacionRepository.Get();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _asignacionRepository.GetById(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Asignacion asig)
        {
             await _asignacionRepository.Insert(asig);
            return Ok(asig);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Asignacion asig, int id)
        {
            asig.Idruta = (uint)id;
            await _asignacionRepository.Put(asig);
            return Ok(asig);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _asignacionRepository.Delete(id);
            return Ok(data);
        }
    }

}
