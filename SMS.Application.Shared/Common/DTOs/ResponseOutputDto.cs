using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Shared.Common.DTOs
{
    public class ResponseOutputDto//<DtoType>  where DtoType : class
    {

        public string Status { get; set; }
        public string Message { get; set; }
        public dynamic resultJSON { get; set; }

        public void Success<DtoType>(DtoType resultJSON) where DtoType : class
        {
            this.Status = "Success";
            this.Message = "Success";
            this.resultJSON = resultJSON;
        }
        public void Error(string message)
        {
            this.Status = "Error";
            this.Message = message;
            this.resultJSON = null;
        }
    }
}
