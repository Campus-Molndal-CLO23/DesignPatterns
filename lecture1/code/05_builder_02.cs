using System;
using System.Text;

// Produktklass som representerar ett e-postmeddelande
public class Email
{
    public string To { get; set; }
    public string From { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"To: {To}");
        sb.AppendLine($"From: {From}");
        sb.AppendLine($"Subject: {Subject}");
        sb.AppendLine($"Body: {Body}");
        return sb.ToString();
    }
}

// Fluent Builder för att skapa ett e-postmeddelande
public class EmailBuilder
{
    private Email email;

    public EmailBuilder()
    {
        email = new Email();
    }

    public EmailBuilder SetTo(string to)
    {
        email.To = to;
        return this; // Returnerar buildern för att möjliggöra metodkedjning
    }

    public EmailBuilder SetFrom(string from)
    {
        email.From = from;
        return this; // Returnerar buildern för att möjliggöra metodkedjning
    }

    public EmailBuilder SetSubject(string subject)
    {
        email.Subject = subject;
        return this; // Returnerar buildern för att möjliggöra metodkedjning
    }

    public EmailBuilder SetBody(string body)
    {
        email.Body = body;
        return this; // Returnerar buildern för att möjliggöra metodkedjning
    }

    public Email Build()
    {
        return email; // Returnerar det färdiga e-postmeddelandet
    }
}

// Klientkod för att använda Fluent Builder-mönstret
class Client
{
    static void Main(string[] args)
    {
        // Bygga ett e-postmeddelande med Fluent Builder
        Email email = new EmailBuilder()
            .SetTo("recipient@example.com")
            .SetFrom("sender@example.com")
            .SetSubject("Hello")
            .SetBody("This is the body of the email.")
            .Build();

        Console.WriteLine(email);
    }
}
