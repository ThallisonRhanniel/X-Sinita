using System.Threading.Tasks;

namespace xsinita.Core.Interfaces
{
    public interface IPostService
    {
        Task<string> EnviarDadosAsync(string name, string category, string comment);
    }
}
