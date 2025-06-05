//A public class named GetActivityList with a defined Query class insite of it, derived from IRequest<List<Activity>> where Activity if from the Domain namespace.
using Domain;
using Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Activities.Queries;

public class GetActivityList : IRequest<List<Activity>>
{
    public class Query : IRequest<List<Activity>>
    { // parameters would go here if needed
    }

    public class Handler(AppDbContext context) : IRequestHandler<Query, List<Activity>>
    {

        public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await context.Activities.ToListAsync(cancellationToken);
        }
    }
}
