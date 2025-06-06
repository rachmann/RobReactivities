// public class to delete an activity
using Domain;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Activities.Commands;

public class DeleteActivity
{
    public class Command : IRequest
    {
        public required string Id { get; set; }  // ID of the activity to be deleted
    }

    public class Handler(AppDbContext context) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await context.Activities
                .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken)
                ?? throw new Exception($"Activity with ID {request.Id} not found.");

            context.Remove(activity);

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
