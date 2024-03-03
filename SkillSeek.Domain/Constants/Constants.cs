namespace SkillSeek.Domain.Constants;

public abstract class Constants
{
    public abstract class Roles
    {
        public const string Admin = "Admin";
        public const string Professional = "Professional";
        public const string Customer = "Customer";
    }

    public abstract class Passwords
    {
        public const string Password = "radi0V!oleta";
    }
    
    public abstract class Entity
    {
        public const string System = "System";
        public const string Admin = "Admin";
        public const string Professional = "Professional";
        public const string Customer = "Customer";
    }
    
    public abstract class Order
    {
        public const string Pending = "Pending";
        public const string Approved = "Approved";
        public const string Processing = "Processing";
        public const string Completed = "Completed";
        public const string Cancelled = "Cancelled";
        public const string Shipped = "Shipped";
    }
    
    public abstract class Payment
    {
        public const string Pending = "Pending";
        public const string Refunded = "Refunded";
        public const string Cancelled = "Cancelled";
        public const string Approved = "Approved";
        public const string Delayed = "Delayed";
        public const string Rejected = "Rejected";
    }
    
    public abstract class Appointment
    {
        public const string Booked = "Booked";
        public const string Completed = "Completed";
        public const string Pending = "Pending";
        public const string Approved = "Approved";
    }

    public abstract class FilePath
    {
        public static string UsersImagesPath => @"wwwroot\images\users\";

        public static string ProfessionalsDocumentsPath => @"wwwroot\documents\";

        public static string ProfessionalsImagesPath => @"wwwroot\images\professionals\";

        public static string ProductsImagesPath => @"wwwroot\images\professionals\";

    }
}