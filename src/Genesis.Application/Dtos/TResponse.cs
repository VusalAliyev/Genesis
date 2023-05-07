﻿namespace Genesis.Application.Dtos
{
    public class TResponse<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccessful { get; set; }

        public List<string>? Errors { get; set; }
        public static TResponse<T> Success(T data, int statusCode)
        {
            return new TResponse<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };
        }
        public static TResponse<T> Success(int statusCode)
        {
            return new TResponse<T> { Data = default(T), StatusCode = statusCode, IsSuccessful = true };
        }
        public static TResponse<T> Fail(List<string> errors, int statusCode)
        {
            return new TResponse<T> { Errors = errors, StatusCode = statusCode, IsSuccessful = false };
        }
        public static TResponse<T> Fail(string error, int statusCode)
        {
            return new TResponse<T> { Errors = new List<string>() { error }, StatusCode = statusCode, IsSuccessful = false };
        }
    }
}
