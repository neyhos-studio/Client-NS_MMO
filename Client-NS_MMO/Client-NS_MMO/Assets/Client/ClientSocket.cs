using Application.Client.Constants;
using Application.Client.Entities.Client;
using Application.Client.Entities.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ClientSocket : MonoBehaviour
{
    #region GUI 	
    private Text email;
    private Text password;
    #endregion

    #region private members 	
    private TcpClient socketConnection;
    private Thread clientReceiveThread;
    private Client me;
    #endregion

    // Use this for initialization 	
    void Start()
    {
        email = GameObject.Find("ThisIsTheUserEmail").GetComponent<Text>();
        password = GameObject.Find("ThisIsTheUserPassword").GetComponent<Text>();

        ConnectToTcpServer();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ClientMessage jump = new ClientMessage("", "INPUT", new string[] { "MOVE", "JUMP" });
            sendMessage(jump);
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            ClientMessage disconnect = new ClientMessage("", "DISCONNECTION", new string[] { me.getToken() });
            sendMessage(disconnect);
        }
    }

    public void connect()
    {
        ClientMessage connect = new ClientMessage("0", "CONNECTION", new string[] { email.text, password.text });
        sendMessage(connect);
    }

    /// <summary> 	
    /// Setup socket connection. 	
    /// </summary> 	
    private void ConnectToTcpServer()
    {
        try
        {
            clientReceiveThread = new Thread(new ThreadStart(ListenForData));
            clientReceiveThread.IsBackground = true;
            clientReceiveThread.Start();
        }
        catch (Exception e)
        {
            Debug.Log("On client connect exception " + e);
        }
    }

    /// <summary> 	
    /// Runs in background clientReceiveThread; Listens for incomming data. 	
    /// </summary>     
    private void ListenForData()
    {
        try
        {
            socketConnection = new TcpClient("127.0.0.1", 5757); //51.91.156.75
            Byte[] bytes = new Byte[1024];
            while (true)
            {
                // Get a stream object for reading 				
                using (NetworkStream stream = socketConnection.GetStream())
                {
                    int length;
                    // Read incomming stream into byte arrary. 					
                    while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        var incommingData = new byte[length];
                        Array.Copy(bytes, 0, incommingData, 0, length);

                        // Convert byte array to string message. 						
                        string serverMessage = Encoding.ASCII.GetString(incommingData);
                        Debug.Log("server message received as: " + serverMessage);


                        // Client message filter and process
                        RequestManager(serverMessage);
                    }
                }
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }

    private void RequestManager(string clientMessage)
    {
        // Put the client string message into an object ClientMessage
        ServerMessage msg = new ServerMessage(clientMessage);

        // Client message is process depending on the ACTION send;
        switch (msg.action)
        {
            case ConstsActions.DISCONNECTION:
                this.me.statusUser = msg.data[0];
                Console.WriteLine("You are now Offline.");
                break;
            case ConstsActions.CONNECTION:
                if (msg.data[0] == "SUCCESS")
                {
                    this.me = new Client(
                        int.Parse(msg.data[1]),
                        int.Parse(msg.data[2]),
                        msg.data[3],
                        msg.data[4],
                        msg.data[5],
                        Convert.ToDateTime(msg.data[6]),
                        msg.data[7],
                        msg.data[8]
                        );
                    Console.WriteLine("You are connected as " + this.me.getToken() +".");
                }
                else if (msg.data[0] == "FAIL")
                {
                    Console.WriteLine("Connection failed");
                }
                break;
            default:
                break;
        }
    }

    /// <summary> 	
    /// Send message to server using socket connection. 	
    /// </summary> 	
    private void sendMessage(ClientMessage serverMessage)
    {
        if (socketConnection == null)
        {
            return;
        }
        try
        {
            // Get a stream object for writing. 			
            NetworkStream stream = socketConnection.GetStream();
            if (stream.CanWrite)
            {
                // Convert string message to byte array.                 
                byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(serverMessage.getMessage());
                // Write byte array to socketConnection stream.                 
                stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
                Debug.Log("Client sent his message - should be received by server");
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }

}
