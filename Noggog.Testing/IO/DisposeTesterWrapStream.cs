﻿using System.IO;

namespace Noggog.Testing.IO
{
    public class DisposeTesterWrapStream : Stream
    {
        public bool Disposed { get; set; }
        public Stream Stream { get; }

        public DisposeTesterWrapStream(Stream stream)
        {
            Stream = stream;
        }

        public override void Flush()
        {
            Stream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return Stream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return Stream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            Stream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            Stream.Write(buffer, offset, count);
        }

        public override bool CanRead => Stream.CanRead;

        public override bool CanSeek => Stream.CanSeek;

        public override bool CanWrite => Stream.CanWrite;

        public override long Length => Stream.Length;

        public override long Position
        {
            get => Stream.Position;
            set => Stream.Position = value;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            Disposed = true;
        }
    }
}