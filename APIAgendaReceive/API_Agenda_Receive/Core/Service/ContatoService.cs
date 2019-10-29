using Core.Data.Contracts;
using Core.Data.Entities;
using Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Service
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoService(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public ContatoItem Add(ContatoItem contatoItem)
        {
            return _contatoRepositorio.Add(contatoItem);
        }

        public ContatoItem Get(long id)
        {
            return _contatoRepositorio.Get(id);
        }

        public List<ContatoItem> GetContato()
        {
            return _contatoRepositorio.GetContato().ToList();
        }

        public ContatoItem Update(ContatoItem item)
        {
            return _contatoRepositorio.Update(item);
        }

        public void Delete(long id)
        {
            _contatoRepositorio.Delete(id);
        }
    }
}
