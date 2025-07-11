using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;
using EshopApp.Application.Exceptions;
using EshopApp.Application.DTOs.CategoryDTOs;

namespace EshopApp.Application.UseCases.CategoryUseCases;
/// <summary>
/// Use case for retrieving all categories as a flattened list with hierarchical names.
/// </summary>
public class GetAllCategoriesUseCase
{
    private readonly ICategoryRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllCategoriesUseCase"/> class.
    /// </summary>
    /// <param name="repository">The category repository to use for data access.</param>
    public GetAllCategoriesUseCase(ICategoryRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executes the use case to retrieve all categories as a flattened list, preserving hierarchy in the names.
    /// </summary>
    /// <returns>A list of <see cref="CategoryDto"/> representing all categories.</returns>
    public async Task<List<CategoryDto>> ExecuteAsync()
    {
        var tree = await _repository.GetAllAsTreeAsync();

        // Recursively flattens the category tree into a list, adding dashes to indicate hierarchy level.
        List<CategoryDto> Flatten(List<Category> nodes, int level = 0)
        {
            var result = new List<CategoryDto>();
            foreach (var node in nodes)
            {
                result.Add(new CategoryDto
                {
                    Id = node.Id,
                    Name = new string('-', level * 2) + node.Name
                });
                if (node.Children != null && node.Children.Any())
                    result.AddRange(Flatten(node.Children, level + 1));
            }
            return result;
        }

        return Flatten(tree);
    }
}
