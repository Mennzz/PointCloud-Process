using System;
using NetTopologySuite.Samples.Voronoi;
using NUnit.Framework;

namespace NetTopologySuite.Samples.Voronoi
{
    [TestFixture]
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new Program().Start();
        }

        private static DelaunayExample delaunay;

        public void Start()
        {
            SamplesTest(true);
        }

        [Test]
        public void SamplesTest()
        {
            SamplesTest(false);
        }

        public void SamplesTest(bool readLine)
        {
            try
            {
                delaunay = new DelaunayExample();
                delaunay.TestDelunayTrianle();
            }
            finally
            {
                if (readLine) Console.ReadLine();
            }
        }
    }
}
