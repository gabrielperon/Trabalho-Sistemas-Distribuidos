using Core.Application.Interface;
using Core.Data.Entities;
using Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Application
{
    public class ContatoApp : IContatoApp
    {
        private readonly IContatoService _ContatoService;

        public ContatoApp(IContatoService contatoService)
        {
            _ContatoService = contatoService;
        }

        public ContatoItem Add(ContatoItem autenticacaoItem)
        {
            return _ContatoService.Add(autenticacaoItem);
        }

        public ContatoItem Get(long id)
        {
            return _ContatoService.Get(id);
        }

        public List<ContatoItem> GetContato()
        {
            return _ContatoService.GetContato().ToList();
        }

        public ContatoItem Update(ContatoItem item)
        {
            return _ContatoService.Update(item);
        }

        public void Delete(long id)
        {
            _ContatoService.Delete(id);
        }

    }
}
