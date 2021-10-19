﻿using Finances.Business.Domain.Enums;

namespace Finances.Business.Domain.Dtos.Base
{
    public class NotificationsResponse
    {
        public NotificationsResponse(ErrorCode code, string message)
        {
            Code = (int)code;
            Message = message;
        }

        public NotificationsResponse(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public int Code { get; set; }
        public string Message { get; set; }
    }
}
