using FreshMarket.Application.DTOs.Auth;
using FreshMarket.Domain.Entities;

namespace FreshMarket.Application.Interfaces;

public interface IJwtService
{
    AuthResponse GenerateToken(User user);
}