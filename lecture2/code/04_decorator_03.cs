using System;

namespace DecoratorPatternComplexExample
{
    // Component - defines the interface for objects that can have responsibilities added to them dynamically
    public interface IWebPage
    {
        void Display();
    }

    // Concrete Component - implements the component interface
    public class BasicWebPage : IWebPage
    {
        public void Display()
        {
            Console.WriteLine("Displaying basic web page.");
        }
    }

    // Decorator - maintains a reference to a component object and defines an interface that conforms to the component's interface
    public abstract class WebPageDecorator : IWebPage
    {
        protected IWebPage _webPage;

        public WebPageDecorator(IWebPage webPage)
        {
            _webPage = webPage;
        }

        public virtual void Display()
        {
            _webPage.Display();
        }
    }

    // Concrete Decorator - adds authentication functionality
    public class AuthenticatedWebPage : WebPageDecorator
    {
        public AuthenticatedWebPage(IWebPage webPage) : base(webPage) { }

        public override void Display()
        {
            Console.WriteLine("Checking user authentication...");
            base.Display();
        }
    }

    // Concrete Decorator - adds authorized functionality
    public class AuthorizedWebPage : WebPageDecorator
    {
        public AuthorizedWebPage(IWebPage webPage) : base(webPage) { }

        public override void Display()
        {
            Console.WriteLine("Checking user authorization...");
            base.Display();
        }
    }

    // Concrete Decorator - adds compression functionality
    public class CompressedWebPage : WebPageDecorator
    {
        public CompressedWebPage(IWebPage webPage) : base(webPage) { }

        public override void Display()
        {
            Console.WriteLine("Compressing web page...");
            base.Display();
        }
    }

    // Client
    class Program
    {
        static void Main(string[] args)
        {
            IWebPage basicWebPage = new BasicWebPage();

            IWebPage authenticatedWebPage = new AuthenticatedWebPage(basicWebPage);
            IWebPage authorizedWebPage = new AuthorizedWebPage(authenticatedWebPage);
            IWebPage compressedWebPage = new CompressedWebPage(authorizedWebPage);

            compressedWebPage.Display();
        }
    }
}

// Output:
// Compressing web page...
// Checking user authorization...
// Checking user authentication...
// Displaying basic web page.
