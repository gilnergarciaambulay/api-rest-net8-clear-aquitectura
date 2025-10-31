namespace WebApi.DTOs
{
    public record ApiResponse<T>(
        string Message,
        T Resultado,
        bool Confirmacion = true
    );
}
