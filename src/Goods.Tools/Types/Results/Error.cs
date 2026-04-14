namespace Goods.Tools.Types.Results;

public class Error
{
    public String Message { get; }
    public String? Key { get; }

    public Error(String error)
    {
        this.Message = error;
    }

    public Error(String key, String message)
    {
        this.Key = key;
        this.Message = message;
    }

    public override String ToString()
    {
        return String.IsNullOrEmpty(Key) ? Message : $"({Key}) {Message}";
    }
}
