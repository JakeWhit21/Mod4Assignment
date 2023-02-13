﻿using NLog;
string path = Directory.GetCurrentDirectory() + "\\nlog.config";
// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
// See https://aka.ms/new-console-template for more information

string file = "movies.csv";

bool duplicate = false;

// ask for input
Console.WriteLine("Enter 1 to create movie entry.");
Console.WriteLine("Enter 2 to parse data.");
Console.WriteLine("Enter anything else to quit.");
// input response
string? resp = Console.ReadLine();

if (resp == "1") {
    if (File.Exists(file))
    {

    Console.WriteLine("Enter movie ID: ");
    
        string movieIdInput = Console.ReadLine();

        StreamReader sr = new StreamReader(file);
        while (!sr.EndOfStream) {
            string line = sr.ReadLine();
            string[] movieValues = line.Split(',');

            if (movieIdInput == movieValues[0]) {
                logger.Error("This is a duplicate id");
                duplicate = true;
            }

        }

        if (!duplicate) {
            Console.WriteLine("this works");
        }

    

    }

} else if (resp == "2") {

    if (File.Exists(file)) {
        // read data from file
        StreamReader sr = new StreamReader(file);
        while (!sr.EndOfStream) {
            string line = sr.ReadLine();
            string[] movieValues = line.Split(',');
            //grab movieid
            Console.WriteLine(movieValues[0] + " " + movieValues[1] + " " + movieValues[2]);
        }
        sr.Close();
    }


}