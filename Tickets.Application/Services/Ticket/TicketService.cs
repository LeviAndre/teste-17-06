using Tickets.Application.Common.Interfaces.Persistence;
using Tickets.Application.Services.Ticket;
using Tickets.Domain.Entities;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;

    public TicketService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<bool> CreateTicket(string title, string description, int userId)
    {
        try
        {
            var ticket = new Ticket{
                Title = title,
                Description = description,
                UserId = userId,
                StatusId = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _ticketRepository.PostTicket(ticket);

            return true;
        }
        catch (Exception ex)
        {
            //LOG DA EXCEPTION AQUI
            throw new Exception("Houve um erro ao tentar criar o chamado. ");
        };
    }

    public async Task<TicketResult> FindTicket(int id)
    {
        try
        {
            var ticket = await _ticketRepository.GetTicket(id);

            if (ticket is null) throw new Exception("Chamado não encontrado. ");

            return new TicketResult(
                ticket.Id,
                ticket.Title,
                ticket.Description,
                ticket.StatusId,
                ticket.UserId,
                ticket.CreatedAt,
                ticket.UpdatedAt
            );
        } 
        catch (Exception ex)
        {
            //LOG DA EXCEPTION AQUI
            throw new Exception("Houve um erro ao buscar esse chamado, tente novamente mais tarde. ");
        };
    }

    public async Task<List<TicketResult>> FindTickets()
    {
        try
        {
            var tickets = await _ticketRepository.GetTickets();

            return tickets.Select(ticket => new TicketResult(
                ticket.Id,
                ticket.Title,
                ticket.Description,
                ticket.StatusId,
                ticket.UserId,
                ticket.CreatedAt,
                ticket.UpdatedAt
            )).ToList();
        }
        catch (Exception ex)
        {
            //LOG DA EXCEPTION AQUI
            throw new Exception("Houve um erro ao buscar os chamados, tente novamente mais tarde. ");
        }
    }
}