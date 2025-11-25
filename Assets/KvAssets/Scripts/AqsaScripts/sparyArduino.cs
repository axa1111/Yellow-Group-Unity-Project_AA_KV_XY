using UnityEngine;
using System.IO.Ports;

public class sparyArduino : MonoBehaviour
{
     SerialPort serial = new SerialPort("COM4", 9600); /*passing 2 parimeters the port and the baud 
    which in out case is going to be 9600//find which port the board is connected to for the port parametre*/
    
    void Start()
    {
        serial.Open(); //enabling the serial
        serial.ReadTimeout = 100; //time serial waits to read the command
    }

    
    void OnApplicationQuit()
        {
            serial.Close(); //to close the serial at the end of the game
        }
    //add this to the onclick method of the button    
    public void SprayTheScent()
    {
        serial.Write("1"); //we are sending the 1 command the arduino board
    }
}
