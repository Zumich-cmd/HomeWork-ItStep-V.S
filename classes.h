#ifndef CLASSES_H
#define CLASSES_H

#include <iostream>
#include <cmath>
using namespace std;

class Equation {
public:
    virtual void findRoots() const = 0;

    virtual ~Equation() {
    }
};

class LinearEquation : public Equation {
private:
    double a;
    double b;

public:
    LinearEquation() {
        a = 0;
        b = 0;
    }

    LinearEquation(double a, double b) {
        this->a = a;
        this->b = b;
    }

    void findRoots() const override {
        cout << "Linear equation: " << a << "x + " << b << " = 0" << endl;

        if (a == 0 && b == 0) {
            cout << "The equation has infinitely many solutions." << endl;
        }
        else if (a == 0 && b != 0) {
            cout << "The equation has no solutions." << endl;
        }
        else {
            double x = -b / a;
            cout << "Root: x = " << x << endl;
        }
    }
};

class QuadraticEquation : public Equation {
private:
    double a;
    double b;
    double c;

public:
    QuadraticEquation() {
        a = 0;
        b = 0;
        c = 0;
    }

    QuadraticEquation(double a, double b, double c) {
        this->a = a;
        this->b = b;
        this->c = c;
    }

    void findRoots() const override {
        cout << "Quadratic equation: " << a << "x^2 + " << b << "x + " << c << " = 0" << endl;

        if (a == 0) {
            cout << "This is not a quadratic equation." << endl;

            if (b == 0 && c == 0) {
                cout << "The equation has infinitely many solutions." << endl;
            }
            else if (b == 0 && c != 0) {
                cout << "The equation has no solutions." << endl;
            }
            else {
                double x = -c / b;
                cout << "Root: x = " << x << endl;
            }

            return;
        }

        double d = b * b - 4 * a * c;

        if (d > 0) {
            double x1 = (-b + sqrt(d)) / (2 * a);
            double x2 = (-b - sqrt(d)) / (2 * a);

            cout << "Root 1: x1 = " << x1 << endl;
            cout << "Root 2: x2 = " << x2 << endl;
        }
        else if (d == 0) {
            double x = -b / (2 * a);
            cout << "One root: x = " << x << endl;
        }
        else {
            cout << "No real roots." << endl;
        }
    }
};

#endif