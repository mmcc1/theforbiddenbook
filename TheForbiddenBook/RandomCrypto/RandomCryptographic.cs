using System;
using System.Security.Cryptography;

namespace TheForbiddenBook.RandomCrypto
{
    class RandomCryptographic
    {
        RNGCryptoServiceProvider _rng;

        public RandomCryptographic()
        {
            _rng = new RNGCryptoServiceProvider();
            
        }

        public int Next(int _min, int _max)
        {
            byte[] _rBytes = new byte[4];
            _rng.GetBytes(_rBytes);
            double _result = (double)_min;

            int _range = (_max - 1) - _min;

            double _step = (double)_range / (double)255.0;

            //Average the bytes
            int _avg = ((int)_rBytes[0] + (int)_rBytes[1] + (int)_rBytes[2] + (int)_rBytes[3]) / 4;

            for (int i = 0; i < _avg; i++)
            {
                _result += _step;
            }

            return (int)_result;
        }
    }
}
