#include "classes.h"

int main() {
    cout << "Task: Namespaces" << endl;
    cout << endl;

    // Math::Fraction
    Math::Fraction f1(1, 2);
    Math::Fraction f2(3, 4);
    Math::Fraction f3;

    cout << "Math namespace:" << endl;

    f3 = f1 + f2;
    cout << "Addition: ";
    f3.print();

    f3 = f1 - f2;
    cout << "Subtraction: ";
    f3.print();

    f3 = f1 * f2;
    cout << "Multiplication: ";
    f3.print();

    f3 = f1 / f2;
    cout << "Division: ";
    f3.print();

    cout << endl;

    // Geometry2D::Point
    Geometry2D::Point p2(5, 10);

    cout << "Geometry2D namespace:" << endl;
    p2.print();

    cout << endl;

    // Geometry3D::Point
    Geometry3D::Point p3(1, 2, 3);

    cout << "Geometry3D namespace:" << endl;
    p3.print();

    return 0;
}