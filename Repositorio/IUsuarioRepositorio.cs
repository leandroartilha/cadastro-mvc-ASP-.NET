using Cadastro.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Cadastro.Data;
namespace Cadastro.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel ListarPorId(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);

        bool Apagar(int id);
    }
}
