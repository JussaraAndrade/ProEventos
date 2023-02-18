using System;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;
        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            _eventoPersist = eventoPersist;
            _geralPersist = geralPersist;

        }

        public async Task<Evento> AddEventos(Evento model)
        {
            // Trata exception de erro na classe de service
            try
            {
                _geralPersist.Add<Evento>(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try     
            {   
                // Dentro do evento quero buscar o GetEventoById
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);

                // Se alguém desse evento não for retornado, retorna null.
                if (evento == null) return null;

                model.Id = evento.Id;

                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try     
            {   
                // Efetuando a leiteira na base pra ver se exisiti o id que está sendo fornecido
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);

                if (evento == null) throw new Exception("Evento para delete não encontrado.");

                _geralPersist.Delete<Evento>(evento);
                return await _geralPersist.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {    // eventos vai esperar eventoPersist
                // Var irá recebe o resultado da busca no banco de dados se contém todos os Eventos
                 var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);
                 if (eventos == null) return null;

                 return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {    // eventos vai esperar eventoPersist
                 var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);
                 if (eventos == null) return null;

                 return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
             try
            {    // eventos vai esperar eventoPersist
                 var eventos = await _eventoPersist.GetEventoByIdAsync(eventoId, includePalestrantes);
                 if (eventos == null) return null;

                 return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}