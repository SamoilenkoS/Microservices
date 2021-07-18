namespace Microservices.TransactionStore
{
  public class BusOptions
  {
    public string Host { get; set; }
    public string Queue { get; set; }
    public string TemporaryQueue { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
  }
}
