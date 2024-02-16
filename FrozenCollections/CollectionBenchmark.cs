using BenchmarkDotNet.Attributes;
using System.Collections.Frozen;
using System.Collections.Immutable;


[MemoryDiagnoser]
public class CollectionsBenchmark
{
    private HashSet<int> _hashSet;
    private ImmutableHashSet<int> _immutableHashSet;
    private FrozenSet<int> _frozenSet;
    private int _middle;

    [Params(1000)] // You can define different sizes to test different collection sizes
    public int Size { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _hashSet = new HashSet<int>(Enumerable.Range(0, Size));
        _immutableHashSet = ImmutableHashSet.CreateRange(Enumerable.Range(0, Size));
        _frozenSet = _hashSet.ToFrozenSet(); // Assuming the existence of ToFrozenSet extension method
        _middle = Size / 2; // Set the middle value for contains checks
    }

    [Benchmark]
    public HashSet<int> HashSet_Init()
    {
        return new HashSet<int>(Enumerable.Range(0, Size));
    }

    [Benchmark]
    public ImmutableHashSet<int> ImmutableHashSet_Init()
    {
        return ImmutableHashSet.CreateRange(Enumerable.Range(0, Size));
    }

    [Benchmark]
    public FrozenSet<int> FrozenSet_Init()
    {
        return _hashSet.ToFrozenSet(); // Assuming the existence of ToFrozenSet extension method
    }

    [Benchmark]
    public bool HashSet_Contains()
    {
        return _hashSet.Contains(_middle);
    }

    [Benchmark]
    public bool ImmutableHashSet_Contains()
    {
        return _immutableHashSet.Contains(_middle);
    }

    [Benchmark]
    public bool FrozenSet_Contains()
    {
        return _frozenSet.Contains(_middle);
    }
}
