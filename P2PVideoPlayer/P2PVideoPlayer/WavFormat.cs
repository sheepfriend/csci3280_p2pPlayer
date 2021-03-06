﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WpfApplication1
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct WavFormat
    {
        public short wFormatTag;
        public short nChannels;
        public int nSamplesPerSec;
        public int nAvgBytesPerSec;
        public short nBlockAlign;
        public short wBitsPerSample;
        public short cbSize;

        public WavFormat(int sampleRate, int bits, int channels)
        {
            wFormatTag = (short)WavFormats.PCM;
            nChannels = (short)channels;
            nSamplesPerSec = sampleRate;
            wBitsPerSample = (short)bits;
            cbSize = 0;

            nBlockAlign = (short)(channels * (bits / 8));
            nAvgBytesPerSec = nSamplesPerSec * nBlockAlign;
        }
    }

    public enum WavFormats
    {
        PCM = 1,
        FLOAT = 3,
    }

    class WinMM
    {

    }
    enum Messages : uint
    {
        MM_WIM_OPEN = 0x3BE,
        MM_WIM_CLOSE = 0x3BF,
        MM_WIM_DATA = 0x3C0,

        MM_WOM_OPEN = 0x3BB,
        MM_WOM_CLOSE = 0x3BC,
        MM_WOM_DONE = 0x3BD,
    }

    [Serializable()]
    public struct WaveHdr
    {
        public IntPtr lpData; // pointer to locked data buffer
        public int dwBufferLength; // length of data buffer
        public int dwBytesRecorded; // used for input only
        public IntPtr dwUser; // for client's use
        public int dwFlags; // assorted flags (see defines)
        public int dwLoops; // loop control counter
        public IntPtr lpNext; // PWaveHdr, reserved for driver
        public int reserved; // reserved for driver
    }
}
