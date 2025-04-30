// 29. Divide Two Integers
// Medium
// Topics
// Companies
// Given two integers dividend and divisor, divide two integers without using multiplication, division, and mod operator.

// The integer division should truncate toward zero, which means losing its fractional part.
// For example, 8.345 would be truncated to 8, and -2.7335 would be truncated to -2.

// Return the quotient after dividing dividend by divisor.

// Note: Assume we are dealing with an environment that could only store integers within the 32-bit
// signed integer range: [−231, 231 − 1]. For this problem, if the quotient is strictly greater than 231 - 1,
// then return 231 - 1, and if the quotient is strictly less than -231, then return -231.

// 7 / 1 = 7  111 / 001 = 111
// 7 / 2 = 3  111 / 010 = 011
// 7 / 3 = 2  111 / 011 = 010
// 7 / 4 = 1  111 / 100 = 001

// 8 / 4 = 2  1000 / 0100 = 0010

int a = 53;
Console.WriteLine(0b11_0101);
Console.WriteLine(a);
a <<= 1;
Console.WriteLine(a);
a <<= 1;
Console.WriteLine(a);
