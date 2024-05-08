namespace WebAPI;

public sealed record class ResponseModel
{
    public bool Success { get; init; }
    public object Response { get; init; }
}
