using System.ComponentModel;

namespace BuyBiletDemo.Core.Enums
{
    public enum HttpMethodEnum
    {
        [Description("GET")]
        GET = 0,
        [Description("POST")]
        POST = 1,
        [Description("PUT")]
        PUT = 2,
        [Description("DELETE")]
        DELETE = 3
    }
}
