namespace ms.common.sharedtypes
{
    public class MyCommand
    {
        public string CommandName { get; set; }
        public MyMessage Payload { get; set; }
    }

    public class MyEvent
    {
        public string EventName { get; set; }
        public MyMessage Payload { get; set; }
    }
}
