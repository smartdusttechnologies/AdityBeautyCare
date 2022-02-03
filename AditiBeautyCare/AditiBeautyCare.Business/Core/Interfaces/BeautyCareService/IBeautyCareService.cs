using System;
using System.Collections.Generic;
using System.Text;
using AditiBeautyCare.Business.Common.Sample;
using AditiBeautyCare.Business.Core.Model.BeautyCareService;

namespace AditiBeautyCare.Business.Core.Interfaces.BeautyCareService
{
    public interface IBeautyCareService
    {
        List<BeautyCareServiceModel> Get();

        BeautyCareServiceModel Get(int id);
        List<BeautyCareServiceModel> GetPages(int pageIndex);

    }
}
