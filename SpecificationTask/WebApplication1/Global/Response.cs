﻿using System.Net;

namespace WebApplication1.Global
{
    public class Response
    {
        public bool Status { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
