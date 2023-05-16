using System;
using System.Linq;

namespace ProbabilityTask
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter Number Items :");
            int ItemsNumber = int.Parse(Console.ReadLine());


            Console.WriteLine("Please Enter Your Items :");
            double[] Items = new double[ItemsNumber];
            for (int i = 0; i < Items.Length; i++)
            {

                Items[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(Items);
            //ترتيب تصاعدي


            Console.WriteLine("-----------------------------");

            double median;
            if (ItemsNumber % 2 != 0)
            {

                median = Items[ItemsNumber / 2];

                Console.WriteLine("The Median of the items is : " + median);
            }
            else
            {
                median = (Items[(ItemsNumber / 2 - 1)] + Items[(ItemsNumber / 2)]) / 2;
                Console.WriteLine("The Median of the items is : " + median);
            }
            Console.WriteLine("-----------------------------");


            double range = Items.Last() - Items.First();
            Console.WriteLine("The Range of the items is : " + range);

            Console.WriteLine("-----------------------------");

            int FirstQuartileIndex = (int)Math.Floor((double)ItemsNumber / 4);

            double FirstQuartile;
            if (ItemsNumber % 4 == 0)
            {
                FirstQuartile = (Items[FirstQuartileIndex - 1] + Items[FirstQuartileIndex]) / 2;
                Console.WriteLine("The first quartile is : " + FirstQuartile);
                //طرحنا من واحد علشان بيبدا من ضفر واحنا عايزينه يعد من اول واحد index 
                //لو باقي القسمه = 0 يبقي الرقم + الرقم الي بعده ونقسمهم علي 2
            }
            else
            {
                FirstQuartile = Items[FirstQuartileIndex];
                Console.WriteLine("The first quartile is : " + FirstQuartile);
                // لو باقي القسمه برقم بنقؤب لاقل رقم وناخده بس كده 
            }


            Console.WriteLine("-----------------------------");

            int ThirdQuartileIndex = (int)Math.Ceiling((double)ItemsNumber * 3 / 4);
            double ThirdQuartile;
            if (ItemsNumber % 4 == 0)
            {
                ThirdQuartile = (Items[ThirdQuartileIndex - 1] + Items[ThirdQuartileIndex]) / 2;
                Console.WriteLine("The third quartile is : " + ThirdQuartile);
                //طرحنا من واحد علشان بيبدا من ضفر واحنا عايزينه يعد من اول واحد index 
                //لو باقي القسمه = 0 يبقي الرقم + الرقم الي بعده ونقسمهم علي 2
            }
            else
            {
                ThirdQuartile = Items[ThirdQuartileIndex];
                Console.WriteLine("The third quartile is : " + ThirdQuartile);
                // لو باقي القسمه برقم بنقؤب لاقل رقم وناخده بس كده

            }

            Console.WriteLine("-----------------------------");



            double interquartile = ThirdQuartile - FirstQuartile;
            Console.WriteLine("The interquartile is : " + interquartile);
            double lowerBound = FirstQuartile - (1.5 * interquartile);


            Console.WriteLine("-----------------------------");

            double upperBound = ThirdQuartile + (1.5 * interquartile);
            Console.WriteLine("Outlier Region Boundaries  is : " + lowerBound + upperBound);


            Console.WriteLine("-----------------------------");

            int counter = 0;
            int max = 0;
            //اكبر عدد تكرار حصلت عليه في counter كام
            double mode = 0;
            double[] U = new double[Items.Length];
            Array.Copy(Items, U, Items.Length);
            for (int i = 0; i < Items.Length; i++)
            {
                counter = 0;
                //كل مره يلف علي عنصر جديد من الاراي الكبير الكونتر لازم يبقي صفر علشان نشوف العنصر الي من الاراي الكبير اتكرر كم مره في الاراي الصغير 
                for (int p = 0; p < Items.Length; p++)
                {
                    if (Items[i] == U[p])//عنصر الاراي الكبير هيتلف علي الاراي الصغير واشوف كام مره اتكرر لو لقيته في الاراي التاني
                    {
                        counter++;//زود ليا الكونتر لو لقيت العنصر 
                    }
                    if (counter >= 2)//لو عدد مرات التكرار دى اكبر من اتنين هبدا اعمل عمليات لو مش اكبر من 2 يبقي مفيش مود
                    {
                        if (counter > max)//لو الكونتر اكبر من ماكس الي انا حطاه بصفر لو الكونتر اتكرر اكتر من الصفر مره 
                        {
                            max = counter;//حطه في الماكس 
                            mode = Items[i];//حط لي القيمه الي اتكررت في المود 
                        }

                    }
                }
            }
            if (max >= 2)
            {
                Console.WriteLine("Mode of the items is :" + mode);
            }
            else
            {
                Console.WriteLine("There is no mode .");
            }

            Console.WriteLine("-----------------------------");


            double P90 =
            ItemsNumber % .9;
            Console.WriteLine("P90 of the items is : " + P90);


        }


    }
}



