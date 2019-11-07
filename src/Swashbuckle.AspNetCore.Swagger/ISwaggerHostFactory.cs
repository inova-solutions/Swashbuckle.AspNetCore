#if !netstandard2
using Microsoft.Extensions.Hosting;

namespace Swashbuckle.AspNetCore.Swagger
{
    public interface ISwaggerHostFactory
    {
        IHost BuildHost();
    }
}
#endif