namespace ControlEntradas.Services;

public interface IDateService
{
    DateTime CodeToDate(string code);
    string DateToCode(DateTime date);
}

public class DateService : IDateService
{
    public string DateToCode(DateTime date) => date.ToString("yyyyMMdd");
    public DateTime CodeToDate(string code) => new(int.Parse(code[..4]), int.Parse(code[4..6]), int.Parse(code[6..]));
}
