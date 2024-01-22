
namespace Verita.Application
{
    public interface IUserClaimService
    {
        string GetUserName();
        string GetUserFirstName();
        string GetUserLastName();
        string GetUserAvatarUrl();
        string GetUserPosition();
        string GetUserNickName();
        DateTime? GetUserDateRegistered();
    }
}
