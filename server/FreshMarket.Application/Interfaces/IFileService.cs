using Microsoft.AspNetCore.Http;

namespace FreshMarket.Application.Interfaces;

public interface IFileService
{
    Task<string> UploadProductImageAsync(IFormFile file);
}