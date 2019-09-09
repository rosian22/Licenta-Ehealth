//using DataLayer.EHealth.Repositories;
//using EHealth.BusinessLogic.Workflow;
//using System.IO;
//using Newtonsoft.Json;
//using System.Net;
//using DataLayer.EHealth;
//using System.Collections.Generic;

//namespace FoodPrepAPI
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {

//            string foodItem = string.Empty;

//            string url1 = $"https://wger.de/api/v2/exercise/";
//            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(url1);
//            request1.AutomaticDecompression = DecompressionMethods.GZip;

//            string url2 = $"https://wger.de/api/v2/exerciseimage/";
//            HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(url2);
//            request2.AutomaticDecompression = DecompressionMethods.GZip;

//            string url3 = $"https://wger.de/api/v2/exerciseinfo/";
//            HttpWebRequest request3 = (HttpWebRequest)WebRequest.Create(url3);
//            request3.AutomaticDecompression = DecompressionMethods.GZip;

//            string url4 = $"https://wger.de/api/v2/exercisecategory/";
//            HttpWebRequest request4 = (HttpWebRequest)WebRequest.Create(url4);
//            request4.AutomaticDecompression = DecompressionMethods.GZip;

//            HttpWebResponse response1 = (HttpWebResponse)request1.GetResponse();
//            HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
//            HttpWebResponse response3 = (HttpWebResponse)request3.GetResponse();
//            HttpWebResponse response4 = (HttpWebResponse)request4.GetResponse();

//            Stream stream1 = response1.GetResponseStream();
//            Stream stream2 = response2.GetResponseStream();
//            Stream stream3 = response3.GetResponseStream();
//            Stream stream4 = response4.GetResponseStream();

//            StreamReader reader1 = new StreamReader(stream1);
//            StreamReader reader2 = new StreamReader(stream2);
//            StreamReader reader3 = new StreamReader(stream3);
//            StreamReader reader4 = new StreamReader(stream4);

//            var repo = RepoUnitOfWork.New();
//            var foodRepo = repo.TrackingRepository<FoodRepository>();

//            var rawExercises = reader1.ReadToEnd();
//            var rawExercisesImage = reader2.ReadToEnd();
//            var rawExercisesInfo = reader3.ReadToEnd();
//            var rawExercisesCategory = reader4.ReadToEnd();

//            var exercises = JsonConvert.DeserializeObject(rawExercises);
//            var exercisesImage = JsonConvert.DeserializeObject(rawExercisesImage);
//            var exercisesInfo = JsonConvert.DeserializeObject(rawExercisesInfo);
//            var exercisesCategory = JsonConvert.DeserializeObject(rawExercisesCategory);

//            var results1 = exercises.GetType().GetProperty("results");
//            var results2 = exercises.GetType().GetProperty("results");


//            foreach (var item in results1.GetValue(exercises, null) as List<object>)
//            {
//                var p1 = item.GetType().GetProperty("description");
//                var p2 = item.GetType().GetProperty("id");




//                var newExercises = new Exercise
//                {
//                    Description = p1.GetValue(item, null) as string,
                    
//                }
//            }


//        }
//    }
//}