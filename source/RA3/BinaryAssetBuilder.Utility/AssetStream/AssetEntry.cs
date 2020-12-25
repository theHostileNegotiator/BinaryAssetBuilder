﻿using System.Runtime.InteropServices;

namespace AssetStream
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AssetEntry
    {
        public uint TypeId;
        public uint InstanceId;
        public uint TypeHash;
        public uint InstanceHash;
        public int AssetReferenceOffset;
        public int AssetReferenceCount;
        public int NameOffset;
        public int SourceFileNameOffset;
        public int InstanceDataSize;
        public int RelocationDataSize;
        public int ImportsDataSize;
        public uint IsTokenized;
    }
}
