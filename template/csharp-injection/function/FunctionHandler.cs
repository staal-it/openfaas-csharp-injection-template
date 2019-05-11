using System;
using System.Text;

namespace Function
{
    public class FunctionHandler
    {
        private IInjectMe _injectMe;

        public FunctionHandler(IInjectMe injectMe)
        {
            _injectMe = injectMe;
        }

        public string Handle(string input) {
            return _injectMe.SayHello(input);
        }
    }
}
