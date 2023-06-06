namespace DictionaryVsConcurrentDictionary
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using BenchmarkDotNet.Attributes;

    using Microsoft.CodeAnalysis.CSharp.Syntax;

    [MemoryDiagnoser]
    public class Benchmarks
    {
        private Random random;
        
        private Dictionary<int, Offer> dictionary;

        private ConcurrentDictionary<int, Offer> concurrentDictionary;

        [Params(10, 100, 1000)]
        public int ItemsCount;

        [GlobalSetup]
        public void Setup()
        {
            var items = new Dictionary<int, Offer>();
            for (var i = 0; i < this.ItemsCount; i++)
            {
                items.Add(i, new Offer($"Item {i}", "Body {i}", $"Comments {i}"));
            }

            this.dictionary = new Dictionary<int, Offer>(items);
            this.concurrentDictionary = new ConcurrentDictionary<int, Offer>(items);
            this.random = new Random(69);
        }

        [Benchmark]
        public Offer FromDictionary() => this.dictionary[this.random.Next(this.ItemsCount)];

        [Benchmark]
        public Offer FromConcurrentDictionary() => this.concurrentDictionary[this.random.Next(this.ItemsCount)];
    }
}