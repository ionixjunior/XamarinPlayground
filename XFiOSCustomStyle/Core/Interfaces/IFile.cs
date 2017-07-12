using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IFile
    {
        Task OpenFromResource(string name);
    }
}
