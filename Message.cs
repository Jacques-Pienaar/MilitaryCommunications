using System;

namespace MilitaryCommunications
{
    class Message : Datahandler
    {
        private int userId;
        private int messageId;
        private string message;
        private DateTime dateOfRead;
        private DateTime timeToDecrypt;
        private List<string> messages;

        public int UserId { get; set; }
        public int MessageId { get; set; }
        public string Message { get; set; }
        public DateTime DateOfRead { get; set; }
        public DateTime TimeToDecrypt { get; set; }
        public List<string> Messages { get; set; }

        Encryption encryption = new Encryption();
        
        public Message(){}

        public Message(int userId, string message, DateTime dateOfRead)
        {
            this.UserId = userId;
            this.Message = message;
            this.DateOfRead = dateOfRead;
        }

        public List<Message> GetListOfMessages()
        {
            List<Message> listToReturn = new List<Message>();

            listToReturn = GetAllMessages();

            return listToReturn;
        }

        public string GetMessage(string textFile)
        {
            this.Message = encryption.GetDecryptedMessage();
            return this.Message;
        }

        public string GetMessages(string textFile)
        {
            this.messages = encryption.GetDecryptedMessages();
            return this.Messages;
        }

        public void SaveMessage()
        {
            //time at which message was read
            encryption.PostEncryptedMessage(message);
        }

    }
}