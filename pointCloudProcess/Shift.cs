using System;
using System.IO;
using NetTopologySuite.Geometries;
using NUnit.Framework;


namespace CoordinateShift { 
public class Shift
{
    public StreamReader file = new StreamReader(@"C:\Users\Danfeng\Desktop\Danfeng\Data\trim1Foto1PointCloud.txt");

    public StreamWriter fileWriter = new StreamWriter(@"C:\Users\Danfeng\Desktop\Danfeng\Data\Foto1ShiftedResult.txt");

    public void ShiftCoordinated()
    {
        string line;
  
        int Points = 588;

        string[] co = new string[9];
        double[] coors = new double[3];

        double[] X_coord = new double[Points];
        double[] Y_coord = new double[Points];
        double[] Z_coord = new double[Points];


            int X_value = 6;
            int Y_value = 7;
            int Z_value = 8;

            int start_line = 1;
            int start_coor = 0;

            double X_min;
            double Y_min;

            line = file.ReadToEnd();

            file.Close();

            string[] lines = line.Split(
            new[] { "\n" },
            StringSplitOptions.None);


            for (int i = start_line; i < lines.Length-1; i++)
            {
                co = lines[i].Split(',');

                coors[0] = Convert.ToDouble(co[X_value]);
                coors[1] = Convert.ToDouble(co[Y_value]);
                coors[2] = Convert.ToDouble(co[Z_value]);

                X_coord[start_coor] = coors[0];
                Y_coord[start_coor] = coors[1];
                Z_coord[start_coor] = coors[2];

                start_coor++;
            }

            //get X min and  Y min
            X_min = X_coord[0];
            Y_min = Y_coord[0];
            for(int i = 1;i < Points; i ++)
            {
                if (X_min > X_coord[i])
                    X_min = X_coord[i];

                if (Y_min > Y_coord[i])
                    Y_min = Y_coord[i];
            }
            Console.WriteLine(X_min + " " + Y_min);

            //shift points
            for(int i = 0;i < Points; i++)
            {
                X_coord[i] = Math.Round((X_coord[i] - X_min),3);
                Y_coord[i] = Math.Round((Y_coord[i] - Y_min),3);

                Console.WriteLine(X_coord[i] + " " + Y_coord[i]);

                fileWriter.WriteLine(X_coord[i] + "," + Y_coord[i] + "," + Z_coord[i]);
            }

            fileWriter.Close();

           Console.WriteLine("finish write file");
        }

}
}
