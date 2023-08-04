using System.Collections.Generic;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface IFooterService
    {
        void AddFooter(Footer footer);
        IList<Footer> GetFooter();
    }
}