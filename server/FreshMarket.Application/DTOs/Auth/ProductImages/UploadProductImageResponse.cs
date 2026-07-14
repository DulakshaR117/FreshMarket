namespace FreshMarket.Application.DTOs.ProductImages;

public class UploadProductImageResponse
{
    public Guid Id { get; set; }

    public string ImageUrl { get; set; } = string.Empty;

    public bool IsThumbnail { get; set; }
}