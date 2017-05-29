using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderComponentService.Handlers
{
    /// <summary>
    /// Comment about the exercise: Use Factory pattern to instantiate the component handler.
    /// </summary
    class PolarReader : Reader
    {
        enum FieldType
        {
            FirstName,
            Country,
            Age
        }
        public override IEnumerable<PersonalData> ReadData()
        {
            var stream = ReadStream("CM-READ");
            var list = stream.Split('&')
                        .Select(s => s.Split(','))
                        .Select(a => ParseStream(a)).AsEnumerable<PersonalData>();


            return list;
        }

        // Comment about the exercise: Use async/await if possible
        public override async Task<IEnumerable<PersonalData>> ReadDataAsync()
        {
            return await Task.Run<IEnumerable<PersonalData>>(() => ReadData());
        }

        PersonalData ParseStream(string[] data)
        {
            PersonalData item = new PersonalData();
            var segment = data[1];

            item.FirstName = data[0];
            item.LastName = segment.Substring(0, segment.Length - 6).Trim();
            item.Country = segment.Substring(segment.Length - 6, 3);
            item.Age = Convert.ToInt32(segment.Substring(segment.Length - 3, 3));

            return item;

        }

        
    }
}
