﻿using Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service.Interface
{
    public interface IContatoService
    {
        ContatoItem Add(ContatoItem item);
        List<ContatoItem> GetContato();
        ContatoItem Get(long id);
        ContatoItem Update(ContatoItem item);
        void Delete(long id);
    }
}
