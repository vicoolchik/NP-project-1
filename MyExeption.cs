using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЗАПОВІДНИК
{
    public enum MyExceptionKind
    {
        WrongUserInputExeption,
        UnknownExeption,
        WrongIndexExeption
    }
    public class MyException : Exception
    {
        private MyExceptionKind? myExceptionKind = null;

        public MyExceptionKind ExceptionKind { get => myExceptionKind.Value; }

        public MyException()
        {
        }

        public MyException(MyExceptionKind myExceptionKind, string message)
            : base(message)
        {
            this.myExceptionKind = myExceptionKind;
        }

        public MyException(MyExceptionKind myExceptionKind, string message, Exception inner)
            : base(message, inner)
        {
            this.myExceptionKind = myExceptionKind;
        }
    }
}

