using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

[ApiController]
[Route("[controller]")]
public class AlertaController : ControllerBase
{
    private readonly string accountSid;
    private readonly string authToken;

    public AlertaController(IConfiguration configuration)
    {
        accountSid = configuration["Twilio:AccountSid"];
        authToken = configuration["Twilio:AuthToken"];

        TwilioClient.Init(accountSid, authToken);
    }

    [HttpPost("EnviarAlerta")]
    public IActionResult EnviarAlerta([FromBody] AlertaRequest request)
    {
        if (string.IsNullOrEmpty(request.PhoneNumber) || string.IsNullOrEmpty(request.Message))
        {
            return BadRequest(new { error = "PhoneNumber e Message são obrigatórios." });
        }

        try
        {
            var messageOptions = new CreateMessageOptions(new PhoneNumber($"whatsapp:{request.PhoneNumber}"))
            {
                From = new PhoneNumber("whatsapp:+14155238886"),
                Body = request.Message
            };

            var message = MessageResource.Create(messageOptions);

            return Ok(new { message = "Alerta enviado com sucesso!", sid = message.Sid });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = "Erro ao enviar mensagem: " + ex.Message });
        }
    }
}
