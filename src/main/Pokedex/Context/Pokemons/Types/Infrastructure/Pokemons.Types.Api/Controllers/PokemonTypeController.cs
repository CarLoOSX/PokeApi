﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pokemons.Types.Api.Converter;
using Pokemons.Types.Application.UseCase;
using Pokemons.Types.Domain.Exceptions;

namespace Pokemons.Types.Api.Controllers
{
    [ApiController]
    [Route("pokedex")]
    public class PokemonTypeController : ControllerBase
    {
        private readonly GetPokemonTypes _getPokemonType;

        public PokemonTypeController(GetPokemonTypes getPokemonType)
        {
            _getPokemonType = getPokemonType;
        }

        [HttpGet("pokemons/types/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                return Ok(PokemonTypeToJsonConverter.Execute(await _getPokemonType.Execute(name)));
            }
            catch (PokemonNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
