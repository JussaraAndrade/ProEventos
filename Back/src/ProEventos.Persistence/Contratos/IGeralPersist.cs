using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    //Cria toda a camada de Persistence
    public interface IGeralPersist //Interface - contrato geral
    {
        /* 
            Esse Add vai ser genérico passando T que vai ser a Entity 
            Where "onde": T é uma classe

            Itens gerais: todo e qualquer Adicionar, Alterar, Deletar, Deletar Range, e Salvar...
        */

        /* 
            GERAL - adicionar, alterar, deletar, deletar range e Salvar.
            Considera como Geral pq está genérico 
        */
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        void DeleteRange<T>(T[] entity) where T: class;
        Task<bool> SaveChangesAsync();
    }
}