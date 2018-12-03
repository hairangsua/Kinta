using Kinta.Models.Models;
using MediatR;

namespace Kinta.Models.Command
{
    public class UserSignUpCommand : IRequest<User>
    {
        public UserDTO UserDTO { get; set; }
    }
}
