using System;
using System.Drawing;
using TheForbiddenBook.RandomCrypto;
using TheForbiddenBook.RandomOrg;

namespace TheForbiddenBook
{
    class TheForbiddenBook
    {
        string[] _charArray = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", ".", "," };
        
        public TheForbiddenBook()
        {
        }

        public string[] GeneratePage(int _pageLength)
        {
            //Random _rand = new Random((int)DateTime.Now.Ticks);
            RandomCryptographic _rand = new RandomCryptographic();
            //RandomNumGen _rand = new RandomNumGen();

            string[] _generatedPage = new string[_pageLength];

            for (int i = 0; i < _generatedPage.Length; i++)
            {
                _generatedPage[i] = _charArray[_rand.Next(0, _charArray.Length)];
            }

            return _generatedPage;
        }

        public Bitmap GenerateImage(int _x, int _y)
        {
            Bitmap _bm = new Bitmap(_x, _y);
            //Random _rand = new Random((int)DateTime.Now.Ticks);
            RandomCryptographic _rand = new RandomCryptographic();
            //RandomNumGen _rand = new RandomNumGen();
            //_rand.Populate(10000, 0, 254);

            for (int i = 0; i < _x; i++)
            {
                for (int j = 0; j < _y; j++)
                {
                    Color _c = Color.FromArgb(_rand.Next(0, 255), _rand.Next(0, 255), _rand.Next(0, 255));
                    _bm.SetPixel(i, j, _c);
                }
            }

            return _bm;
        }
    }
}
