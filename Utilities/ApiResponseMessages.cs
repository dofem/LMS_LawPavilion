namespace LIBRARY_MANAGEMENT_SYSTEM.Utilities
{
    public static class ApiResponseMessages
    {
        public const string SuccessCode = "00";
        public const string NotFoundError = "01";
        public const string ErrorCode = "99";
        public const string InvalidCredentialsCode = "17";

        public const string BookCreated = "Book created successfully";
        public const string BookUpdated = "Book updated successfully";
        public const string BookDeleted = "Book deleted successfully";
        public const string BookRetrieved = "Book Retrieved successfully";

        public const string UserCreated = "User created successfully";
        public const string UserDeleted = "User Deleted successfully";
        public const string RoleUpdated = "User role updated successfully";
        public const string UsersRetrieved = "Users retrieved successfully";

        public const string InvalidCredentials = "Invalid username or password";
        public const string BookNotFound = "Book Not Found";
        public const string UserNotFound = "User Not Found";

        public const string ErrorMessage = "An Error occured, Kindly contact your Administrator";
    }

}
