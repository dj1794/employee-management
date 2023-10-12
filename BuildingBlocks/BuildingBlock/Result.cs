using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlock
{
    public class Result
    {
        private bool IsSuccess { get; set; }
        private int? ErrorCode { get; set; }
        private string? Message { get; set; }
        private dynamic? Data { get; set; }
      public static async Task<Result> SuccessAsync<TData>(TData data)
        {
           return await Task.FromResult(new Result { IsSuccess = true, Data = data, Message ="Success", ErrorCode = null });
        }
      //public static async Task<Result> SuccessAsync(string message)
      //  {
      //      return await Task.FromResult(new Result { IsSuccess = true, Data = null, Message = message, ErrorCode = null });
      //  }
      //public static async Task<Result> FailedAsync()
      //  {
      //      return await Task.FromResult(new Result { IsSuccess = false, Data = null, Message = "Bad Request", ErrorCode = 400 });
      //  }
      public static async Task<Result> FailedAsync(string message, int? errorCode=400)
        {
            return await Task.FromResult(new Result{ IsSuccess = false, Data = null, Message = message, ErrorCode = errorCode });
        }
    }
}
