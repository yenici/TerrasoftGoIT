using System;
using System.Text.RegularExpressions;

namespace Assignment_09_2
{
    public class LongNumber
    {
        public static readonly LongNumber Zero = new LongNumber();
        private String value;
        private Boolean positive;
        public String Value
        {
            get
            {
                if (this.positive)
                    return this.value;
                else
                    return "-" + this.value;
            }
            set
            {
                if (Regex.IsMatch(value, @"^[+-]?[0-9]+$"))
                {
                    this.positive = true;
                    if (value[0] == '-')
                    {
                        this.positive = false;
                        value = value.Substring(1);
                    }
                    else
                    if (value[0] == '+')
                        value = value.Substring(1);
                    // Trim starting zero(s)
                    if (value.Length > 1)
                        value = value.TrimStart('0');
                    this.value = value;
                }
                else
                {
                    this.value = "0";
                    this.positive = true;
                }
            }
        }
        public LongNumber()
        {
            this.Value = "";
        }
        public LongNumber(String value)
        {
            this.Value = value;
        }
        public override string ToString()
        {
            return Value;
        }
        public static LongNumber Add(LongNumber a, LongNumber b)
        {
            if (a.positive == b.positive)
            {
                String operand1 = a.value,
                    operand2 = b.value,
                    result = "";
                int numberLength = LongNumber.AlignLength(ref operand1, ref operand2);
                int positionValue,
                    correction = 0;
                for (int i = numberLength - 1; i >= 0; i--)
                {
                    positionValue = Byte.Parse(operand1.Substring(i, 1)) + Byte.Parse(operand2.Substring(i, 1)) + correction;
                    correction = (positionValue > 9) ? 1 : 0;
                    result = (correction == 1 ? positionValue - 10 : positionValue) + result;
                }
                if (correction > 0)
                    result = correction + result;
                if (!a.positive)
                    result = "-" + result;
                return new LongNumber(result);
            }
            else
            {
                if (a.positive)
                    return LongNumber.Subtract(a, new LongNumber(b.value));
                else
                    return LongNumber.Subtract(b, new LongNumber(a.value));
            }
        }
        public static LongNumber Subtract(LongNumber a, LongNumber b)
        {
            if (!a.positive && b.positive)
                return LongNumber.Add(a, new LongNumber("-" + b.value));
            if (a.positive && !b.positive)
                return LongNumber.Add(a, new LongNumber(b.value));
            String operand1 = a.value,
                operand2 = b.value,
                result = "";
            int numberLength = LongNumber.AlignLength(ref operand1, ref operand2);
            int compareOperands = LongNumber.CompareAbs(operand1, operand2);
            if (compareOperands == 0) // abs(a) == abs(b)
                return new LongNumber(LongNumber.Zero.Value);
            if (compareOperands == -1) // abs(a) < abs(b)
            {
                String temp = operand1;
                operand1 = operand2;
                operand2 = temp;
            }
            int positionValue,
                correction = 0;
            for (int i = numberLength - 1; i >= 0; i--)
            {
                positionValue = Byte.Parse(operand1.Substring(i, 1)) - Byte.Parse(operand2.Substring(i, 1)) - correction;
                if (positionValue < 0)
                {
                    positionValue += 10;
                    correction = 1;
                }
                else
                {
                    correction = 0;
                }
                result = positionValue + result;
            }
            if (compareOperands == 1) // abs(a) > abs(b)
            {
                if (!a.positive)
                    result = "-" + result;
            }
            else  // abs(a) < abs(b)
            {
                if (a.positive)
                    result = "-" + result;
            }
            return new LongNumber(result);
        }
        public static LongNumber Multiply(LongNumber a, LongNumber b)
        {
            if (a.value == LongNumber.Zero.Value || b.value == LongNumber.Zero.Value)
                return new LongNumber();
            String operand1,
                operand2,
                tmpResult;
            int multiplier,
                positionValue,
                correction,
                digit;
            LongNumber result = new LongNumber();
            if (a.value.Length < b.value.Length)
            {
                operand1 = b.value;
                operand2 = a.value;
            }
            else
            {
                operand1 = a.value;
                operand2 = b.value;
            }
            for (int i = operand2.Length - 1, k = 0; i >= 0; i--, k++)
            {
                multiplier = Byte.Parse(operand2.Substring(i, 1));
                if (multiplier !=0)
                {
                    correction = 0;
                    tmpResult = "";
                    for (int j = operand1.Length - 1; j >= 0; j--)
                    {
                        positionValue = multiplier * Byte.Parse(operand1.Substring(j, 1)) + correction;
                        digit = positionValue % 10;
                        correction = (positionValue - digit) / 10;
                        tmpResult = digit + tmpResult;
                    }
                    if (correction > 0)
                        tmpResult = correction + tmpResult;
                    if (k > 0)
                        tmpResult += new String('0', k);
                    result = LongNumber.Add(result, new LongNumber(tmpResult));
                }
                else
                {
                    continue;
                }
            }
            if (a.positive != b.positive)
                result.positive = false;
            return result;
        }
        public static LongNumber Divide(LongNumber a, LongNumber b)
        {
            if (a.value == LongNumber.Zero.Value) // divident = 0
                return new LongNumber(LongNumber.Zero.Value);
            if (b.value == LongNumber.Zero.Value) // divisor = 0 Exception!
                throw new DivideByZeroException();
            if (b.value == "1") // divisor = 1
            {
                if (a.positive == b.positive)
                    return new LongNumber(a.value);
                else
                    return new LongNumber("-" + a.value);
            }
            int compareOperands = LongNumber.CompareAbs(a.value, b.value);
            if (compareOperands == 0) // divident = divisor
                if (a.positive == b.positive)
                    return new LongNumber("1");
                else
                    return new LongNumber("-1");
            if (compareOperands < 0) // divident < divisor
                return new LongNumber();
            LongNumber dividend = new LongNumber(a.value);
            LongNumber divisor = new LongNumber(b.value);
            LongNumber result = new LongNumber();
            int usedLength = b.value.Length;
            LongNumber tempDivident = new LongNumber(a.value.Substring(0, usedLength));
            int quotient = 0;
            while (true)
            {
                if (LongNumber.Compare(tempDivident, divisor) >= 0)
                {
                    quotient = 0;
                    while (LongNumber.Compare(tempDivident, divisor) >= 0)
                    {
                        quotient++;
                        tempDivident = LongNumber.Subtract(tempDivident, divisor);
                    }
                    result.Value = result.value + quotient;
                }
                else
                {
                    result.Value = result.value + "0";
                }
                usedLength++;
                if (usedLength <= a.value.Length)
                    tempDivident.Value = tempDivident.value + a.value.Substring(usedLength - 1, 1);
                else
                    break;
            }
            if (a.positive != b.positive)
                result.positive = false;
            return result;
        }
        public static Boolean TryParse(String value, out LongNumber parsedValue)
        {
            parsedValue = new LongNumber(value);
            return Regex.IsMatch(value, @"^[+-]?[0-9]+$");
        }
        /**
         * Returns:
         *   1 : a > b
         *  -1 : a < b
         *   0 : a = b
         */
        public static int Compare(LongNumber a, LongNumber b)
        {
            if (a.positive != b.positive)
                return (a.positive ? 1 : -1);
            String operand1 = a.value,
                operand2 = b.value;
            int result = LongNumber.CompareAbs(operand1, operand2);
            if (!a.positive)
                result = -result;
            return result;
        }
        private static int CompareAbs(String a, String b)
        {
            int numberLength;
            if (a.Length != b.Length)
                numberLength = LongNumber.AlignLength(ref a, ref b);
            else
                numberLength = a.Length;
            int result = 0;
            for (int i = 0; i < numberLength; i++)
            {
                if (a[i] == b[i])
                    continue;
                if (a[i] < b[i])
                    result = -1;
                else
                    result = 1;
                break;
            }
            return result;
        }
        private static int AlignLength(ref String a, ref String b)
        {
            int numberLength = Math.Max(a.Length, b.Length);
            if (a.Length < numberLength)
                a = new String('0', numberLength - a.Length) + a;
            if (b.Length < numberLength)
                b = new String('0', numberLength - b.Length) + b;
            return numberLength;
        }
    }
}
