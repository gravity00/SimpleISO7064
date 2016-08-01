namespace SimpleISO7064
{
    public class Iso7064Factory
    {
        /// <summary>
        /// Creates a insatnce of <see cref="Iso7064PureSystemProvider"/> with Modulus 11 and Radix 2
        /// </summary>
        /// <returns>An ISO 7064 Pure System provider to validate or compute check digits, with Modulus 11 and Radix 2</returns>
        public static Iso7064PureSystemProvider GetMod11Radix2()
        {
            return new Iso7064PureSystemProvider(11, 2, false, "0123456789X");
        }

        /// <summary>
        /// Creates a insatnce of <see cref="Iso7064PureSystemProvider"/> with Modulus 11 and Radix 2
        /// </summary>
        /// <returns>An ISO 7064 Pure System provider to validate or compute check digits, with Modulus 11 and Radix 2</returns>
        public static Iso7064PureSystemProvider GetMod37Radix2()
        {
            return new Iso7064PureSystemProvider(37, 2, false, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ*");
        }

        /// <summary>
        /// Creates a insatnce of <see cref="Iso7064PureSystemProvider"/> with Modulus 11 and Radix 2
        /// </summary>
        /// <returns>An ISO 7064 Pure System provider to validate or compute check digits, with Modulus 11 and Radix 2</returns>
        public static Iso7064PureSystemProvider GetMod97Radix10()
        {
            return new Iso7064PureSystemProvider(97, 10, true, "0123456789");
        }

        /// <summary>
        /// Creates a insatnce of <see cref="Iso7064PureSystemProvider"/> with Modulus 11 and Radix 2
        /// </summary>
        /// <returns>An ISO 7064 Pure System provider to validate or compute check digits, with Modulus 11 and Radix 2</returns>
        public static Iso7064PureSystemProvider GetMod661Radix26()
        {
            return new Iso7064PureSystemProvider(661, 26, true, "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        }

        /// <summary>
        /// Creates a insatnce of <see cref="Iso7064PureSystemProvider"/> with Modulus 11 and Radix 2
        /// </summary>
        /// <returns>An ISO 7064 Pure System provider to validate or compute check digits, with Modulus 11 and Radix 2</returns>
        public static Iso7064PureSystemProvider GetMod1271Radix36()
        {
            return new Iso7064PureSystemProvider(1271, 36, true, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXZY");
        }
    }
}