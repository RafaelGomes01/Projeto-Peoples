using senai_peoples_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_peoples_webApi.Interfaces
{
    interface IFuncionarioRepository
    {
        List<FuncionarioDomain> ListarTodos();

        FuncionarioDomain BuscarPorId(int Id);

        void Delete(int Id);

        void Atualizar(int id, FuncionarioDomain funcionarioAtualizado);

        void Cadastrar(FuncionarioDomain novoFuncionario);

    }
}
