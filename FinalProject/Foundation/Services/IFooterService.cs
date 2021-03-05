using System.Collections.Generic;
using Foundation.Entities;

namespace Foundation.Services
{
    public interface IFooterService
    {
        void AddFooter(Footer footer);
        IList<Footer> GetFooter();
    }
}