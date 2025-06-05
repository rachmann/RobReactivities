//A public class named GetActivityDetails with a defined Query class insite of it, derived from IRequest<List<Activity>> where Activity is from the Domain namespace.
using Domain;
using Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Activities.Queries;

public class GetActivityDetails : IRequest<Activity>
{
    public class Query : IRequest<Activity>
    {
        public required string Id { get; set; } // Activity ID to fetch details for
    }

    public class Handler(AppDbContext context) : IRequestHandler<Query, Activity>
    {
        public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
        {
            var activity = await context.Activities
                .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            if (activity == null) throw new Exception($"Activity with ID {request.Id} not found.");

            return activity;
        }
    }
}

