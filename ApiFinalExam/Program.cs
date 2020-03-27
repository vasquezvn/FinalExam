using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiFinalExam
{
    public class Program
    {
        HttpClient client = new HttpClient();
        private Student studentJson = new Student();

        static async Task Main(string[] args)
        {
            Program p = new Program();
            await p.GetStudentById(1);

            //var expectedStudent = new Student()
            //{
            //    id = 1,
            //    firstName = "Vernon",
            //    lastName = "Harper",
            //    email = "egestas.rhoncus.Proin@massaQuisqueporttitor.org",
            //    programme = "Financial Analysis",
            //    courses = new string[] { "Accounting", "Statistics" }
            //};

            //var result = p.IsFirstStudentAsync(expectedStudent);


            Console.WriteLine();
        }

        public void GetStudents()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/student/list");

                var responseTask = client.GetAsync("student");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Student[]>();
                    readTask.Wait();

                    var students = readTask.Result;

                    foreach (var student in students)
                    {
                        Console.WriteLine($"Student Name: {student.firstName}");
                    }
                }
            }
        }

        private async Task GetStudentById(int studentId)
        {
            string jsonString = await client.GetStringAsync("http://localhost:8080/student/list");
            List<Student> json = JsonConvert.DeserializeObject<List<Student>>(jsonString);

            foreach (var student in json)
            {
                if (student.id == studentId)
                {
                    studentJson = student;
                    break;
                }
                Console.WriteLine($"Student: {student.firstName}");
            }
        }

        public async Task<bool> IsFirstStudentAsync(Student student)
        {
            var result = false;

            await GetStudentById(1);

            if (studentJson.id == student.id)
                result = true;

            return result;
        }
    }
}
