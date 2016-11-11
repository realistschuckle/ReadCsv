namespace ReadCsv
{
    class DataRecord
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _rut;

        public DataRecord(string firstName, string lastName, string email, string rut)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _rut = rut;
        }

        public string FirstName { get { return _firstName; } }

        public string LastName { get { return _lastName; } }

        public string Email { get { return _email; } }

        public string Rut { get { return _rut; } }

        public static DataRecord Parse(string line)
        {
            string[] entries = line.Split(',');
            return new DataRecord(entries[0], entries[1], entries[2], entries[3]);
        }
    }
}
