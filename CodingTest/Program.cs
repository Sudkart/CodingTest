// See https://aka.ms/new-console-template for more information
using System.Text.Json;

// Path to your JSON file
string filePath = "C:\\F\\Work\\Coding_Test\\CodingTest\\CodingTest\\coding-assigment-orders.json";

// Read the JSON file
string jsonData = File.ReadAllText(filePath);

// Parse JSON to Dictionary
var orders = JsonSerializer.Deserialize<Dictionary<string, AssignmentOrders>>(jsonData);
// Convert dictionary to list of KeyValuePairs
var orderList = new List<KeyValuePair<string, AssignmentOrders>>(orders);

Console.WriteLine("==============User Story 1=============");

UserStory1(orderList);

Console.WriteLine("==============User Story 2=============");
UserStory2(orderList);

void UserStory1(List<KeyValuePair<string, AssignmentOrders>> orders)
{
    int day = 1;
    int dayCounter = 0;
    int flightCounter = 0;
    int flight = 1;
    for (int i = 0; i < orderList.Count; i++)
    {

        Console.WriteLine("Flight: " + (flight) + ", departure: YUL, arrival: " + orderList[i].Value.destination + ", day: " + day);
        if (flightCounter == 20)
        {
            ++flight;
            flightCounter = 0;
        }
        flightCounter++;
        // Increment the flight counter
        dayCounter++;

        // Reset the counter and increment the day after 3 flights
        if (dayCounter == 60)
        {
            day++;
            dayCounter = 0; // Reset the counter after 3 flights
        }
    }

}

void UserStory2(List<KeyValuePair<string, AssignmentOrders>> orders)
{
    //order: order - 001, flightNumber: 1, departure: < departure_city >, arrival: < arrival_city >, day: x
    int flightNumber = 1;
    int flightCapacity = 20; // Each flight has a capacity of 20 boxes (orders)
    int currentCapacity = 0;
    int day = 1;
    int dayCounter = 0;
    for (int i = 0; i < orderList.Count; i++)
    {

        if (currentCapacity < flightCapacity)
        {
            // Schedule the flight
            Console.WriteLine("order: " + orderList[i].Key + " flightNumber: " + (flightNumber) + ", departure: YUL, arrival: " + orderList[i].Value.destination + ", day: " + day);
            currentCapacity++;
        }
        else
        {
            // Start a new flight when capacity is reached
            flightNumber++;
            currentCapacity = 1;
            Console.WriteLine("order: " + orderList[i].Key + " flightNumber: " + (flightNumber) + ", departure: YUL, arrival: " + orderList[i].Value.destination + ", day: " + day);

        }

        ++dayCounter;
        if (dayCounter == 60)
        {
            day++;
            dayCounter = 0;//reset the day counter after 60 packages because each day 3 flights each carrying 20 packages
        }
    }
   

}