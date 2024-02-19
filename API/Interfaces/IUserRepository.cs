using API.DTOs;

namespace API.Interfaces;

public interface IUserRepository
{
  void Update(AppUser user);

  Task<bool> SaveAllAsync();
  Task<IEnumerable<AppUser>> GetUsersAsync();
  Task<AppUser> GetUserByIdAsync(int id);
  Task<AppUser> GetUserBYUsernameAsync(string username);
  Task<IEnumerable<MemberDto>> GetMemberAsync();
  Task<MemberDto> GetMemberAsync(string username);
}
