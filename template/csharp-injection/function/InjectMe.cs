// Copyright (c) Erwin Staal 2019. All rights reserved.
// This simple class is here to demonstrate the injections functionality
 // Feel free to remove

using System;

namespace Function
{
    public class InjectMe : IInjectMe
    {
        public string SayHello(string input)
        {
            return $"Hello {input}";
        }
    }

    public interface IInjectMe
    {
        string SayHello(string input);
    }
}