// create a public class with a defined Command class inside of it, derived from IRequest<Activity> where Activity is from Domain namespace.
using Domain;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Application.Activities.Commands;

public class EditActivity
{
    public class Command : IRequest
    {
        public required Activity Activity { get; set; }  // Activity to be edited
    }

    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await context.Activities
                .FirstOrDefaultAsync(a => a.Id == request.Activity.Id, cancellationToken)
                ?? throw new Exception($"Activity with ID {request.Activity.Id} not found.");

            // Update properties
            mapper.Map(request.Activity, activity);

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
