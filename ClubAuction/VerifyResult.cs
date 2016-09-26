using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubAuction
{
    public static class VerifyResult
    {
        public static int isSuccess { get; set; } = 0;
        public static string errorCode { get; set; } = "10000001";
        public static string errorDesc { get; set; } = "系统繁忙，请稍后再试";

    }
}
