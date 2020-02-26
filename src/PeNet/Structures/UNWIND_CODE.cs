﻿using PeNet.Utilities;

namespace PeNet.Structures
{
    /// <summary>
    ///     The UNWIND_CODE is a struct in
    ///     the UNWIND_INFO used to describe
    ///     exception handling in x64 applications
    ///     and to walk the stack.
    /// </summary>
    public class UNWIND_CODE : AbstractStructure
    {
        /// <summary>
        ///     Create a new UNWIND_INFO object.
        /// </summary>
        /// <param name="buff">A PE file as a byte array.</param>
        /// <param name="offset">Raw offset of the UNWIND_INFO.</param>
        public UNWIND_CODE(byte[] buff, uint offset)
            : base(buff, offset)
        {
        }

        /// <summary>
        ///     Code offset.
        /// </summary>
        public byte CodeOffset
        {
            get => PeFile[Offset];
            set => PeFile[Offset] = value;
        }

        /// <summary>
        ///     Unwind operation.
        /// </summary>
        public byte UnwindOp => (byte) (PeFile[Offset + 0x1] >> 4);

        /// <summary>
        ///     Operation information.
        /// </summary>
        public byte Opinfo => (byte) (PeFile[Offset + 0x1] & 0xF);

        /// <summary>
        ///     Frame offset.
        /// </summary>
        public ushort FrameOffset
        {
            get => PeFile.ReadUShort(Offset + 0x2);
            set => PeFile.WriteUShort(Offset + 0x2, value);
        }
    }
}