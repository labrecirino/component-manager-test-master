using ReaderComponentService.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderComponentService.Factories
{
    /// <summary>
    /// Comment about the exercise: Use Factory pattern to instantiate the component handler.
    /// </summary
    public static class ReaderHandlerFactory
    {
        public enum ReaderType
        {
           
            Generic,
            Polar
        }
        
        public static Reader CreateReader(ReaderType type)
        {
            switch (type)
            {
                case ReaderType.Polar:
                    return new PolarReader();
                case ReaderType.Generic:
                    return new GenericReader();
                default:
                    return new GenericReader();
            }
        }

    }
}
