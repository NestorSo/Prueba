using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaParaExamen2P.Controllers;
using Prueba.Model.Dto;
using Prueba.Model;
using Prueba.Repository.IRepository;

namespace Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly ILogger<AutorController> _logger;
        public readonly IMapper _mapper;
        public readonly IAutorRepository _autorRepos;

        public AutorController(ILogger<AutorController> logger,/* PharmacyContext dataBase*/ IMapper mapper, IAutorRepository autorRepository)
        {
            _logger = logger;
            //_dataBase = dataBase;
            _mapper = mapper;
            _autorRepos = autorRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AutorDto>>> GetAutores()
        {
            _logger.LogInformation("get All Libros");

            var AutorList = await _autorRepos.GetAll();

            return Ok(_mapper.Map<IEnumerable<AutorDto>>(AutorList));
        }
        [HttpGet("{id:int}", Name = "GetAutor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AutorDto>> GetAutor(int id)
        {
            if (id == 0)
            {
                _logger.LogError($"Fallo al traer el Autor con el id: {id}");
                return BadRequest();
            }
            var libro = await _autorRepos.Get(s => s.IdAutor == id);

            if (libro == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AutorDto>(libro));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AutorDto>> addAutor([FromBody] AutorCreateDto AutorCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _autorRepos.Get(s => s.autor.ToLower() == AutorCreateDto.autor.ToLower()) != null)
            {
                ModelState.AddModelError("El autor existe ", "¡El autor con ese titulo ya existe!");
                return BadRequest(ModelState);
            }

            if (AutorCreateDto == null)
            {
                return BadRequest(AutorCreateDto);
            }

            Autor modelo = _mapper.Map<Autor>(AutorCreateDto);



            await _autorRepos.Add(modelo);

            return CreatedAtRoute("GetAutor", new { id = modelo.IdAutor }, modelo);

        }



        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteAutor(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var autor = await _autorRepos.Get(s => s.IdAutor == id);

            if (autor == null)
            {
                return NotFound();
            }

            await _autorRepos.Remove(autor);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAutor(int id, [FromBody] AutorUpdateDto UpdateDto)
        {
            if (UpdateDto == null || id != UpdateDto.IdAutor)
            {
                return BadRequest();
            }

            Autor modelo = _mapper.Map<Autor>(UpdateDto);



            await _autorRepos.Update(modelo);

            return NoContent();
        }

    }
}
