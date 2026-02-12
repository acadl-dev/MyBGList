using Microsoft.AspNetCore.Mvc;
using MyBGList.DTO;

namespace MyBGList.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BoardGamesController : ControllerBase
    {
        private readonly ILogger<BoardGamesController> _logger;
        public BoardGamesController(ILogger<BoardGamesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetBoardGames")]
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 60)]
        //Substituímos o valor de retorno anterior do IEnumerable<BoardGame> por um novo valor de retorno do RestDTO<BoardGame[]> ,
        //que é o que vamos retornar agora.
        public RestDTO<BoardGame[]> Get()
        {
            

            //Substituiu o tipo anônimo anterior, que continha apenas os dados, com o novo tipo RestDTO, que contém os dados e os links descritivos.
            return new RestDTO<BoardGame[]>()
            {
                Data = new[] {
                    new BoardGame()
                    {
                        Id = 1,
                        Name = "Axis and Allies",
                        Year = 1981
                    },
                    new BoardGame()
                    {
                        Id = 2,
                        Name = "Citadels",
                        Year = 2000
                    },
                    new BoardGame()
                    {
                        Id = 3,
                        Name = "Terraforming Mars",
                        Year = 2016
                    }
                },
                //Adicionamos os links descritivos do HATEOAS. Por enquanto, oferecemos suporte a um único endpoint relacionado a jogos de tabuleiro;
                //portanto, o adicionamos usando a referência de relacionamento "self"..
                Links = new List<LinkDTO>
                {
                    new LinkDTO(
                        Url.Action(null, "BoardGames", null, Request.Scheme)!,
                        "self",
                        "GET"),
                }

            };
        }
    }
}
