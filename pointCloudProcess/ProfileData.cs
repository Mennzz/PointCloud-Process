using System;
using System.IO;
using NetTopologySuite.Geometries;
using System.Collections.Generic;
using System.Text;

namespace CoordinateShift
{
    class ProfileData
    {
        public StreamReader file = new StreamReader(@"C:\Users\Danfeng\Desktop\Danfeng\Data\Foto1ShiftedResult.txt");

        public void GetYvalue()
        {
            int PointsNum = 588;
            int count = 0;
            string line;
            string[] co = new string[3];
            double[] coords = new double[3];

            var PointCoords = new Point[PointsNum];

            //read points into PointCoords

            while ((line = file.ReadLine()) != null)
            {
                co = line.Split(',');
                for (int i = 0; i < 3; i++)
                {
                    coords[i] = Convert.ToDouble(co[i]);
                }
                PointCoords[count] = new Point(coords[0], coords[1], coords[2]);
                count++;
            }
            Console.WriteLine("finish reading");
            file.Close();

            for(int i = 0 ; i<PointsNum ; i++ )
            {
                Console.Write(PointCoords[i].Coordinate + " " + PointCoords[i].X);
            }

        }
    }
}
