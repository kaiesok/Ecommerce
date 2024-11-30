namespace Core.Exceptions
{
    // Exception pour une tentative d'inscription avec un e-mail déjà existant
    public class EmailAlreadyExistsException : Exception
    {
        public EmailAlreadyExistsException()
            : base("The email address already exists.") { }

        public EmailAlreadyExistsException(string message)
            : base(message) { }

        public EmailAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    // Exception pour une tentative de connexion avec un mot de passe incorrect
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException()
            : base("Invalid password.") { }

        public InvalidPasswordException(string message)
            : base(message) { }

        public InvalidPasswordException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    // Exception pour une tentative de connexion avec un utilisateur inexistant
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException()
            : base("User not found.") { }

        public UserNotFoundException(string message)
            : base(message) { }

        public UserNotFoundException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    // Exception pour un mot de passe expiré
    public class PasswordExpiredException : Exception
    {
        public PasswordExpiredException()
            : base("Your password has expired.") { }

        public PasswordExpiredException(string message)
            : base(message) { }

        public PasswordExpiredException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    // Exception pour une tentative d'accès non autorisé
    public class UnauthorizedAccessException : Exception
    {
        public UnauthorizedAccessException()
            : base("Unauthorized access.") { }

        public UnauthorizedAccessException(string message)
            : base(message) { }

        public UnauthorizedAccessException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    // Exception pour des données invalides
    public class InvalidDataException : Exception
    {
        public InvalidDataException()
            : base("Invalid data.") { }

        public InvalidDataException(string message)
            : base(message) { }

        public InvalidDataException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    // Exception pour une opération non autorisée dans un contexte donné
    public class OperationNotAllowedException : Exception
    {
        public OperationNotAllowedException()
            : base("Operation not allowed.") { }

        public OperationNotAllowedException(string message)
            : base(message) { }

        public OperationNotAllowedException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    // Exception pour une ressource non trouvée (ex: produit, utilisateur)
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string resource)
            : base($"{resource} not found.") { }

        public ResourceNotFoundException(string resource, string message)
            : base($"{resource}: {message}") { }

        public ResourceNotFoundException(string resource, string message, Exception innerException)
            : base($"{resource}: {message}", innerException) { }
    }

    // Exception pour un token JWT invalide ou expiré
    public class InvalidTokenException : Exception
    {
        public InvalidTokenException()
            : base("Invalid or expired token.") { }

        public InvalidTokenException(string message)
            : base(message) { }

        public InvalidTokenException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    // Exception pour la tentative de modification d'une entité avec des données conflictuelles
    public class ConflictException : Exception
    {
        public ConflictException(string message)
            : base(message) { }

        public ConflictException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
