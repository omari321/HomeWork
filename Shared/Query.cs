using Microsoft.Build.Framework;

public class Query
{
    [Required] public int PageIndex { get; set; }

    [Required] public int PageSize { get; set; }
}
