#ifndef CLASSES_H
#define CLASSES_H

#include <iostream>
using namespace std;

// MATH

namespace Math {

    class Fraction {
    private:
        int numerator;
        int denominator;

    public:
        Fraction() {
            numerator = 0;
            denominator = 1;
        }

        Fraction(int n, int d) {
            numerator = n;
            denominator = d;
        }

        Fraction operator+(const Fraction& other) const {
            Fraction temp;
            temp.numerator = numerator * other.denominator + other.numerator * denominator;
            temp.denominator = denominator * other.denominator;
            return temp;
        }

        Fraction operator-(const Fraction& other) const {
            Fraction temp;
            temp.numerator = numerator * other.denominator - other.numerator * denominator;
            temp.denominator = denominator * other.denominator;
            return temp;
        }

        Fraction operator*(const Fraction& other) const {
            Fraction temp;
            temp.numerator = numerator * other.numerator;
            temp.denominator = denominator * other.denominator;
            return temp;
        }

        Fraction operator/(const Fraction& other) const {
            Fraction temp;
            temp.numerator = numerator * other.denominator;
            temp.denominator = denominator * other.numerator;
            return temp;
        }

        void print() const {
            cout << numerator << "/" << denominator << endl;
        }
    };

}

// GEOMETRY 2D

namespace Geometry2D {

    class Point {
    private:
        double x;
        double y;

    public:
        Point() {
            x = 0;
            y = 0;
        }

        Point(double x, double y) {
            this->x = x;
            this->y = y;
        }

        void setX(double x) {
            this->x = x;
        }

        void setY(double y) {
            this->y = y;
        }

        double getX() const {
            return x;
        }

        double getY() const {
            return y;
        }

        void print() const {
            cout << "(" << x << ", " << y << ")" << endl;
        }
    };

}

// GEOMETRY 3D
namespace Geometry3D {

    class Point {
    private:
        double x;
        double y;
        double z;

    public:
        Point() {
            x = 0;
            y = 0;
            z = 0;
        }

        Point(double x, double y, double z) {
            this->x = x;
            this->y = y;
            this->z = z;
        }

        void setX(double x) {
            this->x = x;
        }

        void setY(double y) {
            this->y = y;
        }

        void setZ(double z) {
            this->z = z;
        }

        double getX() const {
            return x;
        }

        double getY() const {
            return y;
        }

        double getZ() const {
            return z;
        }

        void print() const {
            cout << "(" << x << ", " << y << ", " << z << ")" << endl;
        }
    };

}

#endif