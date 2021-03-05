using System.Collections;
using System.Collections.Generic;
using Foundation.Entities;

namespace Foundation.Services
{
    public interface IHeaderService
    {
        void AddHeaderImage(Header header);
        IList<Header> GetHeader();
        void RemoveHeaderImage();
    }
}