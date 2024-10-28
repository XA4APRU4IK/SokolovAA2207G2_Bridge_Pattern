public interface INotification
{
    void Send(string message);
}
public class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Отправка Email: {message}");
    }
}
public class SmsNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Отправка SMS: {message}");
    }
}
public abstract class NotificationSender
{
    protected INotification notification;

    protected NotificationSender(INotification notification)
    {
        this.notification = notification;
    }
    public abstract void Notify(string message);
}
public class TextNotificationSender : NotificationSender
{
    public TextNotificationSender(INotification notification) : base(notification) { }

    public override void Notify(string message)
    {
        notification.Send(message);
    }
}

public class HtmlNotificationSender : NotificationSender
{
    public HtmlNotificationSender(INotification notification) : base(notification) { }

    public override void Notify(string message)
    {
        string htmlMessage = $"<html><body>{message}</body></html>";
        notification.Send(htmlMessage);
    }
}
class Program
{
    static void Main(string[] args)
    {
        INotification email = new EmailNotification();
        INotification sms = new SmsNotification();

        NotificationSender textEmailSender = new TextNotificationSender(email);
        NotificationSender htmlSmsSender = new HtmlNotificationSender(sms);

        textEmailSender.Notify("Это текстовое уведомление по Email.");
        htmlSmsSender.Notify("Это HTML-уведомление по SMS.");
    }
}
