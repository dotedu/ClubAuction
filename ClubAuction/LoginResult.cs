using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubAuction
{
    public static class LoginResult
    {
        public static string callbcakURL { get; set; }
        public static int isSuccess { get; set; } = 0;
        public static string errorCode { get; set; } = "10000004";
        public static string errorDesc { get; set; } = "非法操作";
        public static string formhash { get; set; }

    }
}
