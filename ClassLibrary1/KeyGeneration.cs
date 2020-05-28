using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public class KeyGeneration
    {
        private int guidCount = 100;
        public List<string> listOfKeys = new List<string>();

        public List<string> KeyGenerator()
        {
            for (int i = 0; i < guidCount; i++)
            {

                Guid key = Guid.NewGuid();

                listOfKeys.Add(key.ToString().ToUpper());
            }

            return listOfKeys;
        }
    }
}
