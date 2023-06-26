
namespace Application.Sms;

public class SmsService : ISmsService
{
    public async Task SendSms(string mobile, string password)
    {

        Kavenegar.KavenegarApi kavenegar = new Kavenegar.KavenegarApi("");
        var result = await kavenegar.VerifyLookup(mobile, password, "chat");
    }
}
