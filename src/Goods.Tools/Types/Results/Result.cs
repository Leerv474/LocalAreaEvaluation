namespace Goods.Tools.Types.Results;

public class Result
{
    public Boolean IsSuccess => Errors.Length == 0;
    public Error[] Errors { get; }

    public Result()
    {
        this.Errors = [];
    }

    public Result(IEnumerable<Error> errors)
    {
        this.Errors = [.. errors];
    }

    public static Result Success()
    {
        return new();
    }

    public static Result Failed(IEnumerable<Error> errors)
    {
        return new(errors);
    }

    public static Result Failed(String error)
    {
        return Failed(new Error(error));
    }

    public static Result Failed(Error errors)
    {
        return new([errors]);
    }
}
