using System.Runtime.Serialization.Formatters.Binary;

namespace ex02TREV
{ 
    public struct Contact
    {
        public string Name;
        public string Phone;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Contact[] contacts = new Contact[5]; 

            contacts[0] = new Contact { Name = "João", Phone = "123456789" };
            contacts[1] = new Contact { Name = "Maria", Phone = "987654321" };

            SaveContacts(contacts);

            Contact[] contactsFromFile = LoadContacts();
            Console.WriteLine("Lista de contatos:");
            foreach (var contact in contactsFromFile)
            {
                Console.WriteLine($"Nome: {contact.Name}, Telefone: {contact.Phone}");
            }
        }

        static void SaveContacts(Contact[] contacts)
        {
            string fileName = "contacts.bin";

            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, contacts);
            }

            Console.WriteLine("Contatos salvos com sucesso!");
        }

        static Contact[] LoadContacts()
        {
            string fileName = "contacts.bin";

            if (!File.Exists(fileName))
            {
                Console.WriteLine("Arquivo de contatos não encontrado.");
                return new Contact[0];
            }

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Contact[] contacts = (Contact[])formatter.Deserialize(fs);
                return contacts;
            }
        }
    }


}