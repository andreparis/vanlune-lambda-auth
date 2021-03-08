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
            { "get#orders","GET"},
            { "put#orders","PUT"},

            //Accounts:
            { "post#accounsts/roles","POST"},
            { "post#accounsts/roles/patch","POST"},
            { "post#accounsts/roles/claims/patch","POST"},

            { "post#accounsts/claims","POST"},
            { "post#accounsts/changepassowrd","POST"},

            { "post#accounsts","POST"},
            { "put#accounsts","PUT"},
            { "delete#accounsts","DELETE"},

            //Products:
            { "post#products","POST"},
            { "put#products","PUT"},
            { "delete#products","DELETE"},
            { "get#products","GET"},

            { "post#products/category","POST"},
            { "get#products/category","GET"},
            { "get#products/category/all","GET"},

            { "post#products/tags","POST"},
            { "get#products/tags","GET"},

            { "post#products/variants","POST"},
            { "get#products/variants","GET"},
        };
    }
}
