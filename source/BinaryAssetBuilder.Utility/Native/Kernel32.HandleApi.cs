﻿using System;

namespace Native
{
    public static partial class Kernel32
    {
        public delegate bool CloseHandleDelegate(IntPtr hObject);

        public static readonly CloseHandleDelegate CloseHandle;
    }
}
