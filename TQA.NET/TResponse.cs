using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TQA.NET
{
    /// <summary>
    /// Encapsulates a response parse into a solid type. Will set IsSuccess to false if not successfull. Avoids having to set T to null for non
    /// nullable types
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TResponse<T>
    {
        public T Response { get; set; }
        public bool IsSuccess { get; set; }
    }
}
