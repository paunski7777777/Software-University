namespace P01.Stream_Progress
{
    public interface IStreamble
    {
        int Length { get; }
        int BytesSent { get; }
    }

}