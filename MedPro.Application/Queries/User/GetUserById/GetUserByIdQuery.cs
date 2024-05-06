using MediatR;
using MedPro.Application.ViewModels;

namespace MedPro.Application.Queries.User.GetUserById;

public class GetUserByIdQuery : IRequest<UserViewModel?>
{
    public GetUserByIdQuery(Guid id)
    {
        Id = id;
    }
    
    public Guid Id { get; set; }
}