namespace DevTracker.API.Entities
{
    public class Package
    {
        public Package(string title, decimal wight)
        {
            Code = Guid.NewGuid().ToString();
            Title = title;
            Wight = wight;
            Delivered = false;
            PostedAt = DateTime.Now;
            Updates = new List<PackageUpdate>();
        }

        public void AddUpdate(string status, bool delivered)
        {
            if (delivered)
            {
                throw new Exception("Package is already delivered.");
            }
            var update = new PackageUpdate(status, Id);
            Updates.Add(update);

            if(delivered)
            {
                Delivered = true;
            }
        }

        public int Id { get; private set; }
        public string Code { get; private set; }
        public string Title { get; private set; }
        public decimal Wight { get; private set; }
        public bool Delivered { get; private set; }
        public DateTime PostedAt { get; private set; }
        public int MyProperty { get; private set; }
        public List<PackageUpdate> Updates { get; private set; }

    }
}
