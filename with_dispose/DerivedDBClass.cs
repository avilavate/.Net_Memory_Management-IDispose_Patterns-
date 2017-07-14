using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace with_dispose
{
    class DerivedDBClass : DBClass, IDisposable
    {
        public IntPtr IPointer { get; set; }

        public void AllocPointer()
        {
            //Allocate 4MB
            IPointer = Marshal.AllocHGlobal(1 * 1024 * 1024);

        }
        public void Dispose()
        {
            Dispose(true);
        }
        protected override void Dispose(bool v)
        {
            if (!v)
            {
                Console.WriteLine("DerivedDB Dispose");

                Marshal.Release(IPointer);
                Marshal.FreeHGlobal(IPointer);
                IPointer = IntPtr.Zero;
            }
            base.Dispose(v);
        }

        ~DerivedDBClass()
        {
            Dispose(false);
        }
    }
}
