using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.WebApplication.Models
{
    public static class RoleName
    {
        // change here only when we need to change the role name without going to all controllers
        public const string Maintainer = "DataMaintainer";
        public const string Editor = "Editor";
        public const string Approver = "Approver";
    }
}