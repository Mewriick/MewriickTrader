using System;
using System.Collections;
using System.Collections.Generic;

namespace MewriickTrader.Core.Candle
{
    public class CandleCollection : ICandlesCollection
    {
        private List<ICandle> candles;

        public int Count => candles.Count;

        public bool IsReadOnly => false;

        public decimal CurrentLow => throw new NotImplementedException();

        public decimal CurrentHigh => throw new NotImplementedException();

        public ICandle this[int index] { get => candles[index]; set => candles[index] = value; }

        public CandleCollection(IEnumerable<ICandle> candles)
        {
            this.candles = new List<ICandle>(candles);
        }

        public CandleCollection()
        {
            this.candles = new List<ICandle>();
        }

        public void Add(ICandle item)
        {
            candles.Add(item);
        }

        public void Clear()
        {
            candles.Clear();
        }

        public bool Contains(ICandle item)
        {
            return candles.Contains(item);
        }

        public void CopyTo(ICandle[] array, int arrayIndex)
        {
            candles.CopyTo(array, arrayIndex);
        }

        public bool Remove(ICandle item)
        {
            return candles.Remove(item);
        }

        public IEnumerator<ICandle> GetEnumerator()
        {
            return candles.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return candles.GetEnumerator();
        }

        public int IndexOf(ICandle item)
        {
            return candles.IndexOf(item);
        }

        public void Insert(int index, ICandle item)
        {
            candles.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            candles.RemoveAt(index);
        }

        public (int candleIndex, decimal value) HigherHigh(int startIndex, int endIndex)
        {
            throw new NotImplementedException();
        }

        public (int candleIndex, decimal value) HigherLow(int startIndex, int endIndex)
        {
            throw new NotImplementedException();
        }

        public (int candleIndex, decimal value) LowerHigh(int startIndex, int endIndex)
        {
            throw new NotImplementedException();
        }

        public (int candleIndex, decimal value) LowerLow(int startIndex, int endIndex)
        {
            throw new NotImplementedException();
        }
    }
}
