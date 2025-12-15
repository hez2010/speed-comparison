using System.Numerics;

var rounds = uint.Parse(File.ReadAllText("rounds.txt"));
var unroll = (uint)Vector<double>.Count;

var den   = Vector<double>.Zero;
var inc   = new Vector<double>(unroll);
var two   = new Vector<double>(2.0);
var mone  = new Vector<double>(-1.0);
var xvec  = new Vector<double>([-1.0, 1.0, -1.0, 1.0, -1.0, 1.0, -1.0, 1.0]);
var ivec  = new Vector<double>([2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0]);
var pivec = Vector<double>.Zero;

rounds += 2;
var vend = rounds - ((rounds - 2) % unroll);

for (var i = 2u; i < vend; i += unroll) {
    den   = (two * ivec) + mone;
    ivec  += inc;
    pivec += xvec / den;
}

var x  = 1.0D;
var pi = 1.0D + Vector.Sum(pivec);

for (var i = vend; i < rounds; ++i) {
    x = -x;
    pi += x / (2 * i - 1);
}

pi *= 4;
Console.WriteLine(pi);
