using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {


        public Result(bool success, string message) : this(success) // iki parametre gönderdiğimizde birde bunu çalıştır diyoruz kendimizi tekrar etmemek için.
        {
            Message = message;
        }

        public Result(bool success) //constructor dışında set edilemez.
        {
            Success = success;
        }


        public bool Success { get; }

        public string Message { get; }
    }
}