using MediatR;

namespace Fatec.Store.User.Application.Queries.v1.GetUserById
{
    public class GetUserByIdQuery(int id) : IRequest<GetUserByIdQueryResponse>
    {
        public int Id { get; set; } = id;
    }
}