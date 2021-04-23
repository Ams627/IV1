using System;
using System.Diagnostics;

namespace IV1
{
    public interface I1
    {
        void Print();
    }

    public class X1 : I1
    {
        public void Print()
        {
            Trace.WriteLine("X1");
        }
    }

    public class AlternativeX1 : I1
    {
        public void Print()
        {
            Trace.WriteLine("Alternative X1");
        }
    }

    public enum CreateType
    {
        Normal,
        Alternative,
        External
    }

    public class XFactory
    {
        private static CreateType createType = CreateType.Normal;
        private static Type altI1Type;

        public static I1 Create()
        {
            switch (createType)
            {
                case CreateType.Normal:
                    return new X1();
                case CreateType.Alternative:
                    return new AlternativeX1();
                case CreateType.External:
                    return (I1)Activator.CreateInstance(altI1Type);
                default:
                    throw new ArgumentException("Bad create type");
            }
        }

        internal static void SetAlt(CreateType v)
        {
            createType = v;
        }

        internal static void ProvideAlt(Type type)
        {
            altI1Type = type;
        }
    }
}
