namespace Resortify.Data.Constants
{
    public class DataConstants
    {
        public class UserConstants
        {
            public const int MaxFirstNameLength = 100;
            public const int MinFirstLength = 2;
            public const int MaxLastNameLength = 100;
            public const int MinLastNameLength = 2;
            public const int MaxUsernameLength = 256;
            public const int MinUsernameLength = 4;
            public const int MaxPasswordLength = 100;
            public const int MinPasswordLength = 8;
        }

        public class AccomoditionConstants
        {
            public const int MaxAccomodationNameLength = 50;
            public const int MinAccomodationNameLength = 2;
            public const int DescriptionMinLength = 10;
        }

        public class PhotoConstants
        {
            public const int MinURLLength = 4;
        }

        public class OwnerConstants
        {
            public const int MaxPhoneNumberLength = 15;
            public const int MinPhoneNumberLength = 7;
            public const int MaxAgnecyNameLength = 50;
        }
    }
}
