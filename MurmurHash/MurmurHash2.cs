using System;

namespace MurmurHash
{
	public class MurmurHash2
	{
		private const uint M = 0x5bd1e995;
		private const int R = 24;

		public static uint Hash(string data)
		{
			return Hash(System.Text.Encoding.UTF8.GetBytes(data));
		}

		public static uint Hash(Span<byte> data, uint seed = 0xc58f1a7a)
		{
			int length = data.Length;
			if (length == 0)
				return 0;
			uint h = seed ^ (uint) length;
			int currentIndex = 0;
			while (length >= 4)
			{
				uint k = (uint) (data[currentIndex++] | data[currentIndex++] << 8 | data[currentIndex++] << 16 |
				                 data[currentIndex++] << 24);
				k *= M;
				k ^= k >> R;
				k *= M;

				h *= M;
				h ^= k;
				length -= 4;
			}

			switch (length)
			{
				case 3:
					h ^= (ushort) (data[currentIndex++] | data[currentIndex++] << 8);
					h ^= (uint) (data[currentIndex] << 16);
					h *= M;
					break;
				case 2:
					h ^= (ushort) (data[currentIndex++] | data[currentIndex] << 8);
					h *= M;
					break;
				case 1:
					h ^= data[currentIndex];
					h *= M;
					break;
			}

			h ^= h >> 13;
			h *= M;
			h ^= h >> 15;

			return h;
		}
	}
}
