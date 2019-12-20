﻿using System.Collections.Generic;
using System.Linq;
using PeNet.Structures;

namespace PeNet.Parser
{
    internal class ImageBaseRelocationsParser : SafeParser<IMAGE_BASE_RELOCATION[]>
    {
        private readonly uint _directorySize;

        public ImageBaseRelocationsParser(
            byte[] buff,
            uint offset,
            uint directorySize
            )
            : base(buff, offset)
        {
            _directorySize = directorySize;
        }

        protected override IMAGE_BASE_RELOCATION[] ParseTarget()
        {
            if (Offset == 0)
                return null;

            var imageBaseRelocations = new List<IMAGE_BASE_RELOCATION>();
            var currentBlock = Offset;


            while (true)
            {
                if (currentBlock >= Offset + _directorySize - 8)
                    break;

                imageBaseRelocations.Add(new IMAGE_BASE_RELOCATION(Buff, currentBlock, _directorySize));
                currentBlock += imageBaseRelocations.Last().SizeOfBlock;
            }

            return imageBaseRelocations.ToArray();
        }
    }
}