using System;
using NUnit.Framework;
using NetTopologySuite.Geometries;

namespace CoordinateShift
{
    [TestFixture]
    public class Program
    {

        private static Shift shiftCoor;
        private static ProfileData profile;

        [STAThread]
        public static void Main(string[] args)
        {
            new Program().Start();
        }

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
                profile = new ProfileData();
                profile.GetYvalue();
                //shiftCoor = new Shift();
               // shiftCoor.ShiftCoordinated();
            }
            finally
            {
                if (readLine) Console.ReadLine();
            }
        }
    }
}
