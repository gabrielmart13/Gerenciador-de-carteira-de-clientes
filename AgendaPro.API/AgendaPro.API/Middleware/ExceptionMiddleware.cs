using AgendaPro.Application.Exceptions;

namespace AgendaPro.Application.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        //Injetando as dependencias necessarias
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next; 
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context); //Tenta pegar o proximo context 
            }
            catch(Exception ex) //Se der ruim entra uma excessao aqui (recebe a excessao q deu na aplicacao)
            {
                if(context.Response.HasStarted)
                {
                    _logger.LogError(ex, "A resposta já havia começado quando ocorreu uma exceção.");

                    throw;
                }


                await HandleExceptionAsync(context, ex); //Chama o analizador de excessoes
            }

        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception) 
        {
            //Variaveis para formar resposta
            int statusCode;
            string message;
            string code;

            switch (exception) //Verifica em cada excessao possivel que criamos e envia a mensagem dela
            {
                case NotFoundException:
                    statusCode = StatusCodes.Status404NotFound;
                    code = "NOT_FOUND";
                    message = exception.Message;
                    break;

                case AgendaPro.Application.Exceptions.ValidationException:
                    statusCode = StatusCodes.Status400BadRequest;
                    code = "VALIDATION_ERROR";
                    message = exception.Message;
                    break;

                case ConflictException:
                    statusCode = StatusCodes.Status409Conflict;
                    code = "CONFLICT";
                    message = exception.Message;
                    break;

                default:
                    statusCode = StatusCodes.Status500InternalServerError;
                    code = "INTERNAL_SERVER_ERROR";
                    message = "Ocorreu um erro interno no servidor.";

                    _logger.LogError(
                        exception,
                        "Erro não tratado durante o processamento da requisição."
                    );
                    break;
            }
            context.Response.Clear();
            context.Response.StatusCode = statusCode;

            var response = new //Forma a resposta
            {
                status = statusCode,
                code,
                message,
                timestamp = DateTime.UtcNow,
                path = context.Request.Path.Value
            };

            await context.Response.WriteAsJsonAsync(response );

        }
    }
}
