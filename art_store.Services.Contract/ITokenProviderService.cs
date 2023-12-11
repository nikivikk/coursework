using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace art_store.Services.Contract
{
    public interface ITokenProviderService
    {
        public string GetClaimValueByType(string accessToken, string claimType);
    }
}

