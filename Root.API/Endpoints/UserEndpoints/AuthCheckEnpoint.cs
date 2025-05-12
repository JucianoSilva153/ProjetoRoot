using FastEndpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;

public class AuthCheckEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/auth/check");
        Description(x => x.WithTags("Authentication"));
        AuthSchemes(JwtBearerDefaults.AuthenticationScheme);
        Summary(s =>
        {
            s.Summary = "Verifica se o token JWT é válido e o usuário está autenticado";
        });
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            var username = User.Identity.Name; // Ou outras claims
            await SendOkAsync(new { authenticated = true, user = username }, ct);
        }
        else
        {
            await SendUnauthorizedAsync(ct);
        }
    }
}