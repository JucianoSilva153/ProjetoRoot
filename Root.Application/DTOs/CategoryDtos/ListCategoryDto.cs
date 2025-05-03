namespace Root.Application.DTOs.CategoryDtos;

public class ListCategoryDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }

    public List<string> PostTitles { get; set; } // ou List<Guid> PostIds, se preferir
}
