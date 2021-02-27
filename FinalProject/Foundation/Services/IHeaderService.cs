using Foundation.Entities;

namespace Foundation.Services
{
    public interface IHeaderService
    {
        void AddHeaderImage(Header header);
        void RemoveHeaderImage();
    }
}