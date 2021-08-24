using System;
using System.Collections.Generic;
using System.Linq;

namespace TugasKelompok
{
    class Program
    {
        public static List<User> users = new List<User>();
        public static int input = 0;
        public static User user = new User();
        public static string idUsername, idPassword;

        static void Main(string[] args)
        {

            /* do
             {*/
            Menu();

            //} while (input != 5);

        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("==BASIC AUTHENTICATION==");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Show User");
            Console.WriteLine("3. Delete User");
            Console.WriteLine("4. Update User");
            Console.WriteLine("5. Search");
            Console.WriteLine("6. Login");
            Console.WriteLine("7. Forgot Password");
            Console.WriteLine("8. Exit");
            try
            {
                Console.Write("Input Menu : ");
                input = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        Create();
                        break;
                    case 2:
                        Console.Clear();
                        Show();
                        break;
                    case 3:
                        DeleteUser();
                        break;
                    case 4:
                        UpdateUser();
                        break;
                    case 6:
                        Login();
                        break;
                    case 8:
                        Console.WriteLine("Terima Kasih Telah Menggunakan Aplikasi Kami");
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Error: Input not Valid");
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
            BackToMenu();
        }

        static void Create()
        {
            Console.WriteLine("==Create User==");
            Console.Write("First Name : ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name : ");
            string lastName = Console.ReadLine();
            Console.Write("Password : ");
            string password = Console.ReadLine();

            string userName = string.Concat(firstName.Substring(0, 2), lastName.Substring(0, 2)).ToLower();

            string usernameCompare = Compare(userName);

            users.Add(new User { firstName = firstName, lastName = lastName, password = password, username = usernameCompare });
            BackToMenu();
        }

        static void Show()
        {
            Console.Clear();
            Console.WriteLine("==SHOW USER==");

            for (int k = 0; k < users.Count; k++)
            {
                Console.WriteLine("======================");
                Console.WriteLine($"NAME : {users[k].firstName} {users[k].lastName}");
                Console.WriteLine($"USERNAME : {users[k].username}");
                Console.WriteLine($"PASSWORD : {PasswordEnc(users[k].password)}");
                Console.WriteLine("======================");
            }
            BackToMenu();

        }

        public static void BackToMenu()
        {
            Console.ReadKey(true);
            Menu();
        }

        public static string PasswordEnc(string password)
        {

            // password = new string('*', password.Length);
            return  new string('*', password.Length);
        }

        public static string Compare(string username)
        {
            bool compareUsername;
            //Compare username;
            compareUsername = users.Exists(user => user.username == username);

            //Generate random number
            Random random = new Random();

            int randomNumber = random.Next(0, 100);
            if (compareUsername)
            {
                return string.Concat(username, randomNumber);
            }

            return username;
        }

        public static void Login()
        {
            Console.Clear();
            bool comparelogin,comparepassword;
            Console.WriteLine("==LOGIN==");
            Console.Write("USERNAME : ");
            idUsername = Console.ReadLine();
            Console.Write("PASSWORD : ");
            idPassword = Console.ReadLine();
            comparelogin = users.Exists(user => user.username == idUsername);
            comparepassword = users.Exists(user => user.password == idPassword);
            if(comparelogin)
            {
                if(comparepassword)
                {
                    Console.WriteLine("Login Successfuly");
                }
                else
                {
                    Console.WriteLine("Password not Match");
                }
            }
            else
            {
                Console.WriteLine("Login Failed");
            }
            BackToMenu();
        }

        public static void DeleteUser()
        {

            for (int k = 0; k < users.Count; k++)
            {
                Console.WriteLine("======================");
                Console.WriteLine($"NAME : {users[k].firstName} {users[k].lastName}");
                Console.WriteLine($"USERNAME : {Compare(users[k].username)}");
                Console.WriteLine($"PASSWORD : {PasswordEnc(users[k].password)}");
                Console.WriteLine("======================");
            }

            Console.WriteLine("Masukan index User yang akan dihapus");
            int index = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Apakah anda yakin?");
            Console.WriteLine("Pilih ya|tidak");

            string deleteOption = Console.ReadLine();

            if(deleteOption.Equals("YA")|| deleteOption.Equals("ya"))
            {
                users.RemoveAt(index -  1);

                Console.WriteLine("User Terhapus");
            } else
            {
                BackToMenu();
            }
            BackToMenu();
        }

        public static void UpdateUser()
        {
            string keywords;
            bool comparename;
            Console.Write("Masukkan username : ");
            keywords = Console.ReadLine();
            comparename = users.Exists(user => user.username == keywords);
            if (comparename)
            {
                Console.WriteLine("==UPDATE PASSWORD==");
                Console.Write("Silakan masukkan password baru : ");
                var pwd = users.FirstOrDefault(name => user.username == keywords);
                users.
                
            }
        } 
    }
}
