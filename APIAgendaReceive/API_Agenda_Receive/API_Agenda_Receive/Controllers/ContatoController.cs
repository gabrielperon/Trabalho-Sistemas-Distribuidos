using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Application.Interface;
using Core.Data.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Agenda_Receive.Controllers
{
    /// <summary>
    /// ContatoController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoApp _contatoApp;

        public ContatoController(IContatoApp contatoApp)
        {
            _contatoApp = contatoApp;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Get(long id)
        {
             ContatoItem result = _contatoApp.Get(id);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetContato()
        {
            List<ContatoItem> contatos = _contatoApp.GetContato().ToList();
            return Ok(contatos);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Add([FromBody]ContatoItem autenticacaoItem)
        {
            ContatoItem adicionar = _contatoApp.Add(autenticacaoItem);
            return Ok(adicionar);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Update([FromBody] ContatoItem item)
        {
            ContatoItem att = _contatoApp.Update(item);
            return Ok(att);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public void Delete(long id)
        {
            _contatoApp.Delete(id);
        }
    }
}