public sealed record ProjectResponseDto
{
    public Guid Id { get; init; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public bool IsArchived { get; set; }

    public Guid ManagerId { get; set; }

    public string ManagerName { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public int TotalBugs { get; set; }

    public int OpenBugs { get; set; }
}