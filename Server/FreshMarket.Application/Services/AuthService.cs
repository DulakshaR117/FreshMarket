using BCrypt.Net;
using FreshMarket.Application.DTOs.Auth;
using FreshMarket.Application.Interfaces;
using FreshMarket.Domain.Entities;

namespace FreshMarket.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IJwtService _jwtService;

    public AuthService(
        IUserRepository userRepository,
        IRoleRepository roleRepository,
        IJwtService jwtService)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _jwtService = jwtService;
    }

    public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email);

        if (existingUser != null)
            throw new Exception("Email already exists.");

        var customerRole = await _roleRepository.GetByNameAsync("Customer");

        if (customerRole == null)
            throw new Exception("Customer role not found.");

        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            RoleId = customerRole.Id,
            Role = customerRole,
            IsActive = true
        };

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        return _jwtService.GenerateToken(user);
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);

        if (user == null)
            throw new Exception("Invalid email or password.");

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            throw new Exception("Invalid email or password.");

        return _jwtService.GenerateToken(user);
    }
}