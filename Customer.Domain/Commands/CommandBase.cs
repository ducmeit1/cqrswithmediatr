using MediatR;

namespace Customer.Domain.Commands
{
    public class CommandBase<T> : IRequest<T> where T : class
    {
        
    }
}