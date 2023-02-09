using GEMEscolar.Infra.Enumerators;

namespace GEMEscolar.Infra.Models
{
    public class ValidationResult
    {
        public bool Success { get; set; }
        public ResultType ResultType { get; set; }
        public string Message { get; set; }
    }

    public class ValidationResult<T> : ValidationResult
    {
        public T Object { get; set; }
    }
}
