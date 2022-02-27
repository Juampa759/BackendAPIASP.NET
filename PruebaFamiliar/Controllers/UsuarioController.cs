using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PruebaFamiliar.DTO_s;
using PruebaFamiliar.DTOs;
using PruebaFamiliar.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaFamiliar.Controllers
{
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> logger;
        private readonly AplicationDbContext context;
        private readonly IMapper mapper;
        public UsuarioController(
            ILogger<UsuarioController> logger,
                AplicationDbContext context,
                IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioDTO>>> Get()
        {
            var usuarios = await context.Usuarios.ToListAsync();
            return mapper.Map<List<UsuarioDTO>>(usuarios);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<UsuarioDTO>> Get(int Id)
        {
            var usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.Id == Id);
            if (usuario == null)
            {
                return NotFound();
            }

            return mapper.Map<UsuarioDTO>(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioCreacionDTO usuarioCreacionDTO)
        {
            var usuario = mapper.Map<Usuario>(usuarioCreacionDTO);
            context.Add(usuario);
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{Id:int}")]
        public async Task<ActionResult> Put(int Id, [FromBody] UsuarioCreacionDTO usuarioCreacionDTO)
        {
            var usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.Id == Id);
            if (usuario == null)
            {
                return NotFound();
            }

            usuario = mapper.Map(usuarioCreacionDTO, usuario);

            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Usuarios.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }
            context.Remove(new Usuario() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }


    }
}
