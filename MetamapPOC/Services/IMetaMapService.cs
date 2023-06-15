using MetamapPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MetamapPOC.Services
{
    public interface IMetaMapService
    {
        Task<GovChecksResponse> Identify(GovChecksModel govChecksModel);
    }
}