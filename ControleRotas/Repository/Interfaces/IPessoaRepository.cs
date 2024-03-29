﻿using ControleRotas.Models;
using System.Collections.Generic;

namespace ControleRotas.Repository.Interfaces
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        void SetActive(int id, bool active);
    }
}
