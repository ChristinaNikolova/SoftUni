using System;

public class Program
{
    public static void Main(string[] args)
    {
        Spy spy = new Spy();

        //string stealFieldInfoResult = spy.StealFieldInfo("Hacker", "username", "password");
        //Console.WriteLine(stealFieldInfoResult);

        //string analyzeAcessModifiersResult = spy.AnalyzeAcessModifiers("Hacker");
        //Console.WriteLine(analyzeAcessModifiersResult);

        //string revealPrivateMethodsResult = spy.RevealPrivateMethods("Hacker");
        //Console.WriteLine(revealPrivateMethodsResult);

        string collectGettersAndSettersResult = spy.CollectGettersAndSetters("Hacker");
        Console.WriteLine(collectGettersAndSettersResult);
    }
}

