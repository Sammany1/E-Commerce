using eCommerce.Domain.Models;

namespace eCommerce.Application.DTOs;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public CategoryDto(Category category)
    {
        Id = category.Id;
        Name = category.Name;
    }
}
