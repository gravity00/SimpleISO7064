namespace SimpleISO7064;

/// <summary>
/// An ISO 7064 Pure System provider to validate or compute check digits
/// </summary>
public interface IIso7064PureSystemProvider
{
    /// <summary>
    /// The pure system modulus
    /// </summary>
    int Modulus { get; }

    /// <summary>
    /// The pure system radix
    /// </summary>
    int Radix { get; }

    /// <summary>
    /// Is the computed check digit composed by two characters?
    /// </summary>
    bool IsDoubleCheckDigit { get; }

    /// <summary>
    /// The supported character set
    /// </summary>
    string CharacterSet { get; }

    /// <summary>
    /// Checks if the given value contains a valid check digit.
    /// </summary>
    /// <param name="value">The value to check</param>
    /// <returns>If the computed value is valid</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    bool IsValid(string value);

    /// <summary>
    /// Computes the check digit from a given value.
    /// </summary>
    /// <param name="value">The value from which the check digit will be computed</param>
    /// <returns>The check digit</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    string ComputeCheckDigit(string value);

    /// <summary>
    /// Computes the check digit and appends it to the given value.
    /// </summary>
    /// <param name="value">The value from which the check digit will be computed</param>
    /// <returns>The value and appended check digit</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    string Compute(string value);
}