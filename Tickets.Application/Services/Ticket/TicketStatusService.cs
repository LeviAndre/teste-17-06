using Tickets.Application.Common.Interfaces.Persistence;
using Tickets.Application.Services.Ticket;
using Tickets.Domain.Entities;

public class TicketStatusService : ITicketStatusService
{
    private readonly ITicketStatusRepository _ticketStatusRepository;

    public TicketStatusService(ITicketStatusRepository ticketStatusRepository)
    {
        _ticketStatusRepository = ticketStatusRepository;
    }

    public async Task<List<TicketStatus>> FindAllTicketStatus()
    {
        try
        {
            var ticketStatus = await _ticketStatusRepository.GetAllTicketStatus();

            return ticketStatus;
        }
        catch (Exception ex)
        {
            //LOG DA EXCEPTION AQUI
            throw new Exception("Houve um erro ao buscar os status de chamado, tente novamente mais tarde. ");
        }
    }
}