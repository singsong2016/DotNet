    #region 文件映射到内存，可以供一台电脑大量独立程序共同读写访问交互
        public static void MemoryMappedFileDemo()
        {
            Create();
            Read();

            static void Create()
            {
                var a = MemoryMappedFile.CreateNew("shared memory", 1);

                using var b = a.CreateViewAccessor();
                b.Write(10, 20000000);
            }

            static void Read()
            {

#pragma warning disable CA1416 // Validate platform compatibility
                var a = MemoryMappedFile.OpenExisting("shared memory");
#pragma warning restore CA1416 // Validate platform compatibility

                using var b = a.CreateViewAccessor();
                short d = 0;
                b.Read(10, out d);
                Console.WriteLine(d);
            }
        }

        #endregion
