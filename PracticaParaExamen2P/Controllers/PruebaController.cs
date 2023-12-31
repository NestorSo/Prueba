using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Prueba.Model;
using Prueba.Model.Dto;
using Prueba.Repository.IRepository;

namespace PracticaParaExamen2P.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {

        private readonly ILogger<PruebaController> _logger;
        public readonly IMapper _mapper;
        public readonly ILibrosRepository _LibroRepos;

        public PruebaController(ILogger<PruebaController> logger,/* PharmacyContext dataBase*/ IMapper mapper, ILibrosRepository LibroRepos)
        {
            _logger = logger;
            //_dataBase = dataBase;
            _mapper = mapper;
            _LibroRepos = LibroRepos;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<LibroDto>>> GetLibros()
        {
            _logger.LogInformation("get All Libros");

            var LibrosList = await _LibroRepos.GetAll();

            return Ok(_mapper.Map<IEnumerable<LibroDto>>(LibrosList));
        }
        [HttpGet("{id:int}", Name = "GetLibro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LibroDto>> GetLibro(int id)
        {
            if (id == 0)
            {
                _logger.LogError($"Fallo al traer el libro con el id: {id}");
                return BadRequest();
            }
            var libro = await _LibroRepos.Get(s => s.IdAutor == id);

            if (libro == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<LibroDto>(libro));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LibroDto>> AddStudent([FromBody] LibroCreateDto libroCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _LibroRepos.Get(s => s.Titulo.ToLower() == libroCreateDto.Titulo.ToLower()) != null)
            {
                ModelState.AddModelError("El libro existe ", "�El libro con ese titulo ya existe!");
                return BadRequest(ModelState);
            }

            if (libroCreateDto == null)
            {
                return BadRequest(libroCreateDto);
            }

            Libro modelo = _mapper.Map<Libro>(libroCreateDto);



            await _LibroRepos.Add(modelo);

            return CreatedAtRoute("GetProduct", new { id = modelo.IdAutor }, modelo);

        }



        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Deleteproduct(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var student = await _LibroRepos.Get(s => s.IdAutor == id);

            if (student == null)
            {
                return NotFound();
            }

            await _LibroRepos.Remove(student);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] LibroUpdateDto UpdateDto)
        {
            if (UpdateDto == null || id != UpdateDto.IdAutor)
            {
                return BadRequest();
            }

            Libro modelo = _mapper.Map<Libro>(UpdateDto);



            await _LibroRepos.Update(modelo);

            return NoContent();
        }

    }
}