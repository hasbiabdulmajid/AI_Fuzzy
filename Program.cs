using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Globalization;
using System.Linq;

namespace tugasAI2
{
	class MainClass
	{
		//fuzzyfikasi
		static double gajiRendah(double x) {
			double batas1 = 0;
			double batas2 = 0.8;
			double batas3 = 1.4;

			if (x >= 0 & x <= 0.8)
				return 1;
			else if (x >= 0.8 & x <= 1.4)
				return (batas3 - x) / (batas3 - batas2);
			else
				return 0;
		}

		static double gajiSedang(double x)
		{
			double batas1 = 0.8;
			double batas2 = 1.4;
			double batas3 = 1.6;

			if (x >= 0.8 & x <= 1.4)
				return (x - batas1) / (batas2 - batas1);
			else if (x >= 1.4 & x <= 1.6)
				return (batas3 - x) / (batas3 - batas2);
			else
				return 0;
		}

		static double gajiTinggi(double x)
		{
			double batas1 = 1.4;
			double batas2 = 1.6;
			double batas3 = 1.8;

			if (x >= 1.4 & x <= 1.6)
				return (x - batas1) / (batas2 - batas1);
			else if (x >= 1.6 & x <= 1.8)
				return 1;
			else
				return 0;
		}

		static double hutangRendah(double x)
		{
			double batas1 = 0;
			double batas2 = 20;
			double batas3 = 40;

			if (x >= 0 & x <= 20)
				return 1;
			else if (x >= 20 & x <= 40)
				return (batas3 - x) / (batas3 - batas2);
			else
				return 0;
		}

		static double hutangSedang(double x)
		{
			double batas1 = 20;
			double batas2 = 40;
			double batas3 = 60;

			if (x >= 20 & x <= 40)
				return (x - batas1) / (batas2 - batas1);
			else if (x >= 40 & x <= 60)
				return (batas3 - x) / (batas3 - batas2);
			else
				return 0;
		}

		static double hutangTinggi(double x)
		{
			double batas1 = 40;
			double batas2 = 60;
			double batas3 = 80;

			if (x >= 40 & x <= 60)
				return (x - batas1) / (batas2 - batas1);
			else if (x >= 60 & x <= 80)
				return 1;
			else
				return 0;	
		}


		//fungsi desufikasi
		static double sugeno(double x, double y) {
			return ((x*20)+(y*60)) / (x+y);
		}




		public static void Main(string[] args)
		{


			using (var reader = new StreamReader(@"C:\Users\SyekhTampan\Desktop\Tugas2AI\DataTugas2.csv"))
			{
				List <string> listA = new List<string>();
				List<string> listB = new List<string>();
				List<string> listC = new List<string>();

				List<double> LA = new List<double>();
				List<double> LB = new List<double>();
				List<double> LC = new List<double>();



				while (!reader.EndOfStream)
        		{
            		var line = reader.ReadLine();
					var values = line.Split(',');

					listA.Add(values[0]);
            		listB.Add(values[1]);
					listC.Add(values[2]);
        		}

				//convert string to float
				for (int i = 0; i < listA.Count; i++) {
					string stringVal = listA[i];
					if (stringVal.Contains("."))
						stringVal = stringVal.Replace(".", ",");

					double x = System.Convert.ToDouble(stringVal);
					LA.Add(x);

				
				}

				for (int i = 0; i<listB.Count; i++) {
					string stringVal = listB[i];
					if (stringVal.Contains("."))
						stringVal = stringVal.Replace(".", ",");

					double x = System.Convert.ToDouble(stringVal);
					LB.Add(x);
									
				}




				for (int i = 0; i<listC.Count; i++) {
					string stringVal = listC[i];
					if (stringVal.Contains("."))
						stringVal = stringVal.Replace(".", ",");

					double x = System.Convert.ToDouble(stringVal);
					LC.Add(x);
				
				}

			List<double> LX = new List<double>();
			List<double> LY = new List<double>();
			List<double> hasil = new List<double>();

				for (int i = 0; i < listA.Count; i++) {
					if ((LB[i]>=0 & LB[i] <= 1.4) & (LC[i] >= 0 & LC[i] <= 40))
						LX.Add(Math.Min(gajiRendah(LB[i]),hutangRendah(LC[i])));
					if ((LB[i]>=1.3 & LB[i] <= 1.4) & (LC[i] >= 0 & LC[i] <= 40))
						LX.Add(Math.Min(gajiSedang(LB[i]),hutangRendah(LC[i])));
					if ((LB[i]>=1.4 & LB[i] <= 1.8) & (LC[i] >= 0 & LC[i] <= 40))
						LX.Add(Math.Min(gajiTinggi(LB[i]),hutangRendah(LC[i])));


					if ((LB[i]>=0 &LB[i] <= 1.4) & (LC[i]>=20 & LC[i] <= 60))
						LX.Add(Math.Min(gajiRendah(LB[i]),hutangSedang(LC[i])));
					if ((LB[i]>=1.3 & LB[i] <= 1.4) & (LC[i]>=20 & LC[i] <= 60))
						LX.Add(Math.Min(gajiSedang(LB[i]),hutangSedang(LC[i])));
					if ((LB[i]>=1.4 & LB[i] <= 1.8) & (LC[i]>=20 & LC[i] <= 60))
						LX.Add(Math.Min(gajiTinggi(LB[i]),hutangSedang(LC[i])));

					if ((LB[i]>=0 & LB[i] <= 1.4) & (LC[i]>=40 & LC[i] <= 80))
						LY.Add(Math.Min(gajiRendah(LB[i]),hutangTinggi(LC[i])));
					if ((LB[i]>=1.3 & LB[i] <= 1.4) & (LC[i]>=40 & LC[i] <= 80))
						LY.Add(Math.Min(gajiSedang(LB[i]),hutangTinggi(LC[i])));
					if ((LB[i] >= 1.4 & LB[i] <= 1.8) & (LC[i] >= 40 & LC[i] <= 80))
						LX.Add(Math.Min(gajiTinggi(LB[i]), hutangTinggi(LC[i])));




					double A = LX.Max();
					double B = LY.DefaultIfEmpty().Max();
					double C = sugeno(A, B);

					//Console.WriteLine(B);

					hasil.Add(C);


						
			} //for
			  //var sortHasil = hasil.OrderBy(order => order);
				hasil.Sort();
				hasil.Reverse();
			  	hasil.ForEach(Console.WriteLine);

				using (var file = File.CreateText(@"C:\Users\SyekhTampan\Desktop\Tugas2AI\HasilDataTugas2test.csv"))
				    {
				        foreach(var arr in hasil) {
							int count = 0;

							if (count <= 19) { 
							    file.WriteLine(string.Join(",", arr));
							}
							count++;
				        }
				    }
				    
				Console.ReadKey();


			} //USING




			
		}
	}
}
