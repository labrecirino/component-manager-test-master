using ReaderComponentService.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ReaderComponentService.Handlers
{
    /// <summary>
    /// Comment about the exercise: Use Factory pattern to instantiate the component handler.
    /// </summary
    public abstract class Reader
    {
        protected string ReadStream(string request)
        {
            using (var clientSocket = new TcpClient()) { 
                
                NetworkStream serverStream;
                string readerPort = ConfigurationUtil.GetSetting(request);


                clientSocket.Connect("localhost", Convert.ToInt32(readerPort));

                serverStream = clientSocket.GetStream();
                if (serverStream.CanWrite && serverStream.CanRead)
                {
                    byte[] outStream = System.Text.Encoding.ASCII.GetBytes(request);
                    serverStream.Write(outStream, 0, outStream.Length);
                    serverStream.Flush();

                    byte[] inStream = new byte[clientSocket.ReceiveBufferSize];
                    var numberOfBytesRead = serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
                    string returndata = System.Text.Encoding.ASCII.GetString(inStream, 0, numberOfBytesRead);
                    return returndata;
                }
            }
            return "";
        }
        public abstract IEnumerable<PersonalData> ReadData();

        public abstract Task<IEnumerable<PersonalData>> ReadDataAsync();
    }
}
