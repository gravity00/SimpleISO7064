namespace SimpleISO7064
{
    /// <summary>
    /// An ISO 7064 Pure System provider to validate or 
    /// compute check digits
    /// </summary>
    public interface IIso7064PureSystemProvider
    {
        /// <summary>
        /// The pure system modulus
        /// </summary>
        int Modulus { get; }

        /// <summary>
        /// The pure system radiz
        /// </summary>
        int Radix { get; }

        /// <summary>
        /// The supported character set
        /// </summary>
        char[] CharacterSet { get; }

        /// <summary>
        /// Is the computed check digit composed by two characters?
        /// </summary>
        bool IsDoubleCheckDigit { get; }

        /// <summary>
        /// Checks if the given value contains a valid check digit.
        /// </summary>
        /// <param name="computedValue">The value to check</param>
        /// <returns></returns>
        bool IsValid(string computedValue);

        /// <summary>
        /// Computes the check digit from a given value.
        /// </summary>
        /// <param name="value">The value from which the check digit will be computed</param>
        /// <returns>The check digit</returns>
        string ComputeCheckDigit(string value);

        /// <summary>
        /// Computes the check digit and appends it to the given value.
        /// </summary>
        /// <param name="value">The value from which the check digit will be computed</param>
        /// <returns>The value and appended check digit</returns>
        string Compute(string value);
    }
}
