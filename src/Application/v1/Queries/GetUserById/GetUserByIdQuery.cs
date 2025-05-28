using MediatR;

namespace Fatec.Store.User.Application.v1.Queries.GetUserById
{
    public class GetUserByIdQuery(int id) : IRequest<GetUserByIdQueryResponse>
    {
        public int Id { get; set; } = id;
    }
}