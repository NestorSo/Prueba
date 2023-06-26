using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Prueba.Model.Dto;
using Prueba.Repository.IRepository;

namespace PracticaParaExamen2P.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

    }
}