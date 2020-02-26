﻿using PeNet.Utilities;

namespace PeNet.Structures
{
    /// <summary>
    ///     The IMAGE_RESOURCE_DATA_ENTRY points to the data of
    ///     the resources in the PE file like version info, strings etc.
    /// </summary>
    public class IMAGE_RESOURCE_DATA_ENTRY : AbstractStructure
    {
        /// <summary>
        ///     Construct a IMAGE_RESOURCE_DATA_ENTRY at a given offset.
        /// </summary>
        /// <param name="buff">PE file as a byte array.</param>
        /// <param name="offset">Offset to the structure in the file.</param>
        public IMAGE_RESOURCE_DATA_ENTRY(byte[] buff, uint offset)
            : base(buff, offset)
        {
        }

        /// <summary>
        ///     Offset to the data of the resource.
        /// </summary>
        public uint OffsetToData
        {
            get => PeFile.ReadUInt(Offset);
            set => PeFile.WriteUInt(Offset, value);
        }

        /// <summary>
        ///     Size of the resource data.
        /// </summary>
        public uint Size1
        {
            get => PeFile.ReadUInt(Offset + 0x4);
            set => PeFile.WriteUInt(Offset + 0x4, value);
        }

        /// <summary>
        ///     Code Page
        /// </summary>
        public uint CodePage
        {
            get => PeFile.ReadUInt(Offset + 0x8);
            set => PeFile.WriteUInt(Offset + 0x8, value);
        }

        /// <summary>
        ///     Reserved
        /// </summary>
        public uint Reserved
        {
            get => PeFile.ReadUInt(Offset + 0xC);
            set => PeFile.WriteUInt(Offset + 0xC, value);
        }
    }
}