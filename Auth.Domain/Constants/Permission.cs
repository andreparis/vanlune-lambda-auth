using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Domain.Constants
{
    public static class Permission
    {
        public static Dictionary<string, string> Claim = new Dictionary<string, string>()
        {
            //Orders:
            { "post#orders","POST"},
            { "post#orders/assign","POST"},
            { "get#orders/user","GET"},
            { "get#orders","GET"},
            { "put#orders","PUT"},
            { "get#orders/filters","GET"},

            //Accounts:
            { "post#accounts/roles","POST"},
            { "get#accounts/roles","GET"},
            { "post#accounts/roles/patch","POST"},
            { "post#accounts/roles/claims/patch","POST"},

            { "post#accounts/claims","POST"},
            { "post#accounts/changepassowrd","POST"},

            { "post#accounts","POST"},
            { "put#accounts","PUT"},
            { "delete#accounts","DELETE"},
            { "get#accounts/filters","GET"},

            //Products:
            { "post#products","POST"},
            { "put#products","PUT"},
            { "delete#products","DELETE"},
            { "get#products","GET"},
            { "get#products/filters","GET"},

            { "post#products/category","POST"},
            { "get#products/category","GET"},
            { "put#products/category","PUT"},
            { "delete#products/category","DELETE"},
            { "get#products/category/all","GET"},
            { "get#products/category/game","GET"},

            { "post#products/tags","POST"},
            { "get#products/tags","GET"},

            { "post#products/variants","POST"},
            { "get#products/variants","GET"},
            { "get#products/variants/servers","GET"},

            { "post#products/customize","POST"},
            { "put#products/customize","PUT"},
            { "get#products/customize/filters","GET"},
            { "delete#products/customize","DELETE"},

            { "get#products/games/all","GET"},
        };
    }
}
