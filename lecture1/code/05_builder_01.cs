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

// Abstrakt buildergränssnitt för att bygga ett e-postmeddelande
public abstract class EmailBuilder
{
    protected Email email = new Email();
    
    public abstract void BuildTo(string to);
    public abstract void BuildFrom(string from);
    public abstract void BuildSubject(string subject);
    public abstract void BuildBody(string body);

    public Email GetEmail()
    {
        return email;
    }
}

// Konkret builder för att bygga ett e-postmeddelande
public class ConcreteEmailBuilder : EmailBuilder
{
    public override void BuildTo(string to)
    {
        email.To = to;
    }

    public override void BuildFrom(string from)
    {
        email.From = from;
    }

    public override void BuildSubject(string subject)
    {
        email.Subject = subject;
    }

    public override void BuildBody(string body)
    {
        email.Body = body;
    }
}

// Direktorklass som styr byggprocessen
public class EmailDirector
{
    public void Construct(EmailBuilder builder, string to, string from, string subject, string body)
    {
        builder.BuildTo(to);
        builder.BuildFrom(from);
        builder.BuildSubject(subject);
        builder.BuildBody(body);
    }
}

// Klientkod för att använda Builder-mönstret
class Client
{
    static void Main(string[] args)
    {
        EmailDirector director = new EmailDirector();
        
        // Bygga ett e-postmeddelande
        EmailBuilder builder = new ConcreteEmailBuilder();
        director.Construct(builder, "recipient@example.com", "sender@example.com", "Hello", "This is the body of the email.");

        Email email = builder.GetEmail();
        Console.WriteLine(email);
    }
}
