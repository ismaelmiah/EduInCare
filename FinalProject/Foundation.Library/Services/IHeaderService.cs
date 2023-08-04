using System.Collections.Generic;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface IHeaderService
    {
        void AddHeaderImage(Header header);
        IList<Header> GetHeader();
        void RemoveHeaderImage();
    }
}