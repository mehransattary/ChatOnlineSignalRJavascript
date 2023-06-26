

namespace Application.Sms;

public interface ISmsService
{
    Task SendSms(string mobile, string password);
}
