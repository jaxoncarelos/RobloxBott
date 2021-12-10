#nullable enable
namespace RobloxBott
{
    public class receivedData
    {
        // {"GameId":"11cc0f68-3274-41a0-836f-ebfec56e2017",
        // "IsOnline":true,
        // "LastLocation":"Playing Open World",
        // "LastOnline":"2021-12-06T22:17:21.76-06:00",
        // "LocationType":4,
        // "PlaceId":7816227995,
        // "VisitorId":1644324990,
        // "PresenceType":2,
        // "UniverseId":null,
        // "Visibility":0}
        public string? GameId { get; set; }
        public bool IsOnline { get; set; }
        public string LastOnline { get; set; }
        public string LastLocation { get; set; }
        public int? LocationType { get; set; }
        public long? PlaceId { get; set; }
        public long? VisitorId   { get; set; }
        public int? PresenceType { get; set; }
        public long? UniverseId { get; set; }
        public int? Visibility { get; set; }
        public bool? hasMessageSent { get; set; }
        public string lastSeenOnline { get; set; }
    }
}