// Webbservice exempel
// Demonstrerar Visitor-mönstret

/*
Förklaringar till koden
IWebServiceVisitor: Gränssnitt för besökare som definierar metoder för att besöka olika typer av webbservice-requests.
IWebServiceRequest: Gränssnitt för element som kan acceptera en besökare.
RestRequest: Konkret element för REST-requests.
SoapRequest: Konkret element för SOAP-requests.
WebServiceLoggerVisitor: Konkret besökare som hanterar och loggar webbservice-requests.
*/

using System;

/* Gränssnitt för besökare */
public interface IWebServiceVisitor
{
    void Visit(RestRequest restRequest);
    void Visit(SoapRequest soapRequest);
}

/* Gränssnitt för element som kan acceptera en besökare */
public interface IWebServiceRequest
{
    void Accept(IWebServiceVisitor visitor);
}

/* Konkret element för REST-requests */
public class RestRequest : IWebServiceRequest
{
    public string Url { get; set; }
    public string Method { get; set; }

    public RestRequest(string url, string method)
    {
        Url = url;
        Method = method;
    }

    public void Accept(IWebServiceVisitor visitor)
    {
        visitor.Visit(this);
    }
}

/* Konkret element för SOAP-requests */
public class SoapRequest : IWebServiceRequest
{
    public string Wsdl { get; set; }
    public string Operation { get; set; }

    public SoapRequest(string wsdl, string operation)
    {
        Wsdl = wsdl;
        Operation = operation;
    }

    public void Accept(IWebServiceVisitor visitor)
    {
        visitor.Visit(this);
    }
}

/* Konkret besökare som hanterar webbservice-requests */
public class WebServiceLoggerVisitor : IWebServiceVisitor
{
    public void Visit(RestRequest restRequest)
    {
        Console.WriteLine($"Logging REST Request: {restRequest.Method} {restRequest.Url}");
    }

    public void Visit(SoapRequest soapRequest)
    {
        Console.WriteLine($"Logging SOAP Request: {soapRequest.Operation} {soapRequest.Wsdl}");
    }
}

/* Programklass för att demonstrera webbservices med Visitor-mönstret */
class Program
{
    static void Main()
    {
        IWebServiceRequest restRequest = new RestRequest("https://api.example.com/data", "GET");
        IWebServiceRequest soapRequest = new SoapRequest("https://api.example.com/service.wsdl", "GetData");

        IWebServiceVisitor logger = new WebServiceLoggerVisitor();

        restRequest.Accept(logger);
        soapRequest.Accept(logger);
    }
}
