using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastro.Data;
using Cadastro.Models;

namespace Cadastro.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _context;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            _context = bancoContext;
        }
        public ContatoModel ListarPorId(int id)
        {
            return _context.ContatoModel.FirstOrDefault(x => x.Id == id);
        }


        public List<ContatoModel> BuscarTodos()
        {
            return _context.ContatoModel.ToList();
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _context.ContatoModel.Add(contato);
            _context.SaveChanges();

            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPorId(contato.Id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na atualização do contato");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _context.ContatoModel.Update(contatoDB);
            _context.SaveChanges();

            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListarPorId(id);

            if (contatoDB == null) throw new System.Exception("Houve erro na deleção de contato");
            _context.ContatoModel.Remove(contatoDB);
            _context.SaveChanges();
            return true;
        }

        
    }
}
