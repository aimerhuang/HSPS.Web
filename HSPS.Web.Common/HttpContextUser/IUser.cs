﻿using HSPS.Web.Model;
using System.Security.Claims;

namespace HSPS.Web.Common.HttpContextUser
{
    public interface IUser
    {
        string Name { get; }
        long ID { get; }
        long TenantId { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
        List<string> GetClaimValueByType(string ClaimType);

        string GetToken();
        List<string> GetUserInfoFromToken(string ClaimType);

        MessageModel<string> MessageModel { get; set; }
    }
}
