using WebApp_Multi_user_chat.Dto;
using WebApp_Multi_user_chat.Entities;

namespace WebApp_Multi_user_chat.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        // Validation de l'utilisateur
        bool ValidateUser(User user);

        // Récupérer un utilisateur par son nom d'utilisateur
        User? GetUserById(string username);

        // Méthode pour enregistrer un nouvel utilisateur
        Task<bool> RegisterUser(UserRequest user);

        Task<UserResponse> LoginAsync(UserRequest request);
    }
}
