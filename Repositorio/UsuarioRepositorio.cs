using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastro.Data;
using Cadastro.Models;

namespace Cadastro.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _context;
        private UsuarioModel usuarioDB;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _context = bancoContext;
        }
        public UsuarioModel ListarPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }


        public List<UsuarioModel> BuscarTodos()
        {
            return _context.Usuarios.ToList();
        }
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarPorId(usuario.Id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na atualização do contato");

            usuarioDB.Nome = usuario.Nome; 
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;


            _context.Usuarios.Update(usuarioDB);
            _context.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = ListarPorId(id);

            if (usuarioDB == null) throw new System.Exception("Houve erro na deleção de contato");
            _context.Usuarios.Remove(usuarioDB);
            _context.SaveChanges();
            return true;
        }

      
  
    }
}
