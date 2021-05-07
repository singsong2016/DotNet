internal static class CClinkCore
    {
        #region sealed read write methods
        internal static bool Init()
        {
            return mdOpen(151, -1, ref Path) == 0;
        }

        internal static void Close()
        {
            mdClose(Path);
        }

        internal static bool Write(bool WB, int Address, UInt16[] data)
        {
            var size = data.Length * 2;
            if (size == 0)
            {
                return true;
            }
            return mdSendEx(Path, 0, 255, (short)(WB ? 24 : 23), Address, ref size, ref data[0]) == 0;
        }

        internal static UInt16[] Read(bool WB, int devno, int size)
        {
            var a = new UInt16[size];
            var s = size * 2;
            mdReceiveEx(Path, 0, 255, (short)(WB ? 24 : 23), devno, ref s, ref a[0]);
            return a;
        }

        internal static bool ReadBool(int address)
        {
            var data = new short[1];
            var a = new int[4];
            a[0] = 1;
            a[1] = 23;
            a[2] = address;
            a[3] = 1;
            mdRandREx(Path, 0, 255, ref a[0], ref data[0], 2);
            return data[0] == 1;
        }

        internal static bool WriteBool(int address, bool value)
        {
            var re = value ? mdDevSetEx(Path, 0, 255, 23, address) : mdDevRstEx(Path, 0, 255, 23, address);

            return re == 0;
        }
        internal static short ReadLed()
        {
            var a = new short[1];
            mdBdLedRead(Path, ref a[0]);
            return a[0];
        }

        private static int Path;
        #endregion

    }
