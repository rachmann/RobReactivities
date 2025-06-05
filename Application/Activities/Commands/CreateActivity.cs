// create a public class with a defined Command class inside of it, derived from IRequest<Unit> where Unit is from MediatR namespace.
using Domain;
using MediatR;  
using Persistence;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Activities.Commands;

public class CreateActivity : IRequest<string>
{
    public class Command : IRequest<string>
    {
        public required Activity Activity { get; set; }  // Activity to be created
    }

    public class Handler(AppDbContext context) : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            context.Activities.Add(request.Activity);
            await context.SaveChangesAsync(cancellationToken);
            return request.Activity.Id; // Return Id to indicate completion
        }
    }
}
