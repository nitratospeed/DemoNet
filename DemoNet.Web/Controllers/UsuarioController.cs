using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DemoNet.Core.Entities;
using DemoNet.Core.Interfaces;
using DemoNet.Web.DTOs;
using DemoNet.Web.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoNet.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var response = await _usuarioRepository.List();
            return Ok(new Response<IEnumerable<UsuarioDTO>>() { Data = _mapper.Map<IEnumerable<UsuarioDTO>>(response) });
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] UsuarioDTO request)
        {
            await _usuarioRepository.Insert(_mapper.Map<UsuarioEntity>(request));
            return Ok(new Response<UsuarioDTO>() {  });
        }
    }
}
