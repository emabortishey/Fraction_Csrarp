﻿using System;
using static System.Console;
using static System.Math; 

Fraction test = new Fraction(1, 2);
Fraction test2 = new Fraction(3, 4);

// ИСПЫТАНИЕ БИНАРНЫХ АРИФМ. ОПЕРАТОРОВ
WriteLine(test + test2);
WriteLine(test - test2);
WriteLine(test * test2);
WriteLine(test / test2);
// ИСПЫТАНИЕ УНАРНЫХ АРИФМ. ОПЕРАТОРОВ
WriteLine(test++);
WriteLine(test--);
// ИСПЫТАНИЕ ОПЕРАТОРОВ ПРОВЕРКИ
WriteLine(test == test2);
WriteLine(test != test2);
WriteLine(test > test2);
WriteLine(test < test2);
// ИСПЫТАНИЕ ЛОГИЧЕСКИХ ОПЕРАТОРОВ
WriteLine(test | test2);
WriteLine(test & test2);

// ИСПЫТАНИЕ ИЗВЛЕЧЕНИЯ ИЗ КОРНЯ
test = new Fraction(16, 36);
test2 = new Fraction(1, 2);
WriteLine(test);
test.sqrt();
WriteLine(test);
// ИСПЫТАНИЕ ВОЗВЕДЕНИЯ В СТЕПЕНЬ
WriteLine(test2);
test2.exp(3);
WriteLine(test2);

// ИСПЫТАНИЕ ПЕРЕГРУЗКИ TRUE/FALSE
Fraction test3 = new Fraction(0, 0);

if(test)
{
    WriteLine("test is test");
}
else
{
    WriteLine("test isn't test");
}

if (test3)
{
    WriteLine("test3 is test");
}
else
{
    WriteLine("test3 isn't test");
}

public class Fraction
{
    int c, z;

    public Fraction(int cp, int zp)
    {
        c = cp;
        z = zp;
    }

    public Fraction(Fraction a)
    {
        c = a.c;
        z = a.z;
    }

    public int C
    {
        get { return c; }
        set { c = value; }
    }
    public int Z
    {
        get { return z; }
        set { z = value; }
    }

    // АРИФМЕТИЧЕСКИЕ

    public static Fraction operator -(Fraction a, Fraction b)
    {
        if (a.z != b.z)
        {
            int buffz = a.z;

            a.c *= b.z;
            a.z *= b.z;

            b.c *= buffz;
        }

        a.c -= b.c;

        return a;
    }

    public static Fraction operator +(Fraction a, Fraction b)
    {
        if (a.z != b.z)
        {
            int buffz = a.z;

            a.c *= b.z;
            a.z *= b.z;

            b.c *= buffz;
        }

        a.c += b.c;

        return a;
    }

    public static Fraction operator /(Fraction a, Fraction b)
    {
        int buff;

        buff = a.c;
        a.c = a.z;
        a.z = buff;

        a.c *= b.c;
        a.z *= b.z;

        return a;
    }

    public static Fraction operator *(Fraction a, Fraction b)
    {
        a.c *= b.c;
        a.z *= b.z;

        return a;
    }

    // АРИФМЕТИЧЕСКИЕ УНАРНЫЕ

    public static Fraction operator ++(Fraction a)
    {
        a.c++;
        a.z++;

        return a;
    }

    public static Fraction operator --(Fraction a)
    {
        a.c--;
        a.z--;

        return a;
    }

    // СРАВНЕНИЯ

    public static bool operator ==(Fraction a, Fraction b)
    {
        return a.c.Equals(b.c) && a.z.Equals(b.z);
    }

    public static bool operator !=(Fraction a, Fraction b)
    {
        return !(a.c.Equals(b.c) && a.z.Equals(b.z));
    }

    public static bool operator >(Fraction a, Fraction b)
    {
        return (a.z < b.z) || (a.z == b.z && a.c > b.c);
    }

    public static bool operator <(Fraction a, Fraction b)
    {
        return (a.z > b.z) || (a.z == b.z && a.c < b.c);
    }

    // TRUE/FALSE

    public static bool operator true(Fraction a)
    {
        return a.C == 0 && a.Z == 0 ? false : true;
    }

    public static bool operator false(Fraction a)
    {
        return a.C == 0 && a.Z == 0 ? true : false;
    }

    // ЛОГИЧЕСКИЕ

    public static bool operator |(Fraction a, Fraction b)
    {
        return (a.C == 0 && a.Z == 0) || (b.C == 0 && b.Z == 0);
    }
    public static bool operator &(Fraction a, Fraction b)
    {
        return (a.C == 0 && a.Z == 0) && (b.C == 0 && b.Z == 0);
    }

    public override string ToString()
    {
        return $"Fractrion: {c}/{z}";
    }

    // КОРЕНЬ

    public void sqrt()
    {
        C = (int)(Math.Sqrt(C));
        Z = (int)(Math.Sqrt(Z));
    }

    // СТЕПЕНЬ

    public void exp(int exp_num)
    {
        int buff_c = c;
        int buff_z = z;

        for (int i = 0; i < exp_num; i++) 
        {
            c *= buff_c;
            z *= buff_z;
        }
    }
}