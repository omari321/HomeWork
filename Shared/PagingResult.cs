namespace Reddit.Shared;

public record PagingResult<T>(IEnumerable<T> Result, int TotalSize);