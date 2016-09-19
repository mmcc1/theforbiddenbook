using System;
using org.random.JSONRPC;

namespace TheForbiddenBook.RandomOrg
{
    //cb7083d3-6de1-417d-92b8-908028c686b4
    class RandomNumGen
    {
        RandomJSONRPC _rjrpc;
        int[] _numberStore;
        int _lastIndex;

        public RandomNumGen()
        {
            _rjrpc = new RandomJSONRPC("");
        }

        public void Populate(int _num, int _min, int _max)
        {
            _numberStore = _rjrpc.GenerateIntegers(_num, _min, _max);
        }

        public int Next(int _min, int _max)
        {
            /*
            for (int i = _lastIndex; i < _numberStore.Length; i++)
            {
                if (_numberStore[i] >= _min && _numberStore[i] < _max)
                {
                    _lastIndex = i + 1;
                    return _numberStore[i];
                }
            }
             */
            if (_lastIndex < _numberStore.Length)
                _lastIndex = _numberStore.Length - 2;

            return _numberStore[_lastIndex++];
        }
    }
}
