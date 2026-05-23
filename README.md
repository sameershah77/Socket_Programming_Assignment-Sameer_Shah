Socket Programming Assignment - Sameer Shah

Overview

This project is a TCP Client-Server Socket Programming Assignment implemented using C# and .NET 8.

The application demonstrates:

- TCP socket communication
- Multi-client handling
- AES Encryption & Decryption
- Async programming using async/await
- Clean project architecture

---

Features

- TCP Client-Server Communication
- AES Encryption & Decryption
- Multi-Client Support
- Async/Await Implementation
- Clean Folder Structure
- Exception Handling
- Configurable Inputs
- Console-Based Application

---

Technologies Used

- C#
- .NET 8
- TCP Sockets
- AES Encryption
- Async Programming


---

Assignment Flow

1. Client sends encrypted message to server.
2. Server decrypts the message.
3. Server validates the received input from predefined collection.
4. Server sends current timestamp response based on retrieved value.
5. Responses are encrypted before sending back to client.
6. Client decrypts and displays server responses.

---

Sample Data Collection

{
  "SetA": { "One": 1, "Two": 2 },
  "SetB": { "Three": 3, "Four": 4 },
  "SetC": { "Five": 5, "Six": 6 },
  "SetD": { "Seven": 7, "Eight": 8 },
  "SetE": { "Nine": 9, "Ten": 10 }
}

---

Example Input

SetA-Two

---

Example Output

23-05-2026 14:27:48
23-05-2026 14:27:49

---

Invalid Input Example

SetX-One

Output:

EMPTY

---

Running the Server

cd SocketServer

dotnet run

---

Running the Client

cd SocketClient

dotnet run

---

Multi-Client Testing

The server supports multiple simultaneous client connections using asynchronous task handling.

To test:

1. Run the server once
2. Open multiple terminals
3. Run multiple clients simultaneously

---

Encryption

AES symmetric encryption is implemented for secure communication between client and server.

---

Key Concepts Demonstrated

- Socket Programming
- TCP Communication
- Async/Await
- Concurrent Client Handling
- Encryption/Decryption
- Clean Architecture
- Exception Handling

---

Author

Sameer Shah

GitHub:
https://github.com/sameershah77

LinkedIn:
https://www.linkedin.com/in/sameershah9167g