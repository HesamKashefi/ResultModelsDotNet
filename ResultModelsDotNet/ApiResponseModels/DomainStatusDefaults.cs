namespace ResultModelsDotNet.ApiResponseModels;

public static class DomainStatusDefaults
{
    public static class Codes
    {
        // OK Range 0-100
        public static byte OK = 0;
        public static byte NO_CONTENT = 1;


        // Client Error Range 100-200
        public static byte BAD_REQUEST = 100;
        public static byte UNAUTHORIZED = 101;
        public static byte FORBIDDEN = 103;
        public static byte NOT_FOUND = 104;
        public static byte NOT_ACCEPTABLE = 105;
        public static byte NOT_SUPPORTED = 106;
        public static byte INVALID_CREDENTIALS = 107;
        public static byte ALREADY_EXISTS = 108;

        public static byte USER_IS_NOT_ACTIVE = 109;
        public static byte USER_IS_LOCKED = 110;
        public static byte USERNAME_ALREADY_TAKEN = 111;
        public static byte EMAIL_ALREADY_TAKEN = 112;
        public static byte ENTITY_HAS_BEEN_CHANGED_SINCE_THEN = 113;

        // Server Error Range 200-300
        public static byte SERVER_ERROR = 200;
        public static byte SERVER_CONFIGURATION_ERROR = 201;

        // db
        public static byte DB_ERROR = 210;
        public static byte DB_DUPLICATE_ENTITY = 211;
        public static byte DB_CONSTRAINT_VIOLATION = 212;
        public static byte DB_DEPENDECY_CONSTRAINT_VIOLATED = 213;
    }
}
